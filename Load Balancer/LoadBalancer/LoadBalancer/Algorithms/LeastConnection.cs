using System.Collections.Concurrent;

namespace LoadBalancer.Algorithms
{
    public class LeastConnection
    {

        ConcurrentDictionary<string, int> connections;
        public LeastConnection(List<string> servers)
        {
            connections = new ConcurrentDictionary<string, int>();
            foreach (var server in servers)
            {
                connections.TryAdd(server, 0);
            }
        }
        public string GetNextServer()
        {
            var pair = connections.MinBy(x => x.Value);
            connections.TryUpdate(pair.Key,pair.Value+1,pair.Value);
            return pair.Key;
        }

        public void RemoveConnection(string server)
        {
            int value = connections[server];
            if (connections[server] <= 0)
                return;
            connections.TryUpdate(server,value-1, value);
        }
    }
}
