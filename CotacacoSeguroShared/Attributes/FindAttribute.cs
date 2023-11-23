namespace CotacacoSeguroShared.Attributes;

public class FindAttribute
{
    public static string FindFullName(System.Type T)
    {
        System.Attribute[] attrs = System.Attribute.GetCustomAttributes(T);
        foreach (System.Attribute attr in attrs)
        {
            if (attr is DataTableAttribute dt)
            {
                return dt.GetFullName();
            }
        }
        return "";
    }

    public static string FindTableName(System.Type T)
    {
        System.Attribute[] attrs = System.Attribute.GetCustomAttributes(T);
        foreach (System.Attribute attr in attrs)
        {
            if (attr is DataTableAttribute dt)
            {
                return dt.GetTableName();
            }
        }
        return "";
    }

    public static string FindSchemaName(System.Type T)
    {
        System.Attribute[] attrs = System.Attribute.GetCustomAttributes(T);
        foreach (System.Attribute attr in attrs)
        {
            if (attr is DataTableAttribute dt)
            {
                return dt.GetSchema();
            }
        }
        return "";
    }
}