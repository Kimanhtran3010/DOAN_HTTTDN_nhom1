using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO.GIAOVIEN;
using doan_htttdn.FF;
using doan_htttdn.Areas.GIAOVIEN.Models;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class ChamcongController : Controller
    {
        // GET: GIAOVIEN/Chamcong
        DAO_Teaching_class dao = new DAO_Teaching_class();
        DAO_Lop dao_lop = new DAO_Lop();
        
        public ActionResult Index()
        {
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
               
                var list = dao.GetALL((int)Session[Common.CommonConstant.ID_SESSION]);
                SetViewBag1();
                SetViewBag2();
                SetViewBag3();
                SetViewBag4();
                return View(list);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
        private void SetViewBag1(string selectName = null) // dung de tim kiem
        {
            ViewBag.month = new SelectList(Create_Month(), "ID", "Name", selectName);
        }
        private void SetViewBag4(string selectName = null) // dung de tim kiem
        {
            var lop1 = dao_lop.GetByIDTeacher((int)Session[Common.CommonConstant.ID_SESSION]);
            ViewBag.lopsearch = new SelectList(lop1.ToList(), "IDClass", "NameClass");
        }
        private void SetViewBag2() // session
        {
            
            ViewBag.session = new SelectList(Create_Month(), "ID", "ID"/*, buoi*/);
        }
        private void SetViewBag3() // lop
        {
            var lop1 = dao_lop.GetByIDTeacher((int)Session[Common.CommonConstant.ID_SESSION]);
            ViewBag.IDClass = new SelectList(lop1.ToList(), "IDClass", "NameClass");
        }
        public List<Month> Create_Month()
        {
            List<Month> months = new List<Month>();
            for( int i = 1; i <= 12; i++)
            {
                Month month = new Month();
                month.ID = i;
                month.Name = "Tháng " + i.ToString();
                months.Add(month);
            }
            return months;
        }
        public ActionResult Search( int month)
        {
            var list = dao.GetALL_IDteacher_IDmonth((int)Session[Common.CommonConstant.ID_SESSION] , month );
            SetViewBag1();
            SetViewBag4();
            var listluong = dao.GetALLLuong((int)Session[Common.CommonConstant.ID_SESSION]).Where(model => model.month == month).ToList();
          //return  RedirectToAction("Luong", listluong);
            return View("Index", list);
        }
        public ActionResult Searchlop(int lopsearch)
        {
            var list = dao.GetALL_IDteacher_IDLop((int)Session[Common.CommonConstant.ID_SESSION], lopsearch);
            SetViewBag1();
            SetViewBag4();
            return View("Index", list);
        }

        public ActionResult Create ()
        {
            if ((int)Session[Common.CommonConstant.USER_STATE] == 1)
            {
                TEACHING_CLASS model = null;
                SetViewBag2();
                SetViewBag3();
                return View(model);
            }
            else
                return null;
            
        }
        [HttpPost]
        public ActionResult ADDchamcong(TEACHING_CLASS model)
        {
            model.IDTeacher = (int)Session[Common.CommonConstant.ID_SESSION];
            if (!dao.Exist_Teaching_Class(model))
            {
                model.State = 1;
                if (dao.Add_TEaching_class1(model) == 1)
                {
                    TempData["msg"] = "<script>alert('Them thanh cong');</script>";
                }
                else
                {
                    if(dao.Add_TEaching_class1(model) == 2)
                    {
                        TempData["msg"] = "<script>alert('Them khong thanh cong');</script>";
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('Ngày của buổi chấm công không nằm trong thòi gian hoạt động của lớp học');</script>";
                    }
                    
                }

            }
            else
            {
                TempData["msg"] = "<script>alert('Ngày công này đã tồn tại');</script>";
            }
            return RedirectToAction("Index", "Chamcong");
        }
        [HttpPost]
        public ActionResult UpdateChamcong(TEACHING_CLASS model)
        {
            model.IDTeacher = (int)Session[Common.CommonConstant.ID_SESSION];
            if (dao.Update_Teaching_class1(model) == 1)
            {
                TempData["msg"] = "<script>alert('Update thanh cong');</script>";
            }
            else
            {
                if(dao.Update_Teaching_class1(model) == 2)
                {
                    TempData["msg"] = "<script>alert('Ngày của buổi chấm công không nằm trong thòi gian hoạt động của lớp học');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Ngày công đã tồn tại, Update không thành công');</script>";
                }
                
            }
            return RedirectToAction("Index", "Chamcong");
        }
        public ActionResult Delete(int ID)
        {
            if (dao.Delete_teaching_class(ID))
            {
                TempData["msg"] = "<script>alert('Xoa thanh cong');</script>";
            }
            else
            {
                TempData["msg"] = "<script>alert('Xoa không thành công');</script>";
            }
            return RedirectToAction("Index", "Chamcong");
        }
        public ActionResult Update()
        {
           
            if ((int)Session[Common.CommonConstant.USER_STATE] == 2)
            {
                var model = dao.getbyIDclass((int)Session[Common.CommonConstant.ID_TEACHING_CLASS]);
                model.Day = model.Day.Date;
                SetViewBag2();
                SetViewBag3();
               
                return View(model);
            }
            else
                return null;
            
        }
        public ActionResult LinkUpdate( int ID)
        {
            Session[Common.CommonConstant.USER_STATE] = 2;
            Session[Common.CommonConstant.ID_TEACHING_CLASS] = ID;
            return RedirectToAction("Index", "Chamcong",ID);
        }
        public ActionResult LinkThem( )
        {
            Session[Common.CommonConstant.USER_STATE] = 1;
            return RedirectToAction("Index", "Chamcong"/*,list*/);
        }
        public ActionResult Luong()
        {
            var list = dao.GetALLLuong((int)Session[Common.CommonConstant.ID_SESSION]);
            SetViewBag1();
            return View(list);
        }
    }
}