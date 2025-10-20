My solutions for [Exercism C# Track](https://exercism.org/tracks/csharp).
Feel free to open issues for questions, comments, or suggestions.

[![](https://github.com/asarkar/exercism-csharp/workflows/CI/badge.svg)](https://github.com/asarkar/exercism-csharp/actions)

## Development

Deleting `bin` and `obj` directories:
```
find . -type d \( -name bin -o -name obj \) -exec rm -rf {} +
```

Adding projects to solution
```
dotnet sln add <directory>
```

Running tests:
```
./.github/run.sh <directory>
```

## License

Released under [Apache License v2.0](LICENSE).