using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.Areas.USER.Models;
namespace doan_htttdn.Areas.ViewModel
{
    public class CheckBoxList
    {
        public IList<Article1> AvariableCheck { get; set; }
        public IList<Article1> SelectedCheck { get; set; }
        public ChooseCheck choosedcheck { get; set; }
    }
    public class ChooseCheck
    {
        public int[] arid { get; set; }
    }
}