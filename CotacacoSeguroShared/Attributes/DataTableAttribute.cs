namespace CotacacoSeguroShared.Attributes;

[System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct,
                       AllowMultiple = true)  // Multiuse attribute.
]
public class DataTableAttribute : System.Attribute
{
    string Schema;
    string TableName;
    string FullName;

    public DataTableAttribute(string schema, string tableName)
    {
        Schema = schema;
        TableName = tableName;
        FullName = $@"{Schema}.{TableName}";
    }

    public string GetSchema() => Schema;
    public string GetTableName() => TableName;
    public string GetFullName() => FullName;

}
