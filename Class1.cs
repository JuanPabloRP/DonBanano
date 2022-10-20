using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonBanano
{

    /*
     Objeto producto:
        id
        nombre
        precio
        cantidad
        disponibilidad
     */
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; } 
        //-----
        //public bool disponibilidad { get; set; }
        
        public Producto(int _id)
        {
            id = _id;
            nombre = null;
            precio = 0;
            cantidad = 0;
            //disponibilidad = _disponibilidad;
        }
    }
}
