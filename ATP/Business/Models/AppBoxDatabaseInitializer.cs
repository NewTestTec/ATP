using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AppBox
{
    //public class AppBoxDatabaseInitializer : DropCreateDatabaseAlways<AppBoxContext>  // DropCreateDatabaseAlways<AppBoxContext>  DropCreateDatabaseIfModelChanges<AppBoxContext>
    public class AppBoxDatabaseInitializer : DropCreateDatabaseIfModelChanges<AppBoxContext>  // DropCreateDatabaseAlways<AppBoxContext>  DropCreateDatabaseIfModelChanges<AppBoxContext>
    {
        protected override void Seed(AppBoxContext context)
        {
            GetConfigs().ForEach(c => context.Configs.Add(c));
            GetDepts().ForEach(d => context.Depts.Add(d));
            GetUsers().ForEach(u => context.Users.Add(u));

            GetRoles().ForEach(r => context.Roles.Add(r));
            GetPowers().ForEach(p => context.Powers.Add(p));
            GetTitles().ForEach(t => context.Titles.Add(t));

            context.SaveChanges();
            // 添加菜单时需要指定ViewPower，所以上面需要先保存到数据库
            GetMenus(context).ForEach(m => context.Menus.Add(m));
        }

        private static List<Menu> GetMenus(AppBoxContext context)
        {
            var menus = new List<Menu> { 
                 
                new Menu
                {
                    Name = "系统管理",
                    SortIndex = 1000,
                    Remark = "顶级菜单",
                    Children = new List<Menu> { 
                        new Menu
                        {
                            Name = "用户管理",
                            SortIndex = 1001,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/user.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreUserView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "职称管理",
                            SortIndex = 1002,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/title.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreTitleView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "职称用户管理",
                            SortIndex = 1003,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/title_user.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreTitleUserView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "部门管理",
                            SortIndex = 1004,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/dept.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreDeptView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "部门用户管理",
                            SortIndex = 1005,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/dept_user.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreDeptUserView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "角色管理",
                            SortIndex = 1006,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/role.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreRoleView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "角色用户管理",
                            SortIndex = 1007,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/role_user.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreRoleUserView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "权限管理",
                            SortIndex = 1008,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/power.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CorePowerView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "角色权限管理",
                            SortIndex = 1009,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/role_power.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreRolePowerView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "菜单管理",
                            SortIndex = 1101,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/menu.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreMenuView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "在线统计",
                            SortIndex = 1102,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/online.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreOnlineView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "系统配置",
                            SortIndex = 1103,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/config.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "CoreConfigView").FirstOrDefault<Power>()
                        },
                        new Menu
                        {
                            Name = "用户设置",
                            SortIndex = 1104,
                            Remark = "二级菜单",
                            NavigateUrl = "~/admin/profile.aspx",
                            ImageUrl = "~/icon/tag_blue.png"
                        }                       
                    }
                     
                },
               
                new Menu
                {
                    Name = "自动化测试管理",
                    SortIndex = 100,
                    Remark = "顶级菜单",
                    Children = new List<Menu> { 
                        new Menu
                        {
                            Name = "测试脚本管理",
                            SortIndex = 101,
                            Remark = "二级菜单",
                            NavigateUrl = "~/apps/Script/Script.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "AppScriptView").FirstOrDefault<Power>()
                        },
                         new Menu
                        {
                            Name = "测试流程管理",
                            SortIndex = 102,
                            Remark = "二级菜单",
                            NavigateUrl = "~/apps/Flow/Flow.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "AppFlowView").FirstOrDefault<Power>()
                        },
                         new Menu
                        {
                            Name = "测试执行管理",
                            SortIndex = 103,
                            Remark = "二级菜单",
                            NavigateUrl = "~/apps/Plan/Plan.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "AppPlanView").FirstOrDefault<Power>()
                        }
                    }
                },

                new Menu
                {
                    Name = "测试项目管理",
                    SortIndex = 80,
                    Remark = "顶级菜单",
                    Children = new List<Menu> { 
                        new Menu
                        {
                            Name = "测试项目管理",
                            SortIndex = 81,
                            Remark = "二级菜单",
                            NavigateUrl = "~/apps/Project/Project.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "ProjectView").FirstOrDefault<Power>()
                        }
                    }
                },

                new Menu
                {
                    Name = "测试资源池管理",
                    SortIndex = 90,
                    Remark = "顶级菜单",
                    Children = new List<Menu> { 
                        new Menu
                        {
                            Name = "测试资源池管理",
                            SortIndex = 91,
                            Remark = "二级菜单",
                            NavigateUrl = "~/apps/HostPool/HostPool.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "HostPoolView").FirstOrDefault<Power>()
                        }
                    }
                },
                new Menu
                {
                    Name = "测试报告管理",
                    SortIndex = 110,
                    Remark = "顶级菜单",
                    Children = new List<Menu> { 
                        new Menu
                        {
                            Name = "测试执行报告",
                            SortIndex = 111,
                            Remark = "二级菜单",
                            NavigateUrl = "~/apps/Script/Script.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "AppScriptView").FirstOrDefault<Power>()
                        },
                         new Menu
                        {
                            Name = "测试项目缺陷报告",
                            SortIndex = 112,
                            Remark = "二级菜单",
                            NavigateUrl = "~/apps/Flow/Flow.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "AppFlowView").FirstOrDefault<Power>()
                        },
                         new Menu
                        {
                            Name = "测试项目执行报告",
                            SortIndex = 113,
                            Remark = "二级菜单",
                            NavigateUrl = "~/apps/Plan/Plan.aspx",
                            ImageUrl = "~/icon/tag_blue.png",
                            ViewPower = context.Powers.Where(p => p.Name == "AppPlanView").FirstOrDefault<Power>()
                        }
                    }
                }
            };
           
            return menus;
        }


        private static List<Title> GetTitles()
        {
            var titles = new List<Title>()
            {
                new Title() 
                {
                    Name = "项目经理"
                },
                new Title() 
                {
                    Name = "高级软件工程师"
                },
                new Title() 
                {
                    Name = "中级软件工程师"
                },
                new Title() 
                {
                    Name = "初级软件工程师"
                },
                new Title() 
                {
                    Name = "高级测试工程师"
                },
                new Title() 
                {
                    Name = "中级测试工程师"
                },
                new Title() 
                {
                    Name = "初级测试工程师"
                }
            };

            return titles;
        }

        private static List<Power> GetPowers()
        {
            var powers = new List<Power>
            {
                new Power
                {
                    Name = "CoreUserView",
                    Title = "浏览用户列表",
                    GroupName = "CoreUser"
                },
                new Power
                {
                    Name = "CoreUserNew",
                    Title = "新增用户",
                    GroupName = "CoreUser"
                },
                new Power
                {
                    Name = "CoreUserEdit",
                    Title = "编辑用户",
                    GroupName = "CoreUser"
                },
                new Power
                {
                    Name = "CoreUserDelete",
                    Title = "删除用户",
                    GroupName = "CoreUser"
                },
                new Power
                {
                    Name = "CoreUserChangePassword",
                    Title = "修改用户登陆密码",
                    GroupName = "CoreUser"
                },
                new Power
                {
                    Name = "CoreRoleView",
                    Title = "浏览角色列表",
                    GroupName = "CoreRole"
                },
                new Power
                {
                    Name = "CoreRoleNew",
                    Title = "新增角色",
                    GroupName = "CoreRole"
                },
                new Power
                {
                    Name = "CoreRoleEdit",
                    Title = "编辑角色",
                    GroupName = "CoreRole"
                },
                new Power
                {
                    Name = "CoreRoleDelete",
                    Title = "删除角色",
                    GroupName = "CoreRole"
                },
                new Power
                {
                    Name = "CoreRoleUserView",
                    Title = "浏览角色用户列表",
                    GroupName = "CoreRoleUser"
                },
                new Power
                {
                    Name = "CoreRoleUserNew",
                    Title = "向角色添加用户",
                    GroupName = "CoreRoleUser"
                },
                new Power
                {
                    Name = "CoreRoleUserDelete",
                    Title = "从角色中删除用户",
                    GroupName = "CoreRoleUser"
                },
                new Power
                {
                    Name = "CoreOnlineView",
                    Title = "浏览在线用户列表",
                    GroupName = "CoreOnline"
                },
                new Power
                {
                    Name = "CoreConfigView",
                    Title = "浏览全局配置参数",
                    GroupName = "CoreConfig"
                },
                new Power
                {
                    Name = "CoreConfigEdit",
                    Title = "修改全局配置参数",
                    GroupName = "CoreConfig"
                },
                new Power
                {
                    Name = "CoreMenuView",
                    Title = "浏览菜单列表",
                    GroupName = "CoreMenu"
                },
                new Power
                {
                    Name = "CoreMenuNew",
                    Title = "新增菜单",
                    GroupName = "CoreMenu"
                },
                new Power
                {
                    Name = "CoreMenuEdit",
                    Title = "编辑菜单",
                    GroupName = "CoreMenu"
                },
                new Power
                {
                    Name = "CoreMenuDelete",
                    Title = "删除菜单",
                    GroupName = "CoreMenu"
                },
                new Power
                {
                    Name = "CoreLogView",
                    Title = "浏览日志列表",
                    GroupName = "CoreLog"
                },
                new Power
                {
                    Name = "CoreLogDelete",
                    Title = "删除日志",
                    GroupName = "CoreLog"
                },
                new Power
                {
                    Name = "CoreTitleView",
                    Title = "浏览职务列表",
                    GroupName = "CoreTitle"
                },
                new Power
                {
                    Name = "CoreTitleNew",
                    Title = "新增职务",
                    GroupName = "CoreTitle"
                },
                new Power
                {
                    Name = "CoreTitleEdit",
                    Title = "编辑职务",
                    GroupName = "CoreTitle"
                },
                new Power
                {
                    Name = "CoreTitleDelete",
                    Title = "删除职务",
                    GroupName = "CoreTitle"
                },
                new Power
                {
                    Name = "CoreTitleUserView",
                    Title = "浏览职务用户列表",
                    GroupName = "CoreTitleUser"
                },
                new Power
                {
                    Name = "CoreTitleUserNew",
                    Title = "向职务添加用户",
                    GroupName = "CoreTitleUser"
                },
                new Power
                {
                    Name = "CoreTitleUserDelete",
                    Title = "从职务中删除用户",
                    GroupName = "CoreTitleUser"
                },
                new Power
                {
                    Name = "CoreDeptView",
                    Title = "浏览部门列表",
                    GroupName = "CoreDept"
                },
                new Power
                {
                    Name = "CoreDeptNew",
                    Title = "新增部门",
                    GroupName = "CoreDept"
                },
                new Power
                {
                    Name = "CoreDeptEdit",
                    Title = "编辑部门",
                    GroupName = "CoreDept"
                },
                new Power
                {
                    Name = "CoreDeptDelete",
                    Title = "删除部门",
                    GroupName = "CoreDept"
                },
                new Power
                {
                    Name = "CoreDeptUserView",
                    Title = "浏览部门用户列表",
                    GroupName = "CoreDeptUser"
                },
                new Power
                {
                    Name = "CoreDeptUserNew",
                    Title = "向部门添加用户",
                    GroupName = "CoreDeptUser"
                },
                new Power
                {
                    Name = "CoreDeptUserDelete",
                    Title = "从部门中删除用户",
                    GroupName = "CoreDeptUser"
                },
                new Power
                {
                    Name = "CorePowerView",
                    Title = "浏览权限列表",
                    GroupName = "CorePower"
                },
                new Power
                {
                    Name = "CorePowerNew",
                    Title = "新增权限",
                    GroupName = "CorePower"
                },
                new Power
                {
                    Name = "CorePowerEdit",
                    Title = "编辑权限",
                    GroupName = "CorePower"
                },
                new Power
                {
                    Name = "CorePowerDelete",
                    Title = "删除权限",
                    GroupName = "CorePower"
                },
                new Power
                {
                    Name = "CoreRolePowerView",
                    Title = "浏览角色权限列表",
                    GroupName = "CoreRolePower"
                },
                new Power
                {
                    Name = "CoreRolePowerEdit",
                    Title = "编辑角色权限",
                    GroupName = "CoreRolePower"
                },
                //new Power
                //{
                //    Name = "AppReportView",
                //    Title = "查看报告权限",
                //    GroupName = "AppReport"
                //},
                //new Power
                //{
                //    Name = "AppReportUpload",
                //    Title = "上传报告权限",
                //    GroupName = "AppReport"
                //},
                new Power
                {
                    Name = "AppScriptView",
                    Title = "浏览脚本列表",
                    GroupName = "AppScript"
                },
                new Power
                {
                    Name = "AppScriptNew",
                    Title = "新增脚本",
                    GroupName = "AppScript"
                },
                new Power
                {
                    Name = "AppScriptEdit",
                    Title = "修改脚本",
                    GroupName = "AppScript"
                },
                new Power
                {
                    Name = "AppScriptDelete",
                    Title = "删除脚本",
                    GroupName = "AppScript"
                },
                 new Power
                {
                    Name = "AppFlowView",
                    Title = "浏览流程列表",
                    GroupName = "AppFlow"
                },
                new Power
                {
                    Name = "AppFlowNew",
                    Title = "新增流程",
                    GroupName = "AppFlow"
                },
                new Power
                {
                    Name = "AppFlowEdit",
                    Title = "修改流程",
                    GroupName = "AppFlow"
                },
                new Power
                {
                    Name = "AppFlowDelete",
                    Title = "删除流程",
                    GroupName = "AppFlow"
                },
                 new Power
                {
                    Name = "AppPlanView",
                    Title = "浏览计划列表",
                    GroupName = "AppPlan"
                },
                new Power
                {
                    Name = "AppPlanNew",
                    Title = "新增计划",
                    GroupName = "AppPlan"
                },
                new Power
                {
                    Name = "AppPlanEdit",
                    Title = "修改计划",
                    GroupName = "AppPlan"
                },
                new Power
                {
                    Name = "AppPlanDelete",
                    Title = "删除计划",
                    GroupName = "AppPlan"
                },
                new Power
                {
                    Name = "ProjectView",
                    Title = "浏览项目信息",
                    GroupName = "Project"
                },
                new Power
                {
                    Name = "ProjectEdit",
                    Title = "编辑项目信息",
                    GroupName = "Project"
                },
                new Power
                {
                    Name = "ProjectDelete",
                    Title = "删除项目信息",
                    GroupName = "Project"
                },
                new Power
                {
                    Name = "ProjectNew",
                    Title = "新建项目信息",
                    GroupName = "Project"
                },
                new Power
                {
                    Name = "HostPoolView",
                    Title = "浏览项目信息",
                    GroupName = "Project"
                },
                new Power
                {
                    Name = "HostPoolEdit",
                    Title = "编辑项目信息",
                    GroupName = "HostPool"
                },
                new Power
                {
                    Name = "HostPoolDelete",
                    Title = "删除项目信息",
                    GroupName = "HostPool"
                },
                new Power
                {
                    Name = "HostPoolNew",
                    Title = "新建项目信息",
                    GroupName = "HostPool"
                }
            };

            return powers;
        }

        private static List<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "系统管理员",
                    Remark = ""
                },
                new Role()
                {
                    Name = "部门管理员",
                    Remark = ""
                },
                new Role()
                {
                    Name = "项目经理",
                    Remark = ""
                },
                new Role()
                {
                    Name = "开发人员",
                    Remark = ""
                },
                new Role()
                {
                    Name = "测试人员",
                    Remark = ""
                }
            };

            return roles;
        }

        private static List<User> GetUsers()
        {
          
            var users = new List<User>();
         
            string gender = "男";
            string chineseName ="楚建欣";
            string userName = "cjx";

            users.Add(new User
            {
                Name = userName,
                Gender = gender,
                Password = PasswordUtil.CreateDbPassword("1"),
                ChineseName = chineseName,
                Email = "1@1.com",
                Enabled = true,
                CreateTime = DateTime.Now
            });

            users.Add(new User
            {
                Name = "lee",
                Gender = "男",
                Password = PasswordUtil.CreateDbPassword("lee"),
                ChineseName = "李洪涛",
                Email = "lee@lee.com",
                Enabled = true,
                CreateTime = DateTime.Now
            });
           
            // 添加超级管理员
            users.Add(new User
            {
                Name = "admin",
                Gender = "男",
                Password = PasswordUtil.CreateDbPassword("admin"),
                ChineseName = "超级管理员",
                Email = "admin@examples.com",
                Enabled = true,
                CreateTime = DateTime.Now
            });

            return users;
        }


        private static List<Dept> GetDepts()
        {
            var depts = new List<Dept> { 
                new Dept
                {
                    Name = "信息中心管理部",
                    SortIndex = 1,
                    Remark = "顶级部门",
                    Children = new List<Dept> { 
                        new Dept
                        {
                            Name = "开发部",
                            SortIndex = 1,
                            Remark = "二级部门"
                        },
                        new Dept
                        {
                            Name = "测试部",
                            SortIndex = 2,
                            Remark = "二级部门"
                        }
                    }
                }
            };

            return depts;
        }

        private static List<Config> GetConfigs()
        {
            var configs = new List<Config> {
                new Config
                {
                    ConfigKey = "Title",
                    ConfigValue = "新测科技自动化测试平台",
                    Remark = "网站的标题"
                },
                new Config
                {
                    ConfigKey = "PageSize",
                    ConfigValue = "20",
                    Remark = "表格每页显示的个数"
                },
                new Config
                {
                    ConfigKey = "MenuType",
                    ConfigValue = "accordion",
                    Remark = "左侧菜单样式"
                },
                new Config
                {
                    ConfigKey = "Theme",
                    ConfigValue = "Neptune",
                    Remark = "网站主题"
                },
                new Config
                {
                    ConfigKey = "HelpList",
                    ConfigValue = "[{\"Text\":\"万年历\",\"Icon\":\"Calendar\",\"ID\":\"wannianli\",\"URL\":\"~/admin/help/wannianli.htm\"},{\"Text\":\"科学计算器\",\"Icon\":\"Calculator\",\"ID\":\"jisuanqi\",\"URL\":\"~/admin/help/jisuanqi.htm\"},{\"Text\":\"系统帮助\",\"Icon\":\"Help\",\"ID\":\"help\",\"URL\":\"~/admin/help/help.htm\"}]",
                    Remark = "帮助下拉列表的JSON字符串"
                }
            };

            return configs;
        }

    }
}