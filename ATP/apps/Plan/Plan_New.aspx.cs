using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUI;
using System.Net;

namespace AppBox.apps.Plan
{
    public partial class Plan_New : PageBase
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
            string PlanName = tbxName.Text.Trim();

            AppBox.Plan Plan = DB.Plans.Where(u => u.Name == PlanName).FirstOrDefault();

            if (Plan != null)
            {
                Alert.Show("计划 " + PlanName + " 已经存在！");
                return;
            }

            SaveItem();

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void SaveItem()
        {
            AppBox.Plan item = new AppBox.Plan();
            item.Name = tbxName.Text.Trim();
            item.Project = tbSelectedDept.Text.Trim();
            item.Version = txtVersion.Text.Trim();
            item.Enabled = cbxEnabled.Checked;
            item.ModifyTime = DateTime.Now;

            DB.Plans.Add(item);
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