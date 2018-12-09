﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;
using doan_htttdn.Areas.GIAOVIEN.Models;

namespace doan_htttdn.DAO
{
    public class DAO_Lop
    {
        QL_SCN db = new QL_SCN();
        
        public IEnumerable<Class_model> GetByIDTeacher(int IDteacher)
        {
            // return db.CLASSes.ToList();
            var list = (from x in db.TEACHING_CLASS
                        join y in db.CLASSes
                        on x.IDClass equals y.IDClass
                        join z in db.COURSEs
                        on y.IDCourse equals z.IDCourse
                        where x.IDTeacher == IDteacher
                        orderby y.IDClass ascending
                        select new Class_model
                        {
                            IDClass = y.IDClass,
                            NameCourse = z.Name,
                            NameClass = y.NameClass,
                            StartDay = y.StartDay,
                            FinishDay = y.FinishDay,
                            Number = y.Number,
                            State = y.State
                        }).Distinct();
            return list.ToList().Distinct();
        }
        
       
        
    }
}