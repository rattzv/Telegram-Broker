using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using CsvHelper;
using System.Threading.Tasks;


namespace SocialApp___Telegram_Broker
{
    class Exporting
    {
        public static void exportCSV(Form2 FormPars, string fileName)
        {
            Directory.CreateDirectory(Application.StartupPath + @"\Parser");

            var fs = new FileStream(Application.StartupPath + @"\Parser\" + fileName + ".csv", FileMode.CreateNew);
            using (var sw = new StreamWriter(fs, Encoding.Default))
            {
                var writer = new CsvWriter(sw);
                writer.WriteField("Имя");
                writer.WriteField("Фамилия");
                writer.WriteField("Username");
                writer.WriteField("Роль");
                writer.WriteField("Статус");
                writer.WriteField("Был в сети");
                writer.NextRecord();


                int RowCount = FormPars.bunifuCustomDataGrid1.RowCount;
                int ColumnCount = FormPars.bunifuCustomDataGrid1.ColumnCount;

                // get the rows data
                for (int currentRow = 0; currentRow < RowCount; currentRow++)
                {
                    if (!FormPars.bunifuCustomDataGrid1.Rows[currentRow].IsNewRow)
                    {
                        for (int currentCol = 0; currentCol < ColumnCount; currentCol++)
                        {
                            if (FormPars.bunifuCustomDataGrid1.Rows[currentRow].Cells[currentCol].Value != null)
                            {
                                writer.WriteField(FormPars.bunifuCustomDataGrid1.Rows[currentRow].Cells[currentCol].Value.ToString());
                            }
                            else
                            {
                                writer.WriteField("no_data");
                            }
                            if (currentCol < ColumnCount - 1)
                            {
                            }
                            else
                            {
                                writer.NextRecord();
                            }
                        }
                    }
                }
            }
            FormPars.notifyIcon1.Icon = System.Drawing.SystemIcons.Application;
            FormPars.notifyIcon1.ShowBalloonTip(1000, "Файл успешно сохранен по пути 'Parser/"+ fileName+"'", "Файл сохранен", ToolTipIcon.Info);
        }
    }
}
