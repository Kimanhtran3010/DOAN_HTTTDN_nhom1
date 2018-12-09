using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.FF;
using doan_htttdn.DAO;
using doan_htttdn.Common;

namespace doan_htttdn.Areas.ADMIN.Controllers
{
    public class GiaoVienController : Controller
    {
        // GET: ADMIN/GiaoVien
     
        DAO_Admin dao = new DAO_Admin();
        public ActionResult GiaoVien()
        {
            return View(dao.List_Teacher());
        }

        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them(TEACHER teacher)
        {
            
            dao.Insert_Teacher(teacher);
            return RedirectToAction("GiaoVien");
        }
        

        
        public ActionResult Sua(int id)
        {
            var bien = dao.GetTeacher(id);
            return View(bien);
        }
        [HttpPost]
        public ActionResult Sua(TEACHER teacher)
        {
            if(ModelState.IsValid)
            {
                if (dao.Update_Teacher(teacher))
                {
                    RedirectToAction("GiaoVien");
                }
                else
                    ModelState.AddModelError("","Lỗi Cập Nhật!");

            }
            return RedirectToAction("GiaoVien");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
           
                if (dao.Delete_teacher(id) == true)

                {
                    ModelState.AddModelError("", "Xóa Thành Công!");
                RedirectToAction("GiaoVien");
                //    return RedirectToAction("GiaoVien");
                //}
                //else
                //{

            }
                
            
            return RedirectToAction("GiaoVien");    

        }

        
    }
}