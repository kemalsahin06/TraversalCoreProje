﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberDasboard
{
    public class _PlatformSetting : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
}
