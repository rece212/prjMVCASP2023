using Microsoft.AspNetCore.Mvc;
using prjMVCASP.Models;

namespace prjMVCASP.Controllers
{
    public class StaffController : Controller
    {
        StaffContext db = new StaffContext();

        public IActionResult Index()
        {
            return View(StaffContext.staffObject);
        }
        public IActionResult edit(int id)
        {
            Staff temp = StaffContext.staffObject.Where(x=>x.Id == id).FirstOrDefault();
            return View(temp);
        }
        public IActionResult Details(int id)
        {
            Staff temp = StaffContext.staffObject.Where(x => x.Id == id).FirstOrDefault();
            return View(temp);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Staff temp)
        {
            Staff sf = temp;
            if (sf.Name == null || sf.Id < 0 || sf.Password == null || sf.Dob == null || sf.Title == null)
            {
                ViewBag.Error = "Please enter all the fields or die";
                return View();
            }
            else
            {
                StaffContext.staffObject.Add(sf);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            Staff temp = StaffContext.staffObject.Where(x => x.Id == id).FirstOrDefault();
            return View(temp);
        }
        [HttpPost]
        public IActionResult DeleteStaff(Staff sf)
        {
            StaffContext.staffObject = StaffContext.staffObject.Where(x => x.Id != sf.Id).ToList();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult edit(Staff sf)
        {
            Staff data = sf;
            if (sf.Name ==null||sf.Id<0||sf.Password==null||sf.Dob==null||sf.Title==null)
            {
                ViewBag.Error = "Please don't be simple:)";
                return View();
            }
            else
            {// add data query here
                (from p in StaffContext.staffObject
                 where p.Id == sf.Id
                 select p).ToList().ForEach(x =>
                 {
                     x.Password = sf.Password;
                     x.Dob = sf.Dob;
                     x.Name = sf.Name;
                     x.Title = sf.Title;
                 });
                return RedirectToAction("Index");
            }
        }
    }
}
