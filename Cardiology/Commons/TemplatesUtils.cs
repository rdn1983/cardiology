using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using Cardiology.Data;
using Cardiology.Data.Model2;
using Cardiology.Data.PostgreSQL;

namespace Cardiology.Commons
{
    public class TemplatesUtils
    {
        public TemplatesUtils()
        {
        }

        public static void fillBlankTemplate(string templateFileName, string hospitalSessionId, Dictionary<string, string> values)
        {

            DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(hospitalSessionId);
            if (hospitalSession != null)
            {
                DdvDoctor doc = service.queryObjectById<DdvDoctor>(hospitalSession.CuringDoctor);
                DdvPatient patient = service.queryObjectById<DdvPatient>(hospitalSession.CuringDoctor);

                values.Add(@"{doctor.who.short}", doc.ShortName);
                values.Add(@"{patient.initials}", patient.ShortName);
                values.Add(@"{patient.birthdate}", patient.Birthdate.ToShortDateString());
                values.Add(@"{patient.diagnosis}", hospitalSession.Diagnosis);
                values.Add(@"{patient.age}", DateTime.Now.Year - patient.Birthdate.Year + "");
                values.Add(@"{admission.date}", hospitalSession.AdmissionDate.ToShortDateString());
                values.Add(@"{patient.historycard}", patient.MedCode);
                values.Add(@"{doctor.who}", doc.FullName);
                values.Add(@"{patient.fullname}", patient.FirstName);
                values.Add(@"{date}", DateTime.Now.ToShortDateString());

                doc = service.queryObject<DdvDoctor>(@"SELECT * FROM " + DdvDoctor + " where dss_login IN " +
                    "(select dss_user_name FROM dm_group_users WHERE dss_group_name ='io_cardio_reanim')");
                values.Add(@"{doctor.io.department}", doc.ShortName);
                doc = service.queryObject<DdvDoctor>(@"SELECT * FROM " + DdvDoctor.NAME + " where dss_login IN " +
                    "(select dss_user_name FROM dm_group_users WHERE dss_group_name ='io_therapy')");
                values.Add(@"{doctor.io.hospital}", doc.ShortName);
            }
            TemplatesUtils.fillTemplateAndShow(Directory.GetCurrentDirectory() + "\\Templates\\" + templateFileName, values);
        }


        public static void fillAmbulanceLetterTemplate(string templateFileName, string hospitalSessionId, Dictionary<string, string> values)
        {
            DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(hospitalSessionId);
            DdvDoctor doc = service.queryObjectById<DdvDoctor>(hospitalSession.CuringDoctor);
            DdvPatient patient = service.queryObjectById<DdvPatient>(hospitalSession.CuringDoctor);
            values.Add(@"{doctor.who.short}", doc.ShortName);
            values.Add(@"{patient.initials}", patient.ShortName);
            values.Add(@"{patient.birthdate}", patient.Birthdate.ToShortDateString());
            values.Add(@"{patient.diagnosis}", hospitalSession.Diagnosis);
            values.Add(@"{patient.age}", DateTime.Now.Year - patient.Birthdate.Year + "");
            values.Add(@"{admission.date}", hospitalSession.AdmissionDate.ToShortDateString());
            values.Add(@"{patient.historycard}", patient.MedCode);
            values.Add(@"{doctor.who}", doc.FullName);
            values.Add(@"{patient.fullname}", patient.FullName);
            values.Add(@"{date}", DateTime.Now.ToShortDateString());
            TemplatesUtils.fillTemplateAndShow(Directory.GetCurrentDirectory() + "\\Templates\\" + templateFileName, values);
        }

        public static string fillTemplate(string templatePath, Dictionary<string, string> mappedValues)
        {
            Word.Document doc = null;
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                doc = app.Documents.Open(templatePath);

                Word.Range wRange;
                foreach (Word.Paragraph mark in doc.Paragraphs)
                {
                    wRange = mark.Range;
                    if (wRange != null)
                    {
                        foreach (KeyValuePair<string, string> entry in mappedValues)
                        {
                            string oldValue = wRange.Text;
                            if (oldValue != null && oldValue.Contains(entry.Key))
                            {
                                wRange.Find.ClearFormatting();
                                wRange.Find.Execute(FindText:entry.Key);
                                wRange.Select();
                                string newVal = entry.Value;
                                if (string.IsNullOrEmpty(newVal))
                                {
                                    newVal = " ";
                                }
                                app.Selection.TypeText(newVal);
                                wRange = mark.Range;
                            }

                        }
                    }
                }
                string filledDocPath = Path.GetTempFileName();
                doc.SaveAs(filledDocPath);
                Console.WriteLine("filled document path=" + filledDocPath);
                return filledDocPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();
                    doc = null;
                }
                if (app != null)
                {
                    app.Quit();
                    app = null;
                }
            }
            return null;

        }

        public static string fillTemplateAndShow(string templatePath, Dictionary<string, string> mappedValues)
        {
            string filledTemplate = fillTemplate(templatePath, mappedValues);
            if (!string.IsNullOrEmpty(filledTemplate))
            {
                showDocument(filledTemplate);
            }

            return filledTemplate;
        }


        public static string mergeFiles(string[] filesToMerge, bool insertPageBreaks)
        {
            object missing = System.Type.Missing;
            object pageBreak = Word.WdBreakType.wdPageBreak;
            object outputFile = Path.GetTempFileName();

            Word._Application wordApplication = null;
            Word._Document wordDocument = null;
            try
            {
                wordApplication = new Word.Application();
                wordDocument = wordApplication.Documents.Add(ref outputFile, ref missing, ref missing, ref missing);

                Word.Selection selection = wordApplication.Selection;
                foreach (string file in filesToMerge)
                {
                    selection.InsertFile(file, ref missing, ref missing, ref missing, ref missing);
                    if (insertPageBreaks)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }
                }
                wordDocument.SaveAs(ref outputFile);
                Console.WriteLine("Generated file after merge=" + outputFile);
                return outputFile.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                if (outputFile != null)
                {
                    File.Delete(outputFile.ToString());
                }
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close();
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit();
                    wordApplication = null;
                }
                foreach (string path in filesToMerge)
                {
                    File.Delete(path);
                }
            }
            return null;
        }

        public static void processTemplateAndMerge(string hospitalSession, string[] types, string[] objectIds)
        {
            List<string> filledTemplatesPaths = new List<string>();
            for (int i = 0; i < types.Length; i++)
            {
                ITemplateProcessor processor = TemplateProcessorManager.getProcessorByObjectType(types[i]);
                if (processor != null)
                {
                    filledTemplatesPaths.Add(processor.processTemplate(hospitalSession, objectIds[i], null));
                }
            }

            string resultPath = mergeFiles(filledTemplatesPaths.ToArray(), false);
        }

        public static void showDocument(string path)
        {
            Word._Application wordApplication = null;
            Word._Document wordDocument = null;
            try
            {
                wordApplication = new Word.Application();
                wordDocument = wordApplication.Documents.Add(path);
                //wordApplication.Activate();
                wordApplication.Visible = true;
            }
            catch (Exception ex)
            {
                if (wordDocument != null)
                {
                    wordDocument.Close();
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit();
                }
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication = null;
                }
            }
        }

    }
}

