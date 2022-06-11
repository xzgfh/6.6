using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task6._6
{
    class CommonOfAllRoles
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public int Age { set; get; }

        public int RecordOfService { set; get; } //security
        public string TimeOfVisit { set; get; } // visitor  
        public string TypeOfManager { set; get; } //manager

        public CommonOfAllRoles(string Name, string Surname, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
        }
    }
    class Security : CommonOfAllRoles
    {
        public Security(string Name, string Surname, int Age, int RecordOfService)
            : base(Name, Surname, Age)
        {
            this.RecordOfService = RecordOfService;

        }
    }
    class Visitor : CommonOfAllRoles
    {


        public Visitor(string Name, string Surname, int Age, string TimeOfVisit)
            : base(Name, Surname, Age)
        {
            this.TimeOfVisit = TimeOfVisit;
        }
    }
    class Manager : CommonOfAllRoles
    {

        public Manager(string Name, string Surname, int Age, string TypeOfManager)
            : base(Name, Surname, Age)
        {
            this.TypeOfManager = TypeOfManager;
        }
    }



    class ListOfObjects<T> : IEnumerable where T : CommonOfAllRoles

                            /* where T : Security
                             where S : Visitor
                             where W : Manager */
    {
        private List<T> arr;
        private List<string> ListOfAccess;
        public ListOfObjects()
        {
            arr = new List<T>();
            ListOfAccess = new List<string>();
        }



        public void ShowAllObjects()
        { 

            Console.WriteLine("\t\t\t ListOfObjects\n\n");

            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write("{0}. {1} {2} , Age : {3} , Role : ", i, arr[i].Name, arr[i].Surname, arr[i].Age);

                if (arr[i] is Security) { Console.Write("Security , Record of service : {0}", arr[i].RecordOfService); }
                if (arr[i] is Visitor) { Console.Write("Visitor , Time of visit : {0}", arr[i].TimeOfVisit); }
                if (arr[i] is Manager) { Console.Write("Manager , Type of manager : {0}", arr[i].TypeOfManager); }

                Console.WriteLine(" , Access level : {0} ; \n", ListOfAccess[i]);


            }
        }

        public int Count
        {
            get
            {
                int num = 0;
                foreach (T p in arr)
                {
                    num++;
                }
                return num;
            }
        }



        public void SetAccess()
        {
            int p = 0;
            string str;



        mark:
            Console.WriteLine("Choise one of indexes : ");

            p = Int32.Parse(Console.ReadLine());
            if (p > arr.Count - 1 || p < 0)
            {
                goto mark;
            }

        mark1:
            Console.WriteLine("\nChoise the access level(Low,Medium,High): \n\n");
            str = Console.ReadLine();

            if (str == "Low" || str == "Medium" || str == "High")
            {
                ListOfAccess[p] = str;
            }
            else goto mark1;




        }
        public void AddObject(T obj1)
        {

            arr.Add(obj1);
            ListOfAccess.Add("None");
        }
        public void DeleteObject()
        {
            int ind = default(int);
            Console.WriteLine("Enter the index of removable element : ");
            ind = Int32.Parse(Console.ReadLine());

            arr.RemoveAt(ind);
        }
        public T this[int ind]
        {
            set { arr[ind] = value; }
            get { return arr[ind]; }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < arr.Count; i++)
            {
                yield return arr[i];
            }


        }

    }



}
