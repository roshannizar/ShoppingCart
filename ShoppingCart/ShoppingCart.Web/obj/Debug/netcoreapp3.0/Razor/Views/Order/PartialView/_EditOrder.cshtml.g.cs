#pragma checksum "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4157db021e5f3b3eef4b26da0c44140213664ccc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_PartialView__EditOrder), @"mvc.1.0.view", @"/Views/Order/PartialView/_EditOrder.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4157db021e5f3b3eef4b26da0c44140213664ccc", @"/Views/Order/PartialView/_EditOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41630f2d9bd82743754fa8f95a1fe7ea773f3e59", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_PartialView__EditOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShoppingCart.Web.ViewModels.OrderItemsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <a class=\"list-group-item list-group-item-action align-items-start\">\r\n        <div class=\"d-flex w-100 justify-content-between\">\r\n            <p");
            BeginWriteAttribute("id", " id=\"", 206, "\"", 228, 2);
            WriteAttributeValue("", 211, "orderid", 211, 7, true);
#nullable restore
#line 5 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 218, Model.Id, 219, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>");
#nullable restore
#line 5 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                        Write(Model.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p");
            BeginWriteAttribute("id", " id=\"", 271, "\"", 295, 2);
            WriteAttributeValue("", 276, "productid", 276, 9, true);
#nullable restore
#line 6 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 285, Model.Id, 286, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>");
#nullable restore
#line 6 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                          Write(Model.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p");
            BeginWriteAttribute("id", " id=\"", 340, "\"", 366, 2);
            WriteAttributeValue("", 345, "productName", 345, 11, true);
#nullable restore
#line 7 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 356, Model.Id, 357, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>");
#nullable restore
#line 7 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                            Write(Model.Products.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p");
            BeginWriteAttribute("id", " id=\"", 415, "\"", 441, 2);
            WriteAttributeValue("", 420, "description", 420, 11, true);
#nullable restore
#line 8 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 431, Model.Id, 432, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>");
#nullable restore
#line 8 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                            Write(Model.Products.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p");
            BeginWriteAttribute("id", " id=\"", 497, "\"", 521, 2);
            WriteAttributeValue("", 502, "unitprice", 502, 9, true);
#nullable restore
#line 9 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 511, Model.Id, 512, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>");
#nullable restore
#line 9 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                          Write(Model.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p");
            BeginWriteAttribute("id", " id=\"", 566, "\"", 589, 2);
            WriteAttributeValue("", 571, "quantity", 571, 8, true);
#nullable restore
#line 10 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 579, Model.Id, 580, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>");
#nullable restore
#line 10 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                         Write(Model.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <h5 class=\"mb-1 font-weight-bold\">Product Name: ");
#nullable restore
#line 11 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                                       Write(Model.Products.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        </div>\r\n        <p class=\"mb-1\">Description: ");
#nullable restore
#line 13 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                Write(Model.Products.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <small");
            BeginWriteAttribute("id", " id=\"", 806, "\"", 836, 2);
            WriteAttributeValue("", 811, "updatedQuantity", 811, 15, true);
#nullable restore
#line 14 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 826, Model.Id, 827, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Quantity: ");
#nullable restore
#line 14 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                                   Write(Model.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n        <br />\r\n        <small>Unit Price: ");
#nullable restore
#line 16 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                      Write(Model.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n        <br />\r\n        <span");
            BeginWriteAttribute("id", " id=\"", 971, "\"", 1003, 2);
            WriteAttributeValue("", 976, "updateTotalAmount", 976, 17, true);
#nullable restore
#line 18 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 993, Model.Id, 994, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"badge badge-success\">Total Amount: Rs: ");
#nullable restore
#line 18 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
                                                                                         Write(Model.UnitPrice * Model.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 19 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
          
            if (ViewBag.Status == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <input type=\"button\" class=\"btn btn-danger btm-sm right margin-left\"");
            BeginWriteAttribute("id", " id=\"", 1244, "\"", 1268, 2);
            WriteAttributeValue("", 1249, "DeleteBtn", 1249, 9, true);
#nullable restore
#line 22 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 1258, Model.Id, 1259, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1269, "\"", 1305, 3);
            WriteAttributeValue("", 1279, "DeleteOrderItem(", 1279, 16, true);
#nullable restore
#line 22 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue("", 1295, Model.Id, 1295, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1304, ")", 1304, 1, true);
            EndWriteAttribute();
            WriteLiteral(" value=\"Delete\">\r\n                <input type=\"button\" class=\"btn btn-warning btm-sm right\"");
            BeginWriteAttribute("id", " id=\"", 1397, "\"", 1419, 2);
            WriteAttributeValue("", 1402, "EditBtn", 1402, 7, true);
#nullable restore
#line 23 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue(" ", 1409, Model.Id, 1410, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-target=\"#createOrderModal\" data-toggle=\"modal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1472, "\"", 1503, 3);
            WriteAttributeValue("", 1482, "EditOrders(", 1482, 11, true);
#nullable restore
#line 23 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
WriteAttributeValue("", 1493, Model.Id, 1493, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1502, ")", 1502, 1, true);
            EndWriteAttribute();
            WriteLiteral(" value=\"Edit\">\r\n");
#nullable restore
#line 24 "C:\Users\Roshan\Documents\GitHub\ShoppingCart\ShoppingCart\ShoppingCart.Web\Views\Order\PartialView\_EditOrder.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </a>

<div class=""modal fade"" id=""createOrderModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalCenterTitle"">Editing Order</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""container-fluid"">
                <br />
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4157db021e5f3b3eef4b26da0c44140213664ccc14909", async() => {
                WriteLiteral("\r\n                    <div class=\"form-group\">\r\n                        <label class=\"small font-weight-bold\" for=\"Name\">Product Name: </label>\r\n                        <input type=\"text\" class=\"form-control\" name=\"Name\" id=\"Name\" disabled");
                BeginWriteAttribute("value", " value=\"", 2475, "\"", 2483, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""eg: Orange"">
                        <input type=""text"" id=""orderId"" hidden/>
                        <input type=""text"" id=""id"" hidden/>
                        <input type=""text"" id=""productid"" hidden />
                    </div>
                    <div class=""form-group"">
                        <label class=""small font-weight-bold"" for=""description"">Description:</label>
                        <textarea class=""form-control"" placeholder=""Give a description about the product"" disabled name=""Description"" id=""description"" rows=""3""></textarea>
                    </div>
                    <div class=""form-row"">
                        <div class=""form-group col-md-4"">
                            <label class=""small font-weight-bold"" for=""UnitPrice"">Unit Price:</label>
                            <input type=""number"" class=""form-control"" placeholder=""eg: 12.00"" disabled name=""UnitPrice"" id=""UnitPrice"">
                        </div>
                        <div class=""form-group c");
                WriteLiteral(@"ol-md-4"">
                            <label class=""small font-weight-bold"" for=""Quantity"">Quantity:</label>
                            <input type=""number"" class=""form-control"" placeholder=""eg: 10"" name=""Quantity"" id=""Quantity"">
                        </div>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                        <button type=""submit"" class=""btn btn-primary"" onclick=""ConfirmOrderChanges()"" data-dismiss=""modal"">Save changes</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShoppingCart.Web.ViewModels.OrderItemsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
