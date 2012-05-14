using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using OpenRasta.Configuration;

namespace OpenRasta.Routing
{
    public class Routing
    {
        public static IEnumerable<RouteInfo> GetRouteInfo(Assembly handlerAssembly)
        {
            return GetRouteInfo(new[] {handlerAssembly});
        }

        public static IEnumerable<RouteInfo> GetRouteInfo(Assembly[] handlerAssemblies)
        {
            return handlerAssemblies.SelectMany(a => a.GetTypes()).Select(GetBaseRouteAttributeFor).SelectMany(
                routeInfo => routeInfo);
        }
        
        public static void Register(Assembly handlerAssembly, Assembly modelAssembly)
        {
            Register(new[] { handlerAssembly }, new[] { modelAssembly });
        }

        public static void Register(Assembly[] handlerAssemblies, Assembly[] modelAssemblies)
        {
            foreach (
                var route in
                    handlerAssemblies.SelectMany(a => a.GetTypes()).Select(GetBaseRouteAttributeFor).SelectMany(
                        routeInfo => routeInfo).OrderByDescending(x => x.Route))
            {
                Debug.WriteLine(string.Format("[OpenRasta.Routing] Registering route '{0}' named '{1}' with handler '{2}'", route.Route, route.Name, route.HandlerType));
                ResourceSpace.Has.ResourcesOfType(route.HandlerType)
                    .AtUri(route.Route).Named(route.Name)
                    .HandledBy(route.HandlerType)
                    .AsJsonDataContract()
                    .And.AsXmlDataContract();
            }
            foreach (var type in modelAssemblies.SelectMany(x => x.GetTypes()))
            {
                Debug.WriteLine(string.Format("[OpenRasta.Routing] Registering  type '{0}'", type));
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