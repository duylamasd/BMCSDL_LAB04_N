using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVN
{
    public partial class StudentManager : Form
    {
        string username { get; set; }
        string password { get; set; }
        string classID { get; set; }
        SqlConnection connection { get; set; }
        public StudentManager(string username, string password, string classID, SqlConnection connection)
        {
            InitializeComponent();

            this.username = username;
            this.password = password;
            this.classID = classID;
            this.connection = connection;

            loadData();
        }

        private void loadData()
        {
            SqlCommand command = new SqlCommand("select * from SINHVIEN where MALOP = @classID", connection);
            command.Parameters.Add("@classID", SqlDbType.VarChar);
            command.Parameters["@classID"].Value = classID;

            DataTable studentTable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                adapter.Fill(studentTable);

            studentView.DataSource = studentTable;
            studentView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void apply_Click(object sender, EventArgs e)
        {
            MD5 hashFunc = MD5.Create();
            byte[] hashValue = hashFunc.ComputeHash(Encoding.Unicode.GetBytes(passwordBox.Text));
            SqlCommand updateCommand = new SqlCommand("exec SP_UPDATE_PUBLIC_ENCRYPT_SINHVIEN @classID, @studentID, @fullName, @birthday, @address, @username, @password", connection);
            updateCommand.Parameters.Add("@classID", SqlDbType.VarChar, 20).Value = classID;
            updateCommand.Parameters.Add("@studentID", SqlDbType.VarChar, 20).Value = studentIDBox.Text;
            updateCommand.Parameters.Add("@fullName", SqlDbType.NVarChar, 100).Value = fullName.Text;
            updateCommand.Parameters.Add("@birthday", SqlDbType.NVarChar).Value = birthdayBox.Text;
            updateCommand.Parameters.Add("@address", SqlDbType.NVarChar, 200).Value = addressBox.Text;
            updateCommand.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = usernameBox.Text;
            updateCommand.Parameters.Add("@password", SqlDbType.VarBinary).Value = hashValue;
            updateCommand.ExecuteNonQuery();

            loadData();
        }
    }
}
