using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisitorExample
{
    public partial class MainForm : Form
    {
        private Employees employees = new Employees();

        public MainForm()
        {
            InitializeComponent();
            ShowEmployeeInfo();
        }

        private void AddClerkButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length > 0)
            {
                employees.Add(new Clerk(nameTextBox.Text));
            }
            ShowEmployeeInfo();
        }

        private void AddDirectorButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length > 0)
            {
                employees.Add(new Director(nameTextBox.Text));
            }
            ShowEmployeeInfo();
        }

        private void AddPresidentButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length > 0)
            {
                employees.Add(new President(nameTextBox.Text));
            }
            ShowEmployeeInfo();
        }

        private void GiveRaisesButton_Click(object sender, EventArgs e)
        {
            employees.GiveRaises();
            ShowEmployeeInfo();
        }

        private void IncreaseVacationsButton_Click(object sender, EventArgs e)
        {
            employees.IncreaseVacations();
            ShowEmployeeInfo();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            employees.Clear();
            ShowEmployeeInfo();
        }

        private void ShowEmployeeInfo()
        {
            InfoTextBox.Text = employees.Info;
        }
    }
}
