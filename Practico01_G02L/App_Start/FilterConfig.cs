﻿using System.Web;
using System.Web.Mvc;

namespace Practico01_G02L
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
