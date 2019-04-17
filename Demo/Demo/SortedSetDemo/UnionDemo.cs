using ExCollection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.SortedSetDemo
{
    public class UnionDemo
    {
        public void Start()
        {
            Console.WriteLine("=============Union Demo============");
            // initialize datas
            uint[] ids = createIDs(10);
            string idstr = ids[0].ToString();
            for (int i = 1; i < ids.Length; i++)
            {
                idstr += " " + ids[i].ToString();
            }

            // add
            KeyedList<uint, DemoItem> list = new KeyedList<uint, DemoItem>();
            KeyedList<uint, DemoItem> list1 = new KeyedList<uint, DemoItem>();
            KeyedList<uint, DemoItem> list2 = new KeyedList<uint, DemoItem>();
            for (int i = 0; i < ids.Length; i++)
            {
                var item = new DemoItem(ids[i], $"Item_{ids[i]}");
                if (i < ids.Length / 2)
                    list1.Add(item);
                else
                    list2.Add(item);
            }

            Console.WriteLine("List1:");
            print(list1);
            Console.WriteLine("List2:");
            print(list2);
            Console.WriteLine("After Union");
            list = KeyedList<uint, DemoItem>.Union(list1, list2);
            print(list);
        }

        private uint[] createIDs(int count)
        {
            uint[] ids = new uint[count];
            for (int i = 0; i < ids.Length; i++)
            {
                ids[i] = (uint)i;
            }
            DemoTools.Shuffle(ref ids);
            return ids;
        }

        private void print(KeyedList<uint, DemoItem> list)
        {
            if (list.Count > 0)
            {
                string str = list[0].Key.ToString();
                for (int i = 1; i < list.Count; i++)
                {
                    str += " " + list[i].Key;
                }
                Console.WriteLine(str);
            }
        }
    }
}
