using System.Collections.Generic;

namespace Kadr.Reports
{
    public class ArgItem
    {
        public ArgItem(string s)
        {
            var up = s.Split(':');
            Name = up[0];
            Type = up[1];
        }

        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Args
    {
        public Args()
        {
        }

        public Args(string s)
        {
            //ar1:1;ar2:1;cb:2

            aItem = new List<ArgItem>();

            var p = s.Split(';');
            foreach (var item in p)
            {
                var ai = new ArgItem(item);
                aItem.Add(new ArgItem(item));
            }
        }

        public List<ArgItem> aItem { get; set; }
    }
}