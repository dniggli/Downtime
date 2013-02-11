﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

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

        public HL7Status SendHL7(string hl7message)
        {
            try
            {
                // Add the leading and trailing characters so it is LLP compliant.
                string llphl7message = Convert.ToChar(11).ToString() + hl7message + Convert.ToChar(28).ToString() + Convert.ToChar(13).ToString();

                // Get the size of the message that we have to send.
                Byte[] bytesSent = Encoding.ASCII.GetBytes(llphl7message);
                Byte[] bytesReceived = new Byte[256];

                // Create a socket connection with the specified server and port.
                Socket s = ConnectSocket();

                // If the socket could not get a connection, then return false.
                if (s == null)
                    return HL7Status.NOCONNECTION;

                // Send message to the server.
                s.Send(bytesSent, bytesSent.Length, 0);

                // Receive the response back
                int bytes = 0;
                s.ReceiveTimeout = 3000;
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
