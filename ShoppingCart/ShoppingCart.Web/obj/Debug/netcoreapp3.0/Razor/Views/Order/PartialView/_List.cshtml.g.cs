#pragma checksum "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0a03f6879443f3c82e8f6b34bf66edd8dd88fa3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_PartialView__List), @"mvc.1.0.view", @"/Views/Order/PartialView/_List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0a03f6879443f3c82e8f6b34bf66edd8dd88fa3", @"/Views/Order/PartialView/_List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41630f2d9bd82743754fa8f95a1fe7ea773f3e59", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_PartialView__List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShoppingCart.Data.Entity.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#exampleModalCenter"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card margin border-color-strip\" style=\"width: 18rem;\">\r\n    <div class=\"card-body\">\r\n        <label class=\"card-title font-weight-bold\">Ref No: ");
#nullable restore
#line 5 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_List.cshtml"
                                                      Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        <span class=\"badge badge-warning right\">Status: ");
#nullable restore
#line 6 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_List.cshtml"
                                                   Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        <hr />\r\n        <label class=\"small\">Customer Name:</label>\r\n        <p class=\"card-text font-weight-bold\">");
#nullable restore
#line 9 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_List.cshtml"
                                         Write(Model.Customers.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 9 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_List.cshtml"
                                                                    Write(Model.Customers.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <label class=\"small\">Date:</label>\r\n        <p class=\"card-text font-weight-bold\">");
#nullable restore
#line 11 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_List.cshtml"
                                         Write(Model.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n        <hr />\r\n        <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">\r\n            <a class=\"btn btn-info btn-sm\">More</a>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0a03f6879443f3c82e8f6b34bf66edd8dd88fa36471", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-orderLineId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_List.cshtml"
                                                                                                               WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderLineId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-orderLineId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderLineId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <button type=\"button\" class=\"btn btn-danger btn-sm\">Remove</button>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShoppingCart.Data.Entity.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
