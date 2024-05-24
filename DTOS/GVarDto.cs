using System.Collections.Generic;

namespace AnasProject.DTOS
{
    public class GVARDto
    {
        public Dictionary<string, Dictionary<string, string>> DicOfDic { get; set; }

        public GVARDto()
        {
            DicOfDic = new Dictionary<string, Dictionary<string, string>>();
        }
    }
}
