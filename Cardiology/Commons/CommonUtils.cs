using Cardiology.Data;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Cardiology.Data.Model2;
using static System.Windows.Forms.ComboBox;

namespace Cardiology.Commons
{
    public class CommonUtils
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static string ToQuotedStr(string str)
        {
            return !string.IsNullOrEmpty(str) ? String.Intern("'" + str + "'") : "''";
        }

        internal static void InitDoctorsComboboxValues(IDbDataService service, ComboBox cb, string whereCnd)
        {
            cb.Items.Clear();
            string query = @"SELECT * FROM ddt_doctors " + (string.IsNullOrEmpty(whereCnd) ? "" : (" WHERE " + whereCnd));
            List<DdvDoctor> doctors = service.GetDdvDoctorService().GetByQuery(query);
            cb.Items.AddRange(doctors.ToArray());
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "ShortName";
        }

        internal static void InitDoctorsByGroupComboboxValues(IDbDataService service, ComboBox cb, string groupName)
        {
            cb.Items.Clear();
            string query = @"SELECT doc.* FROM ddt_doctors doc , dm_group_users gr WHERE gr.dss_group_name='" + groupName + "' AND gr.dss_user_name=doc.dss_login";
            List<DdvDoctor> doctors = service.GetDdvDoctorService().GetByQuery(query);
            cb.Items.AddRange(doctors.ToArray());
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "ShortName";
        }

        internal static void InitCureComboboxValuesByTypeId(IDbDataService service, ComboBox cb, string cureTypeId)
        {
            cb.Items.Clear();
            string query = @"SELECT * FROM ddt_cure WHERE dsid_cure_type= '" + cureTypeId + "'";
            List<DdtCure> cureList = service.GetDdtCureService().GetByQuery(query);
            cb.Items.AddRange(cureList.ToArray());
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "DssName";
        }

        internal static void InitCureTypeComboboxValues(IDbDataService service, ComboBox cb)
        {
            cb.Items.Clear();
            IList<DdtCureType> cureList = service.GetDdtCureTypeService().GetAll();
            foreach(DdtCureType obj in cureList)
            {
                cb.Items.Add(obj);
            }
            cb.ValueMember = "ObjectId";
            cb.DisplayMember = "Name";
        }

        internal static void SetDoctorsComboboxDefaultValue(IDbDataService service, ComboBox cb, string dsidCuringDoctor)
        {
            if (!string.IsNullOrEmpty(dsidCuringDoctor))
            {
                DdvDoctor doctor = service.GetDdvDoctorService().GetById(dsidCuringDoctor);
                cb.SelectedIndex = cb.FindStringExact(doctor.ShortName);
            }
        }


        internal static void InitRangedItems(ComboBox c, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                c.Items.Add(i);
            }
        }

        internal static DateTime ConstructDateWIthTime(DateTime dateSource, DateTime timeSource)
        {
            return new DateTime(dateSource.Year, dateSource.Month, dateSource.Day, timeSource.Hour, timeSource.Minute, 0);
        }


        internal static Control CopyControl(Control srcContainer, int index)
        {
            Control c = CreateControl(srcContainer, index);
            if (c != null)
            {
                for (int i = 0; i < srcContainer.Controls.Count; i++)
                {
                    Control sourceCtrl = srcContainer.Controls[i];
                    Control child;
                    if (sourceCtrl.Controls.Count > 0)
                    {
                        child = CopyControl(sourceCtrl, index);
                    }
                    else
                    {
                        child = CreateControl(sourceCtrl, index);
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

        private static Control CreateControl(Control sourceCtrl, int index)
        {
            Control result = null;
            if (sourceCtrl.GetType() == typeof(Label))
            {
                result = new Label {Visible = sourceCtrl.Visible};
                if (sourceCtrl.Visible)
                {
                    result.Text = sourceCtrl.Text;
                }
            }
            if (sourceCtrl.GetType() == typeof(TextBox))
            {
                result = new TextBox {Visible = sourceCtrl.Visible};
            }
            if (sourceCtrl.GetType() == typeof(CheckBox))
            {
                result = new CheckBox {Visible = sourceCtrl.Visible, Text = sourceCtrl.Text};
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
                result = new RadioButton {Text = sourceCtrl.Text};
            }
            if (sourceCtrl.GetType() == typeof(Button))
            {
                result = new Button {Text = sourceCtrl.Text, Visible = sourceCtrl.Visible};
                ((Button)result).UseVisualStyleBackColor = ((Button)sourceCtrl).UseVisualStyleBackColor;
                ((Button)result).Image = ((Button)sourceCtrl).Image;
            }
            if (result != null)
            {
                result.Size = sourceCtrl.Size;
                result.Font = sourceCtrl.Font;
                string controlName = sourceCtrl.Name;
                int firstDigitIndx = GetFirstDigitIndex(controlName);
                result.Name = String.Intern(controlName.Substring(0, firstDigitIndx)) + index;
            }

            return result;
        }

        internal static int GetFirstDigitIndex(string str)
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

        public static Control FindControl(Control container, string name)
        {
            Control[] c = container.Controls.Find(name, true);
            if (c.Length > 0)
            {
                return c[0];
            }
            return null;
        }

        internal static DdtJournal ResolveKagJournal(IDbDataService service, DateTime incpectionDate, string sessionId)
        {
            string startDateQuery = @"SELECT dsdt_inspection_date FROM " + DdtInspection.NAME + " WHERE dsid_hospitality_session='" + sessionId + "'" +
                " AND dsdt_inspection_date<to_timestamp('" + incpectionDate.ToShortDateString() + " " + incpectionDate.ToLongTimeString() + "', 'DD.MM.YYYY HH24:MI:SS') ORDER BY dsdt_inspection_date DESC";
            DateTime startDate = service.GetTime(startDateQuery);

            return service.queryObject<DdtJournal>(@"SELECT * FROM " + DdtJournal.NAME +
                " WHERE dsid_hospitality_session='" + sessionId + "'" +
                    " AND dsi_journal_type=" + (int)DdtJournalDsiType.AFTER_KAG +
                    (startDate != default(DateTime) ? (" AND dsdt_admission_date>=to_timestamp('" + startDate.ToShortDateString() + " " + startDate.ToLongTimeString() + "', 'dd.mm.yyyy HH24:mi:ss')") : "") +
                    " AND dsdt_admission_date<=to_timestamp('" + incpectionDate.ToShortDateString() + " " + incpectionDate.ToLongTimeString() + "', 'dd.mm.yyyy HH24:mi:ss')");

        }

        internal static string ReplaceJournalIntParameter(string journal, string mask, string newValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(journal))
                {

                    int index = -1;
                    StringBuilder resultBuilder = new StringBuilder();
                    if ((index = journal.IndexOf(mask)) >= 0)
                    {
                        int startIndex = index + mask.Length - 1;
                        int counter = 0;
                        int replaceStartIndex = -1;
                        int replaceEndIndex = -1;
                        while (replaceStartIndex < 0 && counter < 5)
                        {
                            char c = journal[startIndex + counter];
                            if (Char.IsDigit(c))
                            {
                                replaceStartIndex = startIndex + counter;
                            }
                            counter++;
                        }
                        while (replaceEndIndex < 0)
                        {
                            char c = journal[startIndex + counter];
                            bool isLastChar = startIndex + counter == journal.Length - 1;
                            if ((!Char.IsDigit(c) && '/' != c) || isLastChar)
                            {
                                replaceEndIndex = startIndex + counter;
                            }
                            counter++;
                        }

                        if (replaceStartIndex >= 0 && replaceEndIndex >= 0)
                        {
                            bool inserted = false;
                            for (int i = 0; i < journal.Length; i++)
                            {
                                if (i < replaceStartIndex || i >= replaceEndIndex)
                                {
                                    resultBuilder.Append(journal[i]);
                                }
                                else
                                {
                                    if (!inserted)
                                    {
                                        inserted = true;
                                        resultBuilder.Append(newValue);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        resultBuilder.Append(journal).Append(mask).Append(" ").Append(newValue).Append(" ");

                    }
                    return resultBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
            }
            return journal;

        }

    }
}


