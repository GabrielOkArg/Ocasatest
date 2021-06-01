using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.IO;
using BL;

namespace Test_SilvaGabriel
{
    /// <summary>
    /// Descripción breve de EditCliente
    /// </summary>
    public class EditCliente : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            crudClient crudClient = new crudClient();
            string m = new System.IO.StreamReader(context.Request.InputStream).ReadToEnd();
            string[] splitcadena;
            splitcadena = m.Split('=', '&');
            crudClient.EditCliente(splitcadena);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}