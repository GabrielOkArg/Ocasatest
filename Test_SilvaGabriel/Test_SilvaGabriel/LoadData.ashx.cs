using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

using BE;
using BL;

namespace Test_SilvaGabriel
{
    /// <summary>
    /// Descripción breve de LoadData
    /// </summary>
    public class LoadData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            crudClient crudClient = new crudClient();
            var items = crudClient.GetClientes();
                string jsonout = string.Empty;
                context.Response.ContentType = "application/json";
                JavaScriptSerializer js = new JavaScriptSerializer();
                jsonout = js.Serialize(items);
                context.Response.Write(jsonout);
            

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