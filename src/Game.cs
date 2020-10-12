using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class Game
    {
        private readonly Graph _skynet;

        public Game(Graph skynet)
        {
            _skynet = skynet;
        }

        public string FindTargetLink()
        {
            var gateways = _skynet.GetGateways().ToList();
            var paths = new Dictionary<Node, List<Node>>();
            
            foreach (var gateway in gateways)
            {
                var path = GetPathToGateway(gateway);
                paths[gateway] = path;
            }

            Node closestGateway = null;
            var shortestPath = int.MaxValue;

            foreach (var path in paths)
            {
                var pathLength = path.Value.Count;
                if (pathLength < shortestPath)
                {
                    shortestPath = pathLength;
                    closestGateway = path.Key;
                }
            }

            var resultPath = paths[closestGateway];
            var result = $"{resultPath[0].Id} {resultPath[1].Id}";
            _skynet.SeverLink(resultPath);

            return result;
        }

        private List<Node> GetPathToGateway(Node gateway)
        {
            var agentPosition = _skynet.Virus.CurrentPosition;

            var queue = new Queue<Node>();
            queue.Enqueue(agentPosition);

            var map = new Dictionary<Node, Node>();

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (var neighbour in node.Neighbours)
                {
                    if (map.ContainsKey(neighbour))
                        continue;

                    map.Add(neighbour, node);
                    queue.Enqueue(neighbour);
                }
            }

            var path = new List<Node>();
            var current = gateway;

            while (current != agentPosition)
            {
                path.Add(current);
                current = map[current];
            }

            if (path.Count == 1) // if only one element in path then the agent is adjacent to the gateway
                path.Add(current);
            path.Reverse();

            return path;
        }
    }
}
