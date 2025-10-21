using System.Numerics;

internal static class IntergalacticTransmission
{
    public static byte[] GetTransmitSequence(byte[] message)
    {
        var n = message.Length;
        if (n == 0)
        {
            return message;
        }
        // We gain a byte for every 8 bytes in the input.
        var encoded = new byte[n + (n / 8) + 1];
        var buffer = 0;
        var bufferSize = 0;
        var outIndex = 0;

        foreach (var b in message)
        {
            // Shift the existing buffer left to make room for 8 new bits
            buffer <<= 8;
            buffer |= b; // add the new byte on the right
            bufferSize += 8;

            // A parity bit is inserted after every seven bits of data.
            while (bufferSize >= 7)
            {
                var shift = bufferSize - 7;
                var payload = buffer >>> shift; // take top 7 bits
                var parity = BitOperations.PopCount((uint)payload) % 2;
                encoded[outIndex++] = (byte)((payload << 1) | parity);

                bufferSize -= 7;
                buffer &= (1 << bufferSize) - 1; // keep remaining bits
            }
        }

        // Handle leftover bits, which are 7 or less.
        if (bufferSize > 0)
        {
            var payload = buffer << (7 - bufferSize);
            var parity = BitOperations.PopCount((uint)payload) % 2;
            encoded[outIndex++] = (byte)((payload << 1) | parity);
        }
        return encoded;
    }

    public static byte[] DecodeSequence(byte[] receivedSeq)
    {
        var n = receivedSeq.Length;
        if (n == 0)
        {
            return receivedSeq;
        }
        // We extract a byte from every 14 bits.
        var x = n * 7 / 8;
        var decoded = new byte[x];
        var buffer = 0;
        var bufferSize = 0;
        var outIndex = 0;

        for (var i = 0; i < n && outIndex < x; i++)
        {
            var b = receivedSeq[i];
            // Parity validation.
            var data = b >> 1;
            var parity = b & 1;
            var bitCount = BitOperations.PopCount((uint)data);

            if ((bitCount % 2) != parity)
            {
                throw new ArgumentException($"Parity error at byte 0x{b:X2}.");
            }
            buffer = (buffer << 7) | data;
            bufferSize += 7;
            if (bufferSize >= 8)
            {
                var shift = bufferSize - 8;
                var payload = buffer >>> shift;
                decoded[outIndex++] = (byte)payload;

                bufferSize -= 8;
                buffer &= (1 << bufferSize) - 1;
            }
        }
        return decoded;
    }
}