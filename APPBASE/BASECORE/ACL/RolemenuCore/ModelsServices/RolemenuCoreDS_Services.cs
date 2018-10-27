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
    public partial class RolemenuCoreDS
    {
        protected List<RolemenuVM> _Data_list;
        protected List<int?> _DataMenuCore_list;
        protected List<int?> _DataRole_list;

        //Constructor 1
        public RolemenuCoreDS(): base() {
            this._Data_list = new List<RolemenuVM>();
            this._DataMenuCore_list = new List<int?>();
            this._DataRole_list = new List<int?>();
        } //End Constructor
        //Constructor 2
        public RolemenuCoreDS(List<RolemenuVM> Data_list, List<int?> DataMenuCore_list,
            List<int?> DataRole_list) {
            this._Data_list = Data_list;
            this._DataMenuCore_list = DataMenuCore_list;
            this._DataRole_list = DataRole_list;
        } //End Constructor
        //Init Menu
        protected virtual void initDataMenu()
        {
            //CORE USER - 1010
            this._DataMenuCore_list.Add(valMENU.CORE);
            this._DataMenuCore_list.Add(valMENU.CORE_USER);
            this._DataMenuCore_list.Add(valMENU.CORE_USER_INDEX);
            this._DataMenuCore_list.Add(valMENU.CORE_USER_DETAILS);
            this._DataMenuCore_list.Add(valMENU.CORE_USER_CREATE);
            this._DataMenuCore_list.Add(valMENU.CORE_USER_EDIT);
            this._DataMenuCore_list.Add(valMENU.CORE_USER_DELETE);
            this._DataMenuCore_list.Add(valMENU.CORE_USER_ENABLE);
            this._DataMenuCore_list.Add(valMENU.CORE_USER_DISABLE);
        } //end method
        //Init Role All Menu List
        protected void setRoleMenus(int? pnMDLE_ID, int? pnROLE_ID, List<int?> DataMenu_list)
        {
            for (int i = 0; i < DataMenu_list.Count; i++)
            {
                this._Data_list.Add(new RolemenuVM
                {
                    ID = null,
                    MDLE_ID = pnMDLE_ID,
                    MNU_ID = DataMenu_list[i],
                    ROLE_ID = pnROLE_ID
                });
            } //end loop
        } //end method
        //Init Role Menu by Menu Item
        protected void setRoleMenu(int? pnMDLE_ID, int? pnROLE_ID, int? pnMENU_ID)
        {
            this._Data_list.Add(new RolemenuVM
            {
                ID = null,
                MDLE_ID = pnMDLE_ID,
                MNU_ID = pnMENU_ID,
                ROLE_ID = pnROLE_ID
            });
        } //end method
        //Check Granted user to menu
        public Boolean isGrantedMenu(int? pnRoleId = null, int? pnMenuId = null)
        {
            Boolean vReturn = false;
            if (this._Data_list != null)
            {
                var oQRY = this._Data_list.Where(fld => fld.ROLE_ID == pnRoleId && fld.MNU_ID == pnMenuId).ToList();
                if (oQRY.Count > 0) { vReturn = true; } //end if
            } //end if
            return vReturn;
        } //End method
    } //End public partial class
} //End namespace
