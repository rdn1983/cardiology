using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace Cardiology.Utils
{
    public class TemplatesUtils
    {
        public TemplatesUtils()
        {
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
                        string oldValue = wRange.Text;
                        if (oldValue.Contains(entry.Key))
                        {
                            string newParagraphVal = oldValue.Replace(entry.Key, entry.Value).Trim();
                            Console.Write(newParagraphVal);
                            wRange.Text = newParagraphVal;
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

