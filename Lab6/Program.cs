using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Lab6
{
    class Program
    {
        static Model1Container db = new Model1Container();
        static void InitData()
        {
            
            //EquipmentStore store = new EquipmentStore();

            CE_user u1 = new CE_user
            {
                Id = 1,
                name = "Evgen",
                surname = "Kravchenko",
                position = "sys.admin."
            };


            CE_user emp = new CE_user
            {
                Id = 2,
                name = "Emperor",
                surname = "{unknown}",
                position="Emperor of Mankind"
            };


            CE_user u2 = new CE_user
            {
                Id = 3,
                name = "Kama",
                surname = "Puliya",
                position = "philosopher"
            };

            CE_user u3 = new CE_user
            {
                Id = 4,
                name = "Vovan",
                surname = "Poliyan",
                position = "stranger"
            };

            db.CE_user.Add(u1);
            db.CE_user.Add(emp);
            db.CE_user.Add(u2);
            db.CE_user.Add(u3);

            Computing_eguipment c1 = new Computing_eguipment
            {
                Id = 1,
                name = "Comp1",
                price = "200",
                computing_power = "100"
            };

            Computing_eguipment c2 = new Computing_eguipment
            {
                Id=2,
                name = "Comp2",
                price = "210",
                computing_power = "90"
            };

            Computing_eguipment trone = new Computing_eguipment
            {
                Id = 3,
                name = "Golden Trone",
                price = "inf",
                computing_power = "40000"
            };
            db.Computing_eguipment.Add(c1);
            db.Computing_eguipment.Add(c2);
            db.Computing_eguipment.Add(trone);

            c1.CE_user.Add(u1);
            c1.CE_user.Add(u2);
            trone.CE_user.Add(emp);
            c2.CE_user.Add(u2);
            c2.CE_user.Add(u3);

            db.SaveChanges();
        }

        static void Querie1()
        {
            Console.WriteLine("\t\tSelect users of each machine");
            var q1 = from ce in db.Computing_eguipment
                     select ce;
            foreach (var ce in q1)
            {
                Console.WriteLine("Machine: " + ce.ToString());
                    foreach (var u in ce.CE_user)
                    {
                        Console.WriteLine(u.ToString());
                    }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void Querie2()
        {
            Console.WriteLine("\t\tSelect users of machine #13");
            var q1 = from ce in db.Computing_eguipment
                     where (ce.Id == 13)
                     select ce;
            foreach (var ce in q1)
            {
                foreach (var u in ce.CE_user)
                {
                    Console.WriteLine(u.ToString());
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void Querie3()
        {
            Console.WriteLine("\t\tSelect all users in database");
            var q1 = from ce in db.CE_user
                     select ce;
            foreach (var u in q1)
            {
                Console.WriteLine(u.ToString());
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        static void Querie4()
        {
            Console.WriteLine("\t\tSelect all names of users");
            var q1 = from ce in db.CE_user
                     select ce;
            foreach (var u in q1)
            {
                Console.WriteLine(u.name);
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        static void Querie5()
        {
            Console.WriteLine("\t\tSelect the most powerful machine");
            var q1 = from ce in db.Computing_eguipment
                     select ce;
            var pow = new Computing_eguipment();
            foreach (var u in q1)
            {
                if(Convert.ToInt32(pow.computing_power) < Convert.ToInt32(u.computing_power))
                { pow = u; }
            }
            Console.WriteLine(pow.ToString());
            Console.WriteLine();

            Console.ReadLine();
        }

        static void Querie6()
        {
            Console.WriteLine("\t\tSelect all names of users in order");
            var q1 = from ce in db.CE_user
                     select ce;
            q1 = q1.OrderBy(CE_user => CE_user.name);

            foreach (var u in q1)
            {
                Console.WriteLine(u.name);
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        static void Querie7()
        {
            Console.WriteLine("\t\tSelect all machines");
            var q1 = from ce in db.Computing_eguipment
                     select ce;
            foreach (var u in q1)
            {
                Console.WriteLine(u.ToString());
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //InitData();
            Querie1();
            Querie2();
            Querie3();
            Querie4();
            Querie5();
            Querie6();
            Querie7();

        }
    }
}
