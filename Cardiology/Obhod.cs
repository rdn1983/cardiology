using Cardiology.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class Obhod : Form
    {
        private DdtHospital hospitalitySession;
        private DdtInspection inspectionObj;

        public Obhod(DdtHospital hospitalitySession, string id)
        {
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            DataService service = new DataService();
            DdtEkg firstEkg = service.queryObject<DdtEkg>(@"SELECT * FROM ddt_ekg WHERE dsid_hospitality_session='" + hospitalitySession.ObjectId
                + "' AND dsb_admission_analysis=true");
            if (firstEkg != null)
            {
                ekgContainer.Controls.Add(new EkgAnalysisControlcs(firstEkg.ObjectId, true));
            }
            ekgContainer.Controls.Add(new EkgAnalysisControlcs(null, false));
        }

        private void initIssuedCure(DataService service)
        {
            DdtIssuedMedicineList medList = service.queryObjectById<DdtIssuedMedicineList>(DdtIssuedMedicineList.TABLE_NAME, null);
            reinitFromMedList(service, medList);
        }

        private void reinitFromMedList(DataService service, DdtIssuedMedicineList medList)
        {
            if (medList != null)
            {
                issuedMedicineControl1.Init(service, medList);
            }
        }

        private void checkAnalyzesBtn_Click(object sender, EventArgs e)
        {
            /*Analizi analiziForm = new Analizi();
            analiziForm.ShowDialog();*/
        }

        private void addMedicineBtn_Click(object sender, EventArgs e)
        {
            issuedMedicineControl1.addMedicineBox();
        }

        private void saveIssuedMedicine()
        {
            DataService service = new DataService();
            List<DdtIssuedMedicine> meds = issuedMedicineControl1.getIssuedMedicines();
            if (meds.Count > 0)
            {
                DdtIssuedMedicineList medList = service.queryObjectById<DdtIssuedMedicineList>(DdtIssuedMedicineList.TABLE_NAME, null);
                if (medList == null)
                {
                    medList = new DdtIssuedMedicineList();
                    medList.DsidDoctor = hospitalitySession.DsidDutyDoctor;
                    medList.DsidHospitalitySession = hospitalitySession.ObjectId;
                    medList.DsidPatient = hospitalitySession.DsidPatient;
                    medList.DsidParentId = "";
                    string id = service.insertObject<DdtIssuedMedicineList>(medList, DdtIssuedMedicineList.TABLE_NAME);
                    medList.ObjectId = id;
                }
                foreach (DdtIssuedMedicine med in meds)
                {
                    med.DsidMedList = medList.ObjectId;
                    service.updateOrCreateIfNeedObject<DdtIssuedMedicine>(med, DdtIssuedMedicine.TABLE_NAME, med.RObjectId);
                }
            }
        }
    }
}
