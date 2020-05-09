using System;
using System.Windows.Forms;

namespace Lab1_part4_Notepad
{
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
        }

        private void FindForm_Load(object sender, EventArgs e)
        {

        }

        // Создаем перечисление, возвращающее параметр FindCondition
        public RichTextBoxFinds FindCondition
        {
            get
            {
                //Выбраны два чекбокса
                if (cbMatchCase.Checked && cbMatchWhole.Checked)
                {
                    // Возвращаем свойство MatchCase и WholeWord
                    return RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord;
                }
                //Выбран один чекбокс
                if (cbMatchCase.Checked)
                {
                    // Возвращаем свойство MatchCase
                    return RichTextBoxFinds.MatchCase;
                }
                //Выбран другой чекбокс
                if (cbMatchWhole.Checked)
                {
                    // Возвращаем свойство WholeWord
                    return RichTextBoxFinds.WholeWord;
                }
                //Не выбран ни один чекбокс
                return RichTextBoxFinds.None;
            }
        }

        public string FindText
        {
            get { return txtFind.Text; }
            set { txtFind.Text = value; }
        }
    }
}
