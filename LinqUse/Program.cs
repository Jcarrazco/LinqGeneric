using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUse
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] coleccion = { "Hijo de la luna", "A Dios le pido",
                                    "No me doy por vencido", "Y nos dieron las diez",
                                    "Corazón partío"};
            //uso de linq tipo sql
            var orden = from n 
                        in coleccion
                        where n.Length <= 15
                        select n;
            //imprime el resultado
            foreach(var c in orden)
            {
                Console.WriteLine(c);
            }
            Console.ReadKey();

            try
            {
                SqlConnection Conexion = new SqlConnection("server=HGDLAPCARRASCOJ\\SQLEXPRESS ;" +
                    " database=AdventureWorks2014 ; integrated security = true");
                SqlCommand Comando = new SqlCommand("SELECT top(100) BusinessEntityID, " +
                    "FirstName, LastName FROM Person.Person", Conexion);

                Conexion.Open();
                SqlDataReader Reader = Comando.ExecuteReader();
            

                List<empleado> Empleadolist = new List<empleado>();

            
            
                while (Reader.Read())
                {
                    Empleadolist.Add(new empleado { ID = Reader.GetInt32(0),
                        Name = Reader.GetString(1), LName = Reader.GetString(2)});
                }

                IEnumerable<empleado> emplead = Empleadolist.Where(x => x.ID < 1000).ToList();
                Console.WriteLine("Los empleados con menor ID son: ");

                foreach (empleado c in emplead)
                {
                    Console.WriteLine(c.ID + " "+ c.Name + " " + c.LName);
                }

                emplead = Empleadolist.Where(x => x.Name == "Kim").ToList();
                Console.WriteLine("Los empleados cuyo nombre es Kim son: ");

                foreach (empleado c in emplead)
                {
                    Console.WriteLine(c.ID + " " + c.Name + " " + c.LName);
                }

            }

            
            catch (SqlException ex) {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();


        }
    }
}
