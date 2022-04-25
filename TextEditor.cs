//Author: Novoselov Stepan //

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextField1.Clear();
            OpenFile.FileName = @"Текстовый файл.txt";
            OpenFile.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            SaveFile.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void Opener()
        {
            OpenFile.ShowDialog();
            System.Windows.Forms.Form.ActiveForm.Text = OpenFile.FileName;
            if (OpenFile.FileName == String.Empty)
            {
                return;
            }
            // Чтение текстового файла
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                var Reader = new System.IO.StreamReader(
                OpenFile.FileName, Encoding.GetEncoding(1251));
                TextField1.Text = Reader.ReadToEnd();
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

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Opener();
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Opener();
        }

        private void сохранитьКакToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFile.FileName = OpenFile.FileName;
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    var Writer = new System.IO.StreamWriter(
                    SaveFile.FileName, false,
                    System.Text.Encoding.GetEncoding(1251));
                    Writer.Write(TextField1.Text);
                    Writer.Close();
                }
                catch (Exception Situation)
                { // отчет о других ошибках
                    MessageBox.Show(Situation.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void копироватьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TextField1.Copy();
        }

        private void вставкаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TextField1.Paste();
        }

        private void вырезатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TextField1.Cut();
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextField1.Undo();
        }
    }
}
