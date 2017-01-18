using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string serverIP = txtIP.Text;
                int port = Convert.ToInt32(txtPort.Text);

                TcpClient client = new TcpClient(serverIP, port);

                byte[] data = Encoding.ASCII.GetBytes(senderTextBox.Text);                

                NetworkStream netStream = client.GetStream();
                netStream.Write(data, 0, data.Length);

                data = new byte[2048];

                int bytesToRec = netStream.Read(data,0,data.Length);
                string msg = Encoding.ASCII.GetString(data, 0, bytesToRec);

                recTextBox.Text = msg;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
