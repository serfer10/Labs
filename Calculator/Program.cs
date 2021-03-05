using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static string Check()
        {
            exite1:
            Console.WriteLine("Введите выражение");
            string vvod = Console.ReadLine();
            char operant = '0';
            int stringLength = vvod.Length;
            for (int counter = 0; counter < stringLength; counter++)
            {
                if (vvod[counter] == '+' || vvod[counter] == '-' || vvod[counter] == '*' || vvod[counter] == '/')
                {
                    if (operant == '1')
                    {
                        Console.WriteLine("Введено 2 знака операции подряд,повторите ввод");
                        goto exite1;
                    }
                    else
                        operant = '1';
                }
                else
                {
                    operant = '0';
                        switch(vvod[counter])
                        {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                                break;
                            default:
                            Console.WriteLine("Был введен неизвестный знак, повторите ввод");
                            goto exite1;
                        }
                }

            }
            return vvod;
        }
            
            static double GetNextOperant(string vvod)
            {
                double result = 0;
               bool FirstCheck = double.TryParse(vvod, out result);
                if (!FirstCheck)
                {
                    int StringLength = vvod.Length;
                    for (int counter = 0; counter < StringLength; counter++)
                    {
                        if (vvod[counter] == '+' || vvod[counter] == '-')
                        {

                            char[] left = new char[counter];
                            char[] right = new char[StringLength - counter];
                            for (int i = 0; i < counter; i++)
                            {
                                left[i] = vvod[i];
                            }
                            for (int i = counter + 1, j = 0; i < StringLength; i++, j++)
                            {
                                right[j] = vvod[i];
                            }
                            double resultLeft;
                            double resultRight;
                            bool check1 = double.TryParse(left, out resultLeft);
                            bool check2 = double.TryParse(right, out resultRight);
                            string Left = new string(left);
                            string Right = new string(right);
                            if (check1 && check2)
                            {
                                if (vvod[counter] == '+')
                                    return result = resultLeft + resultRight;
                                else
                                    return result = resultLeft - resultRight;
                            }
                            else
                            {
                                if (vvod[counter] == '+')
                                    return result = GetNextOperant(Left) + GetNextOperant(Right);
                                else
                                    return result = GetNextOperant(Left) - GetNextOperant(Right);
                            }
                        }
                    }

                    for(int counter=0;counter<StringLength;counter++)
                    {
                        if(vvod[counter]=='*' || vvod[counter]=='/')
                        {
                            char[] left = new char[counter];
                            char[] right = new char[StringLength - counter];
                            for (int i = 0; i < counter; i++)
                            {
                                left[i] = vvod[i];
                            }
                            for (int i = counter + 1, j = 0; i < StringLength; i++, j++)
                            {
                                right[j] = vvod[i];
                            }
                            double resultLeft;
                            double resultRight;
                            bool check1 = double.TryParse(left, out resultLeft);
                            bool check2 = double.TryParse(right, out resultRight);
                            string Left = new string(left);
                            string Right = new string(right);
                            if (check1 && check2)
                            {
                                if (vvod[counter] == '*')
                                    return result = resultLeft * resultRight;
                                else
                                    return result = resultLeft / resultRight;
                            }
                            else
                            {
                                if (vvod[counter] == '*')
                                    return result = GetNextOperant(Left) * GetNextOperant(Right);
                                else
                                    return result = GetNextOperant(Left) / GetNextOperant(Right);
                            }
                        }
                    }

                }
                return result;
            }
            public static void Main(string[] args)
            {
                string vvod = Check();
                double result = GetNextOperant(vvod);
                Console.WriteLine(result);
            }
    }
}


