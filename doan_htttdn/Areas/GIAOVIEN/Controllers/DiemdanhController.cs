using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.Areas.GIAOVIEN.Models;
using doan_htttdn.Common;
using doan_htttdn.DAO.GIAOVIEN;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class DiemdanhController : Controller
    {

        // GET: GIAOVIEN/Diemdanh
        DAO_Class_Student dao1 = new DAO_Class_Student();
        public ActionResult Index()
        {
            
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
                Session.Add(CommonConstant.ID_CLASS, null);
                var a = dao1.GetALL((int)Session[Common.CommonConstant.ID_SESSION]);
                SetViewBag1();
                return View(a);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Xem_Diemdanh(int id)
        {
            Session.Add(CommonConstant.ID_CLASS, id);
            List<Student_Change__Attendance> ds = dao1._GetALL(id);
            SetViewBag1();
            return View("Index", ds);
        }
        
        public ActionResult Xem_DiemdanhbyID(int lopsearch) // tim kiem
        {
            Session.Add(CommonConstant.ID_CLASS, lopsearch);
            List<Student_Change__Attendance> ds = dao1._GetALL(lopsearch);
            SetViewBag1();
            return View("Index", ds);
        }
        private void SetViewBag1(string selectName = null)// ma lop // dung de tim kiem
        {
            DAO_Lop daolop = new DAO_Lop();
            var lop1 = daolop.GetByIDTeacher((int)Session[Common.CommonConstant.ID_SESSION]);
            ViewBag.lopsearch = new SelectList(lop1.ToList(), "IDClass", "NameClass");
        }
        private void SetViewBag5(string selectName = null)// ma lop dung update
        {
            DAO_Lop daolop = new DAO_Lop();
            var lop1 = daolop.GetByIDTeacher((int)Session[Common.CommonConstant.ID_SESSION]);
            ViewBag.IDClass = new SelectList(lop1.ToList(), "IDClass", "NameClass");
        }
        private void SetViewBag2(int IDclass) // Ten hoc vien
        {
            DAO_Hocvien daohv = new DAO_Hocvien();
            var hocvien = daohv.GetbyIDClass(IDclass);
            ViewBag.IDStudent = new SelectList(hocvien.ToList(), "IDStudent", "Name");
        }
        private void SetViewBag6() // Ten hoc vien chung
        {
            DAO_Hocvien daohv = new DAO_Hocvien();
            var hocvien = daohv.GetALL((int)Session[Common.CommonConstant.ID_SESSION]);
            ViewBag.IDStudent = new SelectList(hocvien.ToList(), "IDStudent", "Name");
        }
        public List<Month> Create_Month()
        {
            List<Month> months = new List<Month>();
            for (int i = 1; i <= 12; i++)
            {
                Month month = new Month();
                month.ID = i;
                month.Name = "Tháng " + i.ToString();
                months.Add(month);
            }
            return months;
        }
        private void SetViewBag3() // session buoi hoc // khong rang buoc
        {
            ViewBag.Session = new SelectList(Create_Month(), "ID", "ID");
        }
        public void SetViewBag4 () // trang thai // khong rang buoc
        {
            List<SelectListItem> trangthai = new List<SelectListItem>()
                {
                new SelectListItem() {Text="Tham gia", Value="1"},
                new SelectListItem() { Text="Vắng", Value="0"}
                };
            ViewBag.State = new SelectList(trangthai, "Value", "Text");
        }
        public ActionResult UpdateDiemdanh ()
        {
            if(Session[Common.CommonConstant.ID_CLASS] != null)
            {
                SetViewBag2((int)Session[Common.CommonConstant.ID_CLASS]); // ten hoc vien co ma lop
            }
            else
            {
                SetViewBag6(); // ten hoc vien chung
            }
            
            SetViewBag3(); // buoi hoc
            SetViewBag4(); // trang thai
            SetViewBag5(); // ma lop
            return View();
        }
        [HttpPost]
        public ActionResult Update(CLASS_STUDENT model)
        {
            if(dao1.Update(model))
            {
                TempData["msg"] = "<script>alert('Update thành công');</script>";
            }
            else
            {
                TempData["msg"] = "<script>alert('Update không thành công');</script>";
            }
            return Xem_Diemdanh(model.IDClass);
        }
        
    }
}