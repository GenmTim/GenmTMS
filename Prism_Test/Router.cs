using Prism_Test.Views;
using System.Collections.Generic;

namespace Prism_Test
{
    public class Router
    {
        private static Router instance = null;
        public static Router Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Router();
                }
                return instance;
            }
        }

        private Dictionary<string, string> routeMap;

        public string this[string view]
        {
            get
            {
                return routeMap[view];
            }
        }

        private Router()
        {
            routeMap = new Dictionary<string, string>();
            routeMap[nameof(MainWindow)] = "";
            routeMap[nameof(A)] = routeMap[nameof(MainWindow)] + "A/";
            {
                routeMap[nameof(A1)] = routeMap[nameof(A)] + "A1/";
                {
                    routeMap[nameof(A2)] = routeMap[nameof(A1)] + "A2/";
                }
            }

            routeMap[nameof(B)] = routeMap[nameof(MainWindow)] + "B/";
            {
                routeMap[nameof(B1)] = routeMap[nameof(B)] + "B1/";
                {
                    routeMap[nameof(B2)] = routeMap[nameof(B1)] + "B2/";
                }
            }
        }

    }
}
