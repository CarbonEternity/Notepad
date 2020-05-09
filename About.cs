using System;
using System.Windows.Forms;

namespace Lab1_part4_Notepad
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink("https://github.com/CarbonEternity");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "Unable to open link that was clicked.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //Добавляем блок для обработки исключений — по разным причинам
            //пользователь может не получить доступа к ресурсу.
            try
            {
                //Вызываем метод VisitLink, определенный ниже
                VisitLink("http://www.notepadcsharp.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "Unable to open link that was clicked.");
            }

        }
        private void VisitLink(string address)
        {
            // Изменяем цвет посещенной ссылки, программно
            //обращаясь к свойству LinkVisited элемента LinkLabel
            linkLabel1.LinkVisited = true;
            //Вызываем метод Process.Start method для запуска браузера,
            //установленного по умолчанию, и открытия ссылки
            System.Diagnostics.Process.Start(address);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
    }
}
