using System;
using UnityEngine;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int LCT01_SequentialSearch1DArray()
        {
            int[] array = new int[] { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;
            int index = -1;

            // Your code here ...
            // ...
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Debug.Log("Target not found in the array.");
            }

            return index;
        }

        public int[] LCT02_SequentialSearch2DArray()
        {
            int[,] array = new int[,]
            {
                { 34, 21, 56 },
                { 12, 78, 90 },
                { 11, 23, 45 }
            };
            int target = 23;
            int row = -1;
            int col = -1;

            // Your code here ...
            // ...
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == target)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
                if (row != -1 && col != -1)
                {
                    break;
                }
            }
            if (row == -1 || col == -1)
            {
                Debug.Log("Target not found in the array.");
            }
            return new[] { row, col };
        }

        public int LCT03_BinarySearch()
        {
            int[] array = new int[] { 11, 12, 21, 23, 34, 45, 56, 78, 90 };
            int target = 23;
            int index = -1;

            // Your code here ...
            // ...
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] == target)
                {
                    index = mid;
                    break;
                }
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if (index == -1)
            {
                Debug.Log("Target not found in the array.");
            }

            return index;
        }

        #endregion

        #region Assignment

        public int[] AS01_FindFirstAndLastElementOfArray(int[] array, int target)
        {
            int first = -1;
            int last = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    if (first == -1)
                    {
                        first = i;
                    }

                    last = i;
                }
            }

            if (first == -1)
            {
                return new int[] { -1 };
            }

            return new int[] { first, last };
        }

        public int AS02_FindMaxLessThan(int[] array, int target)
        {
            int maxVal = int.MinValue;
            bool found = false;

            // วนลูปหาค่าที่น้อยกว่า target แต่มีค่ามากที่สุดในกลุ่มนั้น
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < target && (!found || array[i] > maxVal))
                {
                    maxVal = array[i];
                    found = true;
                }
            }

            // หากไม่มีค่าใดน้อยกว่า target ให้คืนค่า -1
            return found ? maxVal : -1;
        }

        public int[] AS03_FindRange(int[] array, int min, int max)
        {
            // นับจำนวนสมาชิกที่อยู่ในช่วง [min, max] ก่อนเพื่อกำหนดขนาดของ Array ผลลัพธ์
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                {
                    count++;
                }
            }

            // สร้าง Array ผลลัพธ์ตามขนาดที่นับได้
            int[] result = new int[count];
            int index = 0;

            // นำค่าที่อยู่ในช่วงใส่ลงใน Array ผลลัพธ์
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                {
                    result[index] = array[i];
                    index++;
                }
            }

            return result;
        }

        #endregion

        #region Extra

        public int[] EX01_FindTargetEnemies(int[] enemyHPs, int mana)
        {
            // Select enemies in array order while sufficient mana remains.
            int[] selected = new int[enemyHPs.Length];
            int count = 0;
            int remainingMana = mana;

            for (int i = 0; i < enemyHPs.Length; i++)
            {
                if (enemyHPs[i] <= remainingMana)
                {
                    selected[count] = enemyHPs[i];
                    count++;
                    remainingMana -= enemyHPs[i];
                }
            }

            int[] result = new int[count];
            Array.Copy(selected, result, count);
            return result;
        }
        #endregion
    }
}