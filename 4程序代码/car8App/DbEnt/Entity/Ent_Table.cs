﻿//系统自动生成的实体，不能修改。 By: UDI-PC.  At:2013-11-15 13:05:54
using System;
using MyOql;
using MyCmn;
using System.Linq;
using System.Data ;
using System.Data.Common ;
using System.Collections.Generic;
using System.Runtime.Serialization ;
using DbEnt;

namespace DbEnt
{


    
    /// <summary>
    /// 部门附件
    /// </summary>
    [Serializable]
    public sealed partial class DeptAnnexRule : RuleBase, ITableRule,ICloneable
    {


        public  DeptAnnexRule() : base("DeptAnnex")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.DeptID = new SimpleColumn(this, DbType.Int32, 4,"DeptID","DeptID",false);
            this.Key = new SimpleColumn(this, DbType.AnsiString, 50,"Key","Key",true);
            this.AnnexID = new SimpleColumn(this, DbType.Int32, 4,"AnnexID","AnnexID",false);
            this.SortID = new SimpleColumn(this, DbType.Int32, 4,"SortID","SortID",true);
        }

        /// <summary>
        /// ID(Int32)[主键(ID),自增键]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// 部门ID(Int32)[外键(DeptID=TB_Dept:ID)]
        /// </summary>
        public SimpleColumn DeptID { get; set; }
        /// <summary>
        /// 键(AnsiString)
        /// </summary>
        public SimpleColumn Key { get; set; }
        /// <summary>
        /// 附件ID(Int32)[外键(AnnexID=Annex:ID)]
        /// </summary>
        public SimpleColumn AnnexID { get; set; }
        /// <summary>
        /// 排序数(Int32)
        /// </summary>
        public SimpleColumn SortID { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,DeptID,Key,AnnexID,SortID }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Id };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return Id; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "TB_DeptAnnex"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute() ;
        }


        public override object Clone()
        {
            var tab = new DeptAnnexRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.DeptID = this.DeptID.Clone() as SimpleColumn;
            tab.Key = this.Key.Clone() as SimpleColumn;
            tab.AnnexID = this.AnnexID.Clone() as SimpleColumn;
            tab.SortID = this.SortID.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        /// 部门附件 
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 部门附件
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[主键(ID),自增键]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// 部门ID[外键(DeptID=TB_Dept:ID)]
            /// </summary>
            public Int32 DeptID { get; set; }
 
            /// <summary>
            /// 键
            /// </summary>
            public DeptAnnexKeyEnum Key { get; set; }
 
            /// <summary>
            /// 附件ID[外键(AnnexID=Annex:ID)]
            /// </summary>
            public Int32 AnnexID { get; set; }
 
            /// <summary>
            /// 排序数
            /// </summary>
            public Int32 SortID { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "DeptID" ) { this.DeptID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Key" ) { this.Key = ValueProc.As<DeptAnnexKeyEnum>(Value) ; return true; }
                if ( PropertyName == "AnnexID" ) { this.AnnexID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "SortID" ) { this.SortID = ValueProc.As<Int32>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "DeptID" ) { return this.DeptID ; }
                if ( PropertyName == "Key" ) { return this.Key ; }
                if ( PropertyName == "AnnexID" ) { return this.AnnexID ; }
                if ( PropertyName == "SortID" ) { return this.SortID ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","DeptID","Key","AnnexID","SortID" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

            private DeptRule.Entity _GetDept = null;
            public DeptRule.Entity GetDept()
            {
                if (_GetDept != null) return _GetDept;
                _GetDept = dbr.Dept.FindById(this.DeptID);
                return _GetDept;
            }
            private AnnexRule.Entity _GetAnnex = null;
            public AnnexRule.Entity GetAnnex()
            {
                if (_GetAnnex != null) return _GetAnnex;
                _GetAnnex = dbr.Annex.FindById(this.AnnexID);
                return _GetAnnex;
            }
         }
    }


    
    /// <summary>
    /// 用户
    /// </summary>
    [Serializable]
    public sealed partial class PersonRule : RuleBase, ITableRule,ICloneable
    {


        public  PersonRule() : base("Person")
        {
            this.UserID = new SimpleColumn(this, DbType.AnsiString, 50,"UserID","UserID",false);
            this.Password = new SimpleColumn(this, DbType.Binary, 50,"Password","Password",true);
            this.Name = new SimpleColumn(this, DbType.AnsiString, 50,"Name","Name",true);
            this.Logo = new SimpleColumn(this, DbType.Int32, 4,"Logo","Logo",true);
            this.BirthDay = new SimpleColumn(this, DbType.DateTime, 8,"BirthDay","BirthDay",true);
            this.IDCard = new SimpleColumn(this, DbType.AnsiString, 30,"IDCard","IDCard",true);
            this.DeptID = new SimpleColumn(this, DbType.Int32, 4,"DeptID","DeptID",true);
            this.Email = new SimpleColumn(this, DbType.AnsiString, 50,"Email","Email",true);
            this.Sex = new SimpleColumn(this, DbType.AnsiString, 10,"Sex","Sex",true);
            this.Mobile = new SimpleColumn(this, DbType.AnsiString, 50,"Mobile","Mobile",true);
            this.Phone = new SimpleColumn(this, DbType.AnsiString, 50,"Phone","Phone",true);
            this.SortID = new SimpleColumn(this, DbType.Int32, 4,"SortID","SortID",true);
            this.Msn = new SimpleColumn(this, DbType.AnsiString, 50,"Msn","MSN",true);
            this.Qq = new SimpleColumn(this, DbType.AnsiString, 50,"Qq","QQ",true);
            this.Power = new SimpleColumn(this, DbType.AnsiString, 4000,"Power","Power",true);
            this.NotPower = new SimpleColumn(this, DbType.AnsiString, 4000,"NotPower","NotPower",true);
        }

        /// <summary>
        /// 用户ID(AnsiString)[主键(UserID)]
        /// </summary>
        public SimpleColumn UserID { get; set; }
        /// <summary>
        /// 密码(Binary)
        /// </summary>
        public SimpleColumn Password { get; set; }
        /// <summary>
        /// 名称(AnsiString)
        /// </summary>
        public SimpleColumn Name { get; set; }
        /// <summary>
        /// 头像(Int32)[外键(Logo=Annex:ID)]
        /// </summary>
        public SimpleColumn Logo { get; set; }
        /// <summary>
        /// 生日(DateTime)
        /// </summary>
        public SimpleColumn BirthDay { get; set; }
        /// <summary>
        /// 身份证(AnsiString)
        /// </summary>
        public SimpleColumn IDCard { get; set; }
        /// <summary>
        /// DeptID(Int32)[外键(DeptID=TB_Dept:ID)]
        /// </summary>
        public SimpleColumn DeptID { get; set; }
        /// <summary>
        /// 邮箱(AnsiString)
        /// </summary>
        public SimpleColumn Email { get; set; }
        /// <summary>
        /// 性别(AnsiString)
        /// </summary>
        public SimpleColumn Sex { get; set; }
        /// <summary>
        /// 手机(AnsiString)
        /// </summary>
        public SimpleColumn Mobile { get; set; }
        /// <summary>
        /// 座机(AnsiString)
        /// </summary>
        public SimpleColumn Phone { get; set; }
        /// <summary>
        /// 排序数(Int32)
        /// </summary>
        public SimpleColumn SortID { get; set; }
        /// <summary>
        /// MSN(AnsiString)
        /// </summary>
        public SimpleColumn Msn { get; set; }
        /// <summary>
        /// QQ(AnsiString)
        /// </summary>
        public SimpleColumn Qq { get; set; }
        /// <summary>
        /// 权限(AnsiString)
        /// </summary>
        public SimpleColumn Power { get; set; }
        /// <summary>
        /// 禁用的权限(AnsiString)
        /// </summary>
        public SimpleColumn NotPower { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { UserID,Password,Name,Logo,BirthDay,IDCard,DeptID,Email,Sex,Mobile,Phone,SortID,Msn,Qq,Power,NotPower }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { UserID };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return null; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "TB_Person"; }

        public Entity FindByUserID(String UserID)
        {
            if ( UserID.HasValue() == false ) return null ;
            return this.SelectWhere(o => o.UserID == UserID).ToEntity<Entity>();
        }
        public int DeleteByUserID(String UserID)
        {
            if ( UserID.HasValue() == false ) return 0 ;
            return this.Delete(o => o.UserID == UserID).Execute() ;
        }


        public override object Clone()
        {
            var tab = new PersonRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.UserID = this.UserID.Clone() as SimpleColumn;
            tab.Password = this.Password.Clone() as SimpleColumn;
            tab.Name = this.Name.Clone() as SimpleColumn;
            tab.Logo = this.Logo.Clone() as SimpleColumn;
            tab.BirthDay = this.BirthDay.Clone() as SimpleColumn;
            tab.IDCard = this.IDCard.Clone() as SimpleColumn;
            tab.DeptID = this.DeptID.Clone() as SimpleColumn;
            tab.Email = this.Email.Clone() as SimpleColumn;
            tab.Sex = this.Sex.Clone() as SimpleColumn;
            tab.Mobile = this.Mobile.Clone() as SimpleColumn;
            tab.Phone = this.Phone.Clone() as SimpleColumn;
            tab.SortID = this.SortID.Clone() as SimpleColumn;
            tab.Msn = this.Msn.Clone() as SimpleColumn;
            tab.Qq = this.Qq.Clone() as SimpleColumn;
            tab.Power = this.Power.Clone() as SimpleColumn;
            tab.NotPower = this.NotPower.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        /// 用户 
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 用户
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// 用户ID[主键(UserID)]
            /// </summary>
            public String UserID { get; set; }
 
            /// <summary>
            /// 密码
            /// </summary>
            public Byte[] Password { get; set; }
 
            /// <summary>
            /// 名称
            /// </summary>
            public String Name { get; set; }
 
            /// <summary>
            /// 头像[外键(Logo=Annex:ID)]
            /// </summary>
            public Int32 Logo { get; set; }
 
            /// <summary>
            /// 生日
            /// </summary>
            public MyDate BirthDay { get; set; }
 
            /// <summary>
            /// 身份证
            /// </summary>
            public String IDCard { get; set; }
 
            /// <summary>
            /// DeptID[外键(DeptID=TB_Dept:ID)]
            /// </summary>
            public Int32 DeptID { get; set; }
 
            /// <summary>
            /// 邮箱
            /// </summary>
            public String Email { get; set; }
 
            /// <summary>
            /// 性别
            /// </summary>
            public OrgSexEnum Sex { get; set; }
 
            /// <summary>
            /// 手机
            /// </summary>
            public String Mobile { get; set; }
 
            /// <summary>
            /// 座机
            /// </summary>
            public String Phone { get; set; }
 
            /// <summary>
            /// 排序数
            /// </summary>
            public Int32 SortID { get; set; }
 
            /// <summary>
            /// MSN
            /// </summary>
            public String Msn { get; set; }
 
            /// <summary>
            /// QQ
            /// </summary>
            public String Qq { get; set; }
 
            /// <summary>
            /// 权限
            /// </summary>
            public String Power { get; set; }
 
            /// <summary>
            /// 禁用的权限
            /// </summary>
            public String NotPower { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "UserID" ) { this.UserID = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Password" ) { this.Password = ValueProc.As<Byte[]>(Value) ; return true; }
                if ( PropertyName == "Name" ) { this.Name = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Logo" ) { this.Logo = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "BirthDay" ) { this.BirthDay = ValueProc.As<MyDate>(Value) ; return true; }
                if ( PropertyName == "IDCard" ) { this.IDCard = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "DeptID" ) { this.DeptID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Email" ) { this.Email = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Sex" ) { this.Sex = ValueProc.As<OrgSexEnum>(Value) ; return true; }
                if ( PropertyName == "Mobile" ) { this.Mobile = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Phone" ) { this.Phone = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "SortID" ) { this.SortID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Msn" ) { this.Msn = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Qq" ) { this.Qq = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Power" ) { this.Power = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "NotPower" ) { this.NotPower = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "UserID" ) { return this.UserID ; }
                if ( PropertyName == "Password" ) { return this.Password ; }
                if ( PropertyName == "Name" ) { return this.Name ; }
                if ( PropertyName == "Logo" ) { return this.Logo ; }
                if ( PropertyName == "BirthDay" ) { return this.BirthDay ; }
                if ( PropertyName == "IDCard" ) { return this.IDCard ; }
                if ( PropertyName == "DeptID" ) { return this.DeptID ; }
                if ( PropertyName == "Email" ) { return this.Email ; }
                if ( PropertyName == "Sex" ) { return this.Sex ; }
                if ( PropertyName == "Mobile" ) { return this.Mobile ; }
                if ( PropertyName == "Phone" ) { return this.Phone ; }
                if ( PropertyName == "SortID" ) { return this.SortID ; }
                if ( PropertyName == "Msn" ) { return this.Msn ; }
                if ( PropertyName == "Qq" ) { return this.Qq ; }
                if ( PropertyName == "Power" ) { return this.Power ; }
                if ( PropertyName == "NotPower" ) { return this.NotPower ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "UserID","Password","Name","Logo","BirthDay","IDCard","DeptID","Email","Sex","Mobile","Phone","SortID","Msn","Qq","Power","NotPower" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

            private AnnexRule.Entity _GetAnnex = null;
            public AnnexRule.Entity GetAnnex()
            {
                if (_GetAnnex != null) return _GetAnnex;
                _GetAnnex = dbr.Annex.FindById(this.Logo);
                return _GetAnnex;
            }
            private DeptRule.Entity _GetDept = null;
            public DeptRule.Entity GetDept()
            {
                if (_GetDept != null) return _GetDept;
                _GetDept = dbr.Dept.FindById(this.DeptID);
                return _GetDept;
            }
         }
    }


    
    /// <summary>
    /// 部门
    /// </summary>
    [Serializable]
    public sealed partial class DeptRule : RuleBase, ITableRule,ICloneable
    {


        public  DeptRule() : base("Dept")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.Pid = new SimpleColumn(this, DbType.Int32, 4,"Pid","PID",false);
            this.Wbs = new SimpleColumn(this, DbType.AnsiString, 50,"Wbs","Wbs",true);
            this.WebName = new SimpleColumn(this, DbType.AnsiString, 50,"WebName","WebName",true);
            this.Name = new SimpleColumn(this, DbType.AnsiString, 200,"Name","Name",true);
            this.Logo = new SimpleColumn(this, DbType.Int32, 4,"Logo","Logo",true);
            this.Title = new SimpleColumn(this, DbType.Int32, 4,"Title","Title",true);
            this.Address = new SimpleColumn(this, DbType.AnsiString, 100,"Address","Address",true);
            this.Phone = new SimpleColumn(this, DbType.AnsiString, 50,"Phone","Phone",true);
            this.Detail = new SimpleColumn(this, DbType.AnsiString, -1,"Detail","Detail",true);
            this.Profile = new SimpleColumn(this, DbType.AnsiString, -1,"Profile","Profile",true);
            this.About = new SimpleColumn(this, DbType.AnsiString, -1,"About","About",true);
            this.SortID = new SimpleColumn(this, DbType.Int32, 4,"SortID","SortID",false);
            this.KeyWords = new SimpleColumn(this, DbType.AnsiString, 100,"KeyWords","KeyWords",true);
            this.Langs = new SimpleColumn(this, DbType.AnsiString, 50,"Langs","Langs",true);
            this.DefaultLang = new SimpleColumn(this, DbType.AnsiString, 50,"DefaultLang","DefaultLang",true);
            this.AddTime = new SimpleColumn(this, DbType.DateTime, 8,"AddTime","AddTime",true);
            this.BizType = new SimpleColumn(this, DbType.Int32, 4,"BizType","BizType",false);
            this.EndTime = new SimpleColumn(this, DbType.DateTime, 8,"EndTime","EndTime",false);
            this.MySkin = new SimpleColumn(this, DbType.AnsiString, 50,"MySkin","MySkin",true);
            this.GisPos = new SimpleColumn(this, DbType.AnsiString, 50,"GisPos","GisPos",true);
            this.Power = new SimpleColumn(this, DbType.AnsiString, 4000,"Power","Power",true);
            this.TitleExtend = new SimpleColumn(this, DbType.Int32, 4,"TitleExtend","TitleExtend",true);
        }

        /// <summary>
        /// ID(Int32)[主键(ID)]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// 父ID(Int32)
        /// </summary>
        public SimpleColumn Pid { get; set; }
        /// <summary>
        /// 从根到父节点的路径(AnsiString)
        /// </summary>
        public SimpleColumn Wbs { get; set; }
        /// <summary>
        /// 二级域名的名字(AnsiString)[唯一键(WebName)]
        /// </summary>
        public SimpleColumn WebName { get; set; }
        /// <summary>
        /// 名称(AnsiString)
        /// </summary>
        public SimpleColumn Name { get; set; }
        /// <summary>
        /// 头像(Int32)[外键(Logo=Annex:ID)]
        /// </summary>
        public SimpleColumn Logo { get; set; }
        /// <summary>
        /// 公司条幅(Int32)[外键(Title=Annex:ID)]
        /// </summary>
        public SimpleColumn Title { get; set; }
        /// <summary>
        /// 地址(AnsiString)
        /// </summary>
        public SimpleColumn Address { get; set; }
        /// <summary>
        /// 座机(AnsiString)
        /// </summary>
        public SimpleColumn Phone { get; set; }
        /// <summary>
        /// 公司介绍(AnsiString)
        /// </summary>
        public SimpleColumn Detail { get; set; }
        /// <summary>
        /// Profile(AnsiString)
        /// </summary>
        public SimpleColumn Profile { get; set; }
        /// <summary>
        /// 关于我们(AnsiString)
        /// </summary>
        public SimpleColumn About { get; set; }
        /// <summary>
        /// 排序数(Int32)
        /// </summary>
        public SimpleColumn SortID { get; set; }
        /// <summary>
        /// 关键字(AnsiString)
        /// </summary>
        public SimpleColumn KeyWords { get; set; }
        /// <summary>
        /// 语言(AnsiString)
        /// </summary>
        public SimpleColumn Langs { get; set; }
        /// <summary>
        /// 默认语言(AnsiString)
        /// </summary>
        public SimpleColumn DefaultLang { get; set; }
        /// <summary>
        /// 添加时间(DateTime)
        /// </summary>
        public SimpleColumn AddTime { get; set; }
        /// <summary>
        /// 业务类型(Int32)
        /// </summary>
        public SimpleColumn BizType { get; set; }
        /// <summary>
        /// 结束时间(DateTime)
        /// </summary>
        public SimpleColumn EndTime { get; set; }
        /// <summary>
        /// 我的皮肤(AnsiString)
        /// </summary>
        public SimpleColumn MySkin { get; set; }
        /// <summary>
        /// 地理坐标(AnsiString)
        /// </summary>
        public SimpleColumn GisPos { get; set; }
        /// <summary>
        /// 权限(AnsiString)
        /// </summary>
        public SimpleColumn Power { get; set; }
        /// <summary>
        /// TitleExtend(Int32)[外键(TitleExtend=Annex:ID)]
        /// </summary>
        public SimpleColumn TitleExtend { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,Pid,Wbs,WebName,Name,Logo,Title,Address,Phone,Detail,Profile,About,SortID,KeyWords,Langs,DefaultLang,AddTime,BizType,EndTime,MySkin,GisPos,Power,TitleExtend }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Id };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return null; }
        public override SimpleColumn GetUniqueKey() { return  WebName; }
        public override string GetDbName() { return "TB_Dept"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute() ;
        }

        public Entity FindByWebName(String WebName)
        {
             if ( WebName.HasValue() == false ) return null ;
            return this.SelectWhere(o => o.WebName == WebName).ToEntity<Entity>();
        }
        public int DeleteByWebName(String WebName)
        {
             if ( WebName.HasValue() == false ) return 0 ;
            return this.Delete(o => o.WebName == WebName).Execute();
        }

        public override object Clone()
        {
            var tab = new DeptRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.Pid = this.Pid.Clone() as SimpleColumn;
            tab.Wbs = this.Wbs.Clone() as SimpleColumn;
            tab.WebName = this.WebName.Clone() as SimpleColumn;
            tab.Name = this.Name.Clone() as SimpleColumn;
            tab.Logo = this.Logo.Clone() as SimpleColumn;
            tab.Title = this.Title.Clone() as SimpleColumn;
            tab.Address = this.Address.Clone() as SimpleColumn;
            tab.Phone = this.Phone.Clone() as SimpleColumn;
            tab.Detail = this.Detail.Clone() as SimpleColumn;
            tab.Profile = this.Profile.Clone() as SimpleColumn;
            tab.About = this.About.Clone() as SimpleColumn;
            tab.SortID = this.SortID.Clone() as SimpleColumn;
            tab.KeyWords = this.KeyWords.Clone() as SimpleColumn;
            tab.Langs = this.Langs.Clone() as SimpleColumn;
            tab.DefaultLang = this.DefaultLang.Clone() as SimpleColumn;
            tab.AddTime = this.AddTime.Clone() as SimpleColumn;
            tab.BizType = this.BizType.Clone() as SimpleColumn;
            tab.EndTime = this.EndTime.Clone() as SimpleColumn;
            tab.MySkin = this.MySkin.Clone() as SimpleColumn;
            tab.GisPos = this.GisPos.Clone() as SimpleColumn;
            tab.Power = this.Power.Clone() as SimpleColumn;
            tab.TitleExtend = this.TitleExtend.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        /// 部门 
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 部门
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[主键(ID)]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// 父ID
            /// </summary>
            public Int32 Pid { get; set; }
 
            /// <summary>
            /// 从根到父节点的路径
            /// </summary>
            public String Wbs { get; set; }
 
            /// <summary>
            /// 二级域名的名字[唯一键(WebName)]
            /// </summary>
            public String WebName { get; set; }
 
            /// <summary>
            /// 名称
            /// </summary>
            public String Name { get; set; }
 
            /// <summary>
            /// 头像[外键(Logo=Annex:ID)]
            /// </summary>
            public Int32 Logo { get; set; }
 
            /// <summary>
            /// 公司条幅[外键(Title=Annex:ID)]
            /// </summary>
            public Int32 Title { get; set; }
 
            /// <summary>
            /// 地址
            /// </summary>
            public String Address { get; set; }
 
            /// <summary>
            /// 座机
            /// </summary>
            public String Phone { get; set; }
 
            /// <summary>
            /// 公司介绍
            /// </summary>
            public String Detail { get; set; }
 
            /// <summary>
            /// Profile
            /// </summary>
            public String Profile { get; set; }
 
            /// <summary>
            /// 关于我们
            /// </summary>
            public String About { get; set; }
 
            /// <summary>
            /// 排序数
            /// </summary>
            public Int32 SortID { get; set; }
 
            /// <summary>
            /// 关键字
            /// </summary>
            public String KeyWords { get; set; }
 
            /// <summary>
            /// 语言
            /// </summary>
            public String Langs { get; set; }
 
            /// <summary>
            /// 默认语言
            /// </summary>
            public String DefaultLang { get; set; }
 
            /// <summary>
            /// 添加时间
            /// </summary>
            public MyDate AddTime { get; set; }
 
            /// <summary>
            /// 业务类型
            /// </summary>
            public DeptBizTypeEnum BizType { get; set; }
 
            /// <summary>
            /// 结束时间
            /// </summary>
            public MyDate EndTime { get; set; }
 
            /// <summary>
            /// 我的皮肤
            /// </summary>
            public String MySkin { get; set; }
 
            /// <summary>
            /// 地理坐标
            /// </summary>
            public String GisPos { get; set; }
 
            /// <summary>
            /// 权限
            /// </summary>
            public String Power { get; set; }
 
            /// <summary>
            /// TitleExtend[外键(TitleExtend=Annex:ID)]
            /// </summary>
            public Int32 TitleExtend { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Pid" ) { this.Pid = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Wbs" ) { this.Wbs = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "WebName" ) { this.WebName = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Name" ) { this.Name = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Logo" ) { this.Logo = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Title" ) { this.Title = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Address" ) { this.Address = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Phone" ) { this.Phone = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Detail" ) { this.Detail = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Profile" ) { this.Profile = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "About" ) { this.About = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "SortID" ) { this.SortID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "KeyWords" ) { this.KeyWords = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Langs" ) { this.Langs = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "DefaultLang" ) { this.DefaultLang = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "AddTime" ) { this.AddTime = ValueProc.As<MyDate>(Value) ; return true; }
                if ( PropertyName == "BizType" ) { this.BizType = ValueProc.As<DeptBizTypeEnum>(Value) ; return true; }
                if ( PropertyName == "EndTime" ) { this.EndTime = ValueProc.As<MyDate>(Value) ; return true; }
                if ( PropertyName == "MySkin" ) { this.MySkin = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "GisPos" ) { this.GisPos = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Power" ) { this.Power = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "TitleExtend" ) { this.TitleExtend = ValueProc.As<Int32>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "Pid" ) { return this.Pid ; }
                if ( PropertyName == "Wbs" ) { return this.Wbs ; }
                if ( PropertyName == "WebName" ) { return this.WebName ; }
                if ( PropertyName == "Name" ) { return this.Name ; }
                if ( PropertyName == "Logo" ) { return this.Logo ; }
                if ( PropertyName == "Title" ) { return this.Title ; }
                if ( PropertyName == "Address" ) { return this.Address ; }
                if ( PropertyName == "Phone" ) { return this.Phone ; }
                if ( PropertyName == "Detail" ) { return this.Detail ; }
                if ( PropertyName == "Profile" ) { return this.Profile ; }
                if ( PropertyName == "About" ) { return this.About ; }
                if ( PropertyName == "SortID" ) { return this.SortID ; }
                if ( PropertyName == "KeyWords" ) { return this.KeyWords ; }
                if ( PropertyName == "Langs" ) { return this.Langs ; }
                if ( PropertyName == "DefaultLang" ) { return this.DefaultLang ; }
                if ( PropertyName == "AddTime" ) { return this.AddTime ; }
                if ( PropertyName == "BizType" ) { return this.BizType ; }
                if ( PropertyName == "EndTime" ) { return this.EndTime ; }
                if ( PropertyName == "MySkin" ) { return this.MySkin ; }
                if ( PropertyName == "GisPos" ) { return this.GisPos ; }
                if ( PropertyName == "Power" ) { return this.Power ; }
                if ( PropertyName == "TitleExtend" ) { return this.TitleExtend ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","Pid","Wbs","WebName","Name","Logo","Title","Address","Phone","Detail","Profile","About","SortID","KeyWords","Langs","DefaultLang","AddTime","BizType","EndTime","MySkin","GisPos","Power","TitleExtend" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

            private AnnexRule.Entity _GetAnnexByLogo = null;
            public AnnexRule.Entity GetAnnexByLogo()
            {
                if (_GetAnnexByLogo != null) return _GetAnnexByLogo;
                _GetAnnexByLogo = dbr.Annex.FindById(this.Logo);
                return _GetAnnexByLogo;
            }
            private AnnexRule.Entity _GetAnnexByTitle = null;
            public AnnexRule.Entity GetAnnexByTitle()
            {
                if (_GetAnnexByTitle != null) return _GetAnnexByTitle;
                _GetAnnexByTitle = dbr.Annex.FindById(this.Title);
                return _GetAnnexByTitle;
            }
            private AnnexRule.Entity _GetAnnexByTitleExtend = null;
            public AnnexRule.Entity GetAnnexByTitleExtend()
            {
                if (_GetAnnexByTitleExtend != null) return _GetAnnexByTitleExtend;
                _GetAnnexByTitleExtend = dbr.Annex.FindById(this.TitleExtend);
                return _GetAnnexByTitleExtend;
            }
            private DeptAnnexRule.Entity[] _GetDeptAnnexs = null;
            public DeptAnnexRule.Entity[] GetDeptAnnexs()
            {
                if (_GetDeptAnnexs != null) return _GetDeptAnnexs;
                _GetDeptAnnexs = dbr.DeptAnnex.SelectWhere(o => o.DeptID == this.Id).ToEntityList<DeptAnnexRule.Entity>().ToArray();
                return _GetDeptAnnexs;
            }
            private PersonRule.Entity[] _GetPersons = null;
            public PersonRule.Entity[] GetPersons()
            {
                if (_GetPersons != null) return _GetPersons;
                _GetPersons = dbr.Person.SelectWhere(o => o.DeptID == this.Id).ToEntityList<PersonRule.Entity>().ToArray();
                return _GetPersons;
            }
            private ProductTypeRule.Entity[] _GetProductTypes = null;
            public ProductTypeRule.Entity[] GetProductTypes()
            {
                if (_GetProductTypes != null) return _GetProductTypes;
                _GetProductTypes = dbr.Shop.ProductType.SelectWhere(o => o.DeptID == this.Id).ToEntityList<ProductTypeRule.Entity>().ToArray();
                return _GetProductTypes;
            }
         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class AnnexRule : RuleBase, ITableRule,ICloneable
    {


        public  AnnexRule() : base("Annex")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.Name = new SimpleColumn(this, DbType.AnsiString, 128,"Name","Name",true);
            this.Path = new SimpleColumn(this, DbType.AnsiString, 250,"Path","Path",true);
            this.Ext = new SimpleColumn(this, DbType.AnsiString, 50,"Ext","Ext",true);
            this.FullName = new SimpleColumn(this, DbType.AnsiString, 250,"FullName","FullName",true);
            this.Size = new SimpleColumn(this, DbType.AnsiString, 10,"Size","Size",true);
            this.UserID = new SimpleColumn(this, DbType.AnsiString, 50,"UserID","UserID",false);
            this.AddTime = new SimpleColumn(this, DbType.DateTime, 8,"AddTime","AddTime",true);
            this.PmReferenceID = new SimpleColumn(this, DbType.AnsiString, 100,"PmReferenceID","PmReferenceID",true);
        }

        /// <summary>
        /// ID(Int32)[主键(ID),自增键]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// Name(AnsiString)
        /// </summary>
        public SimpleColumn Name { get; set; }
        /// <summary>
        /// Path(AnsiString)
        /// </summary>
        public SimpleColumn Path { get; set; }
        /// <summary>
        /// Ext(AnsiString)
        /// </summary>
        public SimpleColumn Ext { get; set; }
        /// <summary>
        /// FullName(AnsiString)
        /// </summary>
        public SimpleColumn FullName { get; set; }
        /// <summary>
        /// Size(AnsiString)
        /// </summary>
        public SimpleColumn Size { get; set; }
        /// <summary>
        /// UserID(AnsiString)
        /// </summary>
        public SimpleColumn UserID { get; set; }
        /// <summary>
        /// AddTime(DateTime)
        /// </summary>
        public SimpleColumn AddTime { get; set; }
        /// <summary>
        /// PmReferenceID(AnsiString)
        /// </summary>
        public SimpleColumn PmReferenceID { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,Name,Path,Ext,FullName,Size,UserID,AddTime,PmReferenceID }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Id };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return Id; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "Annex"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute() ;
        }


        public override object Clone()
        {
            var tab = new AnnexRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.Name = this.Name.Clone() as SimpleColumn;
            tab.Path = this.Path.Clone() as SimpleColumn;
            tab.Ext = this.Ext.Clone() as SimpleColumn;
            tab.FullName = this.FullName.Clone() as SimpleColumn;
            tab.Size = this.Size.Clone() as SimpleColumn;
            tab.UserID = this.UserID.Clone() as SimpleColumn;
            tab.AddTime = this.AddTime.Clone() as SimpleColumn;
            tab.PmReferenceID = this.PmReferenceID.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[主键(ID),自增键]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// Name
            /// </summary>
            public String Name { get; set; }
 
            /// <summary>
            /// Path
            /// </summary>
            public String Path { get; set; }
 
            /// <summary>
            /// Ext
            /// </summary>
            public String Ext { get; set; }
 
            /// <summary>
            /// FullName
            /// </summary>
            public String FullName { get; set; }
 
            /// <summary>
            /// Size
            /// </summary>
            public String Size { get; set; }
 
            /// <summary>
            /// UserID
            /// </summary>
            public String UserID { get; set; }
 
            /// <summary>
            /// AddTime
            /// </summary>
            public MyDate AddTime { get; set; }
 
            /// <summary>
            /// PmReferenceID
            /// </summary>
            public String PmReferenceID { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Name" ) { this.Name = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Path" ) { this.Path = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Ext" ) { this.Ext = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "FullName" ) { this.FullName = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Size" ) { this.Size = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "UserID" ) { this.UserID = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "AddTime" ) { this.AddTime = ValueProc.As<MyDate>(Value) ; return true; }
                if ( PropertyName == "PmReferenceID" ) { this.PmReferenceID = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "Name" ) { return this.Name ; }
                if ( PropertyName == "Path" ) { return this.Path ; }
                if ( PropertyName == "Ext" ) { return this.Ext ; }
                if ( PropertyName == "FullName" ) { return this.FullName ; }
                if ( PropertyName == "Size" ) { return this.Size ; }
                if ( PropertyName == "UserID" ) { return this.UserID ; }
                if ( PropertyName == "AddTime" ) { return this.AddTime ; }
                if ( PropertyName == "PmReferenceID" ) { return this.PmReferenceID ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","Name","Path","Ext","FullName","Size","UserID","AddTime","PmReferenceID" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

            private DeptAnnexRule.Entity[] _GetDeptAnnexs = null;
            public DeptAnnexRule.Entity[] GetDeptAnnexs()
            {
                if (_GetDeptAnnexs != null) return _GetDeptAnnexs;
                _GetDeptAnnexs = dbr.DeptAnnex.SelectWhere(o => o.AnnexID == this.Id).ToEntityList<DeptAnnexRule.Entity>().ToArray();
                return _GetDeptAnnexs;
            }
            private PersonRule.Entity[] _GetPersons = null;
            public PersonRule.Entity[] GetPersons()
            {
                if (_GetPersons != null) return _GetPersons;
                _GetPersons = dbr.Person.SelectWhere(o => o.Logo == this.Id).ToEntityList<PersonRule.Entity>().ToArray();
                return _GetPersons;
            }
            private DeptRule.Entity[] _GetDeptsByLogo = null;
            public DeptRule.Entity[] GetDeptsByLogo()
            {
                if (_GetDeptsByLogo != null) return _GetDeptsByLogo;
                _GetDeptsByLogo = dbr.Dept.SelectWhere(o => o.Logo == this.Id).ToEntityList<DeptRule.Entity>().ToArray();
                return _GetDeptsByLogo;
            }
            private DeptRule.Entity[] _GetDeptsByTitle = null;
            public DeptRule.Entity[] GetDeptsByTitle()
            {
                if (_GetDeptsByTitle != null) return _GetDeptsByTitle;
                _GetDeptsByTitle = dbr.Dept.SelectWhere(o => o.Title == this.Id).ToEntityList<DeptRule.Entity>().ToArray();
                return _GetDeptsByTitle;
            }
            private DeptRule.Entity[] _GetDeptsByTitleExtend = null;
            public DeptRule.Entity[] GetDeptsByTitleExtend()
            {
                if (_GetDeptsByTitleExtend != null) return _GetDeptsByTitleExtend;
                _GetDeptsByTitleExtend = dbr.Dept.SelectWhere(o => o.TitleExtend == this.Id).ToEntityList<DeptRule.Entity>().ToArray();
                return _GetDeptsByTitleExtend;
            }
            private NoticeInfoRule.Entity[] _GetNoticeInfos = null;
            public NoticeInfoRule.Entity[] GetNoticeInfos()
            {
                if (_GetNoticeInfos != null) return _GetNoticeInfos;
                _GetNoticeInfos = dbr.Shop.NoticeInfo.SelectWhere(o => o.Logo == this.Id).ToEntityList<NoticeInfoRule.Entity>().ToArray();
                return _GetNoticeInfos;
            }
            private ProductAnnexRule.Entity[] _GetProductAnnexs = null;
            public ProductAnnexRule.Entity[] GetProductAnnexs()
            {
                if (_GetProductAnnexs != null) return _GetProductAnnexs;
                _GetProductAnnexs = dbr.Shop.ProductAnnex.SelectWhere(o => o.AnnexID == this.Id).ToEntityList<ProductAnnexRule.Entity>().ToArray();
                return _GetProductAnnexs;
            }
            private ProductInfoRule.Entity[] _GetProductInfos = null;
            public ProductInfoRule.Entity[] GetProductInfos()
            {
                if (_GetProductInfos != null) return _GetProductInfos;
                _GetProductInfos = dbr.Shop.ProductInfo.SelectWhere(o => o.Logo == this.Id).ToEntityList<ProductInfoRule.Entity>().ToArray();
                return _GetProductInfos;
            }
         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class DictRule : RuleBase, ITableRule,ICloneable
    {


        public  DictRule() : base("Dict")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.Key = new SimpleColumn(this, DbType.AnsiString, 50,"Key","Key",true);
            this.Value = new SimpleColumn(this, DbType.AnsiString, 4000,"Value","Value",true);
            this.Trait = new SimpleColumn(this, DbType.AnsiString, 20,"Trait","Trait",true);
            this.SortID = new SimpleColumn(this, DbType.Int32, 4,"SortID","SortID",true);
            this.DeptID = new SimpleColumn(this, DbType.Int32, 4,"DeptID","DeptID",false);
            this.Group = new SimpleColumn(this, DbType.AnsiString, 50,"Group","Group",true);
        }

        /// <summary>
        /// ID(Int32)[主键(ID),自增键]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// Key(AnsiString)
        /// </summary>
        public SimpleColumn Key { get; set; }
        /// <summary>
        /// Value(AnsiString)
        /// </summary>
        public SimpleColumn Value { get; set; }
        /// <summary>
        /// Trait(AnsiString)
        /// </summary>
        public SimpleColumn Trait { get; set; }
        /// <summary>
        /// SortID(Int32)
        /// </summary>
        public SimpleColumn SortID { get; set; }
        /// <summary>
        /// DeptID(Int32)
        /// </summary>
        public SimpleColumn DeptID { get; set; }
        /// <summary>
        /// Group(AnsiString)
        /// </summary>
        public SimpleColumn Group { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,Key,Value,Trait,SortID,DeptID,Group }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Id };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return Id; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "Dict"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute() ;
        }


        public override object Clone()
        {
            var tab = new DictRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.Key = this.Key.Clone() as SimpleColumn;
            tab.Value = this.Value.Clone() as SimpleColumn;
            tab.Trait = this.Trait.Clone() as SimpleColumn;
            tab.SortID = this.SortID.Clone() as SimpleColumn;
            tab.DeptID = this.DeptID.Clone() as SimpleColumn;
            tab.Group = this.Group.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[主键(ID),自增键]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// Key
            /// </summary>
            public String Key { get; set; }
 
            /// <summary>
            /// Value
            /// </summary>
            public String Value { get; set; }
 
            /// <summary>
            /// Trait
            /// </summary>
            public DictTraitEnum Trait { get; set; }
 
            /// <summary>
            /// SortID
            /// </summary>
            public Int32 SortID { get; set; }
 
            /// <summary>
            /// DeptID
            /// </summary>
            public Int32 DeptID { get; set; }
 
            /// <summary>
            /// Group
            /// </summary>
            public String Group { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Key" ) { this.Key = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Value" ) { this.Value = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Trait" ) { this.Trait = ValueProc.As<DictTraitEnum>(Value) ; return true; }
                if ( PropertyName == "SortID" ) { this.SortID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "DeptID" ) { this.DeptID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Group" ) { this.Group = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "Key" ) { return this.Key ; }
                if ( PropertyName == "Value" ) { return this.Value ; }
                if ( PropertyName == "Trait" ) { return this.Trait ; }
                if ( PropertyName == "SortID" ) { return this.SortID ; }
                if ( PropertyName == "DeptID" ) { return this.DeptID ; }
                if ( PropertyName == "Group" ) { return this.Group ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","Key","Value","Trait","SortID","DeptID","Group" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class ResKeyRule : RuleBase, ITableRule,ICloneable
    {


        public  ResKeyRule() : base("ResKey")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.Key = new SimpleColumn(this, DbType.AnsiString, 250,"Key","Key",false);
            this.Group = new SimpleColumn(this, DbType.AnsiString, 50,"Group","Group",true);
        }

        /// <summary>
        /// ID(Int32)[自增键]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// Key(AnsiString)[主键(Key)]
        /// </summary>
        public SimpleColumn Key { get; set; }
        /// <summary>
        /// Group(AnsiString)
        /// </summary>
        public SimpleColumn Group { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,Key,Group }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Key };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return Id; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "ResKey"; }

        public Entity FindByKey(String Key)
        {
            if ( Key.HasValue() == false ) return null ;
            return this.SelectWhere(o => o.Key == Key).ToEntity<Entity>();
        }
        public int DeleteByKey(String Key)
        {
            if ( Key.HasValue() == false ) return 0 ;
            return this.Delete(o => o.Key == Key).Execute() ;
        }
        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute();
        }


        public override object Clone()
        {
            var tab = new ResKeyRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.Key = this.Key.Clone() as SimpleColumn;
            tab.Group = this.Group.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[自增键]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// Key[主键(Key)]
            /// </summary>
            public String Key { get; set; }
 
            /// <summary>
            /// Group
            /// </summary>
            public String Group { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Key" ) { this.Key = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Group" ) { this.Group = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "Key" ) { return this.Key ; }
                if ( PropertyName == "Group" ) { return this.Group ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","Key","Group" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class ResValueRule : RuleBase, ITableRule,ICloneable
    {


        public  ResValueRule() : base("ResValue")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.Lang = new SimpleColumn(this, DbType.Int32, 4,"Lang","Lang",false);
            this.ResID = new SimpleColumn(this, DbType.Int32, 4,"ResID","ResID",false);
            this.Value = new SimpleColumn(this, DbType.AnsiString, 2500,"Value","Value",true);
        }

        /// <summary>
        /// ID(Int32)[自增键]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// Lang(Int32)[主键(Lang,ResID)]
        /// </summary>
        public SimpleColumn Lang { get; set; }
        /// <summary>
        /// ResID(Int32)[主键(Lang,ResID)]
        /// </summary>
        public SimpleColumn ResID { get; set; }
        /// <summary>
        /// Value(AnsiString)
        /// </summary>
        public SimpleColumn Value { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,Lang,ResID,Value }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Lang,ResID };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return Id; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "ResValue"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute();
        }

        public Entity FindByPks(LangEnum Lang,Int32 ResID)
        {
            return this.SelectWhere(o => o.Lang == Lang&o.ResID == ResID).ToEntity<Entity>();
        }
        public int DeleteByPks(LangEnum Lang,Int32 ResID)
        {
            return  this.Delete(o => o.Lang == Lang&o.ResID == ResID).Execute();
        }

        public override object Clone()
        {
            var tab = new ResValueRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.Lang = this.Lang.Clone() as SimpleColumn;
            tab.ResID = this.ResID.Clone() as SimpleColumn;
            tab.Value = this.Value.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[自增键]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// Lang[主键(Lang,ResID)]
            /// </summary>
            public LangEnum Lang { get; set; }
 
            /// <summary>
            /// ResID[主键(Lang,ResID)]
            /// </summary>
            public Int32 ResID { get; set; }
 
            /// <summary>
            /// Value
            /// </summary>
            public String Value { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Lang" ) { this.Lang = ValueProc.As<LangEnum>(Value) ; return true; }
                if ( PropertyName == "ResID" ) { this.ResID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Value" ) { this.Value = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "Lang" ) { return this.Lang ; }
                if ( PropertyName == "ResID" ) { return this.ResID ; }
                if ( PropertyName == "Value" ) { return this.Value ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","Lang","ResID","Value" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class PowerControllerRule : RuleBase, ITableRule,ICloneable
    {


        public  PowerControllerRule() : base("PowerController")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.Area = new SimpleColumn(this, DbType.AnsiString, 50,"Area","Area",true);
            this.Controller = new SimpleColumn(this, DbType.AnsiString, 50,"Controller","Controller",true);
            this.Descr = new SimpleColumn(this, DbType.AnsiString, 150,"Descr","Descr",true);
        }

        /// <summary>
        /// ID(Int32)[主键(ID),自增键]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// Area(AnsiString)
        /// </summary>
        public SimpleColumn Area { get; set; }
        /// <summary>
        /// Controller(AnsiString)
        /// </summary>
        public SimpleColumn Controller { get; set; }
        /// <summary>
        /// Descr(AnsiString)
        /// </summary>
        public SimpleColumn Descr { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,Area,Controller,Descr }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Id };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return Id; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "PowerController"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute() ;
        }


        public override object Clone()
        {
            var tab = new PowerControllerRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.Area = this.Area.Clone() as SimpleColumn;
            tab.Controller = this.Controller.Clone() as SimpleColumn;
            tab.Descr = this.Descr.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[主键(ID),自增键]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// Area
            /// </summary>
            public String Area { get; set; }
 
            /// <summary>
            /// Controller
            /// </summary>
            public String Controller { get; set; }
 
            /// <summary>
            /// Descr
            /// </summary>
            public String Descr { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Area" ) { this.Area = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Controller" ) { this.Controller = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Descr" ) { this.Descr = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "Area" ) { return this.Area ; }
                if ( PropertyName == "Controller" ) { return this.Controller ; }
                if ( PropertyName == "Descr" ) { return this.Descr ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","Area","Controller","Descr" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

            private PowerActionRule.Entity[] _GetPowerActions = null;
            public PowerActionRule.Entity[] GetPowerActions()
            {
                if (_GetPowerActions != null) return _GetPowerActions;
                _GetPowerActions = dbr.PowerAction.SelectWhere(o => o.ControllerID == this.Id).ToEntityList<PowerActionRule.Entity>().ToArray();
                return _GetPowerActions;
            }
         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class PowerActionRule : RuleBase, ITableRule,ICloneable
    {


        public  PowerActionRule() : base("PowerAction")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.Action = new SimpleColumn(this, DbType.AnsiString, 50,"Action","Action",true);
            this.ControllerID = new SimpleColumn(this, DbType.Int32, 4,"ControllerID","ControllerID",true);
            this.Descr = new SimpleColumn(this, DbType.AnsiString, 150,"Descr","Descr",true);
        }

        /// <summary>
        /// ID(Int32)[主键(ID),自增键]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// Action(AnsiString)
        /// </summary>
        public SimpleColumn Action { get; set; }
        /// <summary>
        /// ControllerID(Int32)[外键(ControllerID=PowerController:ID)]
        /// </summary>
        public SimpleColumn ControllerID { get; set; }
        /// <summary>
        /// Descr(AnsiString)
        /// </summary>
        public SimpleColumn Descr { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,Action,ControllerID,Descr }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Id };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return Id; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "PowerAction"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute() ;
        }


        public override object Clone()
        {
            var tab = new PowerActionRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.Action = this.Action.Clone() as SimpleColumn;
            tab.ControllerID = this.ControllerID.Clone() as SimpleColumn;
            tab.Descr = this.Descr.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[主键(ID),自增键]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// Action
            /// </summary>
            public String Action { get; set; }
 
            /// <summary>
            /// ControllerID[外键(ControllerID=PowerController:ID)]
            /// </summary>
            public Int32 ControllerID { get; set; }
 
            /// <summary>
            /// Descr
            /// </summary>
            public String Descr { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Action" ) { this.Action = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "ControllerID" ) { this.ControllerID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Descr" ) { this.Descr = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "Action" ) { return this.Action ; }
                if ( PropertyName == "ControllerID" ) { return this.ControllerID ; }
                if ( PropertyName == "Descr" ) { return this.Descr ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","Action","ControllerID","Descr" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

            private PowerControllerRule.Entity _GetPowerController = null;
            public PowerControllerRule.Entity GetPowerController()
            {
                if (_GetPowerController != null) return _GetPowerController;
                _GetPowerController = dbr.PowerController.FindById(this.ControllerID);
                return _GetPowerController;
            }
            private PowerButtonRule.Entity[] _GetPowerButtons = null;
            public PowerButtonRule.Entity[] GetPowerButtons()
            {
                if (_GetPowerButtons != null) return _GetPowerButtons;
                _GetPowerButtons = dbr.PowerButton.SelectWhere(o => o.ActionID == this.Id).ToEntityList<PowerButtonRule.Entity>().ToArray();
                return _GetPowerButtons;
            }
         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class PowerButtonRule : RuleBase, ITableRule,ICloneable
    {


        public  PowerButtonRule() : base("PowerButton")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.ActionID = new SimpleColumn(this, DbType.Int32, 4,"ActionID","ActionID",false);
            this.Button = new SimpleColumn(this, DbType.AnsiString, 50,"Button","Button",true);
            this.Descr = new SimpleColumn(this, DbType.AnsiString, 150,"Descr","Descr",true);
        }

        /// <summary>
        /// ID(Int32)[主键(ID),自增键]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// ActionID(Int32)[外键(ActionID=PowerAction:ID)]
        /// </summary>
        public SimpleColumn ActionID { get; set; }
        /// <summary>
        /// Button(AnsiString)
        /// </summary>
        public SimpleColumn Button { get; set; }
        /// <summary>
        /// Descr(AnsiString)
        /// </summary>
        public SimpleColumn Descr { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,ActionID,Button,Descr }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Id };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return Id; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "PowerButton"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute() ;
        }


        public override object Clone()
        {
            var tab = new PowerButtonRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.ActionID = this.ActionID.Clone() as SimpleColumn;
            tab.Button = this.Button.Clone() as SimpleColumn;
            tab.Descr = this.Descr.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[主键(ID),自增键]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// ActionID[外键(ActionID=PowerAction:ID)]
            /// </summary>
            public Int32 ActionID { get; set; }
 
            /// <summary>
            /// Button
            /// </summary>
            public String Button { get; set; }
 
            /// <summary>
            /// Descr
            /// </summary>
            public String Descr { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "ActionID" ) { this.ActionID = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Button" ) { this.Button = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Descr" ) { this.Descr = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "ActionID" ) { return this.ActionID ; }
                if ( PropertyName == "Button" ) { return this.Button ; }
                if ( PropertyName == "Descr" ) { return this.Descr ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","ActionID","Button","Descr" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

            private PowerActionRule.Entity _GetPowerAction = null;
            public PowerActionRule.Entity GetPowerAction()
            {
                if (_GetPowerAction != null) return _GetPowerAction;
                _GetPowerAction = dbr.PowerAction.FindById(this.ActionID);
                return _GetPowerAction;
            }
         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class LogRule : RuleBase, ITableRule,ICloneable
    {


        public  LogRule() : base("Log")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","Id",false);
            this.Name = new SimpleColumn(this, DbType.AnsiString, 50,"Name","Name",true);
            this.Type = new SimpleColumn(this, DbType.AnsiString, 50,"Type","Type",true);
            this.Url = new SimpleColumn(this, DbType.AnsiString, 1024,"Url","Url",true);
            this.Title = new SimpleColumn(this, DbType.AnsiString, 200,"Title","Title",true);
            this.Doer = new SimpleColumn(this, DbType.AnsiString, 200,"Doer","Doer",true);
            this.Request = new SimpleColumn(this, DbType.AnsiString, -1,"Request","Request",true);
            this.Msg = new SimpleColumn(this, DbType.AnsiString, 1000,"Msg","Msg",true);
            this.Detail = new SimpleColumn(this, DbType.AnsiString, -1,"Detail","Detail",true);
            this.Exception = new SimpleColumn(this, DbType.AnsiString, 1000,"Exception","Exception",true);
            this.Value = new SimpleColumn(this, DbType.Int64, 8,"Value","Value",true);
            this.AddTime = new SimpleColumn(this, DbType.DateTime, 8,"AddTime","AddTime",true);
            this.Ip = new SimpleColumn(this, DbType.AnsiString, 50,"Ip","IP",true);
            this.Client = new SimpleColumn(this, DbType.AnsiString, 200,"Client","Client",true);
            this.UserName = new SimpleColumn(this, DbType.AnsiString, 50,"UserName","UserName",true);
        }

        /// <summary>
        /// Id(Int32)[主键(Id),自增键]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// 子系统名称 或 模块名称(AnsiString)
        /// </summary>
        public SimpleColumn Name { get; set; }
        /// <summary>
        /// 信息类型(AnsiString)
        /// </summary>
        public SimpleColumn Type { get; set; }
        /// <summary>
        /// Url(AnsiString)
        /// </summary>
        public SimpleColumn Url { get; set; }
        /// <summary>
        /// 发生页面的标题(AnsiString)
        /// </summary>
        public SimpleColumn Title { get; set; }
        /// <summary>
        /// 发生页面的事件源(AnsiString)
        /// </summary>
        public SimpleColumn Doer { get; set; }
        /// <summary>
        /// 请求数据(AnsiString)
        /// </summary>
        public SimpleColumn Request { get; set; }
        /// <summary>
        /// 消息正文(AnsiString)
        /// </summary>
        public SimpleColumn Msg { get; set; }
        /// <summary>
        /// 消息详情(AnsiString)
        /// </summary>
        public SimpleColumn Detail { get; set; }
        /// <summary>
        /// Exception(AnsiString)
        /// </summary>
        public SimpleColumn Exception { get; set; }
        /// <summary>
        /// 数值型消息(Int64)
        /// </summary>
        public SimpleColumn Value { get; set; }
        /// <summary>
        /// 添加时间(DateTime)
        /// </summary>
        public SimpleColumn AddTime { get; set; }
        /// <summary>
        /// 客户端IP(AnsiString)
        /// </summary>
        public SimpleColumn Ip { get; set; }
        /// <summary>
        /// 客户端详细信息，如浏览器，操作系统等(AnsiString)
        /// </summary>
        public SimpleColumn Client { get; set; }
        /// <summary>
        /// 当前用户(AnsiString)
        /// </summary>
        public SimpleColumn UserName { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,Name,Type,Url,Title,Doer,Request,Msg,Detail,Exception,Value,AddTime,Ip,Client,UserName }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Id };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return Id; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "Log"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute() ;
        }


        public override object Clone()
        {
            var tab = new LogRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.Name = this.Name.Clone() as SimpleColumn;
            tab.Type = this.Type.Clone() as SimpleColumn;
            tab.Url = this.Url.Clone() as SimpleColumn;
            tab.Title = this.Title.Clone() as SimpleColumn;
            tab.Doer = this.Doer.Clone() as SimpleColumn;
            tab.Request = this.Request.Clone() as SimpleColumn;
            tab.Msg = this.Msg.Clone() as SimpleColumn;
            tab.Detail = this.Detail.Clone() as SimpleColumn;
            tab.Exception = this.Exception.Clone() as SimpleColumn;
            tab.Value = this.Value.Clone() as SimpleColumn;
            tab.AddTime = this.AddTime.Clone() as SimpleColumn;
            tab.Ip = this.Ip.Clone() as SimpleColumn;
            tab.Client = this.Client.Clone() as SimpleColumn;
            tab.UserName = this.UserName.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// Id[主键(Id),自增键]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// 子系统名称 或 模块名称
            /// </summary>
            public String Name { get; set; }
 
            /// <summary>
            /// 信息类型
            /// </summary>
            public InfoEnum Type { get; set; }
 
            /// <summary>
            /// Url
            /// </summary>
            public String Url { get; set; }
 
            /// <summary>
            /// 发生页面的标题
            /// </summary>
            public String Title { get; set; }
 
            /// <summary>
            /// 发生页面的事件源
            /// </summary>
            public String Doer { get; set; }
 
            /// <summary>
            /// 请求数据
            /// </summary>
            public String Request { get; set; }
 
            /// <summary>
            /// 消息正文
            /// </summary>
            public String Msg { get; set; }
 
            /// <summary>
            /// 消息详情
            /// </summary>
            public String Detail { get; set; }
 
            /// <summary>
            /// Exception
            /// </summary>
            public String Exception { get; set; }
 
            /// <summary>
            /// 数值型消息
            /// </summary>
            public Int64 Value { get; set; }
 
            /// <summary>
            /// 添加时间
            /// </summary>
            public MyDate AddTime { get; set; }
 
            /// <summary>
            /// 客户端IP
            /// </summary>
            public String Ip { get; set; }
 
            /// <summary>
            /// 客户端详细信息，如浏览器，操作系统等
            /// </summary>
            public String Client { get; set; }
 
            /// <summary>
            /// 当前用户
            /// </summary>
            public String UserName { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Name" ) { this.Name = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Type" ) { this.Type = ValueProc.As<InfoEnum>(Value) ; return true; }
                if ( PropertyName == "Url" ) { this.Url = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Title" ) { this.Title = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Doer" ) { this.Doer = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Request" ) { this.Request = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Msg" ) { this.Msg = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Detail" ) { this.Detail = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Exception" ) { this.Exception = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Value" ) { this.Value = ValueProc.As<Int64>(Value) ; return true; }
                if ( PropertyName == "AddTime" ) { this.AddTime = ValueProc.As<MyDate>(Value) ; return true; }
                if ( PropertyName == "Ip" ) { this.Ip = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Client" ) { this.Client = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "UserName" ) { this.UserName = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "Name" ) { return this.Name ; }
                if ( PropertyName == "Type" ) { return this.Type ; }
                if ( PropertyName == "Url" ) { return this.Url ; }
                if ( PropertyName == "Title" ) { return this.Title ; }
                if ( PropertyName == "Doer" ) { return this.Doer ; }
                if ( PropertyName == "Request" ) { return this.Request ; }
                if ( PropertyName == "Msg" ) { return this.Msg ; }
                if ( PropertyName == "Detail" ) { return this.Detail ; }
                if ( PropertyName == "Exception" ) { return this.Exception ; }
                if ( PropertyName == "Value" ) { return this.Value ; }
                if ( PropertyName == "AddTime" ) { return this.AddTime ; }
                if ( PropertyName == "Ip" ) { return this.Ip ; }
                if ( PropertyName == "Client" ) { return this.Client ; }
                if ( PropertyName == "UserName" ) { return this.UserName ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","Name","Type","Url","Title","Doer","Request","Msg","Detail","Exception","Value","AddTime","Ip","Client","UserName" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class MenuRule : RuleBase, ITableRule,ICloneable
    {


        public  MenuRule() : base("Menu")
        {
            this.Id = new SimpleColumn(this, DbType.Int32, 4,"Id","ID",false);
            this.Pid = new SimpleColumn(this, DbType.Int32, 4,"Pid","PID",true);
            this.Text = new SimpleColumn(this, DbType.AnsiString, 50,"Text","Text",true);
            this.Icon = new SimpleColumn(this, DbType.AnsiString, 50,"Icon","Icon",true);
            this.Url = new SimpleColumn(this, DbType.AnsiString, 250,"Url","Url",true);
            this.AddTime = new SimpleColumn(this, DbType.Date, 3,"AddTime","AddTime",true);
            this.Status = new SimpleColumn(this, DbType.AnsiString, 50,"Status","Status",true);
            this.Wbs = new SimpleColumn(this, DbType.AnsiString, 50,"Wbs","Wbs",true);
            this.Name = new SimpleColumn(this, DbType.AnsiString, 50,"Name","Name",true);
            this.AddUser = new SimpleColumn(this, DbType.AnsiString, 50,"AddUser","AddUser",true);
            this.SortID = new SimpleColumn(this, DbType.Single, 8,"SortID","SortID",true);
            this.Code = new SimpleColumn(this, DbType.String, 200,"Code","Code",true);
        }

        /// <summary>
        /// ID(Int32)[主键(ID)]
        /// </summary>
        public SimpleColumn Id { get; set; }
        /// <summary>
        /// PID(Int32)
        /// </summary>
        public SimpleColumn Pid { get; set; }
        /// <summary>
        /// Text(AnsiString)
        /// </summary>
        public SimpleColumn Text { get; set; }
        /// <summary>
        /// Icon(AnsiString)
        /// </summary>
        public SimpleColumn Icon { get; set; }
        /// <summary>
        /// Url(AnsiString)
        /// </summary>
        public SimpleColumn Url { get; set; }
        /// <summary>
        /// AddTime(Date)
        /// </summary>
        public SimpleColumn AddTime { get; set; }
        /// <summary>
        /// Status(AnsiString)
        /// </summary>
        public SimpleColumn Status { get; set; }
        /// <summary>
        /// Wbs(AnsiString)
        /// </summary>
        public SimpleColumn Wbs { get; set; }
        /// <summary>
        /// Name(AnsiString)
        /// </summary>
        public SimpleColumn Name { get; set; }
        /// <summary>
        /// AddUser(AnsiString)
        /// </summary>
        public SimpleColumn AddUser { get; set; }
        /// <summary>
        /// SortID(Single)
        /// </summary>
        public SimpleColumn SortID { get; set; }
        /// <summary>
        /// Code(String)
        /// </summary>
        public SimpleColumn Code { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Id,Pid,Text,Icon,Url,AddTime,Status,Wbs,Name,AddUser,SortID,Code }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Id };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return null; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "Menu"; }

        public Entity FindById(Int32 Id)
        {
             if ( Id <= 0 ) return null ;
            return this.SelectWhere(o => o.Id == Id).ToEntity<Entity>();
        }
        public int DeleteById(Int32 Id)
        {
             if ( Id <= 0 ) return 0 ;
            return this.Delete(o => o.Id == Id).Execute() ;
        }


        public override object Clone()
        {
            var tab = new MenuRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Id = this.Id.Clone() as SimpleColumn;
            tab.Pid = this.Pid.Clone() as SimpleColumn;
            tab.Text = this.Text.Clone() as SimpleColumn;
            tab.Icon = this.Icon.Clone() as SimpleColumn;
            tab.Url = this.Url.Clone() as SimpleColumn;
            tab.AddTime = this.AddTime.Clone() as SimpleColumn;
            tab.Status = this.Status.Clone() as SimpleColumn;
            tab.Wbs = this.Wbs.Clone() as SimpleColumn;
            tab.Name = this.Name.Clone() as SimpleColumn;
            tab.AddUser = this.AddUser.Clone() as SimpleColumn;
            tab.SortID = this.SortID.Clone() as SimpleColumn;
            tab.Code = this.Code.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// ID[主键(ID)]
            /// </summary>
            public Int32 Id { get; set; }
 
            /// <summary>
            /// PID
            /// </summary>
            public Int32 Pid { get; set; }
 
            /// <summary>
            /// Text
            /// </summary>
            public String Text { get; set; }
 
            /// <summary>
            /// Icon
            /// </summary>
            public String Icon { get; set; }
 
            /// <summary>
            /// Url
            /// </summary>
            public String Url { get; set; }
 
            /// <summary>
            /// AddTime
            /// </summary>
            public MyDate AddTime { get; set; }
 
            /// <summary>
            /// Status
            /// </summary>
            public IsAbleEnum Status { get; set; }
 
            /// <summary>
            /// Wbs
            /// </summary>
            public String Wbs { get; set; }
 
            /// <summary>
            /// Name
            /// </summary>
            public String Name { get; set; }
 
            /// <summary>
            /// AddUser
            /// </summary>
            public String AddUser { get; set; }
 
            /// <summary>
            /// SortID
            /// </summary>
            public Single SortID { get; set; }
 
            /// <summary>
            /// Code
            /// </summary>
            public String Code { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Id" ) { this.Id = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Pid" ) { this.Pid = ValueProc.As<Int32>(Value) ; return true; }
                if ( PropertyName == "Text" ) { this.Text = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Icon" ) { this.Icon = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Url" ) { this.Url = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "AddTime" ) { this.AddTime = ValueProc.As<MyDate>(Value) ; return true; }
                if ( PropertyName == "Status" ) { this.Status = ValueProc.As<IsAbleEnum>(Value) ; return true; }
                if ( PropertyName == "Wbs" ) { this.Wbs = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "Name" ) { this.Name = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "AddUser" ) { this.AddUser = ValueProc.As<String>(Value) ; return true; }
                if ( PropertyName == "SortID" ) { this.SortID = ValueProc.As<Single>(Value) ; return true; }
                if ( PropertyName == "Code" ) { this.Code = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Id" ) { return this.Id ; }
                if ( PropertyName == "Pid" ) { return this.Pid ; }
                if ( PropertyName == "Text" ) { return this.Text ; }
                if ( PropertyName == "Icon" ) { return this.Icon ; }
                if ( PropertyName == "Url" ) { return this.Url ; }
                if ( PropertyName == "AddTime" ) { return this.AddTime ; }
                if ( PropertyName == "Status" ) { return this.Status ; }
                if ( PropertyName == "Wbs" ) { return this.Wbs ; }
                if ( PropertyName == "Name" ) { return this.Name ; }
                if ( PropertyName == "AddUser" ) { return this.AddUser ; }
                if ( PropertyName == "SortID" ) { return this.SortID ; }
                if ( PropertyName == "Code" ) { return this.Code ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Id","Pid","Text","Icon","Url","AddTime","Status","Wbs","Name","AddUser","SortID","Code" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

         }
    }


    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed partial class CacheTableRule : RuleBase, ITableRule,ICloneable
    {


        public  CacheTableRule() : base("CacheTable")
        {
            this.Table = new SimpleColumn(this, DbType.AnsiString, 50,"Table","Table",false);
        }

        /// <summary>
        /// Table(AnsiString)[主键(Table)]
        /// </summary>
        public SimpleColumn Table { get; set; }

        public override SimpleColumn[] GetColumns() {  return new SimpleColumn[] { Table }; }
        public override SimpleColumn[] GetPrimaryKeys() { return new SimpleColumn[] { Table };  }
        public override SimpleColumn[] GetComputeKeys() { return new SimpleColumn[] {  }; }
        public override SimpleColumn GetAutoIncreKey() {  return null; }
        public override SimpleColumn GetUniqueKey() { return  null; }
        public override string GetDbName() { return "CacheTable"; }

        public Entity FindByTable(String Table)
        {
            if ( Table.HasValue() == false ) return null ;
            return this.SelectWhere(o => o.Table == Table).ToEntity<Entity>();
        }
        public int DeleteByTable(String Table)
        {
            if ( Table.HasValue() == false ) return 0 ;
            return this.Delete(o => o.Table == Table).Execute() ;
        }


        public override object Clone()
        {
            var tab = new CacheTableRule();
            if ( this._Config_ != null ) tab._Config_ = base._Config_.Clone() as RuleRuntimeConfig ;
            tab.SetAlias(base.Name);
            tab.SetReconfig(base.ReConfig);

            tab.Table = this.Table.Clone() as SimpleColumn;

            return tab;
        }
        /// <summary>
        ///  
        /// </summary>
        public Entity _ { get { return new Entity (); } }
       
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public sealed partial class Entity :IEntity
        {
 
            /// <summary>
            /// Table[主键(Table)]
            /// </summary>
            public String Table { get; set; }

            public bool SetPropertyValue(string PropertyName, object Value)
            {
                if ( PropertyName == "Table" ) { this.Table = ValueProc.As<String>(Value) ; return true; }
                return false ;
           }

            public object GetPropertyValue(string PropertyName)
            {
                if ( PropertyName == "Table" ) { return this.Table ; }
                return null ;
            }

            public string[]  GetProperties() { return new string[]{ "Table" } ; }
            
            public object Clone()
            {
                return this.CloneIEntity() ;
            }

         }
    }



}