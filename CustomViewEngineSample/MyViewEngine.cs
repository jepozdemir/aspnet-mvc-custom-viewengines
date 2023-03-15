﻿using System.Web.Mvc;

namespace CustomViewEngineSample
{
    public class MyViewEngine : VirtualPathProviderViewEngine
    {
        public MyViewEngine()
        {
            // Define the location of the View file
            this.ViewLocationFormats = new string[] { "~/Views/{1}/{0}.myview", "~/Views/Shared/{0}.myview" };

            this.PartialViewLocationFormats = new string[] { "~/Views/{1}/{0}.myview", "~/Views/Shared/{0}.myview" };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(partialPath);
            return new MyView(physicalpath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(viewPath);
            return new MyView(physicalpath);
        }
    }
}