using System.Buffers.Binary;

namespace backend;

// Generic Filer

public class Filer
{
    public static void SaveUser(User user, string filename)
    {
        var data =
            FormatInt(user.Name.Length) + user.Name +
            FormatInt(user.Email.Length) + user.Email +
            FormatInt(user.MasterPassword.Length) + user.MasterPassword;

        data = user.ExtraDetails.Aggregate(data,
            (current, detail) => current + FormatInt(detail.Name.Length) + detail.Name +
                                 FormatInt(detail.Value.Length) + detail.Value);

        data = user.Credentials.Aggregate(data,
            (current, credential) => current + FormatInt(credential.Name.Length) + credential.Name +
                                     FormatInt(credential.Email.Length) + credential.Email +
                                     FormatInt(credential.Url.Length) + credential.Url +
                                     FormatInt(credential.Password.Length) + credential.Password);

        StreamWriter writer = new(filename);
        writer.Write(data);
        writer.Flush();
        writer.Close();
    }

    private static string FormatInt(int prim)
    {
        var bytes = new byte[sizeof(int)];
        BinaryPrimitives.WriteInt32LittleEndian(bytes, prim);
        return System.Text.Encoding.Default.GetString(bytes);
    }

    private static int GetPrimitiveSize(Type type)
    {
        // Return the amount of bytes the primitive occupies in memory
        return Type.GetTypeCode(type) switch
        {
            TypeCode.Boolean => sizeof(bool),
            TypeCode.SByte => sizeof(sbyte),
            TypeCode.Byte => sizeof(byte),
            TypeCode.Int16 => sizeof(short),
            TypeCode.UInt16 => sizeof(ushort),
            TypeCode.Char => sizeof(char),
            TypeCode.Single => sizeof(float),
            TypeCode.Int32 => sizeof(int),
            TypeCode.UInt32 => sizeof(uint),
            TypeCode.Double => sizeof(double),
            TypeCode.Int64 => sizeof(long),
            TypeCode.UInt64 => sizeof(ulong),
            TypeCode.Decimal => sizeof(decimal),
            _ => 0
        };
    }
}