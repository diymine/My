using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.MVCSite.Controllers
{
    public class TestJsController : Controller
    {
        // GET: TestJs
        public ActionResult ZipImg()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(byte[] formFile)
        {
            System.IO.File.WriteAllBytes(@"c:\a.png",formFile);
            return new JsonResult(){};
        }
    }
}