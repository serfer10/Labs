using System;

namespace Calculator
{

    class Program
    {
        static int GetNextOperant(string vvod)
        {
            int result=0;
            bool FirstCheck = int.TryParse(vvod, out result);
            if (!FirstCheck)
            {
                char operant='0';
                int counter = 0;
                int StringLength = vvod.Length;
                for (; counter < StringLength; counter++)
                {
                    if (vvod[counter] == '+' || vvod[counter] == '-')
                    {
                        char[] left = new char[counter];
                        char[] right = new char[StringLength - counter];
                        for (int i = 0; i < counter; i++)
                        {
                            left[i] = vvod[i];
                        }
                        int BufCounter = counter + 1;
                        for (int i = 0; BufCounter < StringLength; BufCounter++)
                        {
                            right[i] = vvod[BufCounter];
                            i++;
                        }
                        int resultLeft;
                        int resultRight;
                        bool check1 = int.TryParse(left, out resultLeft);
                        bool check2 = int.TryParse(right, out resultRight);
                        if (check1 == true && check2 == true)
                        {
                            if (vvod[counter] == '+')
                            {
                                result = resultLeft + resultRight;
                                operant = '+';
                            }
                            else
                            {
                                result = resultLeft - resultRight;
                                operant = '-';
                            }
                        }
                        else
                        {
                            string left1 = new string(left);
                            string right1 = new string(right);
                            if (vvod[counter] == '+')
                            {
                                result = GetNextOperant(left1) + GetNextOperant(right1);
                                operant = '+';
                            }
                            else
                            {
                                result = GetNextOperant(left1) - GetNextOperant(right1);
                                operant = '-';
                            }

                        }
                    }
                    else
                    {
  
                        if (vvod[counter] == '*' || vvod[counter] == '/')
                        {
                            char[] left = new char[counter];
                            char[] right = new char[StringLength - counter];
                            for (int i = 0; i < counter; i++)
                            {
                                left[i] = vvod[i];
                            }
                            int BufCounter = counter + 1;
                            for (int i = 0; BufCounter < StringLength; BufCounter++)
                            {
                                right[i] = vvod[BufCounter];
                                i++;
                            }
                            int resultLeft;
                            int resultRight;
                            bool check1 = int.TryParse(left, out resultLeft);
                            bool check2 = int.TryParse(right, out resultRight);
                            if (check1 == true && check2 == true)
                            {
                                if (vvod[counter] == '*')
                                {
                                    result = resultLeft * resultRight;
                                }
                                else
                                {
                                    result = resultLeft / resultRight;
                                }
                            }
                            else
                            {
                                string left1 = new string(left);
                                string right1 = new string(right);
                                if (vvod[counter] == '*')
                                {
                                    result = GetNextOperant(left1) * GetNextOperant(right1);
                                }
                                else
                                {
                                    result = GetNextOperant(left1) / GetNextOperant(right1);
                                }

                            }
                        }
                    }
                }
            }
            else
                result = int.Parse(vvod);
            return result;
        }
        public static void Main(string[] args)
          {
            Console.WriteLine("Введите выражение");
            string vvod = Console.ReadLine();
           int result = GetNextOperant(vvod);
            Console.WriteLine(result);
          }
    }
}
