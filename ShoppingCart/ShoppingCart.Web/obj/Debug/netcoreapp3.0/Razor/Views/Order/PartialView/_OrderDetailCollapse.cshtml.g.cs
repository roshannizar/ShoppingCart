#pragma checksum "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "235204e3604a1f9be6ce7fdf7531f46b47dfc849"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_PartialView__OrderDetailCollapse), @"mvc.1.0.view", @"/Views/Order/PartialView/_OrderDetailCollapse.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"235204e3604a1f9be6ce7fdf7531f46b47dfc849", @"/Views/Order/PartialView/_OrderDetailCollapse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41630f2d9bd82743754fa8f95a1fe7ea773f3e59", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_PartialView__OrderDetailCollapse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShoppingCart.Data.Models.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div id=""accordion"">
        <div class=""card"">
            <div class=""card-header"" id=""headingOne"">
                <button class=""btn font-weight-bold"" data-toggle=""collapse"" data-target=""#collapseOne"" aria-expanded=""true"" aria-controls=""collapseOne"">Order Detail</button>
            </div>

            <div id=""collapseOne"" class=""collapse show"" aria-labelledby=""headingOne"" data-parent=""#accordion"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col"">
                            <label class=""small font-weight-bold"">Order Id</label>
                            <input type=""text"" class=""form-control form-control-sm""");
            BeginWriteAttribute("value", " value=\"", 749, "\"", 766, 1);
#nullable restore
#line 14 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml"
WriteAttributeValue("", 757, Model.Id, 757, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                        </div>
                        <div class=""col"">
                            <label class=""small font-weight-bold"">Customer Name: </label>
                            <input type=""text"" class=""form-control form-control-sm""");
            BeginWriteAttribute("value", " value=\"", 1030, "\"", 1090, 2);
#nullable restore
#line 18 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml"
WriteAttributeValue("", 1038, Model.Customers.FirstName, 1038, 26, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml"
WriteAttributeValue(" ", 1064, Model.Customers.LastName, 1065, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled />\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <label class=\"small font-weight-bold\">Date: </label>\r\n                            <input type=\"text\" class=\"form-control form-control-sm\"");
            BeginWriteAttribute("value", " value=\"", 1345, "\"", 1364, 1);
#nullable restore
#line 22 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml"
WriteAttributeValue("", 1353, Model.Date, 1353, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled />\r\n                        </div>\r\n                        <div class=\"col\">\r\n                            <label class=\"small font-weight-bold\">Status: </label><br />\r\n");
#nullable restore
#line 26 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml"
                             if (Model.Status == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge badge-warning\">");
#nullable restore
#line 28 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml"
                                                             Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 29 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge badge-success\">");
#nullable restore
#line 32 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml"
                                                             Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 33 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_OrderDetailCollapse.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShoppingCart.Data.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
