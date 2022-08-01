using BusinessLibrary;
using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj2.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        [HttpPost]
        public ActionResult GetUrunForm(FormCollection collection)
        {
            int UrunID = collection["UrunID"].ToInt();
            PageItem item = new PageItem();
            using (OrnekDBEntities1 db = new OrnekDBEntities1())
            {
                item.lstKategorilerIslem = db.Proc_Kategoriler_Islem("Liste", 0, 0, "", "", "").ToList();

                if (UrunID > 0)
                {
                    item.lstUrunlerIslem = db.Proc_Urunler_Islem("Liste", UrunID, 0, "", "", "", "").ToList();
                }
                else
                {
                    item.lstUrunlerIslem.Add(new Proc_Urunler_Islem_Result { urunID = 0, kategoriID = 0, urunResimUrl = ItemHelper.GetResimYokUrl });
                }
            }
            return View(item);
        }



        public ActionResult GetUrunSil(int id)
        {
            PageItem item = new PageItem();
            using (OrnekDBEntities1 db = new OrnekDBEntities1())
            {
                item.lstUrunlerIslem = db.Proc_Urunler_Islem("Liste", id, 0, "", "", "", "").ToList();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult GetKategoriForm(FormCollection collection)
        {
            int KategoriID = collection["KategoriID"].ToInt();
            PageItem item = new PageItem();
            using (OrnekDBEntities1 db = new OrnekDBEntities1())
            {

                if (KategoriID > 0)
                {
                    item.lstKategorilerIslem = db.Proc_Kategoriler_Islem("Liste", KategoriID, 0, "", "", "").ToList();
                }
                else
                {
                    item.lstKategorilerIslem.Add(new Proc_Kategoriler_Islem_Result { UstKategoriID = 0, kategoriID = 0, kategoriResimUrl = ItemHelper.GetResimYokUrl });
                }
                item.lstSelectList = db.Proc_Kategoriler_Islem("Liste", 0, 0, "", "", "").Select(x => new SelectListItem { Value = x.kategoriID.ToString(), Text = x.kategoriBaslik }).ToList();
            }
            return View(item);
        }

        public ActionResult GetKategoriSil(int id)
        {
            PageItem item = new PageItem();
            using (OrnekDBEntities1 db = new OrnekDBEntities1())
            {
                item.lstKategorilerIslem = db.Proc_Kategoriler_Islem("Liste", id, 0, "", "", "").ToList();
            }
            return View(item);
        }
    }
}