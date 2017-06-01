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
    public partial class ClassManager : Form
    {
        string username { get; set; }
        string password { get; set; }
        SqlConnection connection { get; set; }
        public ClassManager(string username, string password, SqlConnection connection)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.connection = connection;

            SqlCommand command = new SqlCommand("select L.MALOP, L.TENLOP, L.MANV from NHANVIEN NV, LOP L where NV.MANV = L.MANV and NV.TENDN = @username", connection);
            command.Parameters.Add("@username", SqlDbType.NVarChar);
            command.Parameters["@username"].Value = username;

            DataTable classTable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                adapter.Fill(classTable);

            classTableView.DataSource = classTable;

            for (int i = 0; i < classTable.Rows.Count; i++)
            {
                string classID = classTable.Rows[i][0].ToString();
                classList.Items.Add(classID);
            }
        }

        private void studentManage_Click(object sender, EventArgs e)
        {
            StudentManager studentManager = new StudentManager(username, password,
                                        classList.SelectedItem.ToString(), connection);
            studentManager.Show();
        }
    }
}
