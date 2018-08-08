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
            TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + templateFileName, values);
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
            TemplatesUtils.fillTemplate(Directory.GetCurrentDirectory() + "\\Templates\\" + templateFileName, values);
        }

        public static void fillTemplate(string templatePath, Dictionary<string, string> mappedValues)
        {
            Word.Document doc = null;
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                doc = app.Documents.Open(templatePath);
                doc.Activate();

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
                Console.WriteLine(filledDocPath);
                doc.SaveAs(filledDocPath);

                app.Documents.Open(filledDocPath);
                app.Activate();
                app.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
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

    }

}

