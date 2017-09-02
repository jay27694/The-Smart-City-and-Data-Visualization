using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;


namespace TeamComet
{
    namespace TcpIp
    {
        namespace Practice
        {
            /// <summary>
            /// A practice server class
            /// </summary>
            public class Server
            {
                private IPAddress _ServerIP;
                private uint _ServerPort;

                /// <summary>
                /// Server\IP Address
                /// </summary>
                public IPAddress ServerIP { get { return _ServerIP; } }
                /// <summary>
                /// Server\Port
                /// </summary>
                public uint ServerPort { get { return _ServerPort; } }

                /// <summary>
                /// Server\State
                /// </summary>
                static bool _StopServer = false;

                private TcpListener Socket_Server;
                private TcpClient Socket_Client;
                private Thread Thread_STS_Client;

                public delegate void DataReceived(XComm.Sample.Message Data);
                static DataReceived Deligator;
                

                enum ReceivedResponceCode : byte
                {
                    JustWait = 0,
                    Send_Level1_Organization = 1,
                    Be_Ready_To_Get_Level2_TimeSheet = 2,
                    Disconnect_Me = 3,
                    Refresh = 4
                }

                public void Initialize(uint Port, DataReceived EventHandler)
                {
                    try
                    {
                        foreach (IPAddress IP in System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList)
                        {
                            if (IP.AddressFamily == AddressFamily.InterNetwork)
                            {
                                _ServerIP = IP;
                            }
                        }
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                    _ServerPort = Port;
                    Deligator = EventHandler;
                }

                public void Start()
                {
                    try
                    {
                            Thread_STS_Client = new Thread(Hosting);
                            Thread_STS_Client.IsBackground = true;
                            Thread_STS_Client.Start();
                            _StopServer = false;
                           
                       
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }

                public void Stop()
                {
                    try
                    {
                        if (Thread_STS_Client.IsAlive)
                        {
                            _StopServer = true;
                            Socket_Server.Stop();
                            Thread_STS_Client.Abort();
                        }
                        _StopServer = true;
                        Socket_Server.Stop();
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }

                public void Hosting()
                {
                    try
                    {
                        Socket_Server = new TcpListener(IPAddress.Any, (int)ServerPort);
                        
                        Socket_Server.Start();

                        while (_StopServer == false)
                        {
                            Socket_Client = Socket_Server.AcceptTcpClient();
                            Handle_StsClient Client = new Handle_StsClient();
                            Client.RespondClient(Socket_Client, Deligator);
                        }

                    }
                    catch (System.Exception)
                    {

                       // throw;
                    }
                }
                private class Handle_StsClient
                {
                    TcpClient Socket_Client;
                    DataReceived _Delegate;

                    // Serialiser Deserialiser
                    BinaryFormatter Formatter = new BinaryFormatter();
                    BinaryFormatter Deserializer = new BinaryFormatter();

                    // Class
                    XComm.Sample.Message _Message;
                    public void RespondClient(TcpClient Socket_Client, DataReceived EventHandler)
                    {
                        this._Delegate = EventHandler;
                        this.Socket_Client = Socket_Client;

                        /*
                        Thread ctThread = new Thread(RespondClientRequest);
                        ctThread.Priority = ThreadPriority.AboveNormal;
                        ctThread.Start();
                        */


                        Task Task_Client = new Task(RespondClientRequest);
                        Task_Client.Start();

                        //Task.Factory.StartNew(RespondClientRequest);

                    }

                    private void RespondClientRequest()
                    {
                        NetworkStream Stream_network;
                        try
                        {
                            Stream_network = Socket_Client.GetStream();

                            while (Socket_Client.Connected == true && _StopServer == false)
                            {
                                _Message = (XComm.Sample.Message)Formatter.Deserialize(Stream_network);



                                ////////////////////////////////////////////////////////////////////////////////
                                _Delegate.Invoke(_Message);

                         /*       if (_Message.UserName == "Jay")
                                {
                                    _Message.UserName = "Ok";
                                    Formatter.Serialize(Stream_network, _Message);
                                }
                                else
                                {
                                    _Message.UserName = "Rejected";*/
                                    Formatter.Serialize(Stream_network, _Message);
                                //}


                                ////////////////////////////////////////////////////////////////////////////////
                            }
                        }
                        catch (System.Exception)
                        {
                            //throw;
                        }
                    }
                }
            }
            public class LocalClient
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                TcpClient Client;
                NetworkStream Stream_Network;

                XComm.Sample.Message _Message = new XComm.Sample.Message();

                public void Connect(string IPAddress, int Port)
                {
                    try
                    {
                        Client = new TcpClient(IPAddress, Port);
                        Stream_Network = Client.GetStream();
                        
                    }
                    catch (System.Exception)
                    {
                        if (true) { }
                    }
                }

                public bool Send(XComm.Sample.Message _Data)
                {
                    _Message = _Data;
                    Formatter.Serialize(Stream_Network, _Message);
                    _Message = (XComm.Sample.Message)Formatter.Deserialize(Stream_Network);
                 /*   if (_Message.UserName == "Ok")
                    {
                        return true;
                    }*/
                    return false;
                }

                public void Close()
                {
                    Stream_Network.Close();
                    Client.Close();
                }
            }
        }
    }
}
