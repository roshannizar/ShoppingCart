#pragma checksum "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40c0ec7514d3e32ba97395a262b06e5a8077d48f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\_ViewImports.cshtml"
using ShoppingCart.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\_ViewImports.cshtml"
using ShoppingCart.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40c0ec7514d3e32ba97395a262b06e5a8077d48f", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41630f2d9bd82743754fa8f95a1fe7ea773f3e59", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShoppingCart.Data.Entity.Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Kraggle | Order";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <h5>Order</h5>\r\n    <a href=\"/Order/OrderItems\" class=\"btn btn-outline-info btn-sm\">New Order</a>\r\n\r\n");
            WriteLiteral("        <div class=\"row\">\r\n");
#nullable restore
#line 12 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\Index.cshtml"
             if(Model != null)
            {
                foreach(var orders in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
#nullable restore
#line 16 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\Index.cshtml"
                  Write(orders.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 17 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\Index.cshtml"
                }
            }else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>No Orders Bro!</p>\r\n");
#nullable restore
#line 21 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
            WriteLiteral("</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShoppingCart.Data.Entity.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
