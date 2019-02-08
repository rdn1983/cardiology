using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model;

namespace Cardiology.UI.Forms
{
    public partial class Serology : Form
    {
        private DdtSerology serology;
        private DdtHospital hospitalitySession;

        public Serology(DdtHospital hospitalitySession)
        {
            this.hospitalitySession = hospitalitySession;
            DataService service = new DataService();
            serology = service.queryObject<DdtSerology>(@"select * from ddt_serology where dsid_hospitality_session='" + hospitalitySession.ObjectId + "'");
            InitializeComponent();
            initBoxes();
        }

        private void initBoxes()
        {
            DataService service = new DataService();
            loadBoxValues(bloodTypeBox, "bloodtype", service);
            loadBoxValues(rhesusFactorBox, "rhesusFactor", service);
            loadBoxValues(kellAgBox, "kellAg", service);
            loadBoxValues(rwBox, "serology", service);
            loadBoxValues(hbsAgBox, "serology", service);
            loadBoxValues(antiHcvBox, "serology", service);
            loadBoxValues(hivBox, "serology", service);

            if (serology != null)
            {
                bloodTypeBox.Text = serology.DssBloodType;
                rhesusFactorBox.Text = serology.DssRhesusFactor;
                kellAgBox.Text = serology.DssKellAg;
                rwBox.Text = serology.DssRw;
                hbsAgBox.Text = serology.DssHbsAg;
                antiHcvBox.Text = serology.DssAntiHcv;
                hivBox.Text = serology.DssHiv;
                phenotypeTxt.Text = serology.DssPhenotype;
                analysisDate.Value = serology.DsdtAnalysisDate;
            } else
            {
                rwBox.SelectedIndex = rwBox.FindStringExact("в работе");
                hbsAgBox.SelectedIndex = hbsAgBox.FindStringExact("в работе");
                antiHcvBox.SelectedIndex = antiHcvBox.FindStringExact("в работе");
                hivBox.SelectedIndex = hivBox.FindStringExact("в работе");
            }

        }

        private void loadBoxValues(ComboBox box, string type, DataService queryService)
        {
            List<DdtValues> values = queryService.queryObjectsCollection<DdtValues>(@"select * from ddt_values where dss_name like '" + type + ".%'");
            box.Items.AddRange(values.ToArray());
            box.ValueMember = "dssValue";
            box.DisplayMember = "dssValue";
            values = null;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!getIsValid())
            {
                MessageBox.Show("Введены не все данные на форме! Обязательные поля выделены жирным шрифтом!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }
            DataService service = new DataService();
            if (serology == null)
            {
                serology = new DdtSerology();
                serology.DsidHospitalitySession = hospitalitySession.ObjectId;
                serology.DsidDoctor = hospitalitySession.DsidCuringDoctor;
                serology.DsidPatient = hospitalitySession.DsidPatient;
            }

            serology.DssAntiHcv = antiHcvBox.Text;
            serology.DssBloodType = bloodTypeBox.Text;
            serology.DssHbsAg = hbsAgBox.Text;
            serology.DssHiv = hivBox.Text;
            serology.DssKellAg = kellAgBox.Text;
            serology.DssPhenotype = phenotypeTxt.Text;
            serology.DssRhesusFactor = rhesusFactorBox.Text;
            serology.DssRw = rwBox.Text;
            serology.DsdtAnalysisDate = analysisDate.Value;

            if (string.IsNullOrEmpty(serology.ObjectId))
            {
                service.insertObject<DdtSerology>(serology, DdtSerology.TABLE_NAME);
            }
            else
            {
                service.updateObject<DdtSerology>(serology, DdtSerology.TABLE_NAME, "r_object_id", serology.ObjectId);
            }
            
            Close();
        }

        private bool getIsValid()
        {
            return bloodTypeBox.SelectedIndex >= 0 && rhesusFactorBox.SelectedIndex >= 0 && kellAgBox.SelectedIndex >= 0 && rwBox.SelectedIndex >= 0 &&
                hbsAgBox.SelectedIndex >= 0 && antiHcvBox.SelectedIndex >= 0 && hivBox.SelectedIndex >= 0;
        }
    }
}
