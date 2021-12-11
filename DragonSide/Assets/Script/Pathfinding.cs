using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used code from https://www.youtube.com/watch?v=alU04hvz6L4&t=1059s
public class Pathfinding 
{
    //cost for diagnal and straight movement
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGNAL_COST = 14;

    private TileMap<PathNode> tileMap;
    //list of nodes that weren't check
    private List<PathNode> openList;
    //list of nodes that were check
    private List<PathNode> closeList;
    //initializing and geting tileMap from the grid in the scene
    public Pathfinding(Grid grid)
    {
        tileMap = grid.GetMap();
    }
    public TileMap<PathNode> GetTileMap()
    {
        return tileMap;
    }
    //find path using coordinates
    public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
    {
        //get node's value
        PathNode startNode = tileMap.GetValue(startX, startY);
        PathNode endNode = tileMap.GetValue(endX, endY);
        //check if there are startNode and endNode on the map
        if (startNode == null || endNode == null)
        {
            return null;
        }
        //initializing open and close list
        //adding start node as checked node
        openList = new List<PathNode> { startNode };
        closeList = new List<PathNode>();
        for (int i = 0; i < tileMap.GetWidth(); i++)
        {
            for (int j = 0; j < tileMap.GetHeigh(); j++)
            {
                //initializing g cost and f cost for each pathnode to max and cleaning all previous information
                PathNode pathNode = tileMap.GetValue(i, j);
                pathNode.gCost = 9999999;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }
        //initializing start node
        startNode.gCost = 0;
        //getting the clossed path cost without walls
        startNode.hCost = CalulateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();
        //do calculations until there are nodes that aren't searched
        while (openList.Count > 0)
        {

            PathNode currentNode = GetLowestFCostNode(openList);
            //if the target was reached then return the list that we gonna get
            if (currentNode == endNode)
            {
                return CalulatePathNode(endNode);
            }
            //put current node as the checked one
            openList.Remove(currentNode);
            closeList.Add(currentNode);
            //checking the cost for each neighbour
            foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
            {
                //if this neighbour was already checked swich to checking another one
                if (closeList.Contains(neighbourNode)) continue;
                //if you can't walk on this node add it to closed list and switch to another one
                if (!neighbourNode.isWalkable)
                {
                    closeList.Add(neighbourNode);
                    continue;
                }

                //theoretical g cost from current node
                int tentativeGCost = currentNode.gCost + CalulateDistanceCost(currentNode, neighbourNode);
                //if this cost is lower then neighbour's cost check the neighbour again
                if (tentativeGCost < neighbourNode.gCost)
                {
                    //getting this cost as actual cost
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
    //when we find the past to end node then go from it backwards to the origin
    private List<PathNode> CalulatePathNode(PathNode endNode_)
    {
        //initialization
        List<PathNode> path = new List<PathNode>();
        //first we need to add the last node and then adding nodes that were before
        path.Add(endNode_);
        PathNode currentNode = endNode_;
        //keep adding nodes until there is nothing to add
        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        //change the order of node, first the last and otherwise
        path.Reverse();
        return path;
    }
    //calculate closest path without walls
    private int CalulateDistanceCost(PathNode a, PathNode b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGNAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }
    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        //first we initialize lowwestFCostNode
        PathNode lowestFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++)
            //comparing the lowest node cost that we had and current fCost
            //if currrent is lower set it as lowest
            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
                lowestFCostNode = pathNodeList[i];
        return lowestFCostNode;
    }
    //finding neighbours of the current node
    private List<PathNode> GetNeighbourList(PathNode currentNode)
    {
        List<PathNode> neighbourList = new List<PathNode>();

        if (currentNode.x - 1 >= 0)
        {
            // Left
            neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y));
            // Left Down
            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
            // Left Up
            if (currentNode.y + 1 < tileMap.GetHeigh()) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
        }
        if (currentNode.x + 1 < tileMap.GetWidth())
        {
            // Right
            neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y));
            // Right Down
            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
            // Right Up
            if (currentNode.y + 1 < tileMap.GetHeigh()) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
        }
        // Down
        if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x, currentNode.y - 1));
        // Up
        if (currentNode.y + 1 < tileMap.GetHeigh()) neighbourList.Add(GetNode(currentNode.x, currentNode.y + 1));

        return neighbourList;
    }
    public PathNode GetNode(int x, int y)
    {
        return tileMap.GetValue(x,y);
    }
    public List<Vector3> FindPath(Vector3 startWorldPosition, Vector3 endWorldPosition)
    {
        tileMap.GetXY(startWorldPosition, out int startX, out int startY);
        tileMap.GetXY(endWorldPosition, out int endX, out int endY);
        List<PathNode> path = FindPath(startX, startY, endX, endY);
        if (path == null)
        {
            return null;
        }
        else
        {
            //convert path to actual position
            List<Vector3> vectorPath = new List<Vector3>();
            foreach (PathNode pathNode in path)
            {
                vectorPath.Add((tileMap.GetWorldPosition(pathNode.x, pathNode.y)) + Vector2.one * tileMap.GetSize() / 2);
            }
            return vectorPath;
        }
    }
}
