﻿using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class FormClient : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        NetworkStream serverStream = default(NetworkStream);

        string readData = null;

        public FormClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("textBox2.Text" + "$");

            serverStream.Write(outStream, 0, outStream.Length);

            serverStream.Flush();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            readData = "Connected to Chat Server ...";

            msg();

            clientSocket.Connect("127.0.0.1", 8888);

            serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("textBox3.Text" + "$");

            serverStream.Write(outStream, 0, outStream.Length);

            serverStream.Flush();


            Thread ctThread = new Thread(GetMessage);

            ctThread.Start();

        }

        private void GetMessage()
        {
            while (true)
            {

                serverStream = clientSocket.GetStream();

                int buffSize = 0;

                byte[] inStream = new byte[10025];

                buffSize = clientSocket.ReceiveBufferSize;

                serverStream.Read(inStream, 0, buffSize);

                string returndata = System.Text.Encoding.ASCII.GetString(inStream);

                readData = "" + returndata;

                msg();
            }
        }

        private void msg()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(msg));
            }
            //else
            //{
            //    "textBox1.Text" = "textBox1.Text" + Environment.NewLine + " >> " + readData;
            //}
        }

    }
}
