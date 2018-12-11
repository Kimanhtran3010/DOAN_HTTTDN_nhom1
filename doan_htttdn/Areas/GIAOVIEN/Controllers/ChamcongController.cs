using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan_htttdn.DAO.GIAOVIEN;
using doan_htttdn.FF;
using doan_htttdn.Areas.ViewModel;

namespace doan_htttdn.Areas.GIAOVIEN.Controllers
{
    public class ChamcongController : Controller
    {
        // GET: GIAOVIEN/Chamcong
        DAO_Teaching_class dao = new DAO_Teaching_class();
        public ActionResult Index( )
        {
            if (Session[Common.CommonConstant.USER_SESSION] != null)
            {
                var model = new ChamCongIndexViewModel();
                model.All_Teacher_Attendance = dao.GetALL((int)Session[Common.CommonConstant.ID_SESSION]).ToList();
                model.Custom_Teacher_Attendance = dao.GetTodayClasses().ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }
        [HttpPost]
        public ActionResult Add()
        {
            DAO_Class_Student dao_cs = new DAO_Class_Student();
            DAO_Teaching_class dao_tc = new DAO_Teaching_class();
            dao_tc.delete((int)Session[Common.CommonConstant.ID_SESSION]);
            //lay tat ca id class tu form post len
            string[] keys = Request.Form.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                //lay id class tu form cham cong 
                string s_id = Request.Form[keys[i]];
                int id = int.Parse(s_id);
                //lay thong tin lop hoc
                var class_info = dao_cs.getByClassInfoByID(id);
                TEACHING_CLASS tc = new TEACHING_CLASS();
                tc.IDClass = class_info.IDClass;
                tc.IDTeacher = (int)Session[Common.CommonConstant.ID_SESSION];
                tc.session = class_info.session;
                tc.State = class_info.State;
                tc.Day = class_info.Day;
                //luu vao db
                dao_tc.Insert(tc);
            }
            return RedirectToAction("index");
        }
    }
}