using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace PortScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Port
        {
            short portNumber;
            string portType;
        };

        private void button1_Click(object sender, EventArgs e)
        {
            short[] portList = { 20, 21, 22, 23, 25, 53, 70, 80, 109, 110, 119, 143, 161, 162, 443, 3389 };
            string host = textBox1.Text;
            listBox1.Items.Add("Scanning ports for :" + host);
            listBox1.Items.Add("It might take a while...");

            foreach (short port in portList)
            {
                this.Refresh();
                try
                {
                    TcpClient client = new TcpClient(host, port);
                    listBox1.Items.Add("Port: " + port.ToString() + " " + port.GetTypeCode() + " is open");
                }
                catch
                {
                    listBox1.Items.Add("Port: " + port.ToString() + " is closed");
                }
            }
        }
    }
}
