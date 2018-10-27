using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcapp;

namespace APPBASE.Models
{
    public partial class RolemenuTskDS: RolemenuMstDS
    {
        protected List<int?> _DataMenuTsk_list;

        //Constructor 1
        public RolemenuTskDS(): base() {
            this._DataMenuTsk_list = new List<int?>();
        } //End Constructor
        //Constructor 2
        public RolemenuTskDS(List<RolemenuVM> Data_list, List<int?> DataMenuCore_list,
            List<int?> DataRole_list, List<int?> DataMenuMst_list,
            List<int?> DataMenuTsk_list)
            : base(Data_list, DataMenuCore_list, DataRole_list, DataMenuMst_list)
        {
                this._DataMenuTsk_list = DataMenuTsk_list;
        } //End Constructor
        
        //Init All Menu [Tiap module berbeda, modif method ini sesuai role pada module bersangkutan]
        protected override void initDataMenu()
        {
            //Init Base Data Menu
            base.initDataMenu();
            //TSK PROJECT - 3010
            this._DataMenuTsk_list.Add(valMENU.TSK);
            this._DataMenuTsk_list.Add(valMENU.TSK_PROJECT);
            this._DataMenuTsk_list.Add(valMENU.TSK_PROJECT_INDEX);
            this._DataMenuTsk_list.Add(valMENU.TSK_PROJECT_DETAILS);
            this._DataMenuTsk_list.Add(valMENU.TSK_PROJECT_CREATE);
            this._DataMenuTsk_list.Add(valMENU.TSK_PROJECT_EDIT);
            this._DataMenuTsk_list.Add(valMENU.TSK_PROJECT_DELETE);
            //TSK TASK - 3020
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK);
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK_INDEX);
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK_DETAILS);
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK_CREATE);
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK_EDIT);
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK_DELETE);
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK_PROGRESS);
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK_VALIDATE);
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK_REPORT_ADMIN);
            this._DataMenuTsk_list.Add(valMENU.TSK_TASK_REPORT_MEMBER);
        } //end method
        //Init All Role [Tiap module berbeda, modif method ini sesuai role pada module bersangkutan]
        protected void initDataRole() {
            this._DataRole_list.Add(valROLE.ROLEID_MASTER);
            this._DataRole_list.Add(valROLE.ROLEID_ADMIN);
            this._DataRole_list.Add(valROLE.ROLEID_LEADER);
            this._DataRole_list.Add(valROLE.ROLEID_MEMBER);
        } //end method
        //Init Role Menu [Tiap module berbeda, modif method ini sesuai role pada module bersangkutan]
        public void initRoleMenu()
        {
            //Init Data Menu
            this.initDataMenu();
            //Init Data Role
            this.initDataRole();
            //Set Role Menu - MASTER
            this.setRoleMenus(1, valROLE.ROLEID_MASTER, this._DataMenuCore_list);
            this.setRoleMenus(1, valROLE.ROLEID_MASTER, this._DataMenuMst_list);
            this.setRoleMenus(1, valROLE.ROLEID_MASTER, this._DataMenuTsk_list);
            //Set Role Menu - ADMIN
            this.setRoleMenus(1, valROLE.ROLEID_ADMIN, this._DataMenuCore_list);
            this.setRoleMenus(1, valROLE.ROLEID_ADMIN, this._DataMenuMst_list);
            this.setRoleMenus(1, valROLE.ROLEID_ADMIN, this._DataMenuTsk_list);
            //Set Role Menu - LEADER
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK_INDEX);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK_DETAILS);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK_CREATE);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK_EDIT);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK_DELETE);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK_PROGRESS);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK_VALIDATE);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK_REPORT_ADMIN);
            this.setRoleMenu(1, valROLE.ROLEID_LEADER, valMENU.TSK_TASK_REPORT_MEMBER);
            //Set Role Menu - MEMBER
            this.setRoleMenu(1, valROLE.ROLEID_MEMBER, valMENU.TSK);
            this.setRoleMenu(1, valROLE.ROLEID_MEMBER, valMENU.TSK_TASK);
            this.setRoleMenu(1, valROLE.ROLEID_MEMBER, valMENU.TSK_TASK_PROGRESS);
            this.setRoleMenu(1, valROLE.ROLEID_MEMBER, valMENU.TSK_TASK_REPORT_MEMBER);
        } //end method
    } //End public partial class
} //End namespace
