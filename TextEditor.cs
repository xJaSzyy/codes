using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ТекстовыйРедактор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFile.ShowDialog();
            System.Windows.Forms.Form.ActiveForm.Text = OpenFile.FileName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            if (OpenFile.FileName == String.Empty)
            {
                return;
            }
            // Чтение текстового файла
            try
            {
                var Reader = new System.IO.StreamReader(
                OpenFile.FileName, Encoding.GetEncoding(1251));
                TextField.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            catch (System.IO.FileNotFoundException Situation)
            {
                MessageBox.Show(Situation.Message + "\nНет такого файла",
                         "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception Situation) // отчет о других ошибках
            { 
                MessageBox.Show(Situation.Message,
                     "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void сохранитьКакToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFile.FileName = OpenFile.FileName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var Writer = new System.IO.StreamWriter(
                    SaveFile.FileName, false,
                    System.Text.Encoding.GetEncoding(1251));
                    Writer.Write(TextField.Text);
                    Writer.Close();
                }
                catch (Exception Situation)
                { // отчет о других ошибках
                    MessageBox.Show(Situation.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextField.Clear();
            OpenFile.FileName = @"Текстовый файл.txt";
            OpenFile.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            SaveFile.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }
    }
}
