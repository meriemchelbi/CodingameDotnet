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
            var agentPosition = _skynet.Virus.CurrentPosition;
            var gateway = _skynet.Nodes.FirstOrDefault(n => n.IsGateway);

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

            var result = $"{path[0].Id} {path[1].Id}";

            return result;
        }
    }
}
