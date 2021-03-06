//  Copyright 2011 U.S. Department of Defense

//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at

//      http://www.apache.org/licenses/LICENSE-2.0

//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.



using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
/// <summary>
/// 
/// </summary>
public partial class Controls_MyModels : Website.Pages.ControlBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //load my models - by User.Id.Name
        if (!Page.IsPostBack)
        {

            vwarDAL.ISearchProxy srch = new vwarDAL.DataAccessFactory().CreateSearchProxy(Context.User.Identity.Name);
            MyModelsDataList.DataSource = srch.GetContentObjectsBySubmitterEmail(Context.User.Identity.Name.Trim());
            MyModelsDataList.DataBind();
            srch.Dispose();
        }
    }
}
