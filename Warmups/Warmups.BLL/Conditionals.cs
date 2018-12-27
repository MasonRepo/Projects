using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == true && bSmile == true || aSmile == false && bSmile == false)
                return true;
            else
                return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday == true && isVacation == true)
                return true;
            else if (isWeekday == false && isVacation == false || isVacation == true)

                return true;

            else
                return false;

        }

        public int SumDouble(int a, int b)
        {
            if (a == b)
                return (a + b) * 2;

            else
                return a + b;

        }

        public int Diff21(int n)
        {
            if (n > 21)
                return (n - 21) * 2;
            else
                return Math.Abs(n - 21);

        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (hour < 7 && isTalking == true)
                return true;

            else if (isTalking == true && hour > 20)
                return true;

            else
                return false;
        }

        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10)
                return true;
            else if (a + b == 10)
                return true;
            else
                return false;


        }

        public bool NearHundred(int n)
        {
            if (Math.Abs(n - 100) <= 10) //|| (n - 10) > 100 || (n + 10) >= 100) (n - 11) < 100 ||
                return true;

            else
                return false;

        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (a > 0 || b > 0)
                return true;
            else if (negative == true && (a < 0 && b < 0))
                return true;
            else
                return false;
        }

        public string NotString(string s)
        {
            string not = "not ";
            if (s.Contains("not"))
            {
                return s;
            }
            else
                return not + s;

        }

        public string MissingChar(string str, int n)
        {
            string firstPart = str.Remove(n);
            string secondPart = str.Remove(0, n + 1);
            return firstPart + secondPart;

        }

        public string FrontBack(string str)
        {
            if (str.Length == 1)
                return str;
            else
            {
                string middle = str.Substring(1, str.Length - 2);
                string first = str.Substring(0, 1);
                string second = str.Substring(str.Length - 1);

                return second + middle + first;
            }

        }

        public string Front3(string str)
        {

            if (str.Length <= 2)
            {
                return str + str + str;
            }

            else
                return str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);


        }

        public string BackAround(string str)
        {
            string last = str.Substring(str.Length - 1);
            if (str.Length == 1)
            {
                return str + str + str;
            }



            else

                return last + str + last;

        }

        public bool Multiple3or5(int number)
        {
            if (number % 5 == 0 || number % 3 == 0)
                return true;
            else
                return false;


        }

        public bool StartHi(string str)
        {
            while (str.Contains("hi"))

                if (str.Contains("hi,") || str.Contains("hi "))
                {
                    return true;
                }
                else
                    return false;
            return false;
        }

        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 > 120 || temp1 < 0)
                return true;
            else if (temp2 > 120 || temp2 < 0)
                return true;

            else
                return false;

        }

        public bool Between10and20(int a, int b)
        {
            if (a > 10 && a < 20)
                return true;
            else if (b > 10 && b < 20)
                return true;
            else
                return false;

        }

        public bool HasTeen(int a, int b, int c)
        {
            if (a > 12 && a < 20)
                return true;
            else if (b > 12 && b < 20)
                return true;
            else if (c > 12 && c < 20)
                return true;
            else
                return false;

        }

        public bool SoAlone(int a, int b)
        {
            if (a > 12 && a < 20 && b > 12 && b < 20)
                return false;

            else if (a > 12 && a < 20 || b > 12 && b < 20)
                return true;
            else if (a < 13 || a > 19 && b < 13 || b > 19)
                return false;


            else
                return true;

        }

        public string RemoveDel(string str)
        {
            if (str.Contains("del"))
                return str.Replace("del", "");
            else
                return str;
        }

        public bool IxStart(string str)
        {
            if (str.Contains("ix"))
                return true;
            else
                return false;


        }

        public string StartOz(string str)
        {
            if (str.Length < 2)

                return str.Remove(0);
            string first = str.Substring(0, 2);

            if (first.Contains("oz"))
                return "oz";
            else if (first.Contains("o"))
                return "o";
            else if (first.Contains("z"))
                return "z";

            else
                return str;

        }

        public int Max(int a, int b, int c)
        {
            if (a > c && a > b)
                return a;
            else if (b > c && b > a)
                return b;
            else
                return c;

        }

        public int Closer(int a, int b)
        {
            int c = Math.Abs(10 - a);
            int d = Math.Abs(10 - b);
            if (c > d)
                return b;
            else if (d > c)
                return a;

            else
                return 0;

        }

        public bool GotE(string str)
        {
            int words = 0;
            for (int i = 0; i < str.Length; i++)
                if (str.Substring(i, 1) == "e")
                {
                    words++;
                }
            if (words > 0 && words < 4)
                return true;
            else
                return false;

        }

        public string EndUp(string str)
        {
            if (str.Length < 3)
                return str.ToUpper();


            else
            {
                string last = str.Substring(str.Length - 3, 3);
                string first = str.Substring(0, str.Length - 3);
                return first + last.ToUpper();
            }
        }

        public string EveryNth(string str, int n)
        {
            string removed = "";
          
           
            for (int i = 0; i < str.Length; i = i + n )
            {
                removed += str.Substring(i, 1);
            }
            return removed;
        }
    }
}
