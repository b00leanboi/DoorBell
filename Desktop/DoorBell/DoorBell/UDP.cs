using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DoorBell
{
    class UDP
    {
        public volatile bool run = true;
        public bool isRunning { get { return running; } }
        private volatile bool running;

        private UdpClient client;
        private IPEndPoint endPoint;
        private Thread thread;

        /// <summary>
        /// When any message is received this will be called.
        /// </summary>
        /// <param name="message"></param>
        public event EventHandler<MessageEventArgs> MessageReceived;

        /// <summary>
        /// Initializes the UDP client and starts the listening thread.
        /// </summary>
        /// <param name="port"></param>
        public UDP(int port)
        {
            client = new UdpClient(port);
            client.Client.ReceiveTimeout = 5000;
            endPoint = new IPEndPoint(IPAddress.Any, port);
            thread = new Thread(Listen);
            thread.Start();
        }
        public void CloseClient()
        {
            CloseThread();
        }
        private void CloseThread()
        {
            run = false;
        }
        private void Listen()
        {
            running = true;

            while (run)
            {
                try
                {
                    byte[] receivedBytes = client.Receive(ref endPoint);
                    string receivedMessage = Encoding.ASCII.GetString(receivedBytes, 0, receivedBytes.Length);
                    MessageReceived.Invoke(this, new MessageEventArgs(receivedMessage));
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode != 10060) //10060 is a timeout error
                    {
                        throw ex;
                    }
                }
            }
            running = false;
        }
    }
    public class MessageEventArgs : EventArgs
    {
        public string message;
        public MessageEventArgs(string message)
        {
            this.message = message;
        }
    }
}