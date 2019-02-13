using System;
using Cardiology.Data;
using Cardiology.Data.Model2;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Data.Commons;

namespace Cardiology.UI
{
    class ControlUtils
    {
        internal static void InitDoctorsByGroupName(IDdvDoctorService service, ComboBox control, string groupName)
        {
            control.Items.Clear();

            IList<DdvDoctor> list = service.GetByGroupName(groupName);
            control.DataSource = list;

            control.ValueMember = "ObjectId";
            control.DisplayMember = "ShortName";
        }

        internal static void InitDoctors(IDdvDoctorService service, ComboBox control, String defaultId)
        {
            control.Items.Clear();

            IList<DdvDoctor> list = service.GetAll();

            var selectIndex = 0;
            for (var index = 0; index < list.Count; index++)
            {
                var obj = list[index];

                if (obj.ObjectId == defaultId)
                {
                    selectIndex = index;
                }
                control.Items.Add(obj);
            }


            control.ValueMember = "ObjectId";
            control.DisplayMember = "ShortName";
            control.SelectedIndex = selectIndex;
        }
    }
}
