using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace MilkotronicSystem.Desktop.WinFormsClient
{


    public partial class LoginForm : Form
    {
        public string sessionKey { get; set; }

        public LoginForm()
        {
            InitializeComponent();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string userServiceUrl = "http://localhost:63494/api/users/login";
                string username = tb_username.Text;
                string pass = tb_password.Text;
                System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
                string authCode = CalculateSHA1(pass, encoder);

                var user = new UserModel()
                {
                    Username = username,
                    AuthCode = authCode
                };
                var userJson = JsonConvert.SerializeObject(user);

                var client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                var result = client.UploadString(userServiceUrl, userJson);

                LoggedUserModel deserializedResult = JsonConvert.DeserializeObject<LoggedUserModel>(result);

                this.sessionKey = deserializedResult.SessionKey;
                MessageBox.Show("Login Successful");
                MilkotronicSystem mainform = new MilkotronicSystem(sessionKey);
                mainform.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        public static string CalculateSHA1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }

       
    }
}
