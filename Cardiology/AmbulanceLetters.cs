using Cardiology.Model;
using Cardiology.Utils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cardiology
{
    public partial class AmbulanceLetters : Form
    {
        private DdtHospital hospitalitySession;

        public AmbulanceLetters(DdtHospital hospitalitySession)
        {
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
            CommonUtils.initDoctorsComboboxValues(new DataService(), doctorsBox, "");
        }

        private void gbUdinaBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdtDoctors doc = (DdtDoctors)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.DssInitials);
            TemplatesUtils.fillAmbulanceLetterTemplate("gkb_yudina_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void gkbBuyanovaBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdtDoctors doc = (DdtDoctors)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.DssInitials);
            TemplatesUtils.fillAmbulanceLetterTemplate("gkb_buyanova_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void lrcBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdtDoctors doc = (DdtDoctors)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.DssInitials);
            TemplatesUtils.fillAmbulanceLetterTemplate("lrc_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdtDoctors doc = (DdtDoctors)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.DssInitials);
            TemplatesUtils.fillAmbulanceLetterTemplate("gkb83_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void mschBtn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdtDoctors doc = (DdtDoctors)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.DssInitials);
            TemplatesUtils.fillAmbulanceLetterTemplate("msch60_letter_template.doc", hospitalitySession.ObjectId, data);
        }

        private void gkb52Btn_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("{from_date}", fromDate.Value.ToShortDateString());
            data.Add("{from_time}", fromTime.Value.ToShortTimeString());
            data.Add("{to_time}", toTime.Value.ToShortTimeString());
            DdtDoctors doc = (DdtDoctors)doctorsBox.SelectedItem;
            data.Add("{doctor.selected}", doc == null ? "" : doc.DssInitials);
            TemplatesUtils.fillAmbulanceLetterTemplate("gkb52_letter_template.doc", hospitalitySession.ObjectId, data);
        }
    }
}
