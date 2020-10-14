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
                
                if (gatewayLink.IsSevered)
                    continue;

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

            _skynet.GetLink(resultOriginId, resultDestinationId).IsSevered = true;

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

                    var linkToNeighbour = _skynet.GetLink(node.Id, neighbour.Id);
                    if (!linkToNeighbour.IsSevered)
                    {
                        map.Add(neighbour, linkToNeighbour);
                        queue.Enqueue(neighbour);
                    }
                    else
                        continue;
                }
            }

            var path = new List<Node>();
            var current = gateway;

            while (current != agentPosition)
            {
                if (map[current].IsSevered)
                {
                    current = map[current].Origin == current
                        ? map[current].Destination
                        : map[current].Origin;
                    continue;
                }
                else
                {
                    path.Add(current);
                    current = map[current].Origin == current
                        ? map[current].Destination
                        : map[current].Origin;
                }
            }

            if (path.Count == 1) // if only one element in path then the agent is adjacent to the gateway
                path.Add(current);
            path.Reverse();

            return path;
        }
    }
}
