using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClssApplication2.Models;
using ClssApplication2.DataAccessLayer;

namespace ClssApplication2.BusinessLayer
{
    public class ClassBusinessLayer
    {
        public void Add(Class classed)
        {
            //设置上下文生存期
            using (var db = new ClassgoingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                db.Classes.Add(classed);
                //保存状态改变
                db.SaveChanges();
            }
        }
        public List<Class> Query()
        {
            using (var db = new ClassgoingContext())
            {
                var query = from b in db.Classes
                            orderby b.ClassName
                            select b;
                return db.Classes.ToList();
            }
        }
        public Class Query(int Classid)
        {
            using (var db = new ClassgoingContext())
            {
                return db.Classes.Find(Classid);
            }
        }
        public void Update(Class classed)
        {
            //设置上下文生存期
            using (var db = new ClassgoingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                db.Entry(classed).State = EntityState.Modified;
                //保存状态改变
                db.SaveChanges();
            }

        }
        public void Delete(Class classed)
        {
            //设置上下文生存期
            using (var db = new ClassgoingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                db.Entry(classed).State = EntityState.Deleted;
                //保存状态改变
                db.SaveChanges();
            }
        }
    }
}
