using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.MemberDasboard
{
    public class _ProfileInformation : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        // componentede viewbag tasınıyomus olaala
        public async Task<IViewComponentResult> InvokeAsync()  // fonksiyon ismini böyle yaptıgımızda olar düzenlendi
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.memberName = values.UserName +" "+ values.Surname;
            ViewBag.memberPhone = values.PhoneNumber;
            ViewBag.memberMail =values.Email;
            return View();
        }
    }
}
