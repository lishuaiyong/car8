﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using MyCmn;
//using MyOql;
//using MyCon;
//using MyBiz;
//using DbEnt;
//using MyBiz.Admin;

//namespace MyWeb.Areas.Admin.Controllers
//{
//    public partial class PowerTableController : MyMvcController
//    {
        
//        public ActionResult List()
//        {
//            return View();
//        }
        
//        [HttpPost]
//        public ActionResult Query(string uid,PowerTableBiz.QueryModel Query)
//        {
//            return PowerTableBiz.Query( Query ) .LoadFlexiGrid();
//        }
	 
//        [HttpPost]
//        public ActionResult Delete(string uid,FormCollection collection)
//        {           
//            if (MySession.Get(MySessionKey.UserID).HasValue() == false)
//            {
//                return new JsonMsg(){ msg = "会话超时,请登录!" };
//            }

//            string[] delIds = collection["query"].Split(',');
//            return PowerTableBiz.Delete( delIds ) ;
//        }

//        public ActionResult Detail(Int32 uid)
//        {
//            return View("Card", dbr.PowerTable.FindById(uid));
//        }
//        public ActionResult Add(string uid)
//        {
//            return View("Card", new PowerTableRule.Entity());
//        }

//        [HttpPost]
//        public ActionResult Add(string uid,PowerTableRule.Entity Entity)
//        {
//            if (MySession.Get(MySessionKey.UserID).HasValue() == false)
//            {
//                return new JsonMsg(){ msg =  "会话超时,请登录!" }  ;
//            }

//            //没有消息,就是好消息.
//            var jm = PowerTableBiz.Add(Entity) ;
 
//            return jm ;
//        }

//        public ActionResult Update(Int32 uid)
//        {
//            return View("Card",dbr.PowerTable.FindById(uid));
//        }

//        [HttpPost]
//        public ActionResult Update(Int32 uid, PowerTableRule.Entity Entity)
//        {
//            if (MySession.Get(MySessionKey.UserID).HasValue() == false)
//            {
//                return new JsonMsg(){ msg =  "会话超时,请登录!" } ;
//            }

//            //没有消息,就是好消息.
//            var jm = PowerTableBiz.Update(Entity) ;
 
//            return jm ;
//        }

//    }
//}
