using System.Collections.Generic;

namespace DonBanano
{

    class Program
    {
        static List<Producto> Inventario = new List<Producto>();
        static List<Producto> Factura = new List<Producto>();
        static List<Trabajador> Trabajadores = new List<Trabajador>();

        

        static void Main(string[] args)
        {
            

            int opcion;

            do
            {
                Console.WriteLine("..................................\n");
                Console.WriteLine("1- iniciar sesion");
                Console.WriteLine("2- crear usuario");
                Console.WriteLine("3- Salir");
                Console.WriteLine("..................................\n");

                Console.WriteLine("Digite una opcion: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    //iniciar sesion
                    case 1:

                        int docI_;
                        string pass_ = null;

                        Console.WriteLine("Digite su cédula");
                        docI_ = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite su contraseña");
                        pass_ = Console.ReadLine();

                        foreach (Trabajador worker in Trabajadores)
                        {

                            if (worker.docI == docI_ && worker.password == pass_)
                            {
                                if (worker.rol == "admin")
                                {
                                    Console.WriteLine("Bienvenido admin <3");
                                    MostrarInventario(Inventario, worker);

                                    MostrarOpciones(Inventario, worker);
                                }
                                else if(worker.rol == "empleado")
                                {
                                    Console.WriteLine("Bienvenido empleado\n\n");

                                    MostrarInventario(Inventario, worker);

                                    MostrarOpciones(Inventario, worker);



                                }
                                else if (true)
                                {

                                }
                                else
                                {
                                    Console.WriteLine("Bienvenido ??? .l.");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Error, verifique su nombre o contraseña");
                            }

                            
                        }

                        break;

                    //registrarse
                    case 2:

                        int id = 0, docI;
                        Random n = new Random();
                        id = n.Next(10000, 99999); 

                        string user = null, pass = null, rol = null;
                        

                        Console.WriteLine("Digite su nombre: ");
                        user = (Console.ReadLine());

                        Console.WriteLine("Digite su cédula: ");
                        docI = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite su contraseña: ");
                        pass = (Console.ReadLine());

                        Console.WriteLine("Digite su rol (admin/empleado): ");
                        rol = (Console.ReadLine());


                        Trabajadores.Add(new Trabajador(id, user, docI,pass, rol));

                        Console.WriteLine("\n---Usuario resgitrado---");


                        break;
                    case 3:
                        Console.WriteLine("Adios...");
                        break;
                    default:
                        Console.WriteLine("Error, ingrese una opción correcta");
                        break;
                }

            } while (opcion != 3 );

        }   

        static void MostrarInventario(List<Producto> Inventario, Trabajador worker)
        {
            Console.WriteLine("\n\nNombre\tPrecio/u\tCantidad");
            foreach (Producto prod in Inventario)
            {
                Console.WriteLine(prod.nombre + "\t" + prod.precio + "\t\t" + prod.cantidad);
            }
            Console.WriteLine("\n\n");
        }


        //admin: manipular (crear, leer, actualizar y borrar), vender prod y generar facturas
        //empleado: solo ver
        static void MostrarOpciones(List<Producto> Inventario, Trabajador worker)
        {
            int op = 0;
            
            
            if(worker.rol == "admin")
            {
                do
                {
                    Console.WriteLine("\nIngrese la opción que desea realizar: \n1-Manipular inventario \n2-Vender prod \n3-Generar facturas \n4-Salir");
                    op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            //manipula el inventario
                            ManipularInventario(Inventario, worker);
                            break;
                        case 2:
                            VenderProductos(Inventario, worker);
                            break;
                        case 3:
                            //genera facturas
                            break;
                        case 4:
                            //se sale
                            Console.WriteLine("Adioooooooos brokiii");
                            break;
                        default:
                            Console.WriteLine("Error, por favor oprima una opción correcta");
                            break;
                    }

                } while (op != 4);

            }else if(worker.rol == "empleado")
            {
                
                do
                {
                    Console.WriteLine("Para salir ingrese: 1");
                    op = int.Parse(Console.ReadLine());

                    if (op == 1)
                    {
                        Console.WriteLine("Adioooooooos madafaker");
                    }
                    else
                    {
                        Console.WriteLine("Por favor oprima 1, no sea mrk como Alvaro :D");
                    }


                } while (op != 1);
            }            


            /*
            if (worker.rol == "admin")
            {
                Console.WriteLine("<3 pal admin");
            }
            else if (worker.rol == "empleado")
            {
                Console.WriteLine(".l. pal empleado");
            }
            else
            {

            }
            */
        }

        static void ManipularInventario(List<Producto> Inventario, Trabajador worker)
        {
            int op = 0, id = 0;
            Random n = new Random();
            id = n.Next(10000, 99999);

            do
            {
                Console.WriteLine("Ingrese la opción que desea realizar: \n1-Crear un producto \n2-Imprimir el inventario \n3-Actualizar un producto \n4-Eliminar un producto \n5-Salir");
                op = int.Parse(Console.ReadLine());



                switch (op)
                {
                    case 1:
                        Producto prod = new Producto(id);

                        Console.WriteLine("Ingrese el nombre del producto: ");
                        prod.nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el precio del producto: ");
                        prod.precio = double.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la cantidad del producto: ");
                        prod.cantidad = int.Parse(Console.ReadLine());

                        Inventario.Add(prod);

                        break;
                    case 2:
                        MostrarInventario(Inventario, worker);
                        break;
                    case 3:

                        string nombre = "";

                        Console.WriteLine("Ingrese el nombre del producto que desea actualizar: ");
                        nombre = Console.ReadLine();

                        foreach(Producto p in Inventario)
                        {
                            if(nombre == p.nombre)
                            {
                                int opc = 0;
                                string nom = "";
                                double pre = 0;
                                int cant = 0;

                                
                                Console.WriteLine("Ingrese el dato que desea actualizar: \n1-Nombre \n2-Precio \n3-Cantidad");
                                opc = int.Parse(Console.ReadLine());

                                switch (opc)
                                {
                                    case 1:
                                        Console.WriteLine("Ingrese el nuevo nombre: ");
                                        nom = Console.ReadLine();
                                        p.nombre = nom;
                                        break;
                                    case 2:
                                        Console.WriteLine("Ingrese el nuevo precio: ");
                                        pre = double.Parse(Console.ReadLine());
                                        p.precio = pre;
                                        break;
                                    case 3:
                                        Console.WriteLine("Ingrese la nueva cantidad: ");
                                        cant = int.Parse(Console.ReadLine());
                                        p.cantidad = cant;
                                        break;
                                    default:
                                        Console.WriteLine("Error, Ingrese una opción correcta");
                                        break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Error, nombre del producto no encontrado");
                            }
                        }

                        break;
                    case 4:
                        nombre = "";

                        Console.WriteLine("Ingrese el nombre del producto que desea eliminar: ");
                        nombre = Console.ReadLine();

                        foreach (Producto p in Inventario.ToList())
                        {
                            if (nombre == p.nombre)
                            {
                                Inventario.Remove(p);
                            }
                            else
                            {
                                Console.WriteLine("Error, producto no encontrado.");
                            }
                        }

                        break;
                    case 5:
                        Console.WriteLine("Ha salido de este submenu");
                        break;
                    default:
                        Console.WriteLine("Error, ingrese una opción valida");
                        break;
                }

            } while (op != 5);
        }

        static void VenderProductos(List<Producto> Inventario, Trabajador worker)
        {
            

            string  product = "";
            double total = 0;
            int cant = 0, continuar = 0, id = 0;

            do
            {
                MostrarInventario(Inventario, worker);

                Console.WriteLine("Que producto desea vender: ");
                product = Console.ReadLine();

                foreach (Producto p in Inventario)
                {
                    if(p.nombre == product)
                    {
                        Console.WriteLine("Cuantos productos desea vender: ");
                        cant = int.Parse(Console.ReadLine());
                        
                        if (p.cantidad >= cant)
                        {
                            
                            Random n = new Random();
                            id = n.Next(10000, 99999);
                            

                            p.cantidad -= cant;
                            total += p.precio * cant;
                            
                            //ARREGLAR
                            Factura.Add(p);
                            p.cantidad = cant;
                            p.precio = total;
                            total = 0;
                        }
                        else
                        {
                            Console.WriteLine("Error, no hay esa cantidad mai");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error, no está el producto");
                    }
                    
                }

                Console.WriteLine("Si desea vender más producto ingrese 1: ");
                continuar = int.Parse(Console.ReadLine());

                

            } while (continuar == 1);

            MostrarFactura(Factura, worker);
        }


        static void MostrarFactura(List<Producto> Factura, Trabajador worker)
        {
            Console.WriteLine("\nFactura de compra: \n");
            Console.WriteLine("\n\nNombre\tPrecioT\tCantidad");
            foreach (Producto prod in Factura)
            {
                Console.WriteLine(prod.nombre + "\t" + prod.precio + "\t" + prod.cantidad);
            }
            Console.WriteLine("\n\n");
        }
    }

}