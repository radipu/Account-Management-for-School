#pragma checksum "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0df098a8beff0701ae3356fc07e6cb8172f9d1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Institution_Views_Users_Admin__GetActorsList), @"mvc.1.0.view", @"/Areas/Institution/Views/Users/Admin/_GetActorsList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0df098a8beff0701ae3356fc07e6cb8172f9d1e", @"/Areas/Institution/Views/Users/Admin/_GetActorsList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9461f7adb4a4bb4441112cd59522b12853608894", @"/Areas/Institution/Views/_ViewImports.cshtml")]
    public class Areas_Institution_Views_Users_Admin__GetActorsList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OE.Web.Areas.Institution.Models.UsersVM.IndexEditActorsVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_ddlActors"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "userAuthentication.ActorId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-for-id", new global::Microsoft.AspNetCore.Html.HtmlString("Id"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
 if (!String.IsNullOrEmpty(Model.Message))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"well\"><b>");
#nullable restore
#line 4 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                    Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></div>\r\n");
#nullable restore
#line 5 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
}

else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-bordered table-hover oePage_backend"">
        <thead>
            <tr>
                <th class=""oeTableTitle"">SN</th>
                <th class=""oeTableTitle"">Actor Name</th>
                <th class=""oeTableTitle"">IsActive</th>
                <th class=""oeTableTitle""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 19 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
             foreach (var item in Model._userAuthentication)
            {
                string Icon_Ok = "<i class=" + "\"fa fa-check \"" + "style =" + " \"font-size:20px;color:green\"" + "></i>";
               

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"showDetails pointer\">");
#nullable restore
#line 24 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                Write(Model._userAuthentication.IndexOf(item) + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"showDetails pointer\" id=\"_Actor\">\r\n");
#nullable restore
#line 26 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                         if (item.ActorId == 11)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <a tabindex=""0"" data-toggle=""popover"" data-trigger=""focus"" data-container=""body"" title=""Admin Actor"" data-content=""Admin actor can not possible to edit or delete because without admin you can run this system. "">
                                <span class=""glyphicon glyphicon-info-sign"" style=""top:5px; font-size:larger""></span>
                            </a>
");
#nullable restore
#line 31 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>");
#nullable restore
#line 32 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                      Write(item.ActorsName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0df098a8beff0701ae3356fc07e6cb8172f9d1e8217", async() => {
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0df098a8beff0701ae3356fc07e6cb8172f9d1e8505", async() => {
                    WriteLiteral("Select Actors");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 34 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList (ViewBag.ddlActors, "Id","Name", item.ActorId));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </td>\r\n                    <td class=\"showDetails pointer\" id=\"_IsActive\">\r\n                        <p>");
#nullable restore
#line 40 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                      Write(Html.Raw(item.IsActive != true ? "" : Icon_Ok));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                        <input type=""checkbox"" name=""userAuthentication.IsActive"" id=""txtEditIsActive"" required style=""width:40px; height:40px; cursor:pointer; display:none"">
                        <br />
                    </td>
                    <td id=""_btns"">
                        <button class=""btn btn-primary btn-sm"" id=""_btnEdit"" ");
#nullable restore
#line 46 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                                         Write(item.ActorId == 11 ? "disabled" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(" data-id=\"");
#nullable restore
#line 46 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                                                                                         Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-userId=\"");
#nullable restore
#line 46 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                                                                                                                Write(item.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-isactive=\"");
#nullable restore
#line 46 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                                                                                                                                             Write(item.IsActive);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <i class=\"fas fa-edit\" aria-hidden=\"true\"></i>\r\n                            Edit\r\n                        </button>\r\n                        <button class=\"btn btn-danger btn-sm\" ");
#nullable restore
#line 50 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                          Write(item.ActorId == 11 ? "disabled" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(" id=\"_btnDelete\" data-id=\"");
#nullable restore
#line 50 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                                                                                          Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-userId=\"");
#nullable restore
#line 50 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                                                                                                                 Write(item.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                            <i class=""fas fa-trash-alt"" aria-hidden=""true""></i>
                            Delete
                        </button>
                        <button class=""btn btn-primary btn-sm"" id=""_btnSave"" style=""display:none"" data-id=""");
#nullable restore
#line 54 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                                                                      Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-userId=\"");
#nullable restore
#line 54 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                                                                                                                             Write(item.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                            <i class=""fas fa-save"" aria-hidden=""true""></i>
                            Save
                        </button>
                        <button class=""btn btn-danger btn-sm"" id=""_btnCancel"" style=""display:none"">
                            <i class=""fas fa-times"" aria-hidden=""true""></i>
                            Cancel
                        </button>
                    </td>
                </tr>
");
#nullable restore
#line 64 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 67 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">   
    //[NOTE: Tip]
    $('[data-toggle=""popover""]').popover({
        trigger: 'focus'
    })      
        var IsEditFieldOpen = false;
        $('tr td #_btnEdit').on(""click"", function () {
            //[NOTE: Check editable field already open or not]
            if (IsEditFieldOpen == false) {
            //[NOTE: Hide normal view fields]
            var currentRow = $(this).closest('tr');
            $(currentRow).children(""#_Actor"").children(""p"").hide();
            $(currentRow).children(""#_IsActive"").children(""p"").hide();
            $(currentRow).children(""#_btns"").children(""#_btnEdit"").hide();
            $(currentRow).children(""#_btns"").children(""#_btnDelete"").hide();
            //[NOTE: Show editabe fields]
            $(currentRow).children(""#_Actor"").children(""#_ddlActors"").show();
                $(currentRow).children(""#_IsActive"").children(""#txtEditIsActive"").show();
            $(currentRow).children(""#_btns"").children(""#_btnSave"").show(");
            WriteLiteral(@");
            $(currentRow).children(""#_btns"").children(""#_btnCancel"").show();
                IsEditFieldOpen = true;

                var Activation = $(this).data(""isactive"");
                if (Activation == ""True"") {
                    $(currentRow).children(""#_IsActive"").children(""#txtEditIsActive"").prop('checked', true);
                } else {
                    $(currentRow).children(""#_IsActive"").children(""#txtEditIsActive"").prop('checked', false);
                }

            }
        });

        $('tr td #_btnCancel').on(""click"", function () {
            if (IsEditFieldOpen = true) {
            var currentRow = $(this).closest('tr');

                $(currentRow).children(""#_Actor"").children(""#_ddlActors"").hide();
                $(currentRow).children(""#_IsActive"").children(""#txtEditIsActive"").hide();
            $(currentRow).children(""#_btns"").children(""#_btnSave"").hide();
            $(currentRow).children(""#_btns"").children(""#_btnCancel"").hide();

          ");
            WriteLiteral(@"      $(currentRow).children(""#_Actor"").children(""p"").show();
                $(currentRow).children(""#_IsActive"").children(""p"").show();
            $(currentRow).children(""#_btns"").children(""#_btnEdit"").show();
            $(currentRow).children(""#_btns"").children(""#_btnDelete"").show();
            IsEditFieldOpen = false;
            }
        });

        $(""tr td #_btnSave"").on('click', function (e) {
               e.preventDefault();
               var currentRow = $(this).closest('tr');
               var _id = $(this).data('id');
               var _userId = $(this).data('userid');

               var _actorId = $(currentRow).children(""#_Actor"").children(""#_ddlActors"").val();
            var _isActive = $(currentRow).children(""#_IsActive"").children(""#txtEditIsActive"").val();

            if ($(currentRow).children(""#_IsActive"").children(""#txtEditIsActive"").is("":checked"")) {
                _isActive = true;
            }
            else {
                _isActive = false;
     ");
            WriteLiteral("       }\r\n\r\n            $.ajax({\r\n                    type: \'POST\',\r\n                    data: { id: _id, userId: _userId, actorId: _actorId, isActive: _isActive },\r\n                dataType: \'json\',\r\n                cache: false,\r\n                url: \'");
#nullable restore
#line 139 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                 Write(Url.Action("UpdateActors", "Users", new { Area = "Institution" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                success: function (data) {\r\n                    if (data.result == null || data.result == \"\") {\r\n                        var url = \'");
#nullable restore
#line 142 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                              Write(Url.Action("ActorsForEdit", "Users"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
                        $('#mdlModify #ActorsList').load(url, { UserId: _userId });
                    } else {
                         $('#msg').text(data.result);
                         $('#MessageBox').modal();
                    }
                    },
                error: function (data) {
                },
                complete: function (data) {
                }
                });
            });

        $(""tr td #_btnDelete"").on('click', function (e) {
            e.preventDefault();
            if (confirm('Are your sure to delete?')) {
                var _id = $(this).data('id');
                var _userId = $(this).data('userid');

                $.ajax({
                type: 'POST',
                data: {  id: _id},
                dataType: 'json',
                cache: false,
                url: '");
#nullable restore
#line 167 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                 Write(Url.Action("DeleteActors", "Users", new { Area = "Institution" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                success: function (data) {\r\n                    if (data.result == null || data.result == \"\") {\r\n                        var url = \'");
#nullable restore
#line 170 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Areas\Institution\Views\Users\Admin\_GetActorsList.cshtml"
                              Write(Url.Action("ActorsForEdit", "Users"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
                        $('#mdlModify #ActorsList').load(url, { UserId: _userId });
                    } else {
                         $('#msg').text(data.result);
                         $('#MessageBox').modal();
                    }
                    },
                error: function (data) {
                },
                complete: function (data) {
                }
                });
            }
            else {}
        });

</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OE.Web.Areas.Institution.Models.UsersVM.IndexEditActorsVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
