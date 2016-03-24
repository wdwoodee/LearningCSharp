using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwitchExample
{
    class Program
    {
        
        static void Main()
        {
            Console.WriteLine("Please input score:");
            string str = Console.ReadLine();
            int Score = Int32.Parse(str.Trim());
            //int i = Convert.ToInt32(str);
            //Console.WriteLine("{0}", i);
            if (Score > 100 || Score < 0)
            {
                Console.WriteLine("The score must be in range 100-0.");
            }
            else
            {
                switch (Score / 10)
                {
                    case 10:
                        Console.Write("满分，");
                        goto case 9;
                    case 9:
                        Console.WriteLine("优秀");
                        break;
                    case 8:
                    case 7:
                        Console.WriteLine("良好");
                        break;
                    case 6:
                        Console.WriteLine("及格");
                        break;
                    default:
                        Console.WriteLine("不及格");
                        break;                    
                }
            }
            Console.ReadLine();
        }
    }
}
