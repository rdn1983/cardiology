using Cardiology.Data.Commons;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Npgsql.Schema;
using DbColumn = System.Data.Common.DbColumn;
using NLog;
using System.Globalization;

namespace Cardiology.Data.PostgreSQL
{
    class PgDataService : IDbDataService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
        private readonly IDdtEkgService ddtEkgService;
        private readonly IDdtSerologyService ddtSerologyService;
        private readonly IDdtEpicrisisService ddtEpicrisisService;
        private readonly IDdtDoctorService dssDdtDoctorService;
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
        private readonly IDdtConsiliumRelationService ddtConsiliumRelationService;
        private readonly IDdtUziService ddtUziService;
        private readonly IDdtVariousSpecConclusonService ddtVariousSpecConclusonService;
        private readonly IDdtTransfusionService ddtTansfusionService;

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
            ddtEkgService = new PgDdtEkgService(connectionFactory);
            ddtSerologyService = new PgDdtSerologyService(connectionFactory);
            ddtEpicrisisService = new PgDdtEpicrisisService(connectionFactory);
            dssDdtDoctorService = new PgDdtDoctorService(connectionFactory);
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
            ddtConsiliumRelationService = new PgDdtConsiliumRelationService(connectionFactory);
            ddtUziService = new PgDdtUziService(connectionFactory);
            ddtVariousSpecConclusonService = new PgDdtVariousSpecConclusonService(connectionFactory);
            ddtTansfusionService = new PgDdtTransfusionService(connectionFactory);
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
            return dssDdtDoctorService;
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

        public IDdtConsiliumRelationService GetDdtConsiliumRelationService()
        {
            return ddtConsiliumRelationService;
        }

        public IDdtUziService GetDdtUziService()
        {
            return ddtUziService;
        }

        public IDdtVariousSpecConclusonService GetDdtVariousSpecConclusonService()
        {
            return ddtVariousSpecConclusonService;
        }

        public IDdtTransfusionService GetDdtTransfusionService()
        {
            return ddtTansfusionService;
        }

        public void Select(string sql, string key, string value, OnKeyValue handler)
        {
            Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    System.Collections.ObjectModel.ReadOnlyCollection<DbColumn> columns = reader.GetColumnSchema();
                    IEnumerator<DbColumn> colsNumerator = columns.GetEnumerator();

                    while (reader.Read())
                    {
                        string attrKeyValue = null;
                        string attrValValue = null;
                        while (colsNumerator.MoveNext())
                        {
                            if (key.Equals(colsNumerator.Current.ColumnName, StringComparison.Ordinal))
                            {
                                int indx = columns.IndexOf(colsNumerator.Current);
                                attrKeyValue = getWrappedValue(reader.GetValue(indx), reader.GetFieldType(indx));
                            }
                            else if (value.Equals(colsNumerator.Current.ColumnName, StringComparison.Ordinal))
                            {
                                int indx = columns.IndexOf(colsNumerator.Current);
                                attrValValue = getWrappedValue(reader.GetValue(indx), reader.GetFieldType(indx));
                            }
                        }
                        colsNumerator.Reset();

                        if (attrKeyValue != null)
                        {
                            handler(attrKeyValue, attrValValue);
                        }
                    }


                }
            }
        }



        private string getWrappedValue(object value, Type fieldType)
        {
            if (fieldType == typeof(int) || fieldType == typeof(double))
            {
                return value + "";
            }
            else if (fieldType == typeof(string))
            {
                return value?.ToString();
            }
            else if (fieldType == typeof(DateTime))
            {
                DateTime dt = (DateTime) value;
                return dt.ToShortDateString() + " " + dt.ToShortTimeString();
            }
            else
            {
                return value?.ToString();
            }

        }

        public string GetString(string sql)
        {
            Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }

                return null;
            }
        }

        public DateTime GetTime(string sql)
        {
            Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetDateTime(0);
                    }
                }

                return default(DateTime);
            }
        }


        public void Delete(string type, string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "delete from " + type + " WHERE r_object_id = '" + id + "'";
                Logger.Debug(CultureInfo.CurrentCulture, "SQL: {0}", sql);

                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                command.ExecuteScalar();
            }
        }

        public void Execute(string sql)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                command.ExecuteScalar();
            }
        }
    }
}
