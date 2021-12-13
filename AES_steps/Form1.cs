using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_steps
{
    public partial class AES_steps : Form
    {
        public AES_steps()
        {
            InitializeComponent();
        }

        private void encryptbtn_Click(object sender, EventArgs e)
        {
            if(encryptkeytxt.Text.Length != 16)
            {
                string message = "Key must be 16 characters long";
                MessageBox.Show(message);
            } else
            {
                byte[] output;
                byte[] input = Encoding.UTF8.GetBytes(plaintexttxt.Text);
                byte[] CIPHER_KEY = Encoding.UTF8.GetBytes(encryptkeytxt.Text);
                AES aes = new AES(CIPHER_KEY);
                output = aes.Encrypt(input);
                plaintextbytes.Text = BitConverter.ToString(input).Replace("-", " ");
                encryptedtext.Text = BitConverter.ToString(output).Replace("-", " ");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

         private byte[] StringToByte(string str)
        {
            return Array.ConvertAll<string, byte>(str.Split(' '), s => Convert.ToByte(s, 16));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decryptkeytxt.Text.Length != 16)
            {
                string message = "Key must be 16 characters long";
                MessageBox.Show(message);
            }
            else
            {
                byte[] output;
                byte[] input = StringToByte(encryptedtext.Text);
                byte[] CIPHER_KEY = Encoding.UTF8.GetBytes(decryptkeytxt.Text);
                AES aes1 = new AES(CIPHER_KEY);
                output = aes1.Decrypt(input);
                decryptedtext.Text = System.Text.Encoding.UTF8.GetString(output);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}