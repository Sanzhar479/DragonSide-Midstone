using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private TileMap<PathNode> tileMap;
    public int x;
    public int y;
    public int gCost;
    public int hCost;
    public int fCost;
    public bool isWalkable;
    public PathNode cameFromNode;
    public PathNode(TileMap<PathNode> tileMap_, int x_, int y_)
    {
        tileMap = tileMap_;
        x = x_;
        y = y_;
        isWalkable = true;
    }
    public void CalculateFCost()
    {
        fCost = hCost + gCost;
    }
    public void SetIsWalkable(bool walkable)
    {
        isWalkable = walkable;
    }
}
