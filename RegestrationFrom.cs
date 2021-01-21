using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace StatRub_v1
{
    public partial class RegestrationFrom : MetroFramework.Forms.MetroForm
    {
        private static string CommandText;
        private MySqlConnection cn;

        public string CText;
        public string C2Text;
        public string C3Text;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        public RegestrationFrom()
        {
            InitializeComponent();
        }

        private void RegestrationFrom_Load(object sender, EventArgs e)
        {

        }
        private void Registration_Load(object sender, EventArgs e)
        {
            cn = new MySqlConnection(@"server=localhost;uid=root;password=root;persistsecurityinfo=True;database=movedb");
            cn.Open();
        }
        public static void CreateCopyMessage(string server) // в будущем
        {
            MailAddress from = new MailAddress("bi50_a.d.rubanov@mpt.ru", "ИИ админа, не отвечай на сообщение а то заспамлю");
            MailAddress to = new MailAddress(CommandText, "Новый пользователь");
            MailMessage message = new MailMessage(from, to);
            // message.Subject = "Using the SmtpClient class.";
            message.Subject = "server=smtp.gmail.com;uid=bi50_a.d.rubanov@mpt.ru;password=*********;";
            message.Body = @"VERIFECTION";
            // Add a carbon copy recipient.
            MailAddress copy = new MailAddress("bi50_a.d.rubanov@mpt.ru");
            message.CC.Add(copy);
            SmtpClient client = new SmtpClient(server);
            // Include credentials if the server requires them.
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            Console.WriteLine("1",
                 to.Address, client.Host);

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("0",
                    ex.ToString());
            }
        }

        private void waterMark1_TextChanged(object sender, EventArgs e) // EMAIL *******************
        {
            CommandText = waterMark1.Text;
        }

        private void waterMark2_TextChanged(object sender, EventArgs e) // USER LOGIN *****************
        {
            string CText = waterMark2.Text;
        }

        private void waterMark3_TextChanged(object sender, EventArgs e) // USER PASSSSSS ***************
        {
            string C2Text = waterMark3.Text;
        }

        private void waterMark4_TextChanged(object sender, EventArgs e) // VISIT CODE 
        {
            string C3Text = waterMark4.Text;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AutoRezation f2 = new AutoRezation();
            f2.Show();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (CText != string.Empty || C2Text != string.Empty || C3Text != string.Empty)
            {
                if (C2Text == C3Text)
                {
                    
                    cmd = new MySqlCommand("SELECT * FROM `users`" + CText + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Такой пользователь уже есть ", "Ошибка 605", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new MySqlCommand("users(@login,@pass)", cn);
                        cmd.Parameters.AddWithValue("login", CText);
                        cmd.Parameters.AddWithValue("pass", C2Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ваш аккаунт создан авторизируйтесь", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Пожайлуста введите нормальный пароль ", "Ошибка 606", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Проверити правильность введенного пароля", "Ошибка 607", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }


}