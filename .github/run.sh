#!/bin/bash

set -e

# Verify that all projects are included in the solution.
while IFS='' read -r -d '' project; do
	dir=${project%/*}
	dir="${dir##*/}"
	found=0
	# Prevent `grep` from prematurely terminating the script.
	grep -q "$dir" Exercism.slnx || found=$?
	if (( found > 0 )); then
		default_color=$(tput -Txterm-256color sgr0)
		red=$(tput -Txterm-256color setaf 1)
		printf "%bProject '%s' is not included in the solution%b\n" "$red" "$dir" "$default_color"
		exit 1
	fi
done < <(find . -type f -name "*.csproj" -maxdepth 2 -print0)

no_test=0
no_lint=0

while (( $# > 0 )); do
   case "$1" in
   	--help)
			printf "run.sh [OPTION]... [DIR]\n"
			printf "options:\n"
			printf "\t--help			Show help\n"
			printf "\t--no-test		Skip tests\n"
			printf "\t--no-lint		Skip linting\n"
			exit 0
      	;;
      --no-test)
			no_test=1
			shift
      	;;
      --no-lint)
			no_lint=1
			shift
			;;
		*)
			break
	      ;;
   esac
done

basedir="${1:-.}"

if [[ -n "$1" && -z "$CI" ]]; then
	# Delete project-specific `.editorconfig` files.
	find "$basedir" -type f -name '.editorconfig' -mindepth 2 -maxdepth 2 -exec rm -f {} +

	# Include skipped tests.
	pattern='s/\[Fact\(.*\)\]/\[Fact\]/'
	if [[ "$(uname)" == "Darwin" ]]; then
		# macOS
		sed -i '' "$pattern" "$1"/*Tests.cs
	elif [[ "$(uname)" == "Linux" ]]; then
		# Linux
		sed -i "$pattern" "$1"/*Tests.cs
	fi
fi

if (( no_test == 0 )); then
  dotnet test "$basedir"
fi

if (( no_lint == 0 )); then
	if [[ -z "$CI" ]]; then
		dotnet format "$basedir" -v n
	else
    	dotnet format "$basedir" -v n --verify-no-changes
	fi
fi
