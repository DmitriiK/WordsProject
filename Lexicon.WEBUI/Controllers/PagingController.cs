using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcPaging;
using Lexicon.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using Lexicon.Core.Repositories;

namespace Lexicon.WebUI.Controllers

{
    public class PagingController : Controller
    {
        private const int DefaultPageSize = 10;

        IContentRepository cr;


        public PagingController(IContentRepository rep)
        {
            cr = rep;
        }
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            // return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));

            // IContentRepository rep = new ContentRepository(new Lexicon.DAL.LexiconDBContext());
            var txt = cr.GetFullContent(391).TextData; //this.LoadContentText()

            return View(txt.ToPagedString(currentPageIndex, 10000));
        }
    }
}