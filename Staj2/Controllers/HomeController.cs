using BusinessLibrary;
using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Staj2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Urunler()
        {
            PageItem item = new PageItem();
            using (OrnekDBEntities1 db = new OrnekDBEntities1())
            {
                item.lstUrunlerIslem = db.Proc_Urunler_Islem("Liste", 0, 0, "", "", "", "").ToList();
            }
            return View(item);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Kategoriler()

        {
            PageItem item = new PageItem();
            using (OrnekDBEntities1 db = new OrnekDBEntities1())
            {
                item.lstKategorilerIslem = db.Proc_Kategoriler_Islem("Liste", 0, 0, "", "", "").ToList();
            }

            return View(item);
        }




        [HttpPost]
        public string UrunIslem(FormCollection collection, HttpPostedFileBase fileUrunResim)
        {
            string result = "";
            try
            {
                int UrunID = collection["UrunID"].ToInt();
                string type = collection["type"].ToString();
                if (type == "Kaydet")
                {
                    int KategoriID = collection["selectKategoriler"].ToInt();
                    string UrunKodu = collection["txtUrunKodu"].ToString();
                    string UrunBaslik = collection["txtUrunBaslik"].ToString();
                    string UrunAciklama = collection["txtUrunAciklama"].ToString();
                    string UrunResimUrl = collection["hdnUrunResim"].ToString();

                    UrunResimUrl = fileUrunResim.ToFileUploadKaydet("/Assets/Dosyalar/Urunler/Resim/", UrunResimUrl);

                    string process = "Yeni";
                    if (UrunID > 0)
                        process = "Guncelle";

                    using (OrnekDBEntities1 db = new OrnekDBEntities1())
                    {
                        Proc_Urunler_Islem_Result item = db.Proc_Urunler_Islem(process, UrunID, KategoriID, UrunKodu, UrunBaslik, UrunAciklama, UrunResimUrl).FirstOrDefault();
                    }
                }
                else if (type == "Sil")
                {
                    using (OrnekDBEntities1 db = new OrnekDBEntities1())
                    {
                        Proc_Urunler_Islem_Result item = db.Proc_Urunler_Islem("Sil", UrunID, 0, "", "", "", "").FirstOrDefault();
                    }
                }
                result = MessageHelper.SuccessMessage;
            }
            catch (Exception)
            {
                result = MessageHelper.ErrorMessage;
            }
            return result;
        }


        [HttpPost]
        public string KategoriIslem(FormCollection collection, HttpPostedFileBase fileKategoriResim)
        {
            string result = "";
            try
            {
                int KategoriID = collection["KategoriID"].ToInt();
                string type = collection["type"].ToString();
                if (type == "Kaydet")
                {
                    int UstKategoriID = collection["selectKategoriler"].ToInt();
                    string KategoriBaslik = collection["txtKategoriBaslik"].ToString();
                    string KategoriAciklama = collection["txtKategoriAciklama"].ToString();
                    string KategoriResimUrl = collection["hdnKategoriResim"].ToString();

                    KategoriResimUrl = fileKategoriResim.ToFileUploadKaydet("/Assets/Dosyalar/Kategoriler/Resim/", KategoriResimUrl);

                    string process = "Yeni";
                    if (KategoriID > 0)
                        process = "Guncelle";

                    using (OrnekDBEntities1 db = new OrnekDBEntities1())
                    {
                        Proc_Kategoriler_Islem_Result item = db.Proc_Kategoriler_Islem(process, KategoriID, UstKategoriID, KategoriBaslik, KategoriAciklama, KategoriResimUrl).FirstOrDefault();
                    }
                }
                else if (type == "Sil")
                {
                    using (OrnekDBEntities1 db = new OrnekDBEntities1())
                    {
                        Proc_Kategoriler_Islem_Result item = db.Proc_Kategoriler_Islem("Sil", KategoriID, 0, "", "", "").FirstOrDefault();
                    }
                }
                result = MessageHelper.SuccessMessage;
            }
            catch (Exception)
            {
                result = MessageHelper.ErrorMessage;
            }
            return result;
        }
    }

    public class PageItem
    {
        public List<Proc_Urunler_Islem_Result> lstUrunlerIslem = new List<Proc_Urunler_Islem_Result>();
        public List<Proc_Kategoriler_Islem_Result> lstKategorilerIslem = new List<Proc_Kategoriler_Islem_Result>();
        public List<SelectListItem> lstSelectList = new List<SelectListItem>();
    }
}