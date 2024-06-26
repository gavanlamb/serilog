using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Serilog.Core;
using Serilog.Events;

namespace Logging.Serilog.Enrichers
{
  public class RoutePattern : ILogEventEnricher
  {
    private readonly IHttpContextAccessor _contextAccessor;

    public RoutePattern() : this(new HttpContextAccessor()) { }

    public RoutePattern(IHttpContextAccessor contextAccessor) => _contextAccessor = contextAccessor;

    public void Enrich(
      LogEvent logEvent, 
      ILogEventPropertyFactory propertyFactory)
    {
      if (_contextAccessor.HttpContext == null)
        return;
      
      var routeData = _contextAccessor.HttpContext.GetRouteData();
      var routeEndpoint = _contextAccessor.HttpContext.GetEndpoint() as RouteEndpoint;
      var pattern = routeEndpoint?.RoutePattern.RawText;
            
      if(routeData.Values.TryGetValue("version", out var version))
      {
        if (pattern?.Contains("{version:apiVersion}") == true)
        {
          pattern = pattern.Replace("{version:apiVersion}", version.ToString());
        }
      }

      if (pattern?.StartsWith("/") == true)
      {
        pattern = "/" + pattern;
      }

      var property = new LogEventProperty("RoutePattern", new ScalarValue(pattern));
      logEvent.AddOrUpdateProperty(property);
    }
  }
}
