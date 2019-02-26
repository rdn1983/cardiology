using System;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.UI.Forms
{
    public partial class AlcoIntoxication : Form
    {
        private DdtHospital hospitalitySession;


        public AlcoIntoxication(DdtHospital hospitalitySession)
        {
            this.hospitalitySession = hospitalitySession;
            InitializeComponent();
            initProtocol();
        }

        private void initProtocol()
        {

            DdvPatient patient = service.queryObjectById<DdtPatient>(hospitalitySession.Patient);
            if (patient != null)
            {
                Text += " " + patient.ShortName;
            }
            DdtAlcoProtocol protocol = service.queryObject<DdtAlcoProtocol>(@"SELECT * FROM ddt_alco_protocol where dsid_hospitality_session='" + hospitalitySession.ObjectId + "'");
            if (protocol != null)
            {
                behaviorTxt.Text = protocol.Behavior;
                bioTxt.Text = protocol.Bio;
                breatheTxt.Text = protocol.Breathe;
                conclusionTxt.Text = protocol.Conclusion;
                docsTxt.Text = protocol.Docs;
                drunkTxt.Text = protocol.Drunk;
                eyesTxt.Text = protocol.Eyes;
                illnessTxt.Text = protocol.Illness;
                lookTxt.Text = protocol.Look;
                mimicsTxt.Text = protocol.Mimics;
                motionTxt.Text = protocol.Motions;
                nistagmTxt.Text = protocol.Nistagm;
                orientationTxt.Text = protocol.Orientation;
                pressureTxt.Text = protocol.Pressure;
                priborTxt.Text = protocol.Pribor;
                pulseTxt.Text = protocol.Pulse;
                skinTxt.Text = protocol.Skin;
                smellTxt.Text = protocol.Smell;
                speechTxt.Text = protocol.Speech;
                touchNoseTxt.Text = protocol.TouchNose;
                trembleTxt.Text = protocol.Tremble;
                trubTxt.Text = protocol.Trub;
                walkTxt.Text = protocol.Walk;
                causeTxt.Text = protocol.Cause;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            DdtAlcoProtocol protocol = service.queryObject<DdtAlcoProtocol>(@"SELECT * FROM ddt_alco_protocol where dsid_hospitality_session='" + hospitalitySession.ObjectId + "'");
            if (protocol == null)
            {
                protocol = new DdtAlcoProtocol();
                protocol.HospitalitySession = hospitalitySession.ObjectId;
                protocol.Template = false;
            }

            protocol.Behavior = behaviorTxt.Text;
            protocol.Bio = bioTxt.Text;
            protocol.Breathe = breatheTxt.Text;
            protocol.Conclusion = conclusionTxt.Text;
            protocol.Docs = docsTxt.Text;
            protocol.Drunk = drunkTxt.Text;
            protocol.Eyes = eyesTxt.Text;
            protocol.Illness = illnessTxt.Text;
            protocol.Look = lookTxt.Text;
            protocol.Mimics = mimicsTxt.Text;
            protocol.Motions = motionTxt.Text;
            protocol.Nistagm = nistagmTxt.Text;
            protocol.Orientation = orientationTxt.Text;
            protocol.Pressure = pressureTxt.Text;
            protocol.Pribor = priborTxt.Text;
            protocol.Pulse = pulseTxt.Text;
            protocol.Skin = skinTxt.Text;
            protocol.Smell = smellTxt.Text;
            protocol.Speech = speechTxt.Text;
            protocol.TouchNose = touchNoseTxt.Text;
            protocol.Tremble = trembleTxt.Text;
            protocol.Trub = trubTxt.Text;
            protocol.Walk = walkTxt.Text;
            protocol.Cause = causeTxt.Text;

            service.updateOrCreateIfNeedObject<DdtAlcoProtocol>(protocol, DdtAlcoProtocol.NAME, protocol.ObjectId);
            Close();
        }
    }
}
