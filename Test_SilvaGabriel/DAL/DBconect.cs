using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class DBconect
    {
        


        public void UpdateDB(Cliente cliente)
        {
            List<Cliente> listado = new List<Cliente>();
            using (SqlConnection conn = new SqlConnection(@"Data Source=EDUARDOSILVA1\SQLEXPRESS01;Initial Catalog=ocasa;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ActualizarCliente";
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = cliente.id;
                cmd.Parameters.Add("@razonsocial", SqlDbType.NVarChar).Value = cliente.razonSocial;
                cmd.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = cliente.direccion;

                cmd.Connection = conn;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

        }

        public void DeleteItem(int id)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=EDUARDOSILVA1\SQLEXPRESS01;Initial Catalog=ocasa;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_EliminarrCliente";
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                cmd.Connection = conn;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public void NewItem(Cliente cliente)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=EDUARDOSILVA1\SQLEXPRESS01;Initial Catalog=ocasa;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_InsertarCliente";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = cliente.id;
                cmd.Parameters.Add("@razon", SqlDbType.NVarChar).Value = cliente.razonSocial;
                cmd.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = cliente.direccion;

                cmd.Connection = conn;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }


        public   List<Cliente> GetClients()
        {
            DataTable dt = new DataTable();
            try
            {
                List<Cliente> listado = new List<Cliente>();
                SqlDataReader sqlDataReader;
                using (SqlConnection conn = new SqlConnection(@"Data Source=EDUARDOSILVA1\SQLEXPRESS01;Initial Catalog=ocasa;Integrated Security=True"))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetClientes";

                    cmd.Connection = conn;

                    cmd.Connection.Open();
                    sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        listado.Add(new Cliente(Convert.ToInt32(sqlDataReader["IdCliente"].ToString()), sqlDataReader["RazonSolcial"].ToString(), sqlDataReader["Direccion"].ToString()));
                    }
                    cmd.Connection.Close();
                }
                return listado;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public static DataTable Getschemma(string tableschemma, SqlDataAdapter da)
        {
            DataTable dt = new DataTable();
            return dt;
        }


    }
}
