using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using Cardiology.Data;
using Cardiology.Data.Model2;

namespace Cardiology.Commons
{
    static class TemplatesUtils
    {
        public static void fillBlankTemplate(IDbDataService service, string templateFileName, string hospitalSessionId, Dictionary<string, string> values)
        {

            DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(hospitalSessionId);
            DdvPatient patient = null;
            if (hospitalSession != null)
            {
                DdvDoctor doc = service.GetDdvDoctorService().GetById(hospitalSession.CuringDoctor);
                patient = service.GetDdvPatientService().GetById(hospitalSession.Patient);

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

                IList<DdvDoctor> allGroupsDoc = service.GetDdvDoctorService().GetByGroupName("cardioreanimation_department_head");
                doc = allGroupsDoc.Count > 0 ? allGroupsDoc[0] : null;
                values.Add(@"{doctor.io.department}", doc?.ShortName);

                allGroupsDoc.Clear();
                allGroupsDoc = service.GetDdvDoctorService().GetByGroupName("therapy_deputy_head");
                doc = allGroupsDoc.Count > 0 ? allGroupsDoc[0] : null;
                values.Add(@"{doctor.io.hospital}", doc?.ShortName);
            }
            string resultName = getTempFileName("Бланк", patient?.FullName);
            TemplatesUtils.FillTemplateAndShow(Directory.GetCurrentDirectory() + "\\Templates\\" + templateFileName, values, resultName);
        }


        public static void fillAmbulanceLetterTemplate(IDbDataService service, string templateFileName, string hospitalSessionId, Dictionary<string, string> values)
        {
            DdtHospital hospitalSession = service.GetDdtHospitalService().GetById(hospitalSessionId);
            DdvDoctor doc = service.GetDdvDoctorService().GetById(hospitalSession.CuringDoctor);
            DdvPatient patient = service.GetDdvPatientService().GetById(hospitalSession.Patient);
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
            string resultName = getTempFileName("Письмо для скорой", patient?.FullName);
            TemplatesUtils.FillTemplateAndShow(Directory.GetCurrentDirectory() + "\\Templates\\" + templateFileName, values, resultName);
        }

        public static string getTempFileName(string typeName, string patientFio)
        {
            return typeName + " " + patientFio + " " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Replace(":", "-");
        }

        public static string FillTemplate(string templatePath, Dictionary<string, string> mappedValues)
        {
            return FillTemplate(templatePath, mappedValues, null);
        }

        public static string FillTemplate(string templatePath, Dictionary<string, string> mappedValues, string resultName)
        {
            Word.Document doc = null;
            Word.Application app = null;
            string filledDocPath = null;
            try
            {
                app = new Word.Application();
                doc = app.Documents.Open(templatePath);

                Word.Range wRange;

                foreach (KeyValuePair<string, string> entry in mappedValues)
                {
                    foreach (Word.Paragraph mark in doc.Paragraphs)
                    {
                        wRange = mark.Range;
                        if (wRange != null)
                        {
                            string oldValue = wRange.Text;
                            if (oldValue != null && oldValue.Contains(entry.Key))
                            {
                                wRange.Find.ClearFormatting();
                                wRange.Find.Execute(FindText: entry.Key);
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
               
                if (resultName == null)
                {
                    filledDocPath = Path.GetTempFileName();
                }
                else
                {
                    filledDocPath = Path.Combine(Path.GetTempPath(), resultName);
                    File.Move(Path.GetTempFileName(), filledDocPath);
                }
                doc.PageSetup.TopMargin = 20;
                doc.PageSetup.BottomMargin = 20;
                doc.PageSetup.LeftMargin = 50;
                //doc.Paragraphs.CharacterUnitFirstLineIndent = 1.5F;
                doc.SaveAs(filledDocPath);
                Console.WriteLine("filled document path=" + filledDocPath);
                return filledDocPath;
            }
            catch (Exception ex)
            {
                if (File.Exists(filledDocPath))
                {
                    File.Delete(filledDocPath);
                }
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

        public static string FillTemplateAndShow(string templatePath, Dictionary<string, string> mappedValues, string resultName)
        {
            string filledTemplate = FillTemplate(templatePath, mappedValues, resultName);
            if (!string.IsNullOrEmpty(filledTemplate))
            {
                ShowDocument(filledTemplate);
            }

            return filledTemplate;
        }


        public static string MergeFiles(string[] filesToMerge, bool insertPageBreaks, string resultName)
        {
            object missing = System.Type.Missing;
            object pageBreak = Word.WdBreakType.wdPageBreak;
            object outputFile = null;
            if (resultName == null) { outputFile = Path.GetTempFileName(); }
            else
            {
                outputFile = Path.Combine(Path.GetTempPath(), resultName);
                File.Move(Path.GetTempFileName(), outputFile.ToString());
            }

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

                wordDocument.PageSetup.TopMargin = 20;
                wordDocument.PageSetup.BottomMargin = 20;
                wordDocument.PageSetup.LeftMargin = 50;
                //wordDocument.Paragraphs.CharacterUnitFirstLineIndent = 1.5F;

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
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            return null;
        }

        public static void ShowDocument(string path)
        {
            Word._Application wordApplication = null;
            Word._Document wordDocument = null;
            try
            {
                wordApplication = new Word.Application();
                wordDocument = wordApplication.Documents.Open(path);
                wordApplication.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

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

