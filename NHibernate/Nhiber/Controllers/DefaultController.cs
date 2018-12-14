using Nhiber.Models;
using NHiber.Models.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhiber.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            var session = NHibernateHelper.OpenSession();

            var list = session.QueryOver<Character>()
           .Where(chr => chr.ID > 1 && chr.ID < 4)
           .List();
            var count = session.QueryOver<Character>().RowCount();

            var only_second_page = session.QueryOver<Character>()
                .OrderBy(x => x.ID).Asc
                .Take(1)
                .Skip((2 - 1) * 1)
                .List();
            session.Save(new Character("Random_nick_" + (count + 1).ToString(), new Random().Next(0, 100), new Random().Next(0, 50),
                 new Random().Next(0, 50), new Random().Next(0, 50)));
            count = session.QueryOver<Character>().RowCount();
            list = session.QueryOver<Character>().List();
            list = session.QueryOver<Character>().List();

            return View();
        }
    }
}