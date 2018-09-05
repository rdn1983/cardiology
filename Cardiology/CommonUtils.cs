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

        public static string toQuotedStr(string str)
        {
            return isNotBlank(str) ? String.Intern("'" + str + "'") : "";
        }

        internal static void initGroupsComboboxValues(DataService service, ComboBox cb)
        {
            cb.Items.Clear();
            string query = @"SELECT * FROM " + DmGroup.TABLE_NAME;
            List<DmGroup> groups = service.queryObjectsCollection<DmGroup>(query);
            cb.Items.AddRange(groups.ToArray());
            cb.ValueMember = "DssName";
            cb.DisplayMember = "DssDescription";
        }

        internal static void initDoctorsComboboxValues(DataService service, ComboBox cb, string whereCnd)
        {
            cb.Items.Clear();
            string query = @"SELECT * FROM ddt_doctors " + (isBlank(whereCnd) ? "" : (" WHERE " + whereCnd));
            List<DdtDoctors> doctors = service.queryObjectsCollection<DdtDoctors>(query);
            cb.Items.AddRange(doctors.ToArray());
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "DssInitials";
        }

        internal static void initDoctorsByGroupComboboxValues(DataService service, ComboBox cb, string groupName)
        {
            cb.Items.Clear();
            string query = @"SELECT * FROM ddt_doctors doc , dm_group_users gr WHERE gr.dss_group_name='" + groupName + "' AND gr.dss_user_name=doc.dss_login";
            List<DdtDoctors> doctors = service.queryObjectsCollection<DdtDoctors>(query);
            cb.Items.AddRange(doctors.ToArray());
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "DssInitials";
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

        internal static void initCureComboboxValues(DataService service, ComboBox cb, int cureType)
        {
            cb.Items.Clear();
            string query = @"SELECT * FROM ddt_cure WHERE dsi_type= " + cureType;
            List<DdtCure> cureList = service.queryObjectsCollection<DdtCure>(query);
            cb.Items.AddRange(cureList.ToArray());
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "DssName";
        }

        internal static void initCureTypeComboboxValues(DataService service, ComboBox cb)
        {
            cb.Items.Clear();
            string query = @"SELECT * FROM ddt_cure_type";
            List<DdtCureType> cureList = service.queryObjectsCollection<DdtCureType>(query);
            cb.Items.AddRange(cureList.ToArray());
            cb.ValueMember = "DsiType";
            cb.DisplayMember = "DssName";
        }

        internal static void initRangedItems(ComboBox c, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                c.Items.Add(i);
            }
        }

        internal static DateTime constructDateWIthTime(DateTime dateSource, DateTime timeSource)
        {
            return new DateTime(dateSource.Year, dateSource.Month, dateSource.Day, timeSource.Hour, timeSource.Minute, 0);
        }


        internal static Control copyControl(Control srcContainer, int index)
        {
            Control c = createControl(srcContainer, index);
            if (c != null)
            {
                for (int i = 0; i < srcContainer.Controls.Count; i++)
                {
                    Control sourceCtrl = srcContainer.Controls[i];
                    Control child;
                    if (sourceCtrl.Controls.Count > 0)
                    {
                        child = copyControl(sourceCtrl, index);
                    }
                    else
                    {
                        child = createControl(sourceCtrl, index);
                    }
                    if (child != null)
                    {
                        child.Bounds = sourceCtrl.Bounds;
                        c.Controls.Add(child);
                    }
                }
            }
            return c;
        }

        private static Control createControl(Control sourceCtrl, int index)
        {
            Control result = null;
            if (sourceCtrl.GetType() == typeof(Label))
            {
                result = new Label();
                result.Visible = sourceCtrl.Visible;
                if (sourceCtrl.Visible)
                {
                    result.Text = sourceCtrl.Text;
                }
            }
            if (sourceCtrl.GetType() == typeof(TextBox))
            {
                result = new TextBox();
                result.Visible = sourceCtrl.Visible;
            }
            if (sourceCtrl.GetType() == typeof(CheckBox))
            {
                result = new CheckBox();
                result.Visible = sourceCtrl.Visible;
                result.Text = sourceCtrl.Text;
            }
            if (sourceCtrl.GetType() == typeof(Panel))
            {
                result = new Panel();
            }
            if (sourceCtrl.GetType() == typeof(DateTimePicker))
            {
                result = new DateTimePicker();
                ((DateTimePicker)result).Format = ((DateTimePicker)sourceCtrl).Format;
                ((DateTimePicker)result).CustomFormat = ((DateTimePicker)sourceCtrl).CustomFormat;
                ((DateTimePicker)result).ShowUpDown = ((DateTimePicker)sourceCtrl).ShowUpDown;

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
            if (sourceCtrl.GetType() == typeof(RadioButton))
            {
                result = new RadioButton();
                result.Text = sourceCtrl.Text;
            }
            if (sourceCtrl.GetType() == typeof(Button))
            {
                result = new Button();
                result.Text = sourceCtrl.Text;
                ((Button)result).Image = ((Button)sourceCtrl).Image;
            }
            if (result != null)
            {
                result.Size = sourceCtrl.Size;
                result.Font = sourceCtrl.Font;
                string controlName = sourceCtrl.Name;
                int firstDigitIndx = getFirstDigitIndex(controlName);
                result.Name = String.Intern(controlName.Substring(0, firstDigitIndx)) + index;
            }

            return result;
        }

        internal static int getFirstDigitIndex(string str)
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

        public static string getStrigControlValue(Control container, string ctrlName)
        {
            Control c = findControl(container, ctrlName);
            if (c != null)
            {
                return c.Text;
            }
            return "";

        }

        public static void updateControl(Control container, string ctrlName, string value)
        {
            Control c = findControl(container, ctrlName);
            if (c != null)
            {
                c.Text = value;
            }
        }

        public static Control findControl(Control container, string name)
        {
            Control[] c = container.Controls.Find(name, true);
            if (c.Length > 0)
            {
                return c[0];
            }
            return null;
        }



    }
}


