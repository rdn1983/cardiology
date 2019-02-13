using Cardiology.Data.Commons;

namespace Cardiology.Data
{
    public interface IDbDataService
    {
        IDdtReleasePatientService GetDdtReleasePatientService();

        IDdtIssuedMedicineListService GetDdtIssuedMedicineListService();

        IDdtIssuedActionService GetDdtIssuedActionService();

        IDdtValuesService GetDdtValuesService();

        IDdtInspectionService GetDdtInspectionService();

        IDdtOncologicMarkersService GetDdtOncologicMarkersService();

        IDdtConsiliumMemberLevelService GetDdtConsiliumMemberLevelService();

        IDdtHormonesService GetDdtHormonesService();

        IDdtHolterService GetDdtHolterService();

        IDdtJournalService GetDdtJournalService();

        IDdtCureService GetDdtCureService();

        IDdtConsiliumService GetDdtConsiliumService();

        IDdtPatientService GetDdtPatientService();

        IDdtBloodAnalysisService GetDdtBloodAnalysisService();

        IDdtXrayService GetDdtXrayService();

        IDdtEkgService GetDdtEkgService();

        IDdtSerologyService GetDdtSerologyService();

        IDdtEpicrisisService GetDdtEpicrisisService();

        IDdtDoctorService GetDdtDoctorService();

        IDdtAnamnesisService GetDdtAnamnesisService();

        IDdtEgdsService GetDdtEgdsService();

        IDdvDoctorService GetDdvDoctorService();

        IDdtSpecialistConclusionService GetDdtSpecialistConclusionService();

        IDdtHistoryService GetDdtHistoryService();

        IDdtUrineAnalysisService GetDdtUrineAnalysisService();

        IDdvActiveHospitalPatientsService GetDdvActiveHospitalPatientsService();

        IDdtKagService GetDdtKagService();

        IDdtHospitalService GetDdtHospitalService();

        IDdtTransferService GetDdtTransferService();

        IDdtAlcoProtocolService GetDdtAlcoProtocolService();

        IDdvHistoryService GetDdvHistoryService();

        IDdtCureTypeService GetDdtCureTypeService();

        IDmGroupUsersService GetDmGroupUsersService();

        IDdtIssuedMedicineService GetDdtIssuedMedicineService();

        IDmGroupService GetDmGroupService();

        IDdtCoagulogramService GetDdtCoagulogramService();

        IDdvAllDiagnosisService GetDdvAllDiagnosisService();

        IDdtConsiliumMemberService GetDdtConsiliumMemberService();

        IDdtUziService GetDdtUziService();

        IDdtVariousSpecConclusonService GetDdtVariousSpecConclusonService();
    }
}
