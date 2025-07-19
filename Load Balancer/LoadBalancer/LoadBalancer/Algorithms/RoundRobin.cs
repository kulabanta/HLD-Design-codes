using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer.Algorithms
{
    public class RoundRobin
    {
        public List<string> Servers;
        private int currentIndex;

        public RoundRobin(List<string> Servers)
        {
            this.Servers = Servers;
            this.currentIndex = -1;
        }

        public string GetNextServer()
        {
            currentIndex = (currentIndex + 1) % Servers.Count;
            return Servers[currentIndex];
        }

    }
}
