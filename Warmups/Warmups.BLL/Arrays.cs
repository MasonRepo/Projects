using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                return true;
            }
            else
                return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length >= 1 && numbers[0] == numbers[numbers.Length - 1])
            {
                return true;
            }
            else
                return false;

        }
        public int[] MakePi(int n)
        {
            throw new NotImplementedException();
        }

        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Sum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        public int[] RotateLeft(int[] numbers)
        {
            int[] rotated = new int[] { numbers[0] };
            // int[] temp = numbers[];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = numbers[i + 1];

            }
            numbers[numbers.Length - 1] = rotated[0];



            return numbers;


        }

        public int[] Reverse(int[] numbers)
        {

            int[] x = new int[numbers.Length];
            int offset = numbers.Length - 1;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {

                x[numbers.Length - 1 - i] = numbers[i];

            }

            return x;


        }

        public int[] HigherWins(int[] numbers)
        {
            int[] x = new int[numbers.Length];
            if (numbers[0] > numbers[numbers.Length - 1])
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    x[i] = numbers[0];
                }


                return x;
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    x[i] = numbers[numbers.Length - 1];

                }
                return x;
            }





        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] x = new int[2];

            x[0] = a[a.Length - 2];
            x[1] = b[b.Length - 2];
            return x;


        }

        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i <= numbers[numbers.Length - 1]; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    return true;
                }
                else if (numbers[i] % 2 != 0)
                    return false;

            }
            return false;

        }

        public int[] KeepLast(int[] numbers)
        {
            int y = numbers.Length + numbers.Length;
            int[] x = new int[numbers.Length * 2];

            x[x.Length - 1] = numbers[numbers.Length -1];

            return x;


        }

        public bool Double23(int[] numbers)
        {
            int x = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2 )
                {
                    x++;
                }
                else if (numbers[i] == 3)
                {
                    x++;
                }

            }
            if (x < 3)
                return true;
            else if (x == 3)
                return true;
            else
                return false;


        }

        public int[] Fix23(int[] numbers)
        {

            for (int i = 0; i < numbers.Length; i++)

            {
                if (numbers[i] == 2 && numbers[i + 1] == 3)
                 numbers[i + 1] = 0;


            }
            return numbers;

        }

        public bool Unlucky1(int[] numbers)
        {

            for (int i = 0; i < numbers.Length - 1; i++)

            {
                if (numbers[i] == 1 && numbers[i + 1] == 3)
                {
                    if (numbers[0] == 1 || numbers[1] == 1 || numbers[numbers.Length -2] == 1 || numbers[numbers.Length -1] == 1)
                        return true;

                }
            }
            return false;
        }

        public int[] Make2(int[] a, int[] b)
        {
            int[] x = new int[2];
            int z = 0;

            for (int i = 0; i < a.Length; i++)
            {
                x[i] = a[i];

            }
            while (a.Length < 2)
            {
                x[a.Length + z] = b[z];
                z++;
            }
            //for (int z = x.Length; z < 2; z++)
            //{
            //    x[a.Length] = b[0];

            //}
            return x;




        }

    }
}
