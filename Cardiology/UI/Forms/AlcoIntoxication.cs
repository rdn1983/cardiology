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

            DdtPatient patient = service.queryObjectById<DdtPatient>(hospitalitySession.DsidPatient);
            if (patient != null)
            {
                Text += " " + patient.DssInitials;
            }
            DdtAlcoProtocol protocol = service.queryObject<DdtAlcoProtocol>(@"SELECT * FROM ddt_alco_protocol where dsid_hospitality_session='" + hospitalitySession.ObjectId + "'");
            if (protocol != null)
            {
                behaviorTxt.Text = protocol.DssBehavior;
                bioTxt.Text = protocol.DssBio;
                breatheTxt.Text = protocol.DssBreathe;
                conclusionTxt.Text = protocol.DssConclusion;
                docsTxt.Text = protocol.DssDocs;
                drunkTxt.Text = protocol.DssDrunk;
                eyesTxt.Text = protocol.DssEyes;
                illnessTxt.Text = protocol.DssIllness;
                lookTxt.Text = protocol.DssLook;
                mimicsTxt.Text = protocol.DssMimics;
                motionTxt.Text = protocol.DssMotions;
                nistagmTxt.Text = protocol.DssNistagm;
                orientationTxt.Text = protocol.DssOrientation;
                pressureTxt.Text = protocol.DssPressure;
                priborTxt.Text = protocol.DssPribor;
                pulseTxt.Text = protocol.DssPulse;
                skinTxt.Text = protocol.DssSkin;
                smellTxt.Text = protocol.DssSmell;
                speechTxt.Text = protocol.DssSpeech;
                touchNoseTxt.Text = protocol.DssTouchNose;
                trembleTxt.Text = protocol.DssTremble;
                trubTxt.Text = protocol.DssTrub;
                walkTxt.Text = protocol.DssWalk;
                causeTxt.Text = protocol.DssCause;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            DdtAlcoProtocol protocol = service.queryObject<DdtAlcoProtocol>(@"SELECT * FROM ddt_alco_protocol where dsid_hospitality_session='" + hospitalitySession.ObjectId + "'");
            if (protocol == null)
            {
                protocol = new DdtAlcoProtocol();
                protocol.DsidHospitalitySession = hospitalitySession.ObjectId;
                protocol.DsbTemplate = false;
            }

            protocol.DssBehavior = behaviorTxt.Text;
            protocol.DssBio = bioTxt.Text;
            protocol.DssBreathe = breatheTxt.Text;
            protocol.DssConclusion = conclusionTxt.Text;
            protocol.DssDocs = docsTxt.Text;
            protocol.DssDrunk = drunkTxt.Text;
            protocol.DssEyes = eyesTxt.Text;
            protocol.DssIllness = illnessTxt.Text;
            protocol.DssLook = lookTxt.Text;
            protocol.DssMimics = mimicsTxt.Text;
            protocol.DssMotions = motionTxt.Text;
            protocol.DssNistagm = nistagmTxt.Text;
            protocol.DssOrientation = orientationTxt.Text;
            protocol.DssPressure = pressureTxt.Text;
            protocol.DssPribor = priborTxt.Text;
            protocol.DssPulse = pulseTxt.Text;
            protocol.DssSkin = skinTxt.Text;
            protocol.DssSmell = smellTxt.Text;
            protocol.DssSpeech = speechTxt.Text;
            protocol.DssTouchNose = touchNoseTxt.Text;
            protocol.DssTremble = trembleTxt.Text;
            protocol.DssTrub = trubTxt.Text;
            protocol.DssWalk = walkTxt.Text;
            protocol.DssCause = causeTxt.Text;

            service.updateOrCreateIfNeedObject<DdtAlcoProtocol>(protocol, DdtAlcoProtocol.NAME, protocol.ObjectId);
            Close();
        }
    }
}
