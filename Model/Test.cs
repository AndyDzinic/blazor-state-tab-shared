using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStateTest1.Model
{
    public class Test
    {
        public string Message { get; set; }
        public List<string> List { get; set; }

        public Test(string message, List<string> list)
        {
            Message = message;
            List = list;
        }
    }
}
