using System;
using System.Windows.Forms;
using System.IO;

namespace Lab1_part4_Notepad
{
    public partial class blank : Form
    {
        public bool IsSaved = false;
        public string DocName = "";
        private string BufferText = "";

        public blank()
        {
            InitializeComponent();
            //Свойству Text панели sbTime устанавливаем системное время,
            // конвертировав его в тип String
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            //В тексте всплывающей подсказки выводим текущую дату
            sbTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());
        }

        private void blank_Load(object sender, EventArgs e)
        {

        }

        // Вырезание текста
        public void Cut()
        {
            this.BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }
        // Копирование текста
        public void Copy()
        {
            this.BufferText = richTextBox1.SelectedText;
        }

        public void Paste()
        {
            richTextBox1.SelectedText = this.BufferText;
        }

        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }

        public void Delete()
        {
            richTextBox1.SelectedText = "";
            this.BufferText = "";
        }

        private void cutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        public void Open(string OpenFileName)
        {
            //Если файл не выбран, возвращаемся назад (появится встроенное предупреждение)
            if (OpenFileName == "")
            {
                return;
            }
            else
            {
                //Создаем новый объект StreamReader и передаем ему переменную //OpenFileName
                StreamReader sr = new StreamReader(OpenFileName);
                //Читаем весь файл и записываем его в richTextBox1
                richTextBox1.Text = sr.ReadToEnd();
                // Закрываем поток
                sr.Close();
                //Переменной DocName присваиваем адресную строку
                DocName = OpenFileName;
            }
        }

        public void Save(string SaveFileName)
        {
            //Если файл не выбран, возвращаемся назад (появится встроенное предупреждение)
            if (SaveFileName == "")
            {
                return;
            }
            else
            {
                //Создаем новый объект StreamWriter и передаем ему переменную //OpenFileName
                StreamWriter sw = new StreamWriter(SaveFileName);
                //Содержимое richTextBox1 записываем в файл
                sw.WriteLine(richTextBox1.Text);
                //Закрываем поток
                sw.Close();
                //Устанавливаем в качестве имени документа название сохраненного файла
                DocName = SaveFileName;
            }
        }

        private void blank_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Если переменная IsSaved имеет значение true, т. е. новый документ
            //был сохранен (Save As) или в открытом документе были сохранены изменения (Save), то //выполняется условие
            if (IsSaved == true)
                //Появляется диалоговое окно, предлагающее сохранить документ.
                if (MessageBox.Show("Do you want save changes in " + this.DocName + "?",
                "Message", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                //Если была нажата кнопка Yes, вызываем метод Save
                {
                    this.Save(this.DocName);
                }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Свойству Text панели sbAmount устанавливаем надпись "Аmount of symbols"
            //и длину текста в RichTextBox.
            sbAmount.Text = "Аmount of symbols" + richTextBox1.Text.Length.ToString();
        }

     
    }
}

