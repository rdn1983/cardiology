using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    class PgDataService : IDbDataService
    {
        private readonly IDbConnectionFactory connectionFactory;
        private readonly IDdtReleasePatientService ddtReleasePatientService;
        private readonly IDdtIssuedMedicineListService ddtIssuedMedicineListService;
        private readonly IDdtIssuedActionService ddtIssuedActionService;
        private readonly IDdtValuesService ddtValuesService;
        private readonly IDdtInspectionService ddtInspectionService;
        private readonly IDdtOncologicMarkersService ddtOncologicMarkersService;
        private readonly IDdvPatientService ddvPatientService;
        private readonly IDdtHormonesService ddtHormonesService;
        private readonly IDdtHolterService ddtHolterService;
        private readonly IDdtJournalService ddtJournalService;
        private readonly IDdtCureService ddtCureService;
        private readonly IDdtConsiliumService ddtConsiliumService;
        private readonly IDdtPatientService ddtPatientService;
        private readonly IDdtBloodAnalysisService ddtBloodAnalysisService;
        private readonly IDdtXrayService ddtXrayService;
        private readonly IDdtConsiliumGroupLevelService ddtConsiliumGroupLevelService;
        private readonly IDdtEkgService ddtEkgService;
        private readonly IDdtSerologyService ddtSerologyService;
        private readonly IDdtEpicrisisService ddtEpicrisisService;
        private readonly IDdtDoctorService ddtDoctorService;
        private readonly IDdtConsiliumGroupMemberService ddtConsiliumGroupMemberService;
        private readonly IDdtAnamnesisService ddtAnamnesisService;
        private readonly IDdvDoctorService ddvDoctorService;
        private readonly IDdtEgdsService ddtEgdsService;
        private readonly IDdtSpecialistConclusionService ddtSpecialistConclusionService;
        private readonly IDdtHistoryService ddtHistoryService;
        private readonly IDdvActiveHospitalPatientsService ddvActiveHospitalPatientsService;
        private readonly IDdtUrineAnalysisService ddtUrineAnalysisService;
        private readonly IDdtKagService ddtKagService;
        private readonly IDdtHospitalService ddtHospitalService;
        private readonly IDdtTransferService ddtTransferService;
        private readonly IDdtConsiliumGroupService ddtConsiliumGroupService;
        private readonly IDdtAlcoProtocolService ddtAlcoProtocolService;
        private readonly IDdvHistoryService ddvHistoryService;
        private readonly IDdtCureTypeService ddtCureTypeService;
        private readonly IDmGroupUsersService dmGroupUsersService;
        private readonly IDdtIssuedMedicineService ddtIssuedMedicineService;
        private readonly IDmGroupService dmGroupService;
        private readonly IDdtCoagulogramService ddtCoagulogramService;
        private readonly IDdvAllDiagnosisService ddvAllDiagnosisService;
        private readonly IDdtConsiliumMemberService ddtConsiliumMemberService;
        private readonly IDdtUziService ddtUziService;
        private readonly IDdtVariousSpecConclusonService ddtVariousSpecConclusonService;

        public PgDataService(IDbConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;

            ddtReleasePatientService = new PgDdtReleasePatientService(connectionFactory);
            ddtIssuedMedicineListService = new PgDdtIssuedMedicineListService(connectionFactory);
            ddtIssuedActionService = new PgDdtIssuedActionService(connectionFactory);
            ddtValuesService = new PgDdtValuesService(connectionFactory);
            ddtInspectionService = new PgDdtInspectionService(connectionFactory);
            ddtOncologicMarkersService = new PgDdtOncologicMarkersService(connectionFactory);
            ddvPatientService = new PgDdvPatientService(connectionFactory);
            ddtHormonesService = new PgDdtHormonesService(connectionFactory);
            ddtHolterService = new PgDdtHolterService(connectionFactory);
            ddtJournalService = new PgDdtJournalService(connectionFactory);
            ddtCureService = new PgDdtCureService(connectionFactory);
            ddtConsiliumService = new PgDdtConsiliumService(connectionFactory);
            ddtPatientService = new PgDdtPatientService(connectionFactory);
            ddtBloodAnalysisService = new PgDdtBloodAnalysisService(connectionFactory);
            ddtXrayService = new PgDdtXrayService(connectionFactory);
            ddtConsiliumGroupLevelService = new PgDdtConsiliumGroupLevelService(connectionFactory);
            ddtEkgService = new PgDdtEkgService(connectionFactory);
            ddtSerologyService = new PgDdtSerologyService(connectionFactory);
            ddtEpicrisisService = new PgDdtEpicrisisService(connectionFactory);
            ddtDoctorService = new PgDdtDoctorService(connectionFactory);
            ddtConsiliumGroupMemberService = new PgDdtConsiliumGroupMemberService(connectionFactory);
            ddtAnamnesisService = new PgDdtAnamnesisService(connectionFactory);
            ddvDoctorService = new PgDdvDoctorService(connectionFactory);
            ddtEgdsService = new PgDdtEgdsService(connectionFactory);
            ddtSpecialistConclusionService = new PgDdtSpecialistConclusionService(connectionFactory);
            ddtHistoryService = new PgDdtHistoryService(connectionFactory);
            ddvActiveHospitalPatientsService = new PgDdvActiveHospitalPatientsService(connectionFactory);
            ddtUrineAnalysisService = new PgDdtUrineAnalysisService(connectionFactory);
            ddtKagService = new PgDdtKagService(connectionFactory);
            ddtHospitalService = new PgDdtHospitalService(connectionFactory);
            ddtTransferService = new PgDdtTransferService(connectionFactory);
            ddtConsiliumGroupService = new PgDdtConsiliumGroupService(connectionFactory);
            ddtAlcoProtocolService = new PgDdtAlcoProtocolService(connectionFactory);
            ddvHistoryService = new PgDdvHistoryService(connectionFactory);
            ddtCureTypeService = new PgDdtCureTypeService(connectionFactory);
            dmGroupUsersService = new PgDmGroupUsersService(connectionFactory);
            ddtIssuedMedicineService = new PgDdtIssuedMedicineService(connectionFactory);
            dmGroupService = new PgDmGroupService(connectionFactory);
            ddtCoagulogramService = new PgDdtCoagulogramService(connectionFactory);
            ddvAllDiagnosisService = new PgDdvAllDiagnosisService(connectionFactory);
            ddtConsiliumMemberService = new PgDdtConsiliumMemberService(connectionFactory);
            ddtUziService = new PgDdtUziService(connectionFactory);
            ddtVariousSpecConclusonService = new PgDdtVariousSpecConclusonService(connectionFactory);
        }

        public IDdtReleasePatientService GetDdtReleasePatientService()
        {
            return ddtReleasePatientService;
        }

        public IDdtIssuedMedicineListService GetDdtIssuedMedicineListService()
        {
            return ddtIssuedMedicineListService;
        }

        public IDdtIssuedActionService GetDdtIssuedActionService()
        {
            return ddtIssuedActionService;
        }

        public IDdtValuesService GetDdtValuesService()
        {
            return ddtValuesService;
        }

        public IDdtInspectionService GetDdtInspectionService()
        {
            return ddtInspectionService;
        }

        public IDdtOncologicMarkersService GetDdtOncologicMarkersService()
        {
            return ddtOncologicMarkersService;
        }

        public IDdvPatientService GetDdvPatientService()
        {
            return ddvPatientService;
        }

        public IDdtHormonesService GetDdtHormonesService()
        {
            return ddtHormonesService;
        }

        public IDdtHolterService GetDdtHolterService()
        {
            return ddtHolterService;
        }

        public IDdtJournalService GetDdtJournalService()
        {
            return ddtJournalService;
        }

        public IDdtCureService GetDdtCureService()
        {
            return ddtCureService;
        }

        public IDdtConsiliumService GetDdtConsiliumService()
        {
            return ddtConsiliumService;
        }

        public IDdtPatientService GetDdtPatientService()
        {
            return ddtPatientService;
        }

        public IDdtBloodAnalysisService GetDdtBloodAnalysisService()
        {
            return ddtBloodAnalysisService;
        }

        public IDdtXrayService GetDdtXrayService()
        {
            return ddtXrayService;
        }

        public IDdtConsiliumGroupLevelService GetDdtConsiliumGroupLevelService()
        {
            return ddtConsiliumGroupLevelService;
        }

        public IDdtEkgService GetDdtEkgService()
        {
            return ddtEkgService;
        }

        public IDdtSerologyService GetDdtSerologyService()
        {
            return ddtSerologyService;
        }

        public IDdtEpicrisisService GetDdtEpicrisisService()
        {
            return ddtEpicrisisService;
        }

        public IDdtDoctorService GetDdtDoctorService()
        {
            return ddtDoctorService;
        }

        public IDdtConsiliumGroupMemberService GetDdtConsiliumGroupMemberService()
        {
            return ddtConsiliumGroupMemberService;
        }

        public IDdtAnamnesisService GetDdtAnamnesisService()
        {
            return ddtAnamnesisService;
        }

        public IDdvDoctorService GetDdvDoctorService()
        {
            return ddvDoctorService;
        }

        public IDdtEgdsService GetDdtEgdsService()
        {
            return ddtEgdsService;
        }

        public IDdtSpecialistConclusionService GetDdtSpecialistConclusionService()
        {
            return ddtSpecialistConclusionService;
        }

        public IDdtHistoryService GetDdtHistoryService()
        {
            return ddtHistoryService;
        }

        public IDdvActiveHospitalPatientsService GetDdvActiveHospitalPatientsService()
        {
            return ddvActiveHospitalPatientsService;
        }

        public IDdtUrineAnalysisService GetDdtUrineAnalysisService()
        {
            return ddtUrineAnalysisService;
        }

        public IDdtKagService GetDdtKagService()
        {
            return ddtKagService;
        }

        public IDdtHospitalService GetDdtHospitalService()
        {
            return ddtHospitalService;
        }

        public IDdtTransferService GetDdtTransferService()
        {
            return ddtTransferService;
        }

        public IDdtConsiliumGroupService GetDdtConsiliumGroupService()
        {
            return ddtConsiliumGroupService;
        }

        public IDdtAlcoProtocolService GetDdtAlcoProtocolService()
        {
            return ddtAlcoProtocolService;
        }

        public IDdvHistoryService GetDdvHistoryService()
        {
            return ddvHistoryService;
        }

        public IDdtCureTypeService GetDdtCureTypeService()
        {
            return ddtCureTypeService;
        }

        public IDmGroupUsersService GetDmGroupUsersService()
        {
            return dmGroupUsersService;
        }

        public IDdtIssuedMedicineService GetDdtIssuedMedicineService()
        {
            return ddtIssuedMedicineService;
        }

        public IDmGroupService GetDmGroupService()
        {
            return dmGroupService;
        }

        public IDdtCoagulogramService GetDdtCoagulogramService()
        {
            return ddtCoagulogramService;
        }

        public IDdvAllDiagnosisService GetDdvAllDiagnosisService()
        {
            return ddvAllDiagnosisService;
        }

        public IDdtConsiliumMemberService GetDdtConsiliumMemberService()
        {
            return ddtConsiliumMemberService;
        }

        public IDdtUziService GetDdtUziService()
        {
            return ddtUziService;
        }

        public IDdtVariousSpecConclusonService GetDdtVariousSpecConclusonService()
        {
            return ddtVariousSpecConclusonService;
        }
    }
}
