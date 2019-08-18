
[System.AttributeUsage(System.AttributeTargets.Field)]
public class PropertiesDesc : System.Attribute
{
    public string Desc { get; private set; }

    public PropertiesDesc(string des)
    {
        Desc = des;
    }
}
