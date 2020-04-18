
using Solucion.Libreria.Consola;    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solucion.VentaRepuesto.Entidades;

namespace VentaRepuesto
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuarActivo = true;

            string menu = "1) Agregar Repuesto \n2) Quitar Repuesto \n3) Modificar precio de repuesto " +
               "\n4) Agregar Stock \n5) Quitar Stock \n6) Traer repuestos de una categoria \n7) Limpiar Consola \nX) Salir";

            Comercio c = new Comercio("Wonderland", "Calle Falsa 123");

            Console.WriteLine("Bienvenido a " + c.NombreComercio);

            do
            {
                Console.WriteLine(menu);

                try
                {
                    
                    string opcionSeleccionada = Console.ReadLine();

                   
                    if (ConsolaHelper.EsOpcionValida(opcionSeleccionada, "1234567X"))
                    {
                        if (opcionSeleccionada.ToUpper() == "X")
                        {
                            continuarActivo = false;
                            continue;
                        }

                        switch (opcionSeleccionada)
                        {
                            case "1":                               
                                Program.AgregarRepuesto(c);
                                break;

                            case "2":
                                Program.QuitarRepuesto(c);
                                break;

                            case "3":
                                Program.ModificarPrecio(c);
                                break;

                            case "4":
                                Program.AgregarStock(c);
                                break;

                            case "5":
                                Program.QuitarStock(c);
                                break;

                            case "6":
                                Program.TraerPorCategoria(c);
                                break;

                            case "7":
                                Console.Clear();
                                break;
                           
                            default:
                                Console.WriteLine("Opción inválida.");
                                break;
                        }

                    }

                    else
                    {
                        Console.WriteLine("Opción inválida.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error durante la ejecución del comando. Por favor intente nuevamente. Mensaje: " + ex.Message);
                }
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                Console.Clear();
            }
            while (continuarActivo);

            Console.ReadKey();
        }

        private static void AgregarRepuesto(Comercio c)
        {
            int cod = ConsolaHelper.PedirInt("Codigo");
            string n = ConsolaHelper.PedirString("Nombre");
            double p = ConsolaHelper.PedirDouble("Precio");
            int s = ConsolaHelper.PedirInt("Stock");
            int cod2 = ConsolaHelper.PedirInt("Codigo de Categoria");
            string n2 = ConsolaHelper.PedirString("Nombre de Categoria");

            Categoria cat = new Categoria(cod2, n2);

            Repuesto r = new Repuesto(cod, n, p, s, cat);

            c.AgregarRepuesto(r);

            Console.WriteLine("Repuesto agregado.");



        }

        private static void QuitarRepuesto(Comercio c)
        {
            Console.WriteLine("Seleccione el codigo de repuesto a eliminar: ");
            int cod = int.Parse(Console.ReadLine());
            List<int> lst = new List<int>();
            foreach (Repuesto r in c.Repuestos)
            {
                lst.Add(r.Codigo);
            }

            if (!lst.Contains(cod))
            {
                Console.WriteLine("El repuesto no pertenece al Comercio.");
            }
            else
            {
                c.QuitarRepuesto(cod);
               
            }
        }

        private static void ModificarPrecio(Comercio c)
        {
            Console.WriteLine("Seleccione el codigo de repuesto a modificar el precio: ");
            int cod = int.Parse(Console.ReadLine());
            Console.WriteLine("Seleccione el nuevo precio: ");
            double p = double.Parse(Console.ReadLine());

            List<int> lst = new List<int>();
            foreach (Repuesto r in c.Repuestos)
            {
                lst.Add(r.Codigo);
            }

            if (!lst.Contains(cod))
            {
                Console.WriteLine("El repuesto no pertenece al Comercio.");
            }
            else
            {
                c.ModificarPrecio(cod,p);
            }

        }

        private static void AgregarStock(Comercio c)
        {
            Console.WriteLine("Seleccione el codigo de repuesto a agregarle stock: ");
            int cod = int.Parse(Console.ReadLine());
            Console.WriteLine("Seleccione la cantidad de stock a agregar: ");
            int cant = int.Parse(Console.ReadLine());

            List<int> lst = new List<int>();
            foreach (Repuesto r in c.Repuestos)
            {
                lst.Add(r.Codigo);
            }

            if (!lst.Contains(cod))
            {
                Console.WriteLine("El repuesto no pertenece al Comercio.");
            }
            else
            {
                c.AgregarStock(cod, cant);
            }

        }

        private static void QuitarStock(Comercio c)
        {
            Console.WriteLine("Seleccione el codigo de repuesto a quitarle stock: ");
            int cod = int.Parse(Console.ReadLine());
            Console.WriteLine("Seleccione la cantidad de stock a quitar: ");
            int cant = int.Parse(Console.ReadLine());

            List<int> lst = new List<int>();
            foreach (Repuesto r in c.Repuestos)
            {
                lst.Add(r.Codigo);
                
            }

            if (!lst.Contains(cod))
            {
                Console.WriteLine("El repuesto no pertenece al Comercio.");
            }
            else
            { 
                c.QuitarStock(cod, cant);
            }

        }

        private static void TraerPorCategoria(Comercio c)
        {
            Console.WriteLine("Seleccione el codigo de categoria a listar: ");
            int cod = int.Parse(Console.ReadLine());


            List<int> lst = new List<int>();
            foreach (Repuesto r in c.Repuestos)
            {
                lst.Add(r.Categoria.Codigo);
            }

            if (!lst.Contains(cod))
            {
                Console.WriteLine("La categoria no pertenece a un respuesto del comercio.");
            }
            else
            {
                c.TraerPorCategoria(cod);
            }

        }

    }
}
