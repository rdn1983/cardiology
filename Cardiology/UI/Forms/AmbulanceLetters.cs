using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class AmbulanceLetters : Form
    {
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;

        public AmbulanceLetters(IDbDataService service, DdtHospital hospitalitySession)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
            ControlUtils.InitDoctorsByGroupNameAndOrder(service.GetDdvDoctorService(), doctorsBox, "cardioreanimation_department", "default.cardioreanimation_department_head");
        }

        private void gbUdinaBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_date}", toDate.Value.ToShortDateString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate(service, "gkb_yudina_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void gkbBuyanovaBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_date}", toDate.Value.ToShortDateString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate(service, "gkb_buyanova_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void lrcBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_date}", toDate.Value.ToShortDateString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate(service, "lrc_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_date}", toDate.Value.ToShortDateString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate(service, "gkb83_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void mschBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_date}", toDate.Value.ToShortDateString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate(service, "msch60_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void gkb52Btn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_date}", toDate.Value.ToShortDateString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate(service, "gkb52_letter_template.doc", hospitalitySession.ObjectId, data);
        }


    }
}
