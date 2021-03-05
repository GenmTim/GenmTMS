using Prism.Regions;
using System;

namespace TMS.DeskTop.Tools.Helper
{
    public static class RouteHelper
    {
        /// <summary>
        /// 跳转函数
        /// 
        /// 搜索公共区域，发送导航请求
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="nowView"></param>
        /// <param name="targetView"></param>
        public static void Goto(IRegionManager regionManager, string nowView, string targetView)
        {
            // 取出目前路径
            string now_url = GetViewPath(nowView);

            // 取出目标路径
            string target_url = GetViewPath(targetView);

            // 寻找公共区域
            string common_view = FindCommonView(now_url, target_url);
            string common_region = GetRegionName(common_view);

            // 寻找公共区域的注入视图，以进行下一步导航
            string next_route = GetNextRoute(GetViewPath(common_view), target_url);


            // 发送导航请求
            if (!next_route.Equals(""))
            {
                NavigationParameters param = new NavigationParameters();
                param.Add("target_view", targetView);

                RegionHelper.RequestNavigate(regionManager, common_region, GetViewName(next_route), param);
            }
        }

        /// <summary>
        /// 过程路由函数
        /// 
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="go_url"></param>
        /// <param name="nowView"></param>
        public static void Route(IRegionManager regionManager, string nowView, string targetView)
        {
            // 取出目前路径
            string now_url = GetViewPath(nowView);

            // 取出目标路径
            string target_url = GetViewPath(targetView);

            // 寻找下个路由
            string next_route = GetNextRoute(now_url, target_url);

            // 发送导航请求
            if (!next_route.Equals(""))
            {
                NavigationParameters param = new NavigationParameters();
                param.Add("target_view", targetView);

                RegionHelper.RequestNavigate(regionManager, GetRegionName(nowView), GetViewName(next_route), param);
            }
        }

        public static string GetRegionName(string view)
        {
            return Router.Instance.GetRegionName(view);
        }

        public static string GetViewPath(string view)
        {
            return Router.Instance.GetViewPath(view);
        }

        public static string GetViewName(string viewPath)
        {
            return Router.Instance.GetViewName(viewPath);
        }

        public static bool IsBackPage(string view)
        {
            return Router.Instance.IsBackPage(view);
        }

        private static string FindCommonView(string view1, string view2)
        {
            int index = -1;
            string common_url = "";
            for (int i = 0; i < Math.Min(view1.Length, view2.Length); ++i)
            {
                if (view1[i] == view2[i])
                {
                    if (view1[i] == '/')
                    {
                        index = i;
                    }
                }
                else
                {
                    break;
                }
            }

            if (index == -1)
            {
                common_url = GetViewPath(Router.Instance.Root);
            }
            else
            {
                common_url = GetViewPath(view1.Substring(0, index + 1));
            }
            return GetViewName(common_url);
        }

        /// <summary>
        /// 获取下一个视图地址
        /// </summary>
        /// <param name="nowUrl">现在view的url路径</param>
        /// <param name="targetUrl">目标view的url路径</param>
        /// <returns></returns>
        public static string GetNextRoute(string nowUrl, string targetUrl)
        {
            int next_index = targetUrl.IndexOf('/', nowUrl.Length);
            string next_route = targetUrl.Substring(0, next_index + 1);
            return next_route;
        }
    }
}
