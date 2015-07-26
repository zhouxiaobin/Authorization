using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Test.Domain;
using Test.Service;

namespace Test.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
	    private string AjaxReturnData = "\"status\":{0},\"data\":{1}";
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
		    return View();
	    }

		/// <summary>
		/// 判断用户是否存在
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		[HttpPost]
	    public string  CheckLogin(FormCollection e)
	    {
			//string tempJson="";
			var js = new JavaScriptSerializer();
			var  ht = new Hashtable();
			CacheMember cacheMember = new CacheMember();
			string username = e["username"];
			ht.Add("username", username);
			ht.Add("userpwd", e["userpwd"]);
			Session["username"] = username;
			try
			{
				User temp = (User)_iBaseService.QueryForObject<User>("User.CheckUser", ht);
				
				if (temp == null)
				{
					return js.Serialize(new { status = 0, msg = username + "：用户名或密码错误" });
				}
				cacheMember.User = temp;
				IList<Role> roles = _iBaseService.QueryForList<Role>("Role.selRoleByUserId", temp.Id);
				IList<Menu> menus = _iBaseService.QueryForList<Menu>("Menu.selMenuByRoleId", 2);
				cacheMember.Roles = roles;
				cacheMember.Menus = menus;
				Session["userAuthorization"] = cacheMember;
				return js.Serialize(new { status = 1, msg = "" });
			}
			catch (Exception)
			{

				return js.Serialize(new { status = -1, msg = "系统异常，请联系管理员" });
			}
	    }

	    [HttpPost]
	    public string checkAnthoriza(FormCollection e)
	    {

		    string result = "";
		    string url = e["url"];
		    var ht = new Hashtable();
		    CacheMember cacheMember =(CacheMember) Session["userAuthorization"];
			var auth = cacheMember.Menus.Where(x => x.Url.ToUpper().Trim() == url.ToUpper().Trim());
			var js = new JavaScriptSerializer();
			if (auth.Count() > 0)
			{
				return js.Serialize(new { status = 1, msg = "" });
			}

			return js.Serialize(new { status = -1, msg = "无权限，请联系管理员" });
	    }

	    public ActionResult Main()
	    {
		    return View();
	    }

		public ActionResult Test1()
		{
			return View();
		}
		public ActionResult Test2()
		{
			return View();
		}
    }
}