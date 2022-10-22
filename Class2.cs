using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonBanano
{
    /*
     Objeto trabajador
        id
        nombre
        contraseña
        rol
     */
    public class Trabajador
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int docI { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
        public Trabajador(int _id, string _nombre, int _docI, string _password, string _rol)
        {
            id = _id;
            nombre = _nombre;
            docI = _docI;
            password = _password;
            rol = _rol;

        }




    }
}
