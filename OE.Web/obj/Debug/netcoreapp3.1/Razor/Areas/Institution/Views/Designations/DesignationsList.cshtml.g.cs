#pragma checksum "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cca281552682979c4c08adbc45e2eba8c1ed8de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Institution_Views_Designations_DesignationsList), @"mvc.1.0.view", @"/Areas/Institution/Views/Designations/DesignationsList.cshtml")]
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
#line 1 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\_ViewImports.cshtml"
using OE.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
using OE.Web.Areas.Institution.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cca281552682979c4c08adbc45e2eba8c1ed8de", @"/Areas/Institution/Views/Designations/DesignationsList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9461f7adb4a4bb4441112cd59522b12853608894", @"/Areas/Institution/Views/_ViewImports.cshtml")]
    public class Areas_Institution_Views_Designations_DesignationsList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OE.Web.Areas.Institution.Models.DesignationsVM.IndexDesignationsListVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("addDesignation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Designations", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DesignationsList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-pg", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("editDesignation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("deleteDesignationList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
  
    //ViewData["Title"] = "Index";
    Pager pager = new Pager();
    int pageNo = 0;
    if (ViewBag.Pager != null)
    {
        pager = ViewBag.Pager;
        pageNo = pager.CurrentPage;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"page-title\">Designation List</h1>\r\n\r\n<br />\r\n");
            WriteLiteral(@"

<div id=""myModal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4>Add </h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cca281552682979c4c08adbc45e2eba8c1ed8de7667", async() => {
                WriteLiteral(@"
                    <label> Designation Name</label>
                    <input type=""text"" name=""Designations.Name"" id=""DesignationsName"" required class=""form-control""><br />
                    <hr />
                    <button class=""btn btn-success btn-md"" id=""btnSaveNewDesignation"">
                        <i class=""fa fa-save"" aria-hidden=""true""></i>
                        Save
                    </button>
                    <button class=""btn btn-danger btn-md "" data-dismiss=""modal"">
                        <i class=""fa fa-times"" aria-hidden=""true""></i>
                        Cancel
                    </button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>
<br />
<br />
<table class=""table table-bordered table-hover"">
    <thead>
        <tr>
            <th>SN</th>
            <th>  Designation Name </th>
            <th>  Action </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 63 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
         foreach (var data in Model._Designations)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td style=\"max-width:10px;\">");
#nullable restore
#line 66 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                                        Write(Model._Designations.IndexOf(data) + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"showDetails pointer\">\r\n                    ");
#nullable restore
#line 68 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
               Write(data.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"max-width:30px;\">\r\n                    <button class=\"btn btn-primary btn-sm\" id=\"btnEdit\" name=\"btnEdit\" data-toggle=\"modal\" data-target=\"#modalEdit\"\r\n                            data-id=\"");
#nullable restore
#line 72 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                                Write(data.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                            data-name=\"");
#nullable restore
#line 73 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                                  Write(data.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                        <i class=""fa fa-edit"" aria-hidden=""true""></i>
                        Edit
                    </button>
                    <button class=""btn btn-danger btn-sm "" id=""btnDelete"" data-toggle=""modal"" data-target=""#modalDelete"" data-id=""");
#nullable restore
#line 77 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                                                                                                                             Write(data.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        <i class=\"fa fa-trash\" aria-hidden=\"true\"></i>\r\n                        Delete\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 83 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<div class=\"container\">\r\n");
#nullable restore
#line 88 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
     if (pager.TotalPages > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul class=\"pagination justify-content-center\">\r\n");
#nullable restore
#line 91 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
             if (pager.CurrentPage > 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cca281552682979c4c08adbc45e2eba8c1ed8de13609", async() => {
                WriteLiteral("First");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pg", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pg"] = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n                <li>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cca281552682979c4c08adbc45e2eba8c1ed8de15632", async() => {
                WriteLiteral("Previous");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pg", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 97 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                                                                                                        WriteLiteral(pager.CurrentPage - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pg"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pg", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pg"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 99 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
             for (var pge = pager.StartPage; pge <= pager.EndPage; pge++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li");
            BeginWriteAttribute("class", " class=\"", 3727, "\"", 3785, 2);
            WriteAttributeValue("", 3735, "page-item", 3735, 9, true);
#nullable restore
#line 102 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
WriteAttributeValue(" ", 3744, pge==pager.CurrentPage? "active" : "", 3745, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cca281552682979c4c08adbc45e2eba8c1ed8de19229", async() => {
#nullable restore
#line 103 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                                                                                                                    Write(pge);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pg", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 103 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                                                                                                       WriteLiteral(pge);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pg"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pg", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pg"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 105 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
             if (pager.CurrentPage < pager.TotalPages)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cca281552682979c4c08adbc45e2eba8c1ed8de22593", async() => {
                WriteLiteral("Next");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pg", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 109 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                                                                                                        WriteLiteral(pager.CurrentPage+1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pg"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pg", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pg"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n                <li>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cca281552682979c4c08adbc45e2eba8c1ed8de25198", async() => {
                WriteLiteral("Last");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pg", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 112 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                                                                                                        WriteLiteral(pager.TotalPages);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pg"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pg", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pg"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 114 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n");
#nullable restore
#line 116 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>

<div id=""modalEdit"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Edit </h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cca281552682979c4c08adbc45e2eba8c1ed8de28639", async() => {
                WriteLiteral(@"
                    <input type=""hidden"" name=""Designations.Id"" id=""editDesignationId"">
                    <hr />
                    <label>Designation tName</label>
                    <input type=""text"" name=""Designations.Name"" id=""txtEditDesignationName"" required class=""form-control"">
                    <hr />
                    <button class=""btn btn-success btn-md"" formmethod=""post"" id=""btnEditDesignation"">
                        <i class=""fa fa-save"" aria-hidden=""true""></i>
                        Save
                    </button>
                    <button class=""btn btn-danger btn-md "" data-dismiss=""modal"">
                        <i class=""fa fa-times"" aria-hidden=""true""></i>
                        Cancel
                    </button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>

<div id=""modalDelete"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">

        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Delete Designation</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cca281552682979c4c08adbc45e2eba8c1ed8de31292", async() => {
                WriteLiteral(@"
                <div class=""modal-body"">
                    <p><h4>Are you sure you want to delete this?</h4></p>
                </div>
                <div class=""modal-footer"">
                    <input type=""hidden"" name=""DesignationId"" id=""delDesignationid"">
                    <button class=""btn btn-md btn-success"" id=""btnDeleteDesignation"">
                        <i class=""fa fa-check"" aria-hidden=""true""></i>
                        Yes
                    </button>
                    <button class=""btn btn-danger btn-md "" data-dismiss=""modal"">
                        <i class=""fa fa-times"" aria-hidden=""true""></i>
                        No
                    </button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

        $('tr td #btnEdit').on('click', function () {
            $(""#editDesignationId"").val($(this).data(""id""));
            $(""#txtEditDesignationName"").val($(this).data(""name""));
        });
        $(""#btnSaveNewDesignation"").on('click', function (e)
        {
            e.preventDefault();
            var formData = new FormData($(""#addDesignation"")[0]);
            $.ajax({
               type: 'POST',
               data: formData,
               contentType: false,
               processData: false,
               url: '");
#nullable restore
#line 193 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                Write(Url.Action("InsertDesignation", "Designations", new { Area = "Institution" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                 success: function (response) {
                     location.reload();
                 },
                 error: function (response) {
                     alert('error: ' + response.message);
                 },
                 complete: function () {
                 }
                });
        });
        $(""#btnEditDesignation"").on('click', function (e)
        {
            e.preventDefault();
            var formData = new FormData($(""#editDesignation"")[0]);
            $.ajax({
               type: 'POST',
               data: formData,
               contentType: false,
               processData: false,
               url: '");
#nullable restore
#line 213 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                Write(Url.Action("UpdateDesignation", "Designations"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                 success: function (response) {
                     location.reload();
                 },
                 error: function (response) {
                     alert('error: ' + response.message);
                 },
                 complete: function () { }

                });
        });
        $(' tr td #btnDelete').on('click', function () {
            $(""#delDesignationid"").val($(this).data(""id""));
        });
        $(""#btnDeleteDesignation"").on('click', function (e)
        {
            e.preventDefault();
            var formData = new FormData($(""#deleteDesignationList"")[0]);
            $.ajax({
               type: 'POST',
               data: formData,
               contentType: false,
               processData: false,

               url: '");
#nullable restore
#line 237 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Designations\DesignationsList.cshtml"
                Write(Url.Action("DeleteDesignation", "Designations"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                 success: function (response) {
                     location.reload();
                 },
                 error: function (response) {
                     alert('error: ' + response.message);
                 },
                 complete: function () { }

                });
        });

        $(' tr td #btnDetails').on('click', function () {
            $(""#detailStudentid"").val($(this).data(""id""));
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OE.Web.Areas.Institution.Models.DesignationsVM.IndexDesignationsListVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
