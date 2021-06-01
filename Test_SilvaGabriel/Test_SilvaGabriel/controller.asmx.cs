using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BE;
using BL;

namespace Test_SilvaGabriel
{
    /// <summary>
    /// Descripción breve de controller
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class controller : System.Web.Services.WebService
    {

        [WebMethod]
        public string Actualizar()
        {
            return "Hola a todos";
        }
    }
}
