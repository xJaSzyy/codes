//Author: Novoselov Stepan //

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
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opener();
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile.FileName = OpenFile.FileName;
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Opener();
        }

        private void отменадействияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextField.Undo();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextField.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextField.Copy();
        }

        private void вставкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextField.Paste();
        }
    }
}
