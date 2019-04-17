using ExCollection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class DemoItem : IKeyable<uint>
    {
        public uint Key { get; set; }
        public object Data;

        public DemoItem(uint key, object data)
        {
            Key = key;
            Data = data;
        }

        public override string ToString()
        {
            return string.Format("{{{0}, {1}}}", Key, Data);
        }
    }
}
