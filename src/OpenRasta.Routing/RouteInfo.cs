using System;

namespace OpenRasta.Routing
{
    public class RouteInfo
    {
        readonly Type _handlerType;
        readonly string _name;
        readonly string _route;

        public RouteInfo(Type handlerType, BaseRouteAttribute routeAttribute)
        {
            _handlerType = handlerType;
            _route = routeAttribute.Route;
            _name = routeAttribute.ForUriName;
        }

        public Type HandlerType
        {
            get { return _handlerType; }
        }

        public string Route
        {
            get { return _route; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}