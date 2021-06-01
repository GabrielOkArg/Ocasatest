using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BL
{
    public class crudClient
    {

       

        public List<Cliente> GetClientes()
        {
            DBconect dBconect = new DBconect();
           
            try
            {
                List<Cliente> aux = dBconect.GetClients();
  

                return aux;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddCliente(string[] array)
        {
            string razon = array[3].Replace('+', ' ');
            string direccion = array[5].Replace('+', ' ');
            Cliente cliente = new Cliente(Convert.ToInt32(array[1]),razon, direccion);
            DBconect dBconect = new DBconect();
            dBconect.NewItem(cliente);
        }

        public void EditCliente(string[] array)
        {
            string razon = array[3].Replace('+', ' ');
            string direccion = array[5].Replace('+', ' ');
            Cliente cliente = new Cliente(Convert.ToInt32(array[1]), razon, direccion);
            DBconect dBconect = new DBconect();
            dBconect.UpdateDB(cliente);
        }

        public void DeleteCliente(int id)
        {
            DBconect dBconect = new DBconect();
            dBconect.DeleteItem(id);
        }

    }
}
