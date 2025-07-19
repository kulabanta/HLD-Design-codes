namespace LoadBalancer.Algorithms
{
    public class WeightedRoundRobin
    {
        List<string> Servers;
        List<int> Weights;
        int currentIndex;
        int currentWeight;
        public WeightedRoundRobin(List<string> Servers,List<int> Weights)
        {
            this.Servers = Servers;
            this.Weights = Weights;
            this.currentIndex = -1;
        }

        public string GetNextServer()
        {
            while (true)
            {
                this.currentIndex = (this.currentIndex + 1) % Servers.Count;
                if (this.currentIndex == 0)
                {
                    this.currentWeight--;
                    if (this.currentWeight <= 0)
                    {
                        this.currentWeight = Weights.Max();
                    }
                }
                if (Weights[this.currentIndex]>this.currentWeight)
                       return this.Servers[this.currentIndex];
            }
        }
    }
}
