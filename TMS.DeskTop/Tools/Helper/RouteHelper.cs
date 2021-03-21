using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;

namespace TMS.DeskTop.Tools.Helper
{
    public static class RouteHelper
    {
        public static void RegisterToContainer(IContainerRegistry containerRegistry)
        {
            foreach (KeyValuePair<Type, string> kv in Router.Instance.GetRouteMap())
            {
                containerRegistry.RegisterForNavigation(kv.Key, kv.Value);
            }
        }

        /// <summary>
        /// 跳转函数
        /// 
        /// 搜索公共区域，发送导航请求
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="nowView"></param>
        /// <param name="targetView"></param>
        public static void Goto(IRegionManager regionManager, Type nowView, Type targetView)
        {
            // 寻找公共视图
            Type common_view = FindCommonView(nowView, targetView);

            // 寻找公共视图对应的公共区域
            string common_region = GetRegionName(common_view);

            // 寻找公共区域的注入视图，以进行下一步导航
            string next_route = GetNextRoute(GetViewPath(common_view), GetViewPath(targetView));

            // 发送导航请求
            if (!next_route.Equals(""))
            {
                NavigationParameters param = new NavigationParameters();
                param.Add("target_view", targetView);

                RegionHelper.RequestNavigate(regionManager, common_region, ConverterViewPathToType(next_route), param);
            }
        }

        public static void Goto(IRegionManager regionManager, Type nowView, string targetView)
        {
            Goto(regionManager, nowView, Router.Instance.ConverterViewNameToType(targetView));
        }

        /// <summary>
        /// 实现直线路由
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="nowView">现在所在的视图的名字</param>
        /// <param name="targetView">目标视图的名字</param>
        public static void Route(IRegionManager regionManager, Type nowView, Type targetView)
        {
            // 寻找下个路由
            string next_route = GetNextRoute(GetViewPath(nowView), GetViewPath(targetView));

            // 发送导航请求
            if (!next_route.Equals(""))
            {
                NavigationParameters param = new NavigationParameters();
                param.Add("target_view", targetView);

                RegionHelper.RequestNavigate(regionManager, GetRegionName(nowView), ConverterViewPathToType(next_route), param);
            }
        }

        public static string GetRegionName(Type view)
        {
            return Router.Instance.GetRegionName(view);
        }

        public static string GetViewPath(Type view)
        {
            return Router.Instance.GetViewPath(view);
        }

        public static Type ConverterViewPathToType(string viewPath)
        {
            return Router.Instance.ConvertViewPathToType(viewPath);
        }

        public static bool IsBackPage(Type view)
        {
            return Router.Instance.IsBackPage(view);
        }

        private static Type FindCommonView(Type view1, Type view2)
        {
            // 取出目前路径
            string view1Path = GetViewPath(view1);

            // 取出目标路径
            string view2Path = GetViewPath(view2);

            int index = -1;
            for (int i = 0; i < Math.Min(view1Path.Length, view2Path.Length); ++i)
            {
                if (view1Path[i] == view2Path[i])
                {
                    if (view1Path[i] == '/')
                    {
                        index = i;
                    }
                }
                else
                {
                    break;
                }
            }

            string common_url;
            if (index == -1)
            {
                common_url = GetViewPath(Router.Instance.Root);
            }
            else
            {
                common_url = view1Path.Substring(0, index + 1);
            }
            return ConverterViewPathToType(common_url);
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
