using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using FunctionalCSharp;
namespace HL7
{

    public enum HL7Status
    {
        ACK,
        NACK,
        NOCONNECTION,
        EXCEPTION
    }



    public class SendHl7
    {
        string server;
        int port;
        public SendHl7(string server, int port)
        {
            this.server = server;
            this.port = port;
        }

        /// <summary>
        /// Send multiple HL7 messages at once
        /// </summary>
        /// <param name="hl7message"></param>
        /// <returns></returns>
        public HL7Status SendHL7Multiple(IEnumerable<string> hl7messages)
        {
            return _SendHL7(SerializeHL7Message(
                //delimit with special characters and thenmerge the messages together with mkString.
                hl7messages.Select(DelimitHL7Message).mkString("\r")
                ));
        }

        /// <summary>
        /// Add the leading and trailing characters so it is LLP compliant.
        /// </summary>
        /// <param name="hl7message"></param>
        /// <returns></returns>
        private string DelimitHL7Message(string hl7message)
        {
            return Convert.ToChar(11).ToString() + hl7message + Convert.ToChar(28).ToString() + Convert.ToChar(13).ToString();
        }

        private Byte[] SerializeHL7Message(string delimitedHl7message)
        {
            //serialize the message
            return Encoding.ASCII.GetBytes(delimitedHl7message);
        }


        public HL7Status SendHL7(string hl7message)
        {
            return _SendHL7(SerializeHL7Message(DelimitHL7Message((hl7message))));
        }
        private HL7Status _SendHL7(Byte[] bytesToSend)
        {
            try
            {
                // Create a socket connection with the specified server and port.
                Socket s = ConnectSocket();

                // If the socket could not get a connection, then return false.
                if (s == null)
                    return HL7Status.NOCONNECTION;

                // Send message to the server.
                s.Send(bytesToSend, bytesToSend.Length, 0);

                // Receive the response back
                int bytes = 0;
                s.ReceiveTimeout = 3000;
                Byte[] bytesReceived = new Byte[256];
                bytes = s.Receive(bytesReceived, bytesReceived.Length, 0); //fails here.
                string page = Encoding.ASCII.GetString(bytesReceived, 0, bytes);
                s.Close();

                // Check to see if it was successful
                if (page.Contains("MSA|AA"))
                {
                    return HL7Status.ACK;
                }
                else
                {
                    return HL7Status.NACK;
                }
            }
            catch (Exception ex)
            {
                return HL7Status.EXCEPTION;
            }
        }

        private Socket ConnectSocket()
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }
    }
}
