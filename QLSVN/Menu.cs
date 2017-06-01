using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVN
{
    public partial class Menu : Form
    {
        string username { get; set; }
        string password { get; set; }
        SqlConnection connection { get; set; }
        public Menu(string username, string password, SqlConnection connection)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.connection = connection;
        }

        private void classManager_Click(object sender, EventArgs e)
        {
            ClassManager classManager = new ClassManager(username, password, connection);
            classManager.Show();
        }

        private void scoreManager_Click(object sender, EventArgs e)
        {
            ScoreManager scoreManager = new ScoreManager(username, password, connection);
            scoreManager.Show();
        }

        private void employeeManage_Click(object sender, EventArgs e)
        {
            EmployeesManager employeeManager = new EmployeesManager(username, password, connection);
            employeeManager.Show();
        }
    }
}
