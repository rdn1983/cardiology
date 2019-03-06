using System;
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

        IDdtHormonesService GetDdtHormonesService();

        IDdtHolterService GetDdtHolterService();

        IDdtJournalService GetDdtJournalService();

        IDdtCureService GetDdtCureService();

        IDdtConsiliumService GetDdtConsiliumService();

        IDdtPatientService GetDdtPatientService();

        IDdvPatientService GetDdvPatientService();

        IDdtBloodAnalysisService GetDdtBloodAnalysisService();

        IDdtXrayService GetDdtXrayService();

        IDdtEkgService GetDdtEkgService();

        IDdtSerologyService GetDdtSerologyService();

        IDdtEpicrisisService GetDdtEpicrisisService();

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

        IDdtConsiliumGroupService GetDdtConsiliumGroupService();

        IDdtAlcoProtocolService GetDdtAlcoProtocolService();

        IDdvHistoryService GetDdvHistoryService();

        IDdtCureTypeService GetDdtCureTypeService();

        IDmGroupUsersService GetDmGroupUsersService();

        IDdtIssuedMedicineService GetDdtIssuedMedicineService();

        IDmGroupService GetDmGroupService();

        IDdtCoagulogramService GetDdtCoagulogramService();

        IDdvAllDiagnosisService GetDdvAllDiagnosisService();

        IDdtConsiliumMemberService GetDdtConsiliumMemberService();

        IDdtConsiliumGroupMemberService GetDdtConsiliumGroupMemberService();

        IDdtUziService GetDdtUziService();

        IDdtVariousSpecConclusonService GetDdtVariousSpecConclusonService();

        void Select(string sql, string key, string value, OnKeyValue handler);

        string GetString(string sql);

        DateTime GetTime(string sql);

        void Delete(string type, string id);

        void Execute(string sql);
    }

    public delegate void OnKeyValue(string key, string value);
}
