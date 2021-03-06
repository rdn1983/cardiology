﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cardiology.Data;
using Cardiology.Data.Model2;
using Cardiology.UI.Controls;

namespace Cardiology.UI.Forms
{
    public partial class AnalysisContainer : Form
    {
        private const string FIRST_ANALYSIS_QRY_TEMPLATE = @"SELECT * FROM {0} WHERE dss_parent_type='ddt_anamnesis' and dsid_hospitality_session='{1}'";

        private string typeName;
        private List<string> selectedIds;
        private string currentId;
        private readonly IDbDataService service;
        private DdtHospital hospitalitySession;

        public AnalysisContainer(IDbDataService service, DdtHospital hospitalitySession, string typeName, string objectId)
        {
            this.service = service;
            this.hospitalitySession = hospitalitySession;
            this.typeName = typeName;
            this.currentId = objectId;
            selectedIds = new List<string>();

            InitializeComponent();
            bool isHorizontalStyle = DdtEkg.NAME.Equals(typeName, StringComparison.Ordinal) || DdtEgds.NAME.Equals(typeName, StringComparison.Ordinal) || DdtHolter.NAME.Equals(typeName, StringComparison.Ordinal);
            combainingContainer.GrowStyle = isHorizontalStyle ? TableLayoutPanelGrowStyle.AddRows : TableLayoutPanelGrowStyle.AddColumns;
            combainingContainer.RowStyles.Clear();
            combainingContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            initControls();
            initTitle();
        }

        private void initControls()
        {
            bool needAdmissionAnalysis = DdtUrineAnalysis.NAME.Equals(typeName, StringComparison.Ordinal) || DdtBloodAnalysis.NAME.Equals(typeName, StringComparison.Ordinal)
                || DdtEgds.NAME.Equals(typeName, StringComparison.Ordinal) || DdtEkg.NAME.Equals(typeName, StringComparison.Ordinal);

            if (needAdmissionAnalysis)
            {
                string firstAnalysisId = service.GetString(string.Format(FIRST_ANALYSIS_QRY_TEMPLATE, typeName, hospitalitySession.ObjectId));
                if (firstAnalysisId != null && !firstAnalysisId.Equals(currentId, StringComparison.Ordinal))
                {
                    createControl(firstAnalysisId);
                }
            }
            createControl(currentId);
        }

        private void createControl(string objectId)
        {
            selectedIds.Add(objectId);

            if (DdtBloodAnalysis.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new BloodAnalysisControl(objectId, null, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal)));
            }
            else if (DdtUrineAnalysis.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new UrineAnalysisControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal)));
            }
            else if (DdtEkg.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                EkgAnalysisControlcs ekg = new EkgAnalysisControlcs(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal));
                combainingContainer.Controls.Add(ekg);
                Console.WriteLine(ekg.Size);
            }
            else if (DdtKag.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new KagAnalysisControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal), hospitalitySession.ObjectId));
            }
            else if (DdtEgds.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new EgdsAnalysisControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal)));
            }
            else if (DdtXRay.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new XRayControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal)));
            }
            else if (DdtHolter.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new HolterControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal)));
            }
            else if (DdtUzi.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new UziAnalysisControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal)));
            }
            else if (DdtSpecialistConclusion.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new SpecialistConclusionControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal)));
            }
            else if (DdtHormones.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new HormonesControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal)));
            }
            else if (DdtCoagulogram.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new CoagulogrammControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal)));
            }
            else if (DdtOncologicMarkers.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                combainingContainer.Controls.Add(new OncologicMarkersControl(objectId, objectId != null && !objectId.Equals(currentId, StringComparison.Ordinal), hospitalitySession.ObjectId));
            }
        }

        private void initTitle()
        {
            if (DdtBloodAnalysis.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "Клинический анализ крови";
            }
            else if (DdtUrineAnalysis.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "Анализ мочи";
            }
            else if (DdtKag.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "КАГ";
            }
            else if (DdtEkg.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "ЭКГ";
            }
            else if (DdtEgds.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "ЭГДС";
            }
            else if (DdtUzi.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "УЗИ";
            }
            else if (DdtXRay.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "Рентген/КТ";
            }
            else if (DdtHolter.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "Холтер/СМАД";
            }
            else if (DdtSpecialistConclusion.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "Заключение специалистов";
            }
            else if (DdtCoagulogram.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "Коагулограмма";
            }
            else if (DdtHormones.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "Гормоны";
            }
            else if (DdtHormones.NAME.Equals(typeName, StringComparison.Ordinal))
            {
                this.Text = "Онкомаркеры";
            }

            DdtHospital hospital = service.GetDdtHospitalService().GetById(hospitalitySession.ObjectId);
            DdvPatient patient = service.GetDdvPatientService().GetById(hospital.Patient);
            if (patient != null)
            {
                this.Text += " " + patient.ShortName;
            }
        }

        private void selectToContainer_Click(object sender, EventArgs e)
        {
            AnalysisSelector.getInstance().ShowDialog(typeName, "dsid_hospitality_session='" + hospitalitySession.ObjectId + "'", "dsdt_analysis_date", "r_object_id", selectedIds);
            if (AnalysisSelector.getInstance().isSuccess())
            {
                List<string> result = AnalysisSelector.getInstance().returnValues();
                foreach (string id in result)
                {
                    createControl(id);
                }

            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            combainingContainer.Controls.Clear();
            selectedIds.Clear();
            currentId = null;
            hospitalitySession = null;
            typeName = null;
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (Control c in combainingContainer.Controls)
            {
                IDocbaseControl docbaseControl = (IDocbaseControl)c;
                docbaseControl.saveObject(hospitalitySession, null, null);
                if (DdtBloodAnalysis.NAME.Equals(typeName, StringComparison.Ordinal))
                {
                    docbaseControl.getObjectId();
                    SetBloodAnalysisIdToTransfusion(docbaseControl.getObjectId());
                }
            }
            Close();
        }

        private void SetBloodAnalysisIdToTransfusion(string objId)
        {
            Transfusion transfusion = this.Owner as Transfusion;
            if (transfusion != null)
            {
                transfusion.BloodAnalysisId = objId;
            }
        }

    }
}
