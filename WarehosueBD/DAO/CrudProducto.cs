using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehosueBD.Models;

namespace WarehosueBD.DAO
{
    public class CrudProducto
    {

        public void AgregueProduct(Producto ParametroProducto)
        {
            using (AlmacenBdContext BaseDeDatos = new AlmacenBdContext())
            {
                Producto product = new Producto();
                product.Nombre = ParametroProducto.Nombre;
                product.Descripcion = ParametroProducto.Descripcion;
                product.Precio = ParametroProducto.Precio;
                product.Stock = ParametroProducto.Stock;
                BaseDeDatos.Add(product);
                BaseDeDatos.SaveChanges();
                
            }
        }

        public Producto ProIndi(int id)
        {
            using (AlmacenBdContext dataB = new AlmacenBdContext())
            {

                var buscar = dataB.Productos.FirstOrDefault(x => x.Id == id);
                return buscar;

            }
        }

        public void ActualizarProducto(Producto ParametroProducto, int Lector)
        {
            using (AlmacenBdContext DataB = new AlmacenBdContext())
            {
                var buscar = ProIndi(ParametroProducto.Id);

                if (buscar == null)
                {
                    Console.WriteLine("El id que ingreso no existe");
                }
                else
                {
                    switch (Lector)
                    { 
                        case 1:
                            buscar.Nombre = ParametroProducto.Nombre;
                            break;

                        case 2:
                            buscar.Descripcion = ParametroProducto.Descripcion; 
                            break;
                        case 3:
                            buscar.Precio = ParametroProducto.Precio;
                            break;

                        case 4:
                            buscar.Stock = ParametroProducto.Stock;
                            break;
                    }
                    DataB.Update(buscar);
                    DataB.SaveChanges();
                }
            }
      
        }

        public String EliminarProducto(int id)
        {
            using (AlmacenBdContext DataB = new AlmacenBdContext())
            {
                var buscar = ProIndi(id);

                if (buscar == null)
                {
                    return "El producto que ingreso no existe";
                }
                else
                {
                    DataB.Productos.Remove(buscar);
                    DataB.SaveChanges();
                    return "El producto que seleciono se elimino";
                }
            }
        }

        public List<Producto> ListarProductos()
        {
            using (AlmacenBdContext DataB = new AlmacenBdContext())
            {
                return DataB.Productos.ToList();
            }
        }
    }

}
