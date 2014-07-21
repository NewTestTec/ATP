using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Text;
using System.Linq;
using System.Data.Entity;

namespace AppBox.apps.Project
{
    public partial class Project_View : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "ProjectView";
            }
        }

        #endregion
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            int id = GetQueryIntValue("id");
            AppBox.Script current = DB.Scripts.Where(u => u.ID == id).FirstOrDefault();
                //.Include(u => u.Roles)
                //.Include(u => u.Dept)
                //.Include(u => u.Titles)
                //.Where(u => u.ID == id).FirstOrDefault();
            if (current == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            labName.Text = current.Name;
            labEnabled.Text = current.Enabled ? "启用" : "禁用";
            //labContent.Text = current.Content;
            labProject.Text = current.Project;
            labVersion.Text = current.Version;
            labCreater.Text = current.Creater;
            labLanguage.Text = current.Language;

            labPath.Text = current.Path;
            labModifyDate.Text = current.ModifyTime.ToString();

        }

        #endregion

    }
}
