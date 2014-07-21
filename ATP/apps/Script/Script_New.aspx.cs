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
namespace AppBox.apps.Script
{
    public partial class Script_New : PageBase
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
                //txtVersion.Text = GetIdentityName();
                tbxCreater.Text = GetIdentityName();
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
            AppBox.Script item = new AppBox.Script();
            item.Name = tbxName.Text.Trim();
            item.Project = ddProject.SelectedText.Trim();
            //item.Version = ddVersion.SelectedValue.Trim();
            item.Version = txtVersion.Text.Trim();
            item.Path = "\\" + item.Project + "\\" + item.Version;
            //item.Content = tbxContent.Text.Trim();
            item.Language = ddlLanguage.SelectedValue.Trim();
            item.FileName = FileName;
            item.Creater = tbxCreater.Text.Trim();
            item.Enabled = cbxEnabled.Checked;
            item.ModifyTime = DateTime.Now;
            item.Size = "1";
            UpLoadFile(Upload.FileName);
            
            DB.Scripts.Add(item);
            DB.SaveChanges();

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        private void InitUserDept(User current)
        {
            if (current.Dept != null)
            {
                AppBox.Project project = new AppBox.Project();
                
                string deptName = current.Dept.Name;
                
                IQueryable<AppBox.Project> q = DB.Projects; //.Include(u => u.Dept);

                // 在用户名称中搜索

                q = q.Where(u => u.DeptRegion.Equals(deptName));//.Where(u => u.Status == "启用");

                string[] ProjectList = q.Select(x => x.ProjectName).ToArray();

                int count = q.Count();
                for (int i = 0; i < count; i++)
                {
                    ddProject.DataSource = ProjectList;
                    ddProject.DataBind();
                }
               

            }    
        }
       
        public void UpLoadFile(string fileNamePath)
        {
                        
            /// 创建WebClient实例 
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            // 要上传的文件 
            FileStream fs = new FileStream("C:\\1.zip", FileMode.Open, FileAccess.Read);
            //FileStream fs = OpenFile(); 
            BinaryReader r = new BinaryReader(fs);
            byte[] postArray = r.ReadBytes((int)fs.Length);
            //Stream postStream = myWebClient.OpenWrite(FileName, "PUT");
            //Stream postStream = myWebClient.OpenWrite("~/Upload/" + FileName, "PUT");
            //C:\文档资料\自动化测试平台\ATP20140629\ATP\Upload
            Stream postStream = myWebClient.OpenWrite("C:\\" + FileName, "PUT");
            try
            {
             
                if (postStream.CanWrite)
                {
                    postStream.Write(postArray, 0, postArray.Length);
                    postStream.Close();
                    fs.Dispose();
                    
                }
                else
                {
                    postStream.Close();
                    fs.Dispose();
                }

            }
            catch (Exception err)
            {
                postStream.Close();
                fs.Dispose();
         
                throw err;
            }
            finally
            {
                postStream.Close();
                fs.Dispose();
            }
        } 

    }
}