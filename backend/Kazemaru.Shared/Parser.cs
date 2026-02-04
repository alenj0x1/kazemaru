using System.Globalization;

namespace Kazemaru.Shared;

public static class Parser
{
    public static DateTime? ToDateTime(string value)
    {
        try
        {
            return System.DateTime.Parse(value, CultureInfo.InvariantCulture);
        }
        catch
        {
            return null;
        }
    }
    
    public static Guid? ToGuid(string value)
    {
        try
        {
            return Guid.Parse(value);
        }
        catch
        {
            return null;
        }
    }
}