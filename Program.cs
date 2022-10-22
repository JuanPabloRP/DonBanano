using System.Collections.Generic;
using System.IO.Compression;

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
                        Console.Clear();
                        int docI_;
                        string pass_ = null;
                       

                        Console.WriteLine("--INICIAR SESION--\n");

                        Console.WriteLine("Digite su cédula");
                        docI_ = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite su contraseña");
                        pass_ = Console.ReadLine();


                        if (Trabajadores.Count() == 0)
                        {
                            Console.WriteLine("Error, el usuario no existe.");
                            break;
                        }

                        foreach (Trabajador worker in Trabajadores)
                        {

                            

                            if (worker.docI == docI_ && worker.password == pass_)
                            {

                               
                                Console.WriteLine("\n-----------------------------------\n");
                                if (worker.rol == "admin")
                                {
                                    Console.Clear();

                                    Console.WriteLine("Bienvenido admin <3");
                                    Console.WriteLine("Inventario Actual: ");
                                    MostrarInventario(Inventario, worker);

                                    MostrarOpciones(Inventario, worker);

                                }
                                else if (worker.rol == "empleado")
                                {
                                    Console.Clear();

                                    Console.WriteLine("Bienvenido empleado\n\n");
                                    Console.WriteLine("Inventario Actual: ");
                                    MostrarInventario(Inventario, worker);

                                    MostrarOpciones(Inventario, worker);


                                }
                                else if (worker.rol == "servicio")
                                {
                                    int pasillo = 0;
                                    Random num = new Random();
                                    pasillo = num.Next(1, 7);
                                    Console.Clear();

                                    Console.WriteLine("Bienvenido, haga por favor aseo en el pasillo " + pasillo);
                                    MostrarOpciones(Inventario, worker);


                                }
                                else
                                {
                                    Console.Clear();

                                    Console.WriteLine("Quien sos .l.");
                                    MostrarOpciones(Inventario, worker);

                                }

                            }
                            else
                            {
                                
                                Console.WriteLine("Error, verifique que: \n\t-Ingresó correctamente su documento de identidad \n\t-Ingresó correctamente su contraseña");
                            }


                        }
                        


                        break;

                    //registrarse
                    case 2:
                        Console.Clear();
                        int id = 0, docI;
                        Random n = new Random();
                        id = n.Next(10000, 99999);

                        string user = null, pass = null, rol = null;

                        Console.WriteLine("--REGISTRARSE--\n");

                        Console.WriteLine("Digite su nombre: ");
                        user = (Console.ReadLine());

                        Console.WriteLine("Digite su cédula: ");
                        docI = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite su contraseña: ");
                        pass = (Console.ReadLine());

                        Console.WriteLine("Digite su rol (admin/empleado/servicio): ");
                        rol = (Console.ReadLine());


                        Trabajadores.Add(new Trabajador(id, user, docI, pass, rol));

                        Console.WriteLine("\n---Usuario resgitrado---");


                        break;
                    case 3:
                        Console.WriteLine("Adios...");
                        break;
                    default:
                        Console.WriteLine("Error, ingrese una opción correcta");
                        break;
                }

            } while (opcion != 3);

        }

        static void MostrarInventario(List<Producto> Inventario, Trabajador worker)
        {
            Console.WriteLine("--INVENTARIO--");
            Console.WriteLine("\n\nNombre\tPrecio\tCantidad\tDestino");
            foreach (Producto prod in Inventario)
            {
                Console.WriteLine(prod.nombre + "\t" + prod.precio + "\t\t" + prod.cantidad + "\t" + prod.destino);
            }
            Console.WriteLine("\n\n");
        }


        //admin: manipular (crear, leer, actualizar y borrar), vender prod y generar facturas
        //empleado: solo ver
        static void MostrarOpciones(List<Producto> Inventario, Trabajador worker)
        {
            int op = 0;


            if (worker.rol == "admin")
            {
                do
                {
                    Console.WriteLine("\n\nIngrese la opción que desea realizar: \n1-Manipular inventario \n2-Vender prod (para generar facturas, debe vender primero) \n3-Salir \n");
                    op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            //manipula el inventario
                            ManipularInventario(Inventario, worker);
                            break;
                        case 2:
                            //vender productos
                            VenderProductos(Inventario, worker);
                            break;
                        case 3:
                            //se sale
                            Console.WriteLine("Adioooooooos brokiii");
                            break;
                        default:
                            Console.WriteLine("Error, por favor oprima una opción correcta");
                            break;
                    }

                } while (op != 3);

            }
            else if (worker.rol != "admin")
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

                Console.WriteLine("--MANIPULAR INVENTARIO--");
                Console.WriteLine("Ingrese la opción que desea realizar: \n1-Crear un producto \n2-Imprimir el inventario \n3-Actualizar un producto \n4-Eliminar un producto \n5-Salir\n");
                op = int.Parse(Console.ReadLine());



                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Producto prod = new Producto(id);

                        Console.WriteLine("--CREAR PRODUCTO--");
                        Console.WriteLine("Ingrese el nombre del producto: ");
                        prod.nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el precio del producto: ");
                        prod.precio = double.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la cantidad del producto: ");
                        prod.cantidad = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el destino del producto: ");
                        prod.destino = Console.ReadLine();
                        Inventario.Add(prod);

                        break;
                    case 2:
                        Console.Clear();
                        MostrarInventario(Inventario, worker);
                        break;
                    case 3:
                        Console.Clear();
                        string nombre = "";
                        bool existProd = false;

                        Console.WriteLine("--ACTUALIZAR PRODUCTO--");
                        Console.WriteLine("Ingrese el nombre del producto que desea actualizar: ");
                        nombre = Console.ReadLine();

                        foreach (Producto p in Inventario)
                        {
                            if (nombre == p.nombre)
                            {
                                existProd = true;
                                int opc = 0;
                                string nom = "";
                                double pre = 0;
                                int cant = 0;
                                string dest = "";


                                Console.WriteLine("Ingrese el dato que desea actualizar: \n1-Nombre \n2-Precio \n3-Cantidad \n4-Sucursal (destino)" +
                                    "");
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
                                    case 4:
                                        Console.WriteLine("Ingrese el destino del producto: ");
                                        dest = Console.ReadLine();
                                        p.destino = dest;
                                        break;
                                    default:
                                        Console.WriteLine("Error, Ingrese una opción correcta");
                                        break;
                                }
                                Console.WriteLine("\nEl producto ingresado se modificó con exito\n");
                            }


                        }

                        if (existProd != true)
                        {
                            Console.WriteLine("\nError, el producto ingresado no existe\n");
                        }


                        existProd = false;

                        break;
                    case 4:
                        Console.Clear();
                        nombre = "";
                        bool existeProd = false;

                        Console.WriteLine("--ELIMINAR PRODUCTO--");
                        Console.WriteLine("Ingrese el nombre del producto que desea eliminar: ");
                        nombre = Console.ReadLine();

                        foreach (Producto p in Inventario.ToList())
                        {
                            if (nombre == p.nombre)
                            {
                                existeProd = true;
                                Inventario.Remove(p);
                                Console.WriteLine("\nEl producto ingresado se eliminó con exito\n");
                            }
                        }

                        if (existeProd != true)
                        {
                            Console.WriteLine("\nError, el producto ingresado no existe\n");
                        }


                        existProd = false;

                        break;
                    case 5:
                        Console.Clear();
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

            Console.Clear();

            Console.WriteLine("--VENDER PRODUCTOS--");
            string product = "";
            double total = 0, totalPrecioProductos = 0;
            int cant = 0, continuar = 0, id = 0;
            bool existeProd = false;




            do
            {
                Console.WriteLine("\nInventario actual: ");
                MostrarInventario(Inventario, worker);

                Console.WriteLine("Que producto desea vender: ");
                product = Console.ReadLine();

s
                foreach (Producto p in Inventario)
                {
                    if (p.nombre == product)
                    {
                        existeProd = true;
                        Console.WriteLine("Cuantos productos desea vender: ");
                        cant = int.Parse(Console.ReadLine());

                        if (p.cantidad >= cant)
                        {
                            total = 0;
                            //CrearFactura(Factura, worker, totalPrecioProductos);

                            Random n = new Random();
                            id = n.Next(10000, 99999);

                            Producto p2 = new Producto(id);

                            p2.nombre = p.nombre;
                            p2.cantidad = cant;
                            p2.precio = p.precio * cant;


                            totalPrecioProductos += p2.precio;

                            p.cantidad -= cant;


                            Factura.Add(p2);



                        }
                        else
                        {
                            Console.WriteLine("Error, no hay esa cantidad mai");
                        }

                    }
                    else
                    {
                        //Console.WriteLine("Error, no está el producto");
                    }

                }

                if (existeProd == true)
                {
                    Console.WriteLine("Si desea vender otro producto ingrese 1: ");
                    continuar = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Producto no encontrada, ingrese 1 si desea vender otro producto: ");
                    continuar = int.Parse(Console.ReadLine());
                }

                existeProd = false;

            } while (continuar == 1);

            MostrarFactura(Factura, worker, totalPrecioProductos);
        }

        static void MostrarFactura(List<Producto> Factura, Trabajador worker, double totalPrecioProductos)
        {
            Console.Clear();   
            Console.WriteLine("\nFactura de compra: \n");
            Console.WriteLine("\n\nNombre\tPrecio Total\tCantidad");
            foreach (Producto prod in Factura)
            {
                Console.WriteLine(prod.nombre + "\t" + prod.precio + "\t\t" + prod.cantidad);
            }

            Console.WriteLine("\nTotal a pagar: " + totalPrecioProductos + "\n");
        }
    }

}