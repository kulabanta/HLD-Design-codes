using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer.Algorithms
{
    public class LeastResponseTime
    {
        Dictionary<string, double> responseTime;
        public LeastResponseTime(List<string> servers)
        {
           responseTime = new Dictionary<string, double>();
            foreach (string server in servers)
            {
                responseTime.Add(server, 0);
            }
        }
        public string GetNextServer()
        {
            var pair = responseTime.MinBy(r => r.Value);
            return pair.Key;
        }
        public void UpdateResponseTime(string server , double time)
        {
            responseTime[server] = time;
        }
    }
}
