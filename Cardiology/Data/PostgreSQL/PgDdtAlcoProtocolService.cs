using System;
using System.Data.Common;
using System.Collections.Generic;
using Cardiology.Data.Model2;
using Cardiology.Data.Commons;
using System.Data;

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
                String sql = "SELECT r_object_id, dss_pribor, dss_conclusion, dss_mimics, dss_breathe, dss_tremble, dss_illness, dss_orientation, dss_skin, " +
                    "dss_drunk, dss_pressure, dss_pulse, dsb_template, dss_touch_nose, dss_docs, dss_bio, dss_speech, dss_cause, dss_smell, dss_motions," +
                    " r_creation_date, dsid_hospitality_session, dss_eyes, r_modify_date, dss_walk, dss_nistagm, dss_look, dss_trub, dss_behavior FROM ddt_alco_protocol";
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DdtAlcoProtocol obj = new DdtAlcoProtocol();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Pribor = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Conclusion = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Mimics = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Breathe = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Tremble = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Illness = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Orientation = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Skin = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Drunk = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Pressure = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Pulse = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Template = reader.GetBoolean(12);
                        obj.TouchNose = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Docs = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.Bio = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.Speech = reader.IsDBNull(16) ? null : reader.GetString(16);
                        obj.Cause = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Smell = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.Motions = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.CreationDate = reader.IsDBNull(20) ? DateTime.MinValue : reader.GetDateTime(20);
                        obj.HospitalitySession = reader.IsDBNull(21) ? null : reader.GetString(21);
                        obj.Eyes = reader.IsDBNull(22) ? null : reader.GetString(22);
                        obj.ModifyDate = reader.IsDBNull(23) ? DateTime.MinValue : reader.GetDateTime(23);
                        obj.Walk = reader.IsDBNull(24) ? null : reader.GetString(24);
                        obj.Nistagm = reader.IsDBNull(25) ? null : reader.GetString(25);
                        obj.Look = reader.IsDBNull(26) ? null : reader.GetString(26);
                        obj.Trub = reader.IsDBNull(27) ? null : reader.GetString(27);
                        obj.Behavior = reader.IsDBNull(28) ? null : reader.GetString(28);
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
                String sql = String.Format("SELECT r_object_id, dss_pribor, dss_conclusion, dss_mimics, dss_breathe, dss_tremble, dss_illness, dss_orientation," +
                    " dss_skin, dss_drunk, dss_pressure, dss_pulse, dsb_template, dss_touch_nose, dss_docs, dss_bio, dss_speech, dss_cause, dss_smell, dss_motions, " +
                    "r_creation_date, dsid_hospitality_session, dss_eyes, r_modify_date, dss_walk, dss_nistagm, dss_look, dss_trub, dss_behavior " +
                    "FROM ddt_alco_protocol WHERE r_object_id = '{0}'", id);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtAlcoProtocol obj = new DdtAlcoProtocol();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Pribor = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Conclusion = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Mimics = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Breathe = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Tremble = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Illness = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Orientation = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Skin = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Drunk = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Pressure = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Pulse = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Template = reader.GetBoolean(12);
                        obj.TouchNose = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Docs = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.Bio = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.Speech = reader.IsDBNull(16) ? null : reader.GetString(16);
                        obj.Cause = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Smell = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.Motions = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.CreationDate = reader.IsDBNull(20) ? DateTime.MinValue : reader.GetDateTime(20);
                        obj.HospitalitySession = reader.IsDBNull(21) ? null : reader.GetString(21);
                        obj.Eyes = reader.IsDBNull(22) ? null : reader.GetString(22);
                        obj.ModifyDate = reader.IsDBNull(23) ? DateTime.MinValue : reader.GetDateTime(23);
                        obj.Walk = reader.IsDBNull(24) ? null : reader.GetString(24);
                        obj.Nistagm = reader.IsDBNull(25) ? null : reader.GetString(25);
                        obj.Look = reader.IsDBNull(26) ? null : reader.GetString(26);
                        obj.Trub = reader.IsDBNull(27) ? null : reader.GetString(27);
                        obj.Behavior = reader.IsDBNull(28) ? null : reader.GetString(28);
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
                String sql = String.Format("SELECT r_object_id, dss_pribor, dss_conclusion, dss_mimics, dss_breathe, dss_tremble, dss_illness, dss_orientation," +
                    " dss_skin, dss_drunk, dss_pressure, dss_pulse, dsb_template, dss_touch_nose, dss_docs, dss_bio, dss_speech, dss_cause, dss_smell," +
                    " dss_motions, r_creation_date, dsid_hospitality_session, dss_eyes, r_modify_date, dss_walk, dss_nistagm, dss_look, dss_trub, dss_behavior " +
                    "FROM ddt_alco_protocol WHERE dsid_hospitality_session = '{0}'", hospitalSessionId);
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(sql, connection);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DdtAlcoProtocol obj = new DdtAlcoProtocol();
                        obj.ObjectId = reader.IsDBNull(0) ? null : reader.GetString(0);
                        obj.Pribor = reader.IsDBNull(1) ? null : reader.GetString(1);
                        obj.Conclusion = reader.IsDBNull(2) ? null : reader.GetString(2);
                        obj.Mimics = reader.IsDBNull(3) ? null : reader.GetString(3);
                        obj.Breathe = reader.IsDBNull(4) ? null : reader.GetString(4);
                        obj.Tremble = reader.IsDBNull(5) ? null : reader.GetString(5);
                        obj.Illness = reader.IsDBNull(6) ? null : reader.GetString(6);
                        obj.Orientation = reader.IsDBNull(7) ? null : reader.GetString(7);
                        obj.Skin = reader.IsDBNull(8) ? null : reader.GetString(8);
                        obj.Drunk = reader.IsDBNull(9) ? null : reader.GetString(9);
                        obj.Pressure = reader.IsDBNull(10) ? null : reader.GetString(10);
                        obj.Pulse = reader.IsDBNull(11) ? null : reader.GetString(11);
                        obj.Template = reader.GetBoolean(12);
                        obj.TouchNose = reader.IsDBNull(13) ? null : reader.GetString(13);
                        obj.Docs = reader.IsDBNull(14) ? null : reader.GetString(14);
                        obj.Bio = reader.IsDBNull(15) ? null : reader.GetString(15);
                        obj.Speech = reader.IsDBNull(16) ? null : reader.GetString(16);
                        obj.Cause = reader.IsDBNull(17) ? null : reader.GetString(17);
                        obj.Smell = reader.IsDBNull(18) ? null : reader.GetString(18);
                        obj.Motions = reader.IsDBNull(19) ? null : reader.GetString(19);
                        obj.CreationDate = reader.IsDBNull(20) ? DateTime.MinValue : reader.GetDateTime(20);
                        obj.HospitalitySession = reader.IsDBNull(21) ? null : reader.GetString(21);
                        obj.Eyes = reader.IsDBNull(22) ? null : reader.GetString(22);
                        obj.ModifyDate = reader.IsDBNull(23) ? DateTime.MinValue : reader.GetDateTime(23);
                        obj.Walk = reader.IsDBNull(24) ? null : reader.GetString(24);
                        obj.Nistagm = reader.IsDBNull(25) ? null : reader.GetString(25);
                        obj.Look = reader.IsDBNull(26) ? null : reader.GetString(26);
                        obj.Trub = reader.IsDBNull(27) ? null : reader.GetString(27);
                        obj.Behavior = reader.IsDBNull(28) ? null : reader.GetString(28);
                        return obj;
                    }
                }
            }
            return null;
        }

        public string Save(DdtAlcoProtocol obj)
        {
            using (dynamic connection = connectionFactory.GetConnection())
            {
                if (GetById(obj.ObjectId) != null)
                {
                    string sql = "UPDATE ddt_alco_protocol SET " +
                                        "dsid_hospitality_session = @HospitalitySession, " +
                                        "dss_look = @Look, " +
                                        "dss_cause = @Cause, " +
                                        "dss_behavior = @Behavior, " +
                                        "dss_orientation = @Orientation, " +
                                        "dss_speech = @Speech, " +
                                        "dss_skin = @Skin, " +
                                        "dss_breathe = @Breathe, " +
                                        "dss_pulse = @Pulse, " +
                                        "dss_pressure = @Pressure, " +
                                        "dss_eyes = @Eyes, " +
                                        "dss_nistagm = @Nistagm, " +
                                        "dss_motions = @Motions, " +
                                        "dss_mimics = @Mimics, " +
                                        "dss_walk = @Walk, " +
                                        "dss_touch_nose = @TouchNose, " +
                                        "dss_tremble = @Tremble, " +
                                        "dss_illness = @Illness, " +
                                        "dss_drunk = @Drunk, " +
                                        "dss_smell = @Smell, " +
                                        "dss_pribor = @Pribor, " +
                                        "dss_trub = @Trub, " +
                                        "dss_bio = @Bio, " +
                                        "dss_docs = @Docs, " +
                                        "dss_conclusion = @Conclusion, " +
                                        "dsb_template = @Template " +
                                         "WHERE r_object_id = @ObjectId";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Look", obj.Look == null ? "" : obj.Look);
                        cmd.Parameters.AddWithValue("@Cause", obj.Cause == null ? "" : obj.Cause);
                        cmd.Parameters.AddWithValue("@Behavior", obj.Behavior == null ? "" : obj.Behavior);
                        cmd.Parameters.AddWithValue("@Orientation", obj.Orientation == null ? "" : obj.Orientation);
                        cmd.Parameters.AddWithValue("@Speech", obj.Speech == null ? "" : obj.Speech);
                        cmd.Parameters.AddWithValue("@Skin", obj.Skin == null ? "" : obj.Skin);
                        cmd.Parameters.AddWithValue("@Breathe", obj.Breathe == null ? "" : obj.Breathe);
                        cmd.Parameters.AddWithValue("@Pulse", obj.Pulse == null ? "" : obj.Pulse);
                        cmd.Parameters.AddWithValue("@Pressure", obj.Pressure == null ? "" : obj.Pressure);
                        cmd.Parameters.AddWithValue("@Eyes", obj.Eyes == null ? "" : obj.Eyes);
                        cmd.Parameters.AddWithValue("@Nistagm", obj.Nistagm == null ? "" : obj.Nistagm);
                        cmd.Parameters.AddWithValue("@Motions", obj.Motions == null ? "" : obj.Motions);
                        cmd.Parameters.AddWithValue("@Mimics", obj.Mimics == null ? "" : obj.Mimics);
                        cmd.Parameters.AddWithValue("@Walk", obj.Walk == null ? "" : obj.Walk);
                        cmd.Parameters.AddWithValue("@TouchNose", obj.TouchNose == null ? "" : obj.TouchNose);
                        cmd.Parameters.AddWithValue("@Tremble", obj.Tremble == null ? "" : obj.Tremble);
                        cmd.Parameters.AddWithValue("@Illness", obj.Illness == null ? "" : obj.Illness);
                        cmd.Parameters.AddWithValue("@Drunk", obj.Drunk == null ? "" : obj.Drunk);
                        cmd.Parameters.AddWithValue("@Smell", obj.Smell == null ? "" : obj.Smell);
                        cmd.Parameters.AddWithValue("@Pribor", obj.Pribor == null ? "" : obj.Pribor);
                        cmd.Parameters.AddWithValue("@Trub", obj.Trub == null ? "" : obj.Trub);
                        cmd.Parameters.AddWithValue("@Bio", obj.Bio == null ? "" : obj.Bio);
                        cmd.Parameters.AddWithValue("@Docs", obj.Docs == null ? "" : obj.Docs);
                        cmd.Parameters.AddWithValue("@Conclusion", obj.Conclusion == null ? "" : obj.Conclusion);
                        cmd.Parameters.AddWithValue("@Template", obj.Template);
                        cmd.Parameters.AddWithValue("@ObjectId", obj.ObjectId);
                        cmd.ExecuteNonQuery();
                    }
                    return obj.ObjectId;
                }
                else
                {
                    string sql = "INSERT INTO ddt_alco_protocol(dsid_hospitality_session,dss_look,dss_cause,dss_behavior,dss_orientation,dss_speech,dss_skin,dss_breathe,dss_pulse,dss_pressure,dss_eyes,dss_nistagm,dss_motions,dss_mimics,dss_walk,dss_touch_nose,dss_tremble,dss_illness,dss_drunk,dss_smell,dss_pribor,dss_trub,dss_bio,dss_docs,dss_conclusion,dsb_template) " +
                                                              "VALUES(@HospitalitySession,@Look,@Cause,@Behavior,@Orientation,@Speech,@Skin,@Breathe,@Pulse,@Pressure,@Eyes,@Nistagm,@Motions,@Mimics,@Walk,@TouchNose,@Tremble,@Illness,@Drunk,@Smell,@Pribor,@Trub,@Bio,@Docs,@Conclusion,@Template) RETURNING r_object_id";
                    using (Npgsql.NpgsqlCommand cmd = new Npgsql.NpgsqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@HospitalitySession", obj.HospitalitySession);
                        cmd.Parameters.AddWithValue("@Look", obj.Look == null ? "" : obj.Look);
                        cmd.Parameters.AddWithValue("@Cause", obj.Cause == null ? "" : obj.Cause);
                        cmd.Parameters.AddWithValue("@Behavior", obj.Behavior == null ? "" : obj.Behavior);
                        cmd.Parameters.AddWithValue("@Orientation", obj.Orientation == null ? "" : obj.Orientation);
                        cmd.Parameters.AddWithValue("@Speech", obj.Speech == null ? "" : obj.Speech);
                        cmd.Parameters.AddWithValue("@Skin", obj.Skin == null ? "" : obj.Skin);
                        cmd.Parameters.AddWithValue("@Breathe", obj.Breathe == null ? "" : obj.Breathe);
                        cmd.Parameters.AddWithValue("@Pulse", obj.Pulse == null ? "" : obj.Pulse);
                        cmd.Parameters.AddWithValue("@Pressure", obj.Pressure == null ? "" : obj.Pressure);
                        cmd.Parameters.AddWithValue("@Eyes", obj.Eyes == null ? "" : obj.Eyes);
                        cmd.Parameters.AddWithValue("@Nistagm", obj.Nistagm == null ? "" : obj.Nistagm);
                        cmd.Parameters.AddWithValue("@Motions", obj.Motions == null ? "" : obj.Motions);
                        cmd.Parameters.AddWithValue("@Mimics", obj.Mimics == null ? "" : obj.Mimics);
                        cmd.Parameters.AddWithValue("@Walk", obj.Walk == null ? "" : obj.Walk);
                        cmd.Parameters.AddWithValue("@TouchNose", obj.TouchNose == null ? "" : obj.TouchNose);
                        cmd.Parameters.AddWithValue("@Tremble", obj.Tremble == null ? "" : obj.Tremble);
                        cmd.Parameters.AddWithValue("@Illness", obj.Illness == null ? "" : obj.Illness);
                        cmd.Parameters.AddWithValue("@Drunk", obj.Drunk == null ? "" : obj.Drunk);
                        cmd.Parameters.AddWithValue("@Smell", obj.Smell == null ? "" : obj.Smell);
                        cmd.Parameters.AddWithValue("@Pribor", obj.Pribor == null ? "" : obj.Pribor);
                        cmd.Parameters.AddWithValue("@Trub", obj.Trub == null ? "" : obj.Trub);
                        cmd.Parameters.AddWithValue("@Bio", obj.Bio == null ? "" : obj.Bio);
                        cmd.Parameters.AddWithValue("@Docs", obj.Docs == null ? "" : obj.Docs);
                        cmd.Parameters.AddWithValue("@Conclusion", obj.Conclusion == null ? "" : obj.Conclusion);
                        cmd.Parameters.AddWithValue("@Template", obj.Template);
                        return (string)cmd.ExecuteScalar();
                    }
                }
            }
        }

    }
}
