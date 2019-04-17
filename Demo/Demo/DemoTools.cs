using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class DemoTools
    {
        #region Random
        private const int randomMax = 1000;
        private static int randomCount = 0;
        private static Random _random;
        private static Random random
        {
            get
            {
                if (_random == null || randomCount >= randomMax)
                {
                    _random = new Random();
                    randomCount = 0;
                }
                randomCount++;
                return _random;
            }
        }
        #endregion

        public static void Swap<T>(ref T x, ref T y)
        {
            T tmp = x;
            x = y;
            y = tmp;
        }

        public static void Shuffle<T>(ref T[] array)
        {
            int rIndex;
            for(int i = 0; i < array.Length; i++)
            {
                rIndex = random.Next(i, array.Length - 1);
                Swap(ref array[i], ref array[rIndex]);
            }
        }
    }
}
