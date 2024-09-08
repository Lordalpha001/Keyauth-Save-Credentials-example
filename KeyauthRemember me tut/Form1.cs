using KeyAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyauthRemember_me_tut
{
    public partial class Form1 : Form
    {

        public class Credentials
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        public static api KeyAuthApp = new api(
             name: "ADD YOURS", // Application Name
             ownerid: "ADD YOURS", // Owner ID
             secret: "ADD YOURS", // Application Secret
             version: "ADD YOURS" // Application Version /*
            );


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();


            string configpath = "Config.json";
            if (File.Exists(configpath)) 
                {
                siticoneOSToggleSwith1.Checked = true;
                    string json = File.ReadAllText(configpath);
                Credentials credentials = JsonConvert.DeserializeObject<Credentials>(json);
                string credentialsString = string.Format("username: {0}, Password: {1}", credentials.Username, credentials.Password);
                siticoneMaterialTextBox1.Text = credentials.Username;
                siticoneMaterialTextBox2.Text = credentials.Password;
                }
        }

        private void siticoneGradientButton1_Click(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith1.Checked == true)
            {
                KeyAuthApp.login(siticoneMaterialTextBox1.Text, siticoneMaterialTextBox2.Text);
                if (KeyAuthApp.response.success)
                {
                    Credentials credentials = new Credentials
                    {
                        Username = siticoneMaterialTextBox1.Text,
                        Password = siticoneMaterialTextBox2.Text
                    };
                    string json = JsonConvert.SerializeObject(credentials);
                    string filePath = "Config.json";
                    File.WriteAllText(filePath, json);
                    main main = new main();
                    main.Show();
                    this.Hide();
                }
            }

            if (siticoneOSToggleSwith1.Checked == false)
            {
                KeyAuthApp.login(siticoneMaterialTextBox1.Text, siticoneMaterialTextBox2.Text);
                if (KeyAuthApp.response.success )
                {
                    string filepath = "config.json";
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);
                    }
                    main main = new main();
                    main.Show();
                    this.Hide();
                }
            }
        }
    }
}
