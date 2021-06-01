using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente
    {

        public Cliente(int id, string razonsolcial, string direccion)
        {
            this.direccion = direccion;
            this.id = id;
            this.razonSocial = razonsolcial;
        }



      

        public string razonSocial { get; set; }
        public string direccion { get; set; }
        public int id { get; set; }
       
    }
}
