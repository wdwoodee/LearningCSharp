using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    public class LambdaTest
    {
        //传统的调用委托的示例##############  
        public static void FindListDelegate()
        {
            //先创建一个泛型的List类    
            List<string> list = new List<string>();
            list.AddRange(new string[] { "ASP.NET课程", "J2EE课程", "PHP课程", "数据结构课程" });
            Predicate<string> findPredicate = new Predicate<string>(IsBookCategory);
            List<string> bookCategory = list.FindAll(findPredicate);
            foreach (string str in bookCategory)
            {
                Console.WriteLine("{0}\t", str);
            }
        }
        //谓词方法，这个方法将被传递给FindAll方法进行书书籍分类的判断    
        public static bool IsBookCategory(string str)
        {
            return str.EndsWith("课程") ? true : false;
        }

        //使用匿名方法来进行搜索过程##############  
        public static void FindListAnonymousMethod()
        {
            //先创建一个泛型的List类    
            List<string> list = new List<string>();
            list.AddRange(new string[] { "ASP.NET课程", "J2EE课程", "PHP课程", "数据结构课程" });
            //在这里，使用匿名方法直接为委托创建一个代码块，而不用去创建单独的方法    
            List<string> bookCategory = list.FindAll(delegate(string str)
            {
                return str.EndsWith("课程") ? true : false;
            });
            foreach (string str in bookCategory)
            {
                Console.WriteLine("{0}\t", str);
            }
        }

        //使用Lambda来实现搜索过程##############   
        public static void FindListLambdaExpression()
        {
            //先创建一个泛型的List类    
            List<string> list = new List<string>();
            list.AddRange(new string[] { "ASP.NET课程", "J2EE课程", "PHP课程", "数据结构课程" });
            //在这里，使用了Lambda来创建一个委托方法    
            List<string> bookCategory = list.FindAll((string str) => str.EndsWith("课程"));
            foreach (string str in bookCategory)
            {
                Console.WriteLine("{0}\t", str);
            }
        }    
    }
}
