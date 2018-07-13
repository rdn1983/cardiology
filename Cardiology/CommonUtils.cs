using Cardiology.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

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

        internal static Control copyControl(Control srcContainer, int index)
        {
            Control c = createControl(srcContainer);
            if (c != null)
            {
                for (int i = 0; i < srcContainer.Controls.Count; i++)
                {
                    Control sourceCtrl = srcContainer.Controls[i];
                    Control child = createControl(sourceCtrl);
                    if (child != null)
                    {
                        child.Bounds = sourceCtrl.Bounds;
                        c.Controls.Add(child);
                    }
                }
            }
            return c;
        }

        private static Control createControl(Control sourceCtrl)
        {
            Control result = null;
            if (sourceCtrl.GetType() == typeof(Label))
            {
                result = new Label();
                result.Text = sourceCtrl.Text;
            }
            if (sourceCtrl.GetType() == typeof(TextBox))
            {
                result = new TextBox();
            }
            if (sourceCtrl.GetType() == typeof(Panel))
            {
                result = new Panel();
            }
            if (sourceCtrl.GetType() == typeof(DateTimePicker))
            {
                result = new DateTimePicker();
                ((DateTimePicker)result).Format = ((DateTimePicker)sourceCtrl).Format;
            }
            if (sourceCtrl.GetType() == typeof(ComboBox))
            {
                result = new ComboBox();
                ObjectCollection items = ((ComboBox)sourceCtrl).Items;
                for (int i = 0; i < items.Count; i++)
                {
                    ((ComboBox)result).Items.Add(items[i]);
                }
                ((ComboBox)result).ValueMember = ((ComboBox)sourceCtrl).ValueMember;
                ((ComboBox)result).DisplayMember = ((ComboBox)sourceCtrl).DisplayMember;
                ((ComboBox)result).DropDownStyle = ((ComboBox)sourceCtrl).DropDownStyle;
            }
            if (sourceCtrl.GetType() == typeof(RichTextBox))
            {
                result = new RichTextBox();
            }
            if (result != null)
            {
                result.Size = sourceCtrl.Size;
                result.Font = sourceCtrl.Font;
                result.Visible = sourceCtrl.Visible;
                string controlName = sourceCtrl.Name;
                int firstDigitIndx = getFirstDigitIndex(controlName);
                string indexPart = String.Intern(controlName.Substring(firstDigitIndx));
                int newINdx = Convert.ToInt16(indexPart) + 1;
                result.Name = String.Intern(controlName.Substring(0, firstDigitIndx - 1)) + newINdx;
            }

            return result;
        }

        private static int getFirstDigitIndex(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (!Char.IsDigit(str[i]))
                {
                    return i + 1;
                }
            }
            return -1;
        }



    }
}


