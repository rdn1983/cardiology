using System;
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
            control.DataSource = service.GetByGroupName(groupName);
            control.ValueMember = "ObjectId";
            control.DisplayMember = "ShortName";
        }

        internal static void InitDoctorsByGroupNameAndOrder(IDdvDoctorService service, ComboBox control, string groupName, string orderName)
        {
            control.DataSource = service.GetByGroupNameAndOrder(groupName, orderName);
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


        internal static void InitGroupsComboboxValues(IDmGroupService service, ComboBox control)
        {
            control.DataSource = service.GetAll();
            control.ValueMember = "Name";
            control.DisplayMember = "Description";
        }

        internal static void InitConsiliumGroupsComboboxValues(IDdtConsiliumGroupService service, ComboBox control)
        {
            control.DataSource = service.GetAll();
            control.ValueMember = "Name";
            control.DisplayMember = "Description";
        }

        internal static void InitDoctorsByConsiliumGroupId(IDdvDoctorService service, ComboBox control, string consiliumGroupId)
        {
            control.DataSource = service.GetByConsiliumGroupId(consiliumGroupId);
            control.ValueMember = "ObjectId";
            control.DisplayMember = "ShortName";
        }
    }
}
