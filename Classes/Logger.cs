using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManageBordingFeeses.Classes
{
    internal static class Logger
    {
        private static StreamWriter _streamWriter;

        internal static void WriteLogOfRecord(string payBy, string payPrice)
        {
            string yearAndMonth = DateTime.Now.ToString("yyyy-MM");
            var path = "D://logs-bording-payments//" + yearAndMonth + ".log";

            try
            {
                string space = "                             "; 

                if (!File.Exists(path))
                {
                    using (_streamWriter = File.CreateText(path))
                    {
                        File.SetAttributes(path, FileAttributes.Normal);

                        _streamWriter.WriteLine(" " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                                                (" |" + "MONTHLY BILL PAYMENTS RECORD LOG") + (" |" + "STARTED"));
                        _streamWriter.WriteLine(" " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                                                (" |" + "MONTH                           ") + (" |" + DateTime.Now.ToString("yyyy-MM")));

                        _streamWriter.WriteLine(" ");

                        // THEN WRITE THE LOG
                        string paidByPerson = $"PAID BY : {payBy}";
                        _streamWriter.WriteLine(" " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                                                (" |" + paidByPerson + space.Substring(paidByPerson.Length, (space.Length - paidByPerson.Length)) + (" |" + $"PAID : {payPrice}")));
                    }

                }
                else
                {
                    using (_streamWriter = File.AppendText(path))
                    {
                        string paidByPerson = $"PAID BY  : {payBy}";
                        _streamWriter.WriteLine(" " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                                                (" |" + paidByPerson + space.Substring(paidByPerson.Length, (space.Length - paidByPerson.Length)) + (" |" + $"PAID : {payPrice}")));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error in Logger : {ex.Message}");
            }

        }

    }
}
