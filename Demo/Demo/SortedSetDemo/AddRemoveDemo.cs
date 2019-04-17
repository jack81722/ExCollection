using ExCollection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.SortedSetDemo
{
    public class AddRemoveDemo
    {
        public void Start()
        {
            Console.WriteLine("==========Add/Remove Demo==========");
            // initialize datas
            uint[] ids = createIDs(10);
            string idstr = ids[0].ToString();
            for(int i = 1; i < ids.Length; i++)
            {
                idstr += " " + ids[i].ToString();
            }
            Console.WriteLine("Before add : ");
            Console.WriteLine(idstr);

            // add demo
            KeyedList<uint, DemoItem> list = new KeyedList<uint, DemoItem>();
            for(int i = 0; i < ids.Length; i++)
            {
                var item = new DemoItem(ids[i], $"Item_{ids[i]}");
                list.Add(item);
            }
            Console.WriteLine("After add : ");
            print(list);

            // remove demo
            for (int i = 0; i < ids.Length / 2; i++)
            {   
                list.RemoveByKey(ids[i]);
            }
            Console.WriteLine("After remove : ");
            print(list);
        }

        private uint[] createIDs(int count)
        {
            uint[] ids = new uint[count];
            for(int i = 0; i < ids.Length; i++)
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
