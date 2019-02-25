using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Commons;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class AmbulanceLetters : Form
    {
        private DdtHospital hospitalitySession;

        public AmbulanceLetters(IDbDataService service, DdtHospital hospitalitySession)
        {
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
            CommonUtils.InitDoctorsComboboxValues(service, doctorsBox, "");
        }

        private void gbUdinaBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate("gkb_yudina_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void gkbBuyanovaBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate("gkb_buyanova_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void lrcBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate("lrc_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate("gkb83_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void mschBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate("msch60_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void gkb52Btn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdvDoctor doc = (DdvDoctor)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.ShortName);
            TemplatesUtils.fillAmbulanceLetterTemplate("gkb52_letter_template.doc", hospitalitySession.ObjectId, data);
        }


    }
}
