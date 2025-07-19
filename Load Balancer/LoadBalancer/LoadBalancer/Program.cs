
using LoadBalancer.Algorithms;

List<string> Servers = new List<string>() {"Server-1","Server-2" ,"Server-3", "Server-4","Server-5"};
List<int> Weights = new List<int>() { 3, 2, 5, 1,3 };
int requestCount = 7;
Console.WriteLine("Load Balancing Algorithms");

Console.WriteLine("Round Robin Algorithm - Start");
Console.WriteLine();
RoundRobin roundRobinLoadBalancing = new(Servers);
for (int i = 1; i <= requestCount; i++)
{
    string server = roundRobinLoadBalancing.GetNextServer();
    Console.WriteLine($"request {i} is assigned to server {server}");
}
Console.WriteLine("Round Robin Algorithm - End");
Console.WriteLine();

Console.WriteLine("Weighted Round Robin Algorithm - Start");
Console.WriteLine();
WeightedRoundRobin weightedRoundRobinLoadBalancing = new(Servers, Weights);
for (int i = 1; i <= requestCount; i++)
{
    string server = weightedRoundRobinLoadBalancing.GetNextServer();
    Console.WriteLine($"request {i} is assigned to server {server}");
}
Console.WriteLine("Weighted Round Robin Algorithm - End");
Console.WriteLine();


Console.WriteLine("Least connection Algorithm - Start");
Console.WriteLine();
LeastConnection leastConnectionLoadBalancing = new(Servers);
Random random = new Random();
Parallel.For(1, requestCount + 1, (i) =>
{
    string server = leastConnectionLoadBalancing.GetNextServer();
    Console.WriteLine($"request {i} is assigned to server {server}");
    Task.Delay(random.Next(1000, 2000));
    leastConnectionLoadBalancing.RemoveConnection(server);
});
Console.WriteLine("Least connection Algorithm - End");
Console.WriteLine();

Console.WriteLine("Least Response time Algorithm - Start");
Console.WriteLine();
LeastResponseTime leastResponseTimeLoadBalancing = new(Servers);
for (int i = 1; i <= requestCount; i++)
{
    string server = leastResponseTimeLoadBalancing.GetNextServer();
    Console.WriteLine($"request {i} is assigned to server {server}");
    var randomValue = random.Next(1000, 2000);
    Task.Delay(randomValue).Wait();
    leastResponseTimeLoadBalancing.UpdateResponseTime(server, randomValue);
}
Console.WriteLine("Least Response time Algorithm - End");
Console.WriteLine();

Console.WriteLine("IP Hash Algorithm - Start");
Console.WriteLine();
IPHash ipHash = new IPHash(Servers);
for (int i = 1; i <= requestCount; i++)
{
    int ipAddress = random.Next(1000, 4000);
    string server = ipHash.GetNextServer(ipAddress);
    Console.WriteLine($"request {i} with IP Address {ipAddress} is assigned to server {server}");
}
Console.WriteLine("IP Hash Algorithm - End");
Console.WriteLine();
