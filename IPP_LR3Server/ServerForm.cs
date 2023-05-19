///Програма-сервер містить два вікна edit, у які користувач може уводити свій текст. 
///Програма-клієнт має 2 кнопки, по натисканню однієї з який, клієнт одержує текст відповідного вікна програми-сервера.
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LB3
{
    public partial class ServerForm : Form
    {
        private Socket serverSocket;
        private Socket clientSocket;
        private byte[] receivingBuffer;
        private byte[] sendingbuffer = new byte[1];

        public ServerForm()
        {
            InitializeComponent();
            Starter();
        }

        private static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Starter()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, 3333));
                serverSocket.Listen(10);
                serverSocket.BeginAccept(Acception, null);
            }
            catch (SocketException ex) when (HandleSocketException(ex))
            {
                // Exception handled in HandleSocketException method
            }
            catch (ObjectDisposedException ex) when (HandleObjectDisposedException(ex))
            {
                // Exception handled in HandleObjectDisposedException method
            }
        }

        private bool HandleSocketException(SocketException ex)
        {
            ShowErrorDialog(ex.Message);
            return true; // Exception handled
        }

        private bool HandleObjectDisposedException(ObjectDisposedException ex)
        {
            ShowErrorDialog(ex.Message);
            return true; // Exception handled
        }

        private void Acception(IAsyncResult AR)
        {
            try
            {
                clientSocket = serverSocket.EndAccept(AR);
                receivingBuffer = new byte[clientSocket.ReceiveBufferSize];
                clientSocket.BeginReceive(receivingBuffer, 0, receivingBuffer.Length, SocketFlags.None, Receiver, null);
                serverSocket.BeginAccept(Acception, null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndSend(AR);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void Receiver(IAsyncResult AR)
        {
            try
            {
                int received = clientSocket.EndReceive(AR);
                if (received == 0)
                {
                    return;
                }

                var receivedData = new byte[received];
                Array.Copy(receivingBuffer, receivedData, received);
                var receivedMessage = Encoding.ASCII.GetString(receivedData).Trim('\0');

                byte[] sendingBuffer = null;
                if (receivedMessage == "FirstW")
                {
                    sendingBuffer = Encoding.ASCII.GetBytes(tbLeft.Text);
                }
                else if (receivedMessage == "SecondW")
                {
                    sendingBuffer = Encoding.ASCII.GetBytes(tbRight.Text);
                }

                if (sendingBuffer != null)
                {
                    clientSocket.BeginSend(sendingBuffer, 0, sendingBuffer.Length, SocketFlags.None, SendCallback, null);
                }

                Array.Clear(receivingBuffer, 0, receivingBuffer.Length);
                clientSocket.BeginReceive(receivingBuffer, 0, receivingBuffer.Length, SocketFlags.None, Receiver, null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serverSocket?.Shutdown(SocketShutdown.Both);
                serverSocket?.Close();
                clientSocket?.Shutdown(SocketShutdown.Both);
                clientSocket?.Close();
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}
