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
                var gatewayLink = _skynet.GetLink(path.Value[0].Id, path.Value[1].Id);
                
                // if agent is next to the gateway
                if (path.Value[1] == _skynet.Virus.CurrentPosition)
                    return ComputeResult(path.Value);
                
                var pathLength = path.Value.Count;
                if (pathLength <= shortestPath)
                {
                    shortestPath = pathLength;
                    closestGateway = path.Key;
                }
            }

            var resultPath = paths[closestGateway];

            return ComputeResult(resultPath);
        }

        private string ComputeResult(List<Node> path)
        {
            var resultOriginId = path[0].Id;
            var resultDestinationId = path[1].Id;

            var linkToSever = _skynet.GetLink(resultOriginId, resultDestinationId);
            _skynet.SeverLink(linkToSever);

            return $"{resultOriginId} {resultDestinationId}";
        }

        private List<Node> GetPathToGateway(Node gateway)
        {
            var agentPosition = _skynet.Virus.CurrentPosition;

            var queue = new Queue<Node>();
            queue.Enqueue(agentPosition);

            var map = new Dictionary<Node, Link>();

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (var neighbour in node.Neighbours)
                {
                    if (map.ContainsKey(neighbour))
                        continue;

                    else
                    {
                        var linkToNeighbour = _skynet.GetLink(node.Id, neighbour.Id);
                        map.Add(neighbour, linkToNeighbour);
                        queue.Enqueue(neighbour);
                    }
                }
            }

            var path = new List<Node>();
            var current = gateway;

            while (current != agentPosition)
            {
                path.Add(current);
                current = map[current].Origin == current
                    ? map[current].Destination
                    : map[current].Origin;
            }

            if (path.Count == 1) // if only one element in path then the agent is adjacent to the gateway
                path.Add(current);
            path.Reverse();

            return path;
        }
    }
}
