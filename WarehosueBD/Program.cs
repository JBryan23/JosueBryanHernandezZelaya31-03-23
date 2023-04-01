using WarehosueBD.DAO;
using WarehosueBD.Models;

CrudProducto CrudProducto = new CrudProducto();
Producto product = new Producto();

bool Continuar = true;

while (Continuar)
{



    Console.Write("Bienvienido Usuario Inteligente\n");

    Console.WriteLine(@"
======================================================
MENU
Ingrese 0 para ingresar un nuevo producto que desee
Ingrese 1 para actualizar un producto que desee
Ingrese 2 para eliminar un producto que desee
Ingrese 3 para mostrar el listado de los productos
Ingrese 4 para salir del programa
=====================================================");

    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {
        case 0:
            bool bucle = true;
            while (bucle == true)
            {
                Console.Write("Escriba el nombre del producto nuevo: ");
                product.Nombre = Console.ReadLine();
                Console.Write("Escriba la descripcion  del producto nuevo: ");
                product.Descripcion = Console.ReadLine();
                Console.Write("Ingrese  el precio del producto nuevo: $");
                product.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Escriba la cantidad  del producto nuevo: ");
                product.Stock = Convert.ToInt32(Console.ReadLine());

                CrudProducto.AgregueProduct(product);
                Console.WriteLine(@"
El producto nuevo ya esta registrado

Ingrese 0 para ingresar un nuevo producto que desee
Ingrese 1 para salir
");
                var Menu1 = Convert.ToInt32(Console.ReadLine());

                switch (Menu1)
                {
                    case 0:
                        bucle = true;
                        break;
                    case 1:
                        bucle = false;
                        break;

                }




            }
            break;

        case 1:
            Console.WriteLine("Eligió actualizar datos");
            Console.Write("Porfavor ingrese el Id del producto a actualizar: ");

            var BuscarProductosIndividuall = CrudProducto.ProIndi(Convert.ToInt32(Console.ReadLine()));

            if (BuscarProductosIndividuall == null)
            {
                Console.WriteLine("El producto no existe");
            }
            else
            {
                Console.Write("ACTUALIZACION");
                Console.WriteLine($"\nId: {BuscarProductosIndividuall.Id}, Nombre: {BuscarProductosIndividuall.Nombre}, Descripcion: {BuscarProductosIndividuall.Descripcion}, Precio{BuscarProductosIndividuall.Precio}, Stock: {BuscarProductosIndividuall.Stock}");
                Console.WriteLine(@"
Elija lo que quiere actualizar 

Ingrese 1 para actualizar el Nombre
Ingrese 2 para actualizar la Descripcion 
Ingrese 3 para actualizar el Precio
Ingrese 4 para actualizar el Stock:
");

                var Lector = Convert.ToInt32(Console.ReadLine());

                switch (Lector)
                {
                    case 1:
                        Console.WriteLine("Ingrese el  nombre: ");
                        BuscarProductosIndividuall.Nombre = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Ingrese la descripcion : ");
                        BuscarProductosIndividuall.Descripcion = Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el  precio: ");
                        BuscarProductosIndividuall.Precio = Convert.ToInt32(Console.ReadLine());
                        break;

                    case 4:
                        Console.WriteLine("Ingrese el stock: ");
                        BuscarProductosIndividuall.Stock = Convert.ToInt32(Console.ReadLine());
                        break;

                    default:
                        Console.WriteLine("ERROR no se encuentra la opcion que ingreso ");
                        break;


                }

                CrudProducto.ActualizarProducto(BuscarProductosIndividuall, Lector);
                Console.WriteLine("la actualizacion esta completada");


            }

            break;

        case 2:
            Console.Write("\nIngrese el ID del producto que desea eliminar");
            var ProductosIndividualDELE = CrudProducto.ProIndi(Convert.ToInt32(Console.ReadLine()));
            if (ProductosIndividualDELE == null)
            {
                Console.Write("El producto que indica no existe");
            }
            else
            {
                Console.Write("ELIMINACION");
                Console.WriteLine($"\nId: {ProductosIndividualDELE.Id}, Nombre: {ProductosIndividualDELE.Nombre}, Descripcion: {ProductosIndividualDELE.Descripcion}, Precio{ProductosIndividualDELE.Precio}, Stock: {ProductosIndividualDELE.Stock}");

                Console.Write("El producto que se encontro es el correcto 1:  ");
                var Lector = Convert.ToInt32(Console.ReadLine());

                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write(CrudProducto.EliminarProducto(Id));
                }
                else
                {
                    Console.Write("Vamos de nuevo, inica otra vez");
                }


            }
            break;

        case 3:
            Console.Write("Listado de productos");

            var ListaProduc = CrudProducto.ListarProductos();
            foreach (var i in ListaProduc)
            {
                Console.Write($"{i.Id}, {i.Nombre}, {i.Descripcion}, {i.Precio}, {i.Stock}");
            }
            break;

        case 4:
            Continuar = false;
            break;


        default:
            Console.WriteLine("ERROR no se encuentra la opcion que ingreso ");
            break;



    }

    Console.WriteLine(@"Usuario Inteligente desea continua?
Ingrese SI para continuar 
Ingrese NO para salir : ");

    var cont = Console.ReadLine();

    if (cont.Equals("NO"))
    {
        Continuar = false;
    }
    else if (cont.Equals("SI"))
    {
        Continuar = true;
    }


}