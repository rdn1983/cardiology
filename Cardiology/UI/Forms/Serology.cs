using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class Serology : Form
    {
        private readonly IDbDataService service;
        private DdtSerology serology;
        private DdtHospital hospitalitySession;

        public Serology(IDbDataService service, DdtHospital hospitalitySession)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;

            serology = new DataService().queryObject<DdtSerology>(@"select * from ddt_serology where dsid_hospitality_session='" + hospitalitySession.ObjectId + "'");
            InitializeComponent();
            InitBoxes();
        }

        private void InitBoxes()
        {
            LoadBoxValues(bloodTypeBox, "bloodtype");
            LoadBoxValues(rhesusFactorBox, "rhesusFactor");
            LoadBoxValues(kellAgBox, "kellAg");
            LoadBoxValues(rwBox, "serology");
            LoadBoxValues(hbsAgBox, "serology");
            LoadBoxValues(antiHcvBox, "serology");
            LoadBoxValues(hivBox, "serology");

            if (serology != null)
            {
                bloodTypeBox.Text = serology.BloodType;
                rhesusFactorBox.Text = serology.RhesusFactor;
                kellAgBox.Text = serology.KellAg;
                rwBox.Text = serology.Rw;
                hbsAgBox.Text = serology.HbsAg;
                antiHcvBox.Text = serology.AntiHcv;
                hivBox.Text = serology.Hiv;
                phenotypeTxt.Text = serology.Phenotype;
                analysisDate.Value = serology.AnalysisDate;
            } else
            {
                rwBox.SelectedIndex = rwBox.FindStringExact("в работе");
                hbsAgBox.SelectedIndex = hbsAgBox.FindStringExact("в работе");
                antiHcvBox.SelectedIndex = antiHcvBox.FindStringExact("в работе");
                hivBox.SelectedIndex = hivBox.FindStringExact("в работе");
            }

        }

        private void LoadBoxValues(ComboBox box, string type)
        {
            IList<DdtValues> list = service.GetDdtValuesService().GetListByNameLike(type + ".'");
            box.DataSource = list;

            box.ValueMember = "Value";
            box.DisplayMember = "Value";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!getIsValid())
            {
                MessageBox.Show("Введены не все данные на форме! Обязательные поля выделены жирным шрифтом!", "Предупреждение!", MessageBoxButtons.OK);
                return;
            }
            if (serology == null)
            {
                serology = new DdtSerology();
                serology.HospitalitySession = hospitalitySession.ObjectId;
                serology.Doctor = hospitalitySession.CuringDoctor;
                serology.Patient = hospitalitySession.Patient;
            }

            serology.AntiHcv = antiHcvBox.Text;
            serology.BloodType = bloodTypeBox.Text;
            serology.HbsAg = hbsAgBox.Text;
            serology.Hiv = hivBox.Text;
            serology.KellAg = kellAgBox.Text;
            serology.Phenotype = phenotypeTxt.Text;
            serology.RhesusFactor = rhesusFactorBox.Text;
            serology.Rw = rwBox.Text;
            serology.AnalysisDate = analysisDate.Value;

            service.GetDdtSerologyService().Save(serology);
           
            Close();
        }

        private bool getIsValid()
        {
            return bloodTypeBox.SelectedIndex >= 0 && rhesusFactorBox.SelectedIndex >= 0 && kellAgBox.SelectedIndex >= 0 && rwBox.SelectedIndex >= 0 &&
                hbsAgBox.SelectedIndex >= 0 && antiHcvBox.SelectedIndex >= 0 && hivBox.SelectedIndex >= 0;
        }
    }
}
