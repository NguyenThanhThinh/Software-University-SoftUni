namespace WebServer.Server
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Handlers;
    using HTTP;
    using HTTP.Contracts;
    using Routing.Contracts;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            string request = await this.ReadRequest();

            IHttpContext httpContext = new HttpContext(request);

            IHttpResponse httpResponse = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

            ArraySegment<byte> toBytes = new ArraySegment<byte>(Encoding.UTF8.GetBytes(httpResponse.ToString()));

            await this.client.SendAsync(toBytes, SocketFlags.None);

            Console.WriteLine(request);
            Console.WriteLine(httpResponse.ToString());

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadRequest()
        {
            StringBuilder request = new StringBuilder();

            ArraySegment<byte> data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None);

                if (numBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.ASCII.GetString(data.Array, 0, numBytesRead);
                request.Append(bytesAsString);

                if (numBytesRead < 1024)
                {
                    break;
                }
            }

            return request.ToString();
        }
    }
}