using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._1
{
    class Matrix
    {
        public static int size = 5;
        int[,] matrix = new int[size, size];

        public int this[int x, int y]
        {
            get
            {
                return matrix[x, y];
            }
            set
            {
                matrix[x, y] = value;
            }
        }

        public void fillRandom()
        {
            Random rand = new();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    matrix[i, j] = rand.Next(-500, 500);
                }
            }
        }

        private int[] findMaxLeft()
        {
            int maxLeft = matrix[0, 0];
            int x = 0;
            int y = 0;
            for (int i = 0; i < size - 1; ++i)
            {
                for (int j = 1; j < size - i - 1; ++j)
                {
                    if (matrix[i, j] >= maxLeft)
                    {
                        maxLeft = matrix[i, j];
                        x = i;
                        y = j;
                    }
                }
            }
            int[] max = new int[] { x, y };
            return max;
        }

        private int[] findMaxRight()
        {
            int maxRight = matrix[1, size - 1];
            int x = 0;
            int y = 0;
            for (int i = 1; i < size; ++i)
            {
                for (int j = size - i; j < size; ++j)
                {
                    if (matrix[i, j] >= maxRight)
                    {
                        maxRight = matrix[i, j];
                        x = i;
                        y = j;
                    }
                }
            }
            int[] max = new int[] { x, y };
            return max;
        }

        public void changeMaxes()
        {
            int[] maxLeft = findMaxLeft();
            int[] maxRight = findMaxRight();

            int temp = matrix[maxLeft[0], maxLeft[1]];
            matrix[maxLeft[0], maxLeft[1]] = matrix[maxRight[0], maxRight[1]];
            matrix[maxRight[0], maxRight[1]] = temp;
        }
    }
}
