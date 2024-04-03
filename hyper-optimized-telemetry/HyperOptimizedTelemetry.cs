using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var result = new byte[9];
        byte[] payload;
        switch (reading)
        {
            case >= 4_294_967_296 or <= -2_147_483_649:
                payload = BitConverter.GetBytes(reading);
                result[0] = 248;
                break;
            case >= 2_147_483_648:
                payload = BitConverter.GetBytes((uint)reading);
                result[0] = 4;
                break;
            case >= 65_536 or <= -32_769:
                payload = BitConverter.GetBytes((int)reading);
                result[0] = 252;
                break;
            case >= 0:
                payload = BitConverter.GetBytes((ushort)reading);
                result[0] = 2;
                break;
            default:
                payload = BitConverter.GetBytes((short)reading);
                result[0] = 254;
                break;
        }

        Array.Copy(payload, 0, result, 1, payload.Length);
        return result;
    }

    public static long FromBuffer(byte[] buffer) =>
        buffer[0] switch
        {
            256 - 8 or 4 or 2 => BitConverter.ToInt64(buffer, 1),
            256 - 4 => BitConverter.ToInt32(buffer, 1),
            256 - 2 => BitConverter.ToInt16(buffer, 1),
            _ => 0
        };
}
