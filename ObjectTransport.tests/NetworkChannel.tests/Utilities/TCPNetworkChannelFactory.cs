﻿using OTransport.NetworkChannel.TCP;
using OTransport;
using OTransport.Test.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Test
{
    class TCPObjectTransportChannel
    {
        private static TCPServerChannel server = new TCPServerChannel();
        private static TCPClientChannel tcpclient = new TCPClientChannel();
        public static Tuple<OTransport.ObjectTransport, ObjectTransport> GetConnectObjectTransports()
        {
            server.Start("127.0.0.1", 0);

            ObjectTransport serverObjectTransport = TestObjectTransportFactory.CreateNewObjectTransport(server);

            tcpclient.Start("127.0.0.1", server.LocalPort);
            ObjectTransport client = TestObjectTransportFactory.CreateNewObjectTransport(tcpclient);

            Tuple<ObjectTransport, ObjectTransport> result = new Tuple<ObjectTransport, ObjectTransport>(serverObjectTransport, client);
            return result;
        }
        public static void TearDown()
        {
            if (server != null)
                server.Stop();
            if (tcpclient != null)
                tcpclient.Stop();
        }
    }
}
