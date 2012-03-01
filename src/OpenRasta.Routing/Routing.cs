using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenRasta.Configuration;

namespace OpenRasta.Routing
{
    public class Routing
    {
        public static void Register(Assembly controllerAssembly)
        {
            Register(new[] { controllerAssembly });
        }

        public static void Register(Assembly[] controllerAssemblies)
        {
            foreach (
                var typedRoute in
                    controllerAssemblies.SelectMany(a => a.GetTypes()).Select(GetBaseRouteAttributeFor).SelectMany(
                        routeInfo => routeInfo))
            {
                ResourceSpace.Has.ResourcesOfType<object>()
                    .AtUri(typedRoute.Route).Named(typedRoute.Name)
                    .HandledBy(typedRoute.HandlerType)
                    .AsJsonDataContract()
                    .And.AsXmlDataContract();
            }
        }

        static IEnumerable<RouteInfo> GetBaseRouteAttributeFor(Type type)
        {
            return
                type.GetMethods().SelectMany(x => x.GetCustomAttributes(true)).Where(IsOurAttribute).Select(
                    x => new RouteInfo(type, x as BaseRouteAttribute));
        }

        static bool IsOurAttribute(object customAttribute)
        {
            var attr = (customAttribute as BaseRouteAttribute);
            return attr != null;
        }
    }

}