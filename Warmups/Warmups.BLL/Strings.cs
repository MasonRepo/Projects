using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            
            return a + b + b + a;

        }

        public string MakeTags(string tag, string content)
        {
            

            return ($"<{tag}>{content}</{tag}>");


        }

        public string InsertWord(string container, string word)
        {
            return ($"{container.Substring(0, 2)}{word}{container.Substring(2)}");
            
        }

        public string MultipleEndings(string str)
        {
            string strRemoved = str.Substring(str.Length -2, 2);
            if (str.Length < 2)
            {
                Console.WriteLine("Please input at least a word with 2 letters");
            }
            return ($"{strRemoved}{strRemoved}{strRemoved}");
            //return ($"{str.Substring(-2, 2)}{str.Substring(-2, 2)}{str.Substring(-2, 2)}");
        }

        public string FirstHalf(string str)
        {
            //string half = str.Substring(str.Length / -2);
            //string easy = half.Substring(0);
            //string help = str.Remove(str.Length / 2);

            return str.Substring(0, str.Length / 2);
            // return ($"{str.Substring(str.Length / -2)}");

        }

        public string TrimOne(string str)
        {
            //string removed = str.Substring(0 ,1);
            //string removedone = str.Substring(str.Length -1, 1);

            return str.Substring(1, str.Length -2 );

        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return b + a + b;

            }
            else
            {
                return a + b + a;
            }
                
            
        }

        public string RotateLeft2(string str)
        {

            if (str.Length > 2)
            {

                return str.Substring(2) + str.Substring(0,2);

            }
            else
            {
                return str;
            }
        }

        public string RotateRight2(string str)
        {
            return str.Substring(str.Length - 2, 2) + str.Substring(0, str.Length - 2);
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront == true)
            {
                return str.Substring(0, 1);
            }
            else
            {
                return str.Substring(str.Length -1);
            }

        }

        public string MiddleTwo(string str)
        {
            if (str.Length < 2)
            {
                return str;
            }
         else if (str.Length % 2 == 0)
            {
                return str.Substring(str.Length / 2 - 1, 2);
            }
            return str;
        }

        public bool EndsWithLy(string str)
        {
            if (str.Length == 1)
            {
                return false;
            }
            else if (str.Substring(str.Length - 2) == "ly")
            {
                return true;
            }
            else
                {
                return false;
            }
                
        }

        public string FrontAndBack(string str, int n)
        {

            return str.Substring(0, n) + str.Substring(str.Length - n, n);



        }

        public string TakeTwoFromPosition(string str, int n)
        {
            throw new NotImplementedException();
        }

        public bool HasBad(string str)
        {
            throw new NotImplementedException();
        }

        public string AtFirst(string str)
        {
            throw new NotImplementedException();
        }

        public string LastChars(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string ConCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string SwapLast(string str)
        {
            throw new NotImplementedException();
        }

        public bool FrontAgain(string str)
        {
            throw new NotImplementedException();
        }

        public string MinCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string TweakFront(string str)
        {
            throw new NotImplementedException();
        }

        public string StripX(string str)
        {
            throw new NotImplementedException();
        }
    }
}
