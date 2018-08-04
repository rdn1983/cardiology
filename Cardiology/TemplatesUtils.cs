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

        public static void fillTemplate(string templatePath, Dictionary<string, string> mappedValues)
        {
            Word.Document doc = null;
            try
            {
                Word.Application app = new Word.Application();
                doc = app.Documents.Open(templatePath);
                doc.Activate();

                Word.Paragraphs paragraphs = doc.Paragraphs;
                Word.Range wRange;

                foreach (Word.Paragraph mark in paragraphs)
                {
                    wRange = mark.Range;
                    foreach (KeyValuePair<string, string> entry in mappedValues)
                    {
                        if (wRange != null)
                        {
                            string oldValue = wRange.Text;
                            if (oldValue.Contains(entry.Key))
                            {
                                string newParagraphVal = oldValue.Replace(entry.Key, entry.Value);
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

