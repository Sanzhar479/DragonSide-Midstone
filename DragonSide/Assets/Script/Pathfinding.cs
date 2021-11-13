using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pathfinding 
{
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGNAL_COST = 14;
    private TileMap<PathNode> tileMap;
    private List<PathNode> openList;
    private List<PathNode> closeList;

    //public static Pathfinding Instance { get; private set; }
    public Pathfinding(Vector3 center_, int width_, int height_)
    {
        tileMap = new TileMap<PathNode>(center_, width_, height_, 1f, (TileMap<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }
    public TileMap<PathNode> GetTileMap()
    {
        return tileMap;
    }
    public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
    {
        PathNode startNode = tileMap.GetValue(startX, startY);
        PathNode endNode = tileMap.GetValue(endX, endY);
        openList = new List<PathNode> { startNode };
        closeList = new List<PathNode>();
        for (int i = 0; i < tileMap.GetWidth(); i++)
        {
            for (int j = 0; j < tileMap.GetHeigh(); j++)
            {
                PathNode pathNode = tileMap.GetValue(i, j);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }
        startNode.gCost = 0;
        startNode.hCost = CalulateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();
        while (openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
                return CalulatePathNode(endNode);
            openList.Remove(currentNode);
            closeList.Add(currentNode);
            foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
            {
                if (closeList.Contains(neighbourNode)) continue;
                if (!neighbourNode.isWalkable)
                {
                    closeList.Add(neighbourNode);
                    continue;
                }
                int tentativeGCost = currentNode.gCost + CalulateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalulateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }
        return null;
    }
    private List<PathNode> CalulatePathNode(PathNode endNode_)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode_);
        PathNode currentNode = endNode_;
        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        path.Reverse();
        return path;
    }
    private int CalulateDistanceCost(PathNode a, PathNode b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGNAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }
    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        PathNode lowestFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++)
            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
                lowestFCostNode = pathNodeList[i];
        return lowestFCostNode;
    }
    private List<PathNode> GetNeighbourList(PathNode currentNode)
    {
        List<PathNode> neighbourList = new List<PathNode>();
        if (currentNode.x - 1 >= 0)
        {
            neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y));
            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
            if (currentNode.y + 1 < tileMap.GetHeigh()) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
        }
        if (currentNode.x + 1 < tileMap.GetWidth())
        {
            neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y));
            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
            if (currentNode.y + 1 < tileMap.GetHeigh()) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
        }
        if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x, currentNode.y - 1));
        if (currentNode.y + 1 < tileMap.GetHeigh()) neighbourList.Add(GetNode(currentNode.x, currentNode.y + 1));
        return neighbourList;
    }
    public PathNode GetNode(int x, int y)
    {
        return tileMap.GetValue(new Vector2(x, y));
    }
    public List<Vector2> FindPath(Vector2 startWorldPosition, Vector2 endWorldPosition)
    {
        Debug.Log("+");
        tileMap.GetXY(startWorldPosition, out int startX, out int startY);
        tileMap.GetXY(endWorldPosition, out int endX, out int endY);
        List<PathNode> path = FindPath(startX, startY, endX, endY);
        if (path == null)
        {
            return null;
        }
        else
        {
            List<Vector2> vectorPath = new List<Vector2>();
            foreach (PathNode pathNode in path)
            {
                vectorPath.Add(new Vector2(pathNode.x, pathNode.y) * tileMap.GetSize() + Vector2.one * tileMap.GetSize() / 2);
            }
            return vectorPath;
        }
    }
}
