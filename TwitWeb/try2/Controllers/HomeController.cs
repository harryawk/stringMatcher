using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Tuittuit
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
//			Program p = new Program ();
//			p.tuitTuit ();
//			p.printTweet ();


			var mvcName = typeof(Controller).Assembly.GetName ();
			var isMono = Type.GetType ("Mono.Runtime") != null;

			ViewData ["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData ["Runtime"] = isMono ? "Mono" : ".NET";

			return View ();
		}


		public ActionResult Result (string TwitterSearchInput, string Input1, string Input2, string Input3, string Input4, string Input5)
		{
			Console.WriteLine (TwitterSearchInput);
			Console.WriteLine (Input1);
			Console.WriteLine (Input2);
			Console.WriteLine (Input3);
			Console.WriteLine (Input4);
			Console.WriteLine (Input5);
			return View ();
		}

		public ActionResult Help ()
		{
			return View ();
		}

		public ActionResult About ()
		{
			return View ();
		}

		public ActionResult SearchResult ()
		{
			return View ();
		}	

		public ActionResult Location ()
		{
			return View ();
		}	
	}
}

