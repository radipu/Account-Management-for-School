#pragma checksum "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Salaries\InsertSalary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87588f9b65c183a88569c7b12f370295cb207e5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Institution_Views_Salaries_InsertSalary), @"mvc.1.0.view", @"/Areas/Institution/Views/Salaries/InsertSalary.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87588f9b65c183a88569c7b12f370295cb207e5f", @"/Areas/Institution/Views/Salaries/InsertSalary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9461f7adb4a4bb4441112cd59522b12853608894", @"/Areas/Institution/Views/_ViewImports.cshtml")]
    public class Areas_Institution_Views_Salaries_InsertSalary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OE.Web.Areas.Institution.Models.SalariesVM.IndexSalariesListVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("addClasses"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div id=""mdlAdd"" class="" "">
    <div class=""modal-dialog"">
        <!-- Modal content-->
        <div class=""content"">
            <div class=""header"">
                <h3>Provide Salary</h3>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87588f9b65c183a88569c7b12f370295cb207e5f4346", async() => {
                WriteLiteral(@"
                    <label> StaffId</label>
                    <input type=""number"" name=""Salaries.StaffId"" id=""ClassName"" required class=""form-control"">
                    <hr />
                    <label> date</label>
                    <input type=""text"" name=""Salaries.date"" id=""ClassName"" required class=""form-control datetime"">
                    <hr />
                    <label> Amount</label>
                    <input type=""number"" name=""Salaries.Amount"" id=""ClassName"" required class=""form-control"">
                    <hr />
                    <label> Remark</label>
                    <input type=""text"" name=""Salaries.Remark"" id=""ClassName"" required class=""form-control"">
                    <hr />
                    <button class=""btn btn-success btn-md"" id=""btnSaveNewClasses"">
                        <i class=""fa fa-save"" aria-hidden=""true""></i>
                        Save
                    </button>
                    <button class=""btn btn-danger btn-md "" data-dismiss");
                WriteLiteral("=\"modal\">\r\n                        <i class=\"fa fa-times\" aria-hidden=\"true\"></i>\r\n                        Cancel\r\n                    </button>\r\n                ");
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
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

        $(""#btnSaveNewClasses"").on('click', function (e) {
            e.preventDefault();
            var formData = new FormData($(""#addClasses"")[0]);
             $.ajax({
               type: 'POST',
               data: formData,
               contentType: false,
               processData: false,
                  url: '");
#nullable restore
#line 52 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Salaries\InsertSalary.cshtml"
                   Write(Url.Action("InsertSalary", "Salaries", new { Area = "Institution" }));

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
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OE.Web.Areas.Institution.Models.SalariesVM.IndexSalariesListVM> Html { get; private set; }
    }
}
#pragma warning restore 1591