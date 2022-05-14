using System.Reflection;

namespace backend;

// Generic Filer

public class Filer
{
    private Type _type;

    private int _length;

    public Filer(object obj)
    {
        _type = obj.GetType();
        
        // Recursively get object size

        //_length = _type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
    }
    
    public int GetTypeSize(Type type)
    {
        Console.WriteLine(type.FullName);
        
        if (type.IsPrimitive)
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
        
        // array handling, only need to run GetTypeSize on single object
        if (type.IsArray)
        {
            Console.WriteLine(type.FullName);
        }
        
        // Complex type handling with recursion


        return 0;
    }
}