using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUI;
using System.Net;
using System.IO;
namespace AppBox.apps.Project
{
    public partial class Project_New : PageBase
    {
        public string FileName = Guid.NewGuid().ToString() + ".zip";
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "AppScriptNew";
            }
        }

        #endregion
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

            //ddVersion.Items.Add("1.0","1.0");
            //ddVersion.Items.Add("1.1", "1.1");
            //ddVersion.Items.Add("1.2", "1.2");
            // 初始化用户所属部门
            string userName = GetIdentityName();
            User user = DB.Users.Where(u => u.Name == userName).FirstOrDefault();
            InitUserDept(user);
           
            
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string ScriptName = tbxName.Text.Trim();

            AppBox.Script script = DB.Scripts.Where(u => u.Name == ScriptName).FirstOrDefault();

            if (script != null)
            {
                Alert.Show("脚本 " + ScriptName + " 已经存在！");
                return;
            }

            SaveItem();

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void SaveItem()
        {
            AppBox.Project item = new AppBox.Project();

            item.ProjectName = tbxName.Text.Trim();
            item.DomainName = txtDomain.Text.Trim();
            item.Owner = txtOwner.Text.Trim();
            item.DeptRegion = tbSelectedDept.Text.Trim();
            item.StartTime = Convert.ToDateTime(txtStartTime.Text);
            item.EndTime = Convert.ToDateTime(txtEndTime.Text);
            item.Enabled = cbxEnabled.Checked;
            item.CreateTime = DateTime.Now;
            DB.Projects.Add(item);
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
       
        public void UpLoadFile(string fileNamePath)
        {
                        
        } 

    }
}