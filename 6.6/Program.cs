using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Security one = new Security("Иван", "Петров", 48, 5);
            Visitor two = new Visitor("Петя", "Иванов", 50, "16.00");
            Manager three = new Manager("Коля", "Зайцев", 30, "LowManager");


            ListOfObjects<CommonOfAllRoles> obj = new ListOfObjects<CommonOfAllRoles>();
            obj.AddObject(one);
            obj.AddObject(two);
            obj.AddObject(three);

            obj.ShowAllObjects();
            Console.WriteLine("\n\n");

            for (int i = 0; i < obj.Count; i++)
            {
                Console.WriteLine(obj[i].Name + " " + obj[i].Surname);


            }

            obj.ShowAllObjects();
            obj.DeleteObject();
            obj.ShowAllObjects();



            Console.WriteLine(obj[0].Name);
            Console.ReadKey();

        }
    }
}
