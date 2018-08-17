using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using Cardiology.Model;

namespace Cardiology.Utils
{
    public class TemplatesUtils
    {
        public TemplatesUtils()
        {
        }

        public static void fillBlankTemplate(string templateFileName, string hospitalSessionId, Dictionary<string, string> values)
        {
            DataService service = new DataService();
            DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, hospitalSessionId);
            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospitalSession.DsidCuringDoctor);
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalSession.DsidPatient);
            values.Add(@"{doctor.who.short}", doc.DssInitials);
            values.Add(@"{patient.initials}", patient.DssInitials);
            values.Add(@"{patient.birthdate}", patient.DsdtBirthdate.ToShortDateString());
            values.Add(@"{patient.diagnosis}", hospitalSession.DssDiagnosis);
            values.Add(@"{patient.age}", DateTime.Now.Year - patient.DsdtBirthdate.Year + "");
            values.Add(@"{admission.date}", hospitalSession.DsdtAdmissionDate.ToShortDateString());
            values.Add(@"{patient.historycard}", patient.DssMedCode);
            values.Add(@"{doctor.who}", doc.DssFullName);
            values.Add(@"{patient.fullname}", patient.DssFullName);
            values.Add(@"{date}", DateTime.Now.ToShortDateString());
            TemplatesUtils.fillTemplateAndShow(Directory.GetCurrentDirectory() + "\\Templates\\" + templateFileName, values);
        }


        public static void fillAmbulanceLetterTemplate(string templateFileName, string hospitalSessionId, Dictionary<string, string> values)
        {
            DataService service = new DataService();
            DdtHospital hospitalSession = service.queryObjectById<DdtHospital>(DdtHospital.TABLENAME, hospitalSessionId);
            DdtDoctors doc = service.queryObjectById<DdtDoctors>(DdtDoctors.TABLE_NAME, hospitalSession.DsidCuringDoctor);
            DdtPatient patient = service.queryObjectById<DdtPatient>(DdtPatient.TABLENAME, hospitalSession.DsidPatient);
            values.Add(@"{doctor.who.short}", doc.DssInitials);
            values.Add(@"{patient.initials}", patient.DssInitials);
            values.Add(@"{patient.birthdate}", patient.DsdtBirthdate.ToShortDateString());
            values.Add(@"{patient.diagnosis}", hospitalSession.DssDiagnosis);
            values.Add(@"{patient.age}", DateTime.Now.Year - patient.DsdtBirthdate.Year + "");
            values.Add(@"{admission.date}", hospitalSession.DsdtAdmissionDate.ToShortDateString());
            values.Add(@"{patient.historycard}", patient.DssMedCode);
            values.Add(@"{doctor.who}", doc.DssFullName);
            values.Add(@"{patient.fullname}", patient.DssFullName);
            values.Add(@"{date}", DateTime.Now.ToShortDateString());
            TemplatesUtils.fillTemplateAndShow(Directory.GetCurrentDirectory() + "\\Templates\\" + templateFileName, values);
        }

        public static void fillTemplate2(string templatePath, Dictionary<string, string> mappedValues)
        {
            Word.Document doc = null;
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                doc = app.Documents.Open(templatePath);

                Word.Paragraphs paragraphs = doc.Paragraphs;
                Word.Range wRange;

                foreach (Word.Paragraph mark in paragraphs)
                {
                    wRange = mark.Range;
                    if (wRange != null)
                    {
                        foreach (KeyValuePair<string, string> entry in mappedValues)
                        {
                            string oldValue = wRange.Text;
                            if (oldValue.Contains(entry.Key))
                            {
                                string newParagraphVal = oldValue.Replace(entry.Key, entry.Value);
                                newParagraphVal = newParagraphVal.Replace("\r", "").Replace("\a", "");
                                Console.WriteLine(newParagraphVal);
                                wRange.Text = newParagraphVal;
                            }

                        }
                    }
                }
                string filledDocPath = Path.GetTempFileName();
                Console.WriteLine("filled document path=" + filledDocPath);
                doc.SaveAs(filledDocPath);
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
                }
            }

        }

        public static void fillTemplateAndShow(string templatePath, Dictionary<string, string> mappedValues)
        {
            Word.Document doc = null;
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                doc = app.Documents.Open(templatePath);
                //doc.Activate();

                Word.Paragraphs paragraphs = doc.Paragraphs;
                Word.Range wRange;

                foreach (Word.Paragraph mark in paragraphs)
                {
                    wRange = mark.Range;
                    if (wRange != null)
                    {
                        foreach (KeyValuePair<string, string> entry in mappedValues)
                        {
                            string oldValue = wRange.Text;
                            if (oldValue!=null && oldValue.Contains(entry.Key))
                            {
                                string newParagraphVal = oldValue.Replace(entry.Key, entry.Value);
                                newParagraphVal = newParagraphVal.Replace("\r", "").Replace("\a", "");
                                Console.WriteLine(newParagraphVal);
                                wRange.Text = newParagraphVal;
                            }

                        }
                    }
                }
                string filledDocPath = Path.GetTempFileName();
                Console.WriteLine(filledDocPath);
                doc.SaveAs(filledDocPath);

                app.Documents.Open(filledDocPath);
                app.Activate();
                app.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                if (doc != null)
                {
                    doc.Close();
                }
                if (app != null)
                {
                    app.Quit();
                }
            }
            finally
            {
                if (doc != null)
                {
                    doc = null;
                }
            }

        }


        public static void mergeFiles(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            object missing = System.Type.Missing;
            object pageBreak = Word.WdBreakType.wdPageBreak;
            object outputFile = outputFilename;

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
                Console.WriteLine("Generated file after merge=" + outputFilename);
                wordDocument.SaveAs(ref outputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                if (wordDocument != null)
                {
                    wordDocument.Close();
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref missing, ref missing, ref missing);
                }
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument = null;
                }
            }
        }

        public void processTemplateAndMerge()
        {

        }

    }

}

