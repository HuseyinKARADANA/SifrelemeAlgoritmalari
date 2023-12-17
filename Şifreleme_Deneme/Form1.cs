using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Şifreleme_Deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string privateKey ="";
        string publicKey = "";

        RSAAlgorithm rsaAlgorithm = new RSAAlgorithm();
        private void button1_Click(object sender, EventArgs e)
        {
            // Anahtar çiftini oluştur
            var keyPair = new RSAAlgorithm().GenerateKeyPair();
             privateKey = keyPair.privateKey;
             publicKey = keyPair.publicKey;

            // Şifreleme
            string encryptedText = new RSAAlgorithm().Encrypt(txtMetin.Text.ToString(), publicKey);
            richTextBox1.Text = encryptedText;

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            // Çözme
            string decryptedText = new RSAAlgorithm().Decrypt(rbSifreli.Text.ToString(), privateKey);
            txtCozulmus.Text=decryptedText;
        }
    }
}
