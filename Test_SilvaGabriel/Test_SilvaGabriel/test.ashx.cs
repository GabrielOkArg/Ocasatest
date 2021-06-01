using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL;

namespace Test_SilvaGabriel
{
    /// <summary>
    /// Descripción breve de test
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            BL.crudClient crudClient = new crudClient();

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