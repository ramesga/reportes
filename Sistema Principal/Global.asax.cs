using System;
using System.Web.Routing;
using System.Web.Optimization;

namespace Sistema_Principal
{
  public class Global : System.Web.HttpApplication
  {

    protected void Application_Start(object sender, EventArgs e)
    {
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }

    protected void Session_Start(object sender, EventArgs e)
    {

    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {

    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {

    }

    protected void Application_Error(object sender, EventArgs e)
    {
      Exception err = Server.GetLastError();
      Response.Clear();
      Response.Write("<h1>" + err.InnerException.Message.Trim() + "</h1>");
      Response.Write("<pre>" + err.ToString() + "</pre>");
      Server.ClearError();


  }
   


    protected void Session_End(object sender, EventArgs e)
    {

    }

    protected void Application_End(object sender, EventArgs e)
    {

    }
  }
}