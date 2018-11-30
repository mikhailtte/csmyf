using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace proxydll
{
    public class proxydll : IWebProxy
    {
        public ICredentials Credentials
        {
            get { return new NetworkCredential("3VuEq8", "0WCuzw", "45.4.197.155:8000"); }
            set { }
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri("http://45.4.197.155:8000");
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }

    }
}