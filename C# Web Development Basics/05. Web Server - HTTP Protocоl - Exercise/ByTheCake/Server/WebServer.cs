﻿namespace ByTheCake.Server
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using Contracts;
    using Routing;
    using Routing.Contracts;

    public class WebServer : IRunnable
    {
        private const string LocalHostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly IServerRouteConfig serverRouteConfig;

        private readonly TcpListener tcpListener;

        private bool isRunning;

        public WebServer(int port, IAppRouteConfig appRouteConfig)
        {
            this.port = port;
            this.tcpListener = new TcpListener(IPAddress.Parse(LocalHostIpAddress), port);

            this.serverRouteConfig = new ServerRouteConfig(appRouteConfig);
        }

        public void Run()
        {
            this.tcpListener.Start();

            this.isRunning = true;

            Console.WriteLine($"Server started. Listening to TCP clients at {LocalHostIpAddress}:{this.port}");

            Task task = Task.Run(this.ListenLoop);
            task.Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                Socket client = await this.tcpListener.AcceptSocketAsync();
                ConnectionHandler connectionHandler = new ConnectionHandler(client, this.serverRouteConfig);
                await connectionHandler.ProcessRequestAsync();
            }
        }
    }
}