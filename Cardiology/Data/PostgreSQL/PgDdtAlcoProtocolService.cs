using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;

namespace Cardiology.Data.PostgreSQL
{
    public class PgDdtAlcoProtocolService : IDdtAlcoProtocolService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PgDdtAlcoProtocolService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<DdtAlcoProtocol> GetAll()
        {
            IList<DdtAlcoProtocol> list = new List<DdtAlcoProtocol>();
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = "SELECT r_object_id, dss_pribor, dss_conclusion, dss_mimics, dss_breathe, dss_tremble, dss_illness, dss_orientation, dss_skin, dss_drunk, dss_pressure, dss_pulse, dsb_template, dss_touch_nose, dss_docs, dss_bio, dss_speech, dss_cause, dss_smell, dss_motions, r_creation_date, dsid_hospitality_session, dss_eyes, r_modify_date, dss_walk, dss_nistagm, dss_look, dss_trub, dss_behavior FROM ddt_alco_protocol";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtAlcoProtocol obj = new DdtAlcoProtocol();
                        obj.ObjectId = reader.GetString(1);
                        obj.Pribor = reader.GetString(2);
                        obj.Conclusion = reader.GetString(3);
                        obj.Mimics = reader.GetString(4);
                        obj.Breathe = reader.GetString(5);
                        obj.Tremble = reader.GetString(6);
                        obj.Illness = reader.GetString(7);
                        obj.Orientation = reader.GetString(8);
                        obj.Skin = reader.GetString(9);
                        obj.Drunk = reader.GetString(10);
                        obj.Pressure = reader.GetString(11);
                        obj.Pulse = reader.GetString(12);
                        obj.Template = reader.GetBoolean(13);
                        obj.TouchNose = reader.GetString(14);
                        obj.Docs = reader.GetString(15);
                        obj.Bio = reader.GetString(16);
                        obj.Speech = reader.GetString(17);
                        obj.Cause = reader.GetString(18);
                        obj.Smell = reader.GetString(19);
                        obj.Motions = reader.GetString(20);
                        obj.CreationDate = reader.GetDateTime(21);
                        obj.HospitalitySession = reader.GetString(22);
                        obj.Eyes = reader.GetString(23);
                        obj.ModifyDate = reader.GetDateTime(24);
                        obj.Walk = reader.GetString(25);
                        obj.Nistagm = reader.GetString(26);
                        obj.Look = reader.GetString(27);
                        obj.Trub = reader.GetString(28);
                        obj.Behavior = reader.GetString(29);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public DdtAlcoProtocol GetById(string id)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_pribor, dss_conclusion, dss_mimics, dss_breathe, dss_tremble, dss_illness, dss_orientation, dss_skin, dss_drunk, dss_pressure, dss_pulse, dsb_template, dss_touch_nose, dss_docs, dss_bio, dss_speech, dss_cause, dss_smell, dss_motions, r_creation_date, dsid_hospitality_session, dss_eyes, r_modify_date, dss_walk, dss_nistagm, dss_look, dss_trub, dss_behavior FROM ddt_alco_protocol WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtAlcoProtocol obj = new DdtAlcoProtocol();
                        obj.ObjectId = reader.GetString(1);
                        obj.Pribor = reader.GetString(2);
                        obj.Conclusion = reader.GetString(3);
                        obj.Mimics = reader.GetString(4);
                        obj.Breathe = reader.GetString(5);
                        obj.Tremble = reader.GetString(6);
                        obj.Illness = reader.GetString(7);
                        obj.Orientation = reader.GetString(8);
                        obj.Skin = reader.GetString(9);
                        obj.Drunk = reader.GetString(10);
                        obj.Pressure = reader.GetString(11);
                        obj.Pulse = reader.GetString(12);
                        obj.Template = reader.GetBoolean(13);
                        obj.TouchNose = reader.GetString(14);
                        obj.Docs = reader.GetString(15);
                        obj.Bio = reader.GetString(16);
                        obj.Speech = reader.GetString(17);
                        obj.Cause = reader.GetString(18);
                        obj.Smell = reader.GetString(19);
                        obj.Motions = reader.GetString(20);
                        obj.CreationDate = reader.GetDateTime(21);
                        obj.HospitalitySession = reader.GetString(22);
                        obj.Eyes = reader.GetString(23);
                        obj.ModifyDate = reader.GetDateTime(24);
                        obj.Walk = reader.GetString(25);
                        obj.Nistagm = reader.GetString(26);
                        obj.Look = reader.GetString(27);
                        obj.Trub = reader.GetString(28);
                        obj.Behavior = reader.GetString(29);
                        return obj;
                    }
                }
            }
            return null;
        }

        public DdtAlcoProtocol GetByHospitalSession(string hospitalSessionId)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                String sql = String.Format("SELECT r_object_id, dss_pribor, dss_conclusion, dss_mimics, dss_breathe, dss_tremble, dss_illness, dss_orientation, dss_skin, dss_drunk, dss_pressure, dss_pulse, dsb_template, dss_touch_nose, dss_docs, dss_bio, dss_speech, dss_cause, dss_smell, dss_motions, r_creation_date, dsid_hospitality_session, dss_eyes, r_modify_date, dss_walk, dss_nistagm, dss_look, dss_trub, dss_behavior FROM ddt_alco_protocol WHERE r_object_id = '{0}'", hospitalSessionId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtAlcoProtocol obj = new DdtAlcoProtocol();
                        obj.ObjectId = reader.GetString(1);
                        obj.Pribor = reader.GetString(2);
                        obj.Conclusion = reader.GetString(3);
                        obj.Mimics = reader.GetString(4);
                        obj.Breathe = reader.GetString(5);
                        obj.Tremble = reader.GetString(6);
                        obj.Illness = reader.GetString(7);
                        obj.Orientation = reader.GetString(8);
                        obj.Skin = reader.GetString(9);
                        obj.Drunk = reader.GetString(10);
                        obj.Pressure = reader.GetString(11);
                        obj.Pulse = reader.GetString(12);
                        obj.Template = reader.GetBoolean(13);
                        obj.TouchNose = reader.GetString(14);
                        obj.Docs = reader.GetString(15);
                        obj.Bio = reader.GetString(16);
                        obj.Speech = reader.GetString(17);
                        obj.Cause = reader.GetString(18);
                        obj.Smell = reader.GetString(19);
                        obj.Motions = reader.GetString(20);
                        obj.CreationDate = reader.GetDateTime(21);
                        obj.HospitalitySession = reader.GetString(22);
                        obj.Eyes = reader.GetString(23);
                        obj.ModifyDate = reader.GetDateTime(24);
                        obj.Walk = reader.GetString(25);
                        obj.Nistagm = reader.GetString(26);
                        obj.Look = reader.GetString(27);
                        obj.Trub = reader.GetString(28);
                        obj.Behavior = reader.GetString(29);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
