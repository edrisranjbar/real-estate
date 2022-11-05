using System.Net;
using System.Net.NetworkInformation;

namespace Real_Estate
{
    class Netchecker
    {
        public bool CheckForInternetConnection()
        {
            /*try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            */
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("8.8.8.8", 600);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
