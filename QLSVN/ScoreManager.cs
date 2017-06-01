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
    public partial class ScoreManager : Form
    {
        string username { get; set; }
        string password { get; set; }
        SqlConnection connection { get; set; }
        string pubkey { get; set; }
        X509Certificate2 certificate { get; set; }
        public ScoreManager(string username, string password, SqlConnection connection)
        {
            InitializeComponent();

            this.username = username;
            this.password = password;
            this.connection = connection;

            SqlCommand getPubkeyCommand = new SqlCommand("select PUBKEY from NHANVIEN where TENDN = @username", connection);
            getPubkeyCommand.Parameters.Add("@username", SqlDbType.NVarChar);
            getPubkeyCommand.Parameters["@username"].Value = username;

            using (SqlDataReader reader = getPubkeyCommand.ExecuteReader())
                while (reader.Read())
                    this.pubkey = reader[0].ToString();

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

            Thread.Sleep(200);

            certificate = new X509Certificate2(@"D:\temp\pf.pfx", "1312310", X509KeyStorageFlags.PersistKeySet);
            loadData();

            File.Delete(@"D:\temp\pr.pvk");
            File.Delete(@"D:\temp\pb.cer");
            File.Delete(@"D:\temp\pf.pfx");
        }

        private void loadData()
        {
            SqlCommand loadCommand = new SqlCommand("exec SP_SEL_PUBLIC_ENCRYPT_BANGDIEM", connection);
            DataTable data = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(loadCommand))
                adapter.Fill(data);

            data.Columns["DIEMTHI"].ReadOnly = false;
            List<float> scoreList = new List<float>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                RSACryptoServiceProvider cryptoProvider = (RSACryptoServiceProvider)certificate.PrivateKey;
                DataRow row = data.Rows[i];
                byte[] cipher = row["DIEMTHI"] as byte[];
                byte[] decryptedBytes = cryptoProvider.Decrypt(cipher, true);

                string stringValue = Encoding.Unicode.GetString(decryptedBytes);
                float scoreValue = float.Parse(stringValue);
                scoreList.Add(scoreValue);
            }

            data.Columns.Remove("DIEMTHI");
            data.Columns.Add("DIEMTHI", typeof(float));
            for (int i = 0; i < data.Rows.Count; i++)
                data.Rows[i]["DIEMTHI"] = scoreList[i];

            scoreView.DataSource = data;
            data.Columns["DIEMTHI"].ReadOnly = true;
            scoreView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void apply_Click(object sender, EventArgs e)
        {
            if (studentIDBox.Text == "")
            {
                MessageBox.Show("Please insert MASV!");
                return;
            }

            if (subjectIDBox.Text == "")
            {
                MessageBox.Show("Please insert MAHP!");
                return;
            }

            if (scoreBox.Text == "")
            {
                MessageBox.Show("Please insert score!");
                return;
            }

            RSACryptoServiceProvider cryptoProvider = (RSACryptoServiceProvider)certificate.PublicKey.Key;
            byte[] cipherScore = Encoding.Unicode.GetBytes(scoreBox.Text);
            byte[] encryptedScore = cryptoProvider.Encrypt(cipherScore, true);

            SqlCommand insertCommand = new SqlCommand("exec SP_INS_PUBLIC_ENCRYPT_BANGDIEM @studentID, @subjectID, @score", connection);
            insertCommand.Parameters.Add("@studentID", SqlDbType.VarChar, 20).Value = studentIDBox.Text;
            insertCommand.Parameters.Add("@subjectID", SqlDbType.VarChar, 20).Value = subjectIDBox.Text;
            insertCommand.Parameters.Add("@score", SqlDbType.VarBinary).Value = encryptedScore;
            insertCommand.ExecuteNonQuery();

            loadData();
        }
    }
}
