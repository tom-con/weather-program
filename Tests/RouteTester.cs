public class RouteTester
{
    HttpConfiguration config;
    HttpRequestMessage request;
    IHttpRouteData routeData;
    IHttpControllerSelector controllerSelector;
    HttpControllerContext controllerContext;

    public RouteTester(HttpConfiguration conf, HttpRequestMessage req)
    {
        config = conf;
        request = req;
    }

    public string GetActionName()
    {

    }
        public Type GetControllerType()
        {
            
        }

}