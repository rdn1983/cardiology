using Cardiology.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology.Utils
{
    public class CommonUtils
    {
        public static bool isNotBlank(string str)
        {
            return str != null && str.Length > 0;
        }

        public static bool isBlank(string str)
        {
            return str == null || str.Length == 0;
        }

        internal static void initDoctorsComboboxValues(DataService service, ComboBox cb, string whereCnd)
        {
            cb.Items.Clear();
            string query = @"SELECT * FROM ddt_doctors " + (isBlank(whereCnd) ? "" : (" WHERE " + whereCnd)); 
            List<DdtDoctors> doctors = service.queryObjectsCollection<DdtDoctors>(query);
            cb.Items.AddRange(doctors.ToArray());
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "DssFullName";
        }

        internal static void initCureComboboxValues(DataService service, ComboBox cb, string whereCnd)
        {
            cb.Items.Clear();
            string query = @"SELECT * FROM ddt_cure " + (isBlank(whereCnd) ? "" : (" WHERE " + whereCnd)) + " ORDER BY dsi_type";
            List<DdtCure> cureList = service.queryObjectsCollection<DdtCure>(query);
            cb.Items.AddRange(cureList.ToArray());
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "DssName";
        }

        

    }
}


