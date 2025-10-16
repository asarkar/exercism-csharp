using System.Globalization;
using System.Runtime.InteropServices;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        Type t = reading switch
        {
            > uint.MaxValue => typeof(long),
            > int.MaxValue => typeof(uint),
            > ushort.MaxValue => typeof(int),
            >= ushort.MinValue => typeof(ushort),
            >= short.MinValue => typeof(short),
            >= int.MinValue => typeof(int),
            _ => typeof(long)
        };
        dynamic val = Convert.ChangeType(reading, t, CultureInfo.InvariantCulture);
        byte[] bytes = BitConverter.GetBytes(val);
        var n = bytes.Length;
        // Tests expect an array of length 9.
        Array.Resize(ref bytes, 9);
        Array.Copy(bytes, 0, bytes, 1, n);
        // sizeof works only on compile-time known types, not on variables.
        // Marshal.SizeOf may not work for char and bool. 
        var size = Marshal.SizeOf(t);
        if (t != typeof(ushort) && t != typeof(uint))
        {
            size = 256 - size;
        }
        bytes[0] = (byte)size;

        return bytes;
    }

    public static long FromBuffer(byte[] buffer)
    {
        var size = Math.Min(256 - buffer[0], buffer[0]);
        return buffer[0] switch
        {
            // Cannot extract buffer.AsSpan because size may be invalid.
            2 => BitConverter.ToUInt16(buffer.AsSpan(1, size)),
            4 => BitConverter.ToUInt32(buffer.AsSpan(1, size)),
            248 => BitConverter.ToInt64(buffer.AsSpan(1, size)),
            252 => BitConverter.ToInt32(buffer.AsSpan(1, size)),
            254 => BitConverter.ToInt16(buffer.AsSpan(1, size)),
            _ => 0L
        };
    }
}