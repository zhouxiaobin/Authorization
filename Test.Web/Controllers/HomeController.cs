using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Domain;
using Test.Service;

namespace Test.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
		private  readonly IBaseService _iBaseService;
		public HomeController()
        {
        }
		public HomeController(IBaseService iBaseService)
	    {
			_iBaseService = iBaseService;
	    }

	    public ActionResult Index()
        {
			var persons = _iBaseService.QueryForList<Person>("SelectAllClasses", null);
			return View(persons);
        }
	}
}