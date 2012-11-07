﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Signum.Entities;
    
    #line 1 "..\..\Signum\Views\PopupControl.cshtml"
    using Signum.Entities.Reflection;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 2 "..\..\Signum\Views\PopupControl.cshtml"
    using Signum.Web.Properties;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Signum/Views/PopupControl.cshtml")]
    public class PopupControl : System.Web.Mvc.WebViewPage<TypeContext>
    {
        public PopupControl()
        {
        }
        public override void Execute()
        {




            
            #line 4 "..\..\Signum\Views\PopupControl.cshtml"
   var modifiable = (ModifiableEntity)Model.UntypedValue; 

            
            #line default
            #line hidden
WriteLiteral("<div id=\"");


            
            #line 5 "..\..\Signum\Views\PopupControl.cshtml"
    Write(Model.Compose("panelPopup"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"sf-popup-control\" data-prefix=\"");


            
            #line 5 "..\..\Signum\Views\PopupControl.cshtml"
                                                                        Write(Model.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n    <span class=\"sf-popup-title\">\r\n    <span style=\"float:left; display:block" +
"\">\r\n    ");


            
            #line 8 "..\..\Signum\Views\PopupControl.cshtml"
Write(Navigator.Manager.GetTypeTitle(modifiable));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </span>\r\n");


            
            #line 10 "..\..\Signum\Views\PopupControl.cshtml"
        
            var ident = Model.UntypedValue as IdentifiableEntity;

            if (ident != null && !ident.IsNew && Navigator.IsNavigable(ident))
            {

            
            #line default
            #line hidden
WriteLiteral("                <a href=\"");


            
            #line 15 "..\..\Signum\Views\PopupControl.cshtml"
                    Write(Navigator.NavigateRoute(ident));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"sf-popup-fullscreen\">\r\n                <span class=\"ui-icon ui-icon-extl" +
"ink\">fullscreen</span>\r\n                </a>\r\n");


            
            #line 18 "..\..\Signum\Views\PopupControl.cshtml"
            }
        

            
            #line default
            #line hidden
WriteLiteral("    </span>\r\n    <span class=\"sf-entity-title\">");


            
            #line 21 "..\..\Signum\Views\PopupControl.cshtml"
                              Write(ViewBag.Title ?? Model.UntypedValue.TryToString());

            
            #line default
            #line hidden
WriteLiteral(" </span>\r\n    <div class=\"sf-button-bar\">\r\n");


            
            #line 23 "..\..\Signum\Views\PopupControl.cshtml"
           var saveProtected = Navigator.Manager.OnSaveProtected(Model.UntypedValue.GetType()); 

            
            #line default
            #line hidden

            
            #line 24 "..\..\Signum\Views\PopupControl.cshtml"
         if (ViewData.ContainsKey(ViewDataKeys.OkVisible) && (bool)ViewData[ViewDataKeys.OkVisible])
        {  

            
            #line default
            #line hidden
WriteLiteral("            <button id=\"");


            
            #line 26 "..\..\Signum\Views\PopupControl.cshtml"
                   Write(Model.Compose("btnOk"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"sf-entity-button sf-ok-button");


            
            #line 26 "..\..\Signum\Views\PopupControl.cshtml"
                                                                                 Write(saveProtected ? " sf-save-protected" : "");

            
            #line default
            #line hidden
WriteLiteral("\" ");


            
            #line 26 "..\..\Signum\Views\PopupControl.cshtml"
                                                                                                                               Write(ViewData[ViewDataKeys.OnOk] != null ? Html.Raw("onclick=\"" + ViewData[ViewDataKeys.OnOk] + "\"") : null);

            
            #line default
            #line hidden
WriteLiteral(">\r\n                OK</button>                \r\n");


            
            #line 28 "..\..\Signum\Views\PopupControl.cshtml"
        }

            
            #line default
            #line hidden

            
            #line 29 "..\..\Signum\Views\PopupControl.cshtml"
         if (ViewData.ContainsKey(ViewDataKeys.SaveVisible) && (bool)ViewData[ViewDataKeys.SaveVisible] && !saveProtected)
        {  

            
            #line default
            #line hidden
WriteLiteral("            <button id=\"");


            
            #line 31 "..\..\Signum\Views\PopupControl.cshtml"
                   Write(Model.Compose("ebSave"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"sf-entity-button sf-save\" ");


            
            #line 31 "..\..\Signum\Views\PopupControl.cshtml"
                                                                               Write(ViewData[ViewDataKeys.OnSave] != null ? Html.Raw("onclick=\"" + ViewData[ViewDataKeys.OnSave] + "\"") : null);

            
            #line default
            #line hidden
WriteLiteral(">\r\n                ");


            
            #line 32 "..\..\Signum\Views\PopupControl.cshtml"
           Write(Resources.Save);

            
            #line default
            #line hidden
WriteLiteral("</button>                \r\n");


            
            #line 33 "..\..\Signum\Views\PopupControl.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");


            
            #line 34 "..\..\Signum\Views\PopupControl.cshtml"
   Write(ButtonBarEntityHelper.GetForEntity(new EntityButtonContext
        {
            Buttons = (ViewButtons)ViewData[ViewDataKeys.ViewButtons],
            ControllerContext = this.ViewContext,
            PartialViewName = ViewData[ViewDataKeys.PartialViewName].ToString(),
            Prefix = Model.ControlID
        }, modifiable).ToString(Html));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    ");


            
            #line 42 "..\..\Signum\Views\PopupControl.cshtml"
Write(Html.ValidationSummaryAjax(Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div id=\"");


            
            #line 43 "..\..\Signum\Views\PopupControl.cshtml"
        Write(Model.Compose("divMainControl"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"sf-main-control");


            
            #line 43 "..\..\Signum\Views\PopupControl.cshtml"
                                                                 Write(modifiable.SelfModified ? " sf-changed" : "");

            
            #line default
            #line hidden
WriteLiteral("\" \r\n        data-prefix=\"");


            
            #line 44 "..\..\Signum\Views\PopupControl.cshtml"
                Write(Model.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\" \r\n        data-runtimeinfo=\"");


            
            #line 45 "..\..\Signum\Views\PopupControl.cshtml"
                     Write(Model.RuntimeInfo().ToString());

            
            #line default
            #line hidden
WriteLiteral("\">\r\n");


            
            #line 46 "..\..\Signum\Views\PopupControl.cshtml"
           
            ViewData[ViewDataKeys.InPopup] = true;
            Html.RenderPartial(ViewData[ViewDataKeys.PartialViewName].ToString(), Model);
        

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");


        }
    }
}
#pragma warning restore 1591
