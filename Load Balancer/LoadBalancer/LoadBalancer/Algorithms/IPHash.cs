namespace LoadBalancer.Algorithms
{
    public class IPHash
    {
        List<string> Servers;
        public IPHash(List<string> Servers)
        {
            this.Servers = Servers;
        }

        public string GetNextServer(int serverIp)
        {
            int serverIndex = GetHash(serverIp) % Servers.Count;
            return Servers[serverIndex];
        }
        private int GetHash(int serverIp)
        {
            int hash = 0; 
            while(serverIp>0)
            {
                hash += serverIp % 10;
                serverIp /= 10;
            }
            return hash;
        }
    }
}
