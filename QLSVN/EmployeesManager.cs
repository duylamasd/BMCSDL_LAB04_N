using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVN
{
    public partial class EmployeesManager : Form
    {
        bool isAddingActivated { get; set; }
        string username { get; set; }
        string password { get; set; }
        SqlConnection connection { get; set; }
        string pubkey { get; set; }
        X509Certificate2 certificate { get; set; }
        public EmployeesManager(string username, string password, SqlConnection connection)
        {
            InitializeComponent();
            isAddingActivated = false;
            this.username = username;
            this.password = password;
            this.connection = connection;

            SqlCommand getPubkeyCommand = new SqlCommand("select PUBKEY from NHANVIEN where TENDN = @username", connection);
            getPubkeyCommand.Parameters.Add("@username", SqlDbType.NVarChar);
            getPubkeyCommand.Parameters["@username"].Value = username;

            pubkey = getPubkeyCommand.ExecuteScalar().ToString();

            SqlCommand cmdPublic = new SqlCommand("exec dbo.sp_get_publickey @keyname", connection);
            cmdPublic.Parameters.Add("@keyname", SqlDbType.VarChar, 20).Value = pubkey;
            SqlCommand cmdPrivate = new SqlCommand("exec dbo.sp_get_privatekey @keyname, 1", connection);
            cmdPrivate.Parameters.Add("@keyname", SqlDbType.VarChar, 20).Value = pubkey;
            byte[] publicPortion = cmdPublic.ExecuteScalar() as byte[];
            byte[] privatePortion = cmdPrivate.ExecuteScalar() as byte[];
            File.WriteAllBytes(@"D:\temp\pr.pvk", privatePortion);
            File.WriteAllBytes(@"D:\temp\pb.cer", publicPortion);

            ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.1A\Bin\pvk2pfx.exe",
                    @"-pvk D:\temp\pr.pvk -pi 1312310 -spc D:\temp\pb.cer -pfx D:\temp\pf.pfx -po 1312310");
            Process.Start(startInfo);

            Thread.Sleep(150);

            certificate = new X509Certificate2(@"D:\temp\pf.pfx", "1312310", X509KeyStorageFlags.PersistKeySet);
            loadData();

            File.Delete(@"D:\temp\pr.pvk");
            File.Delete(@"D:\temp\pb.cer");
            File.Delete(@"D:\temp\pf.pfx");
        }

        private void loadData()
        {
            SqlCommand loadThisUser = new SqlCommand("exec SP_SEL_PUBLIC_ENCRYPT_NHANVIEN @username, @password", connection);
            loadThisUser.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
            SHA1 hashPassword = SHA1Managed.Create();
            byte[] hashValue = hashPassword.ComputeHash(Encoding.Unicode.GetBytes(password));
            loadThisUser.Parameters.Add("@password", SqlDbType.VarBinary).Value = hashValue;

            SqlCommand loadUserCommand = new SqlCommand("select TENDN from NHANVIEN", connection);
            SqlCommand loadPassCommand = new SqlCommand("select MATKHAU from NHANVIEN", connection);
            List<string> userList = new List<string>();
            List<byte[]> passList = new List<byte[]>();
            DataTable data = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(loadThisUser))
                adapter.Fill(data);
            using (SqlDataReader reader = loadUserCommand.ExecuteReader())
                while (reader.Read())
                    userList.Add(reader[0].ToString());
            using (SqlDataReader reader = loadPassCommand.ExecuteReader())
                while (reader.Read())
                    passList.Add(reader[0] as byte[]);

            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i] != username)
                {
                    SqlCommand rowCommand = new SqlCommand("exec SP_SEL_PUBLIC_ENCRYPT_NHANVIEN @username, @password", connection);
                    rowCommand.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = userList[i];
                    rowCommand.Parameters.Add("@password", SqlDbType.VarBinary).Value = passList[i];
                    DataTable rowValue = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(rowCommand))
                        adapter.Fill(rowValue);
                    DataRow row = rowValue.Rows[0];
                    data.ImportRow(row);
                }
            }

            List<long> salaryList = new List<long>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                long salaryValue = -1;
                if (i == 0)
                {
                    RSACryptoServiceProvider cryptoProvider = (RSACryptoServiceProvider)certificate.PrivateKey;
                    DataRow row = data.Rows[i];
                    byte[] cipher = row["LUONG"] as byte[];
                    byte[] decryptedBytes = cryptoProvider.Decrypt(cipher, true);

                    string stringValue = Encoding.Unicode.GetString(decryptedBytes);
                    salaryValue = long.Parse(stringValue);
                }
                salaryList.Add(salaryValue);
            }

            data.Columns.Remove("LUONG");
            data.Columns.Add("LUONG", typeof(long));
            for (int i = 0; i < data.Rows.Count; i++)
                data.Rows[i]["LUONG"] = salaryList[i];

            employeeView.DataSource = data;
            employeeView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void add_Click(object sender, EventArgs e)
        {
            isAddingActivated = true;
        }

        private void update_Click(object sender, EventArgs e)
        {
            SHA1 hashFunc = SHA1Managed.Create();
            byte[] hashValue = hashFunc.ComputeHash(Encoding.Unicode.GetBytes(passwordBox.Text));

            SqlCommand getPubkeyName = new SqlCommand("select PUBKEY from NHANVIEN where MANV = @employeeID", connection);
            getPubkeyName.Parameters.Add("@employeeID", SqlDbType.VarChar, 20).Value = employeeIDBox.Text;
            string pubkeyName = getPubkeyName.ExecuteScalar().ToString();

            SqlCommand cmdPublic = new SqlCommand("exec dbo.sp_get_publickey @keyname", connection);
            cmdPublic.Parameters.Add("@keyname", SqlDbType.VarChar, 20).Value = pubkeyName;
            byte[] publicPortion = cmdPublic.ExecuteScalar() as byte[];
            File.WriteAllBytes(@"D:\temp\pb.cer", publicPortion);
            Thread.Sleep(100);
            X509Certificate2 cert = new X509Certificate2(File.ReadAllBytes(@"D:\temp\pb.cer"));
            RSACryptoServiceProvider encryptor = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] encryptedSalary = encryptor.Encrypt(Encoding.Unicode.GetBytes(salaryBox.Text), true);
            File.Delete(@"D:\temp\pb.cer");

            SqlCommand updateCommand = new SqlCommand("update NHANVIEN set MANV = @employeeID, HOTEN = @fullName, EMAIL = @email, LUONG = @salary, TENDN = @username, MATKHAU = @password where MANV = @employeeID", connection);
            updateCommand.Parameters.Add("@employeeID", SqlDbType.VarChar, 20).Value = employeeIDBox.Text;
            updateCommand.Parameters.Add("@fullName", SqlDbType.NVarChar, 100).Value = fullNameBox.Text;
            updateCommand.Parameters.Add("@email", SqlDbType.VarChar, 20).Value = emailBox.Text;
            updateCommand.Parameters.Add("@salary", SqlDbType.VarBinary).Value = encryptedSalary;
            updateCommand.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = usernameBox.Text;
            updateCommand.Parameters.Add("@password", SqlDbType.VarBinary).Value = hashValue;
            updateCommand.ExecuteNonQuery();

            loadData();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlCommand getUsername = new SqlCommand("select TENDN from NHANVIEN where MANV = @employeeID", connection);
            getUsername.Parameters.Add("@employeeID", SqlDbType.VarChar, 20).Value = employeeIDBox.Text;
            string deletingUser = getUsername.ExecuteScalar().ToString();
            if (username == deletingUser)
            {
                MessageBox.Show("Không thể xóa thông tin khi đang đăng nhập.");
                return;
            }

            SqlCommand getPubkeyName = new SqlCommand("select PUBKEY from NHANVIEN where MANV = @employeeID", connection);
            getPubkeyName.Parameters.Add("@employeeID", SqlDbType.VarChar, 20).Value = employeeIDBox.Text;
            string pubkeyName = getPubkeyName.ExecuteScalar().ToString();

            SqlCommand deletePubkey = new SqlCommand("drop certificate " + pubkeyName, connection);
            deletePubkey.ExecuteNonQuery();

            SqlCommand deleteCommand = new SqlCommand("delete from NHANVIEN where MANV = @employeeID", connection);
            deleteCommand.Parameters.Add("@employeeID", SqlDbType.VarChar, 20).Value = employeeIDBox.Text;
            deleteCommand.ExecuteNonQuery();

            loadData();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (isAddingActivated)
            {
                SHA1 hashFunc = SHA1Managed.Create();
                byte[] hashValue = hashFunc.ComputeHash(Encoding.Unicode.GetBytes(passwordBox.Text));

                SqlCommand createCertCommand = new SqlCommand("exec dbo.sp_create_certificate @pubkey", connection);
                createCertCommand.Parameters.Add("@pubkey", SqlDbType.VarChar, 20).Value = pubkeyNameBox.Text;
                createCertCommand.ExecuteNonQuery();

                SqlCommand cmdPublic = new SqlCommand("exec dbo.sp_get_publickey @keyname", connection);
                cmdPublic.Parameters.Add("@keyname", SqlDbType.VarChar, 20).Value = pubkeyNameBox.Text;
                byte[] publicPortion = cmdPublic.ExecuteScalar() as byte[];
                File.WriteAllBytes(@"D:\temp\pb.cer", publicPortion);
                Thread.Sleep(100);
                X509Certificate2 cert = new X509Certificate2(File.ReadAllBytes(@"D:\temp\pb.cer"));
                RSACryptoServiceProvider encryptor = (RSACryptoServiceProvider)cert.PublicKey.Key;
                byte[] encryptedSalary = encryptor.Encrypt(Encoding.Unicode.GetBytes(salaryBox.Text), true);
                File.Delete(@"D:\temp\pb.cer");

                SqlCommand insertCommand = new SqlCommand("exec SP_INS_PUBLIC_ENCRYPT_NHANVIEN @employeeID, @fullName, @email, @salary, @username, @password, @pubkey", connection);
                insertCommand.Parameters.Add("@employeeID", SqlDbType.VarChar, 20).Value = employeeIDBox.Text;
                insertCommand.Parameters.Add("@fullName", SqlDbType.NVarChar, 100).Value = fullNameBox.Text;
                insertCommand.Parameters.Add("@email", SqlDbType.VarChar, 20).Value = emailBox.Text;
                insertCommand.Parameters.Add("@salary", SqlDbType.VarBinary).Value = encryptedSalary;
                insertCommand.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = usernameBox.Text;
                insertCommand.Parameters.Add("@password", SqlDbType.VarBinary).Value = hashValue;
                insertCommand.Parameters.Add("@pubkey", SqlDbType.VarChar, 20).Value = pubkeyNameBox.Text;
                insertCommand.ExecuteNonQuery();

                loadData();
            }
        }

        private void none_Click(object sender, EventArgs e)
        {
            // do nothing.
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
