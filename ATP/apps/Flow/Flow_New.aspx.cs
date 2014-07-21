using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUI;
using System.Net;


namespace AppBox.apps.Flow
{
    public partial class Flow_New : PageBase
    {
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

            // 初始化用户所属部门
            string userName = GetIdentityName();
            User user = DB.Users.Where(u => u.Name == userName).FirstOrDefault();
            InitUserDept(user);

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string FlowName = tbxName.Text.Trim();

            AppBox.Flow Flow = DB.Flows.Where(u => u.Name == FlowName).FirstOrDefault();

            if (Flow != null)
            {
                Alert.Show("流程 " + FlowName + " 已经存在！");
                return;
            }

            SaveItem();

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void SaveItem()
        {
            AppBox.Flow item = new AppBox.Flow();
            item.Name = tbxName.Text.Trim();
            item.Project = tbSelectedDept.Text.Trim();
            item.Version = txtVersion.Text.Trim();
            item.Enabled = cbxEnabled.Checked;
            item.ModifyTime = DateTime.Now;

            DB.Flows.Add(item);
            DB.SaveChanges();

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        private void InitUserDept(User current)
        {
            if (current.Dept != null)
            {
                tbSelectedDept.Text = current.Dept.Name;
                hfSelectedDept.Text = current.Dept.ID.ToString();
            }
        }
    }
}