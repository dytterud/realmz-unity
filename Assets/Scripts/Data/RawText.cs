using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class RawText
{
    public byte Length { get; set; }
    public byte[] Value { get; set; }

    public static RawText Parse(BinaryReader b, int stringLength)
    {
        var m = new RawText
        {
            Length = b.ReadByte(),
            Value = b.ReadBytes(stringLength)
        };

        return m;
    }

    public override string ToString()
    {
        return Length > Value.Length ? Encoding.UTF8.GetString(Value, 0, Value.Length) : Encoding.UTF8.GetString(Value, 0, Length);
    }
}
