using doan_htttdn.FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doan_htttdn.DAO.TinTuc
{
    public class DAO_TinTuc
    {
        public QL_SCN dbb = new QL_SCN();
        public List<ARTICLE> Get_Article()
        {
            return dbb.ARTICLEs.ToList();
        }
        public List<ARTICLE> Search_Article(string key)
        {
            return dbb.ARTICLEs.Where(x => x.Title.Contains(key)).ToList();
        }
        public ARTICLE Get_DetailArticle(string id)
        {
            int change = int.Parse(id);
            var bien = dbb.ARTICLEs.Where(x => x.ID_Article == change).SingleOrDefault();
            return bien;
        }
        public bool Update_ARTICLEs(ARTICLE article)
        {
            var bien = dbb.ARTICLEs.Where(x => x.ID_Article == article.ID_Article).SingleOrDefault();
            if (bien != null)
            {
                bien.Title = article.Title;
                bien.Summary = article.Summary;
                bien.Contents = article.Contents;
                bien.Day = article.Day;
                bien.Image = article.Image;
                bien.IDAdmin = article.IDAdmin;
                bien.ID_Menu = article.ID_Menu;
                dbb.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public bool check_id(string id)
        {
            int cateid = int.Parse(id);
            var bien = dbb.ARTICLEs.Where(x => x.ID_Article == cateid);
            if (bien != null)
                return true;
            else
                return false;
        }
        public bool Insert_Article(ARTICLE article)
        {
            
                try
                {
                    dbb.ARTICLEs.Add(article);
                    dbb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            

        }
        public bool ExitArticle(string id)
        {
            int cateid = int.Parse(id);
            var bien = dbb.ARTICLEs.Where(x => x.ID_Article == cateid).SingleOrDefault();
            if (bien != null)
                return true;
            else
                return false;
        }
        public bool Delete_Article(string id)
        {
            int cateid = int.Parse(id);
            var bien = dbb.ARTICLEs.Where(x => x.ID_Article == cateid).SingleOrDefault();
            if (bien != null)
            {
                
                    dbb.ARTICLEs.Remove(bien);
                    dbb.SaveChanges();
                    return true;
                
               
            }
            return false;
        }
    }
}