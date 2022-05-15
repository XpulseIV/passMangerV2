using System.Buffers.Binary;

namespace backend;

// Generic Filer

public class Filer
{
    private StreamReader _reader;
    private StreamWriter _writer;

    public Filer(string filename)
    {
        _reader = new StreamReader(filename);
        _writer = new StreamWriter(filename);
    }
    
    public void SaveUser(User user)
    {
        var data =
            FormatInt(user.Name.Length) + user.Name +
            FormatInt(user.Email.Length) + user.Email +
            FormatInt(user.MasterPassword.Length) + user.MasterPassword;

        data += FormatInt(user.ExtraDetails.Count);
        data = user.ExtraDetails.Aggregate(data,
            (current, detail) => current + FormatInt(detail.Name.Length) + detail.Name +
                                 FormatInt(detail.Value.Length) + detail.Value);

        data += FormatInt(user.Credentials.Count);
        data = user.Credentials.Aggregate(data,
            (current, credential) => current + FormatInt(credential.Name.Length) + credential.Name +
                                     FormatInt(credential.Email.Length) + credential.Email +
                                     FormatInt(credential.Url.Length) + credential.Url +
                                     FormatInt(credential.Password.Length) + credential.Password);
        
        _writer.Write(data);
        _writer.Flush();
        _writer.Close();
    }

    private static string FormatInt(int num)
    {
        var bytes = new byte[sizeof(int)];
        BinaryPrimitives.WriteInt32LittleEndian(bytes, num);
        return System.Text.Encoding.Default.GetString(bytes);
    }

    public User LoadUser()
    {
        var name = ReadField();
        var email = ReadField();
        var masterPassword = ReadField();
        
        List<Detail> details = new(ReadInt());
        for (var i = 0; i < details.Capacity; i++)
            details.Add(new Detail(ReadField(), ReadField()));

        List<Credential> credentials = new(ReadInt());
        for (var i = 0; i < credentials.Capacity; i++)
            credentials.Add(new Credential(ReadField(), ReadField(), ReadField(), ReadField()));
        
        return new User(name, email, masterPassword, details, credentials);
    }
    
    private string ReadField()
    {
        var chars = new char[ReadInt()];
        _reader.ReadBlock(chars);
        return new string(chars);
    }

    private int ReadInt()
    {
        var chars = new char[sizeof(int)];
        _reader.ReadBlock(chars);
        var bytes = System.Text.Encoding.Default.GetBytes(chars);
        return BinaryPrimitives.ReadInt32LittleEndian(bytes);
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