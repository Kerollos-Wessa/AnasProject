using System.Collections.Generic;
using System.Data;

public class GVAR
{
    public Dictionary<string, Dictionary<string, string>> DicOfDic { get; set; }
    public Dictionary<string, DataTable> DicOfDT { get; set; }

    public GVAR()
    {
        DicOfDic = new Dictionary<string, Dictionary<string, string>>();
        DicOfDT = new Dictionary<string, DataTable>();
    }
}
