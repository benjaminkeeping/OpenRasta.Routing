using System;

namespace OpenRasta.Routing
{
    public class GetAttribute : BaseRouteAttribute
    {
        public GetAttribute(string route)
            : base(route)
        {
            Method = "GET";
        }
    }
}