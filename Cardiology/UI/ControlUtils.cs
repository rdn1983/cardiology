using Cardiology.Data;
using Cardiology.Data.Model2;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology.UI
{
    class ControlUtils
    {
        internal static void initDoctorsByGroupName(IDbDoctorService service, ComboBox control, string groupName)
        {
            control.Items.Clear();

            IList<DdtDoctorV2> list = service.GetDoctorsByGroupName(groupName);
            control.DataSource = list;

            control.ValueMember = "Id";
            control.DisplayMember = "Initials";
        }

        internal static void initDoctors(IDbDoctorService service, ComboBox control)
        {
            control.Items.Clear();

            IList<DdtDoctorV2> list = service.GetAll();
            for(int index = 0; index < list.Count; index++)
            {
                control.Items.Add(list[index]); ;
            }

            control.ValueMember = "Id";
            control.DisplayMember = "Initials";
        }
    }
}
