using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenRasta.Configuration;

namespace OpenRasta.Routing
{
    public class Routing
    {
        public static void Register(Assembly handlerAssembly, Assembly modelAssembly)
        {
            Register(new[] { handlerAssembly }, new[] { modelAssembly });
        }

        public static void Register(Assembly[] handlerAssemblies, Assembly[] modelAssemblies)
        {
            foreach (
                var route in
                    handlerAssemblies.SelectMany(a => a.GetTypes()).Select(GetBaseRouteAttributeFor).SelectMany(
                        routeInfo => routeInfo))
            {
                ResourceSpace.Has.ResourcesOfType<object>()
                    .AtUri(route.Route).Named(route.Name)
                    .HandledBy(route.HandlerType)
                    .AsJsonDataContract()
                    .And.AsXmlDataContract();
            }
            foreach (var type in modelAssemblies.SelectMany(x => x.GetTypes()))
            {
                ResourceSpace.Has.ResourcesOfType(type)
                    .WithoutUri
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