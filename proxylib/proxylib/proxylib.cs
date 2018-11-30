using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace proxylib
{
    public class proxylib : IWebProxy
    {
        public ICredentials Credentials
        {
            get { return new NetworkCredential("user", "password", "domain"); }
            set { }
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri("http://my.proxy:8080");
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }

    }
}
