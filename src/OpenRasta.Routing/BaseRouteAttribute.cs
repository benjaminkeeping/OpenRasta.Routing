using System;
using System.Reflection;
using OpenRasta.Web;

namespace OpenRasta.Routing
{
    public class BaseRouteAttribute : HttpOperationAttribute
    {
        readonly string _route;
        
        protected BaseRouteAttribute(string route, string method)
        {
            _route = route;
            ForUriName = string.Format("{0}-{1}", GetNamrFrom(route), method);
            Method = method;
        }

        string GetNamrFrom(string route)
        {
            var name = route.Replace("/", "-");
            return name.StartsWith("-") ? name.Substring(1) : name;
        }

        public string Route
        {
            get { return _route; }
        }
    }
}