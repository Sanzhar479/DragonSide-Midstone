using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathNode
{
    private TileMap<PathNode> tileMap;
    public int x;
    public int y;
    //walking cost from the start node
    //g cost increases
    public int gCost;
    //straight cost without walls
    //h cost decreases
    public int hCost;
    //sum of both
    public int fCost;
    public bool isWalkable;
    //last node
    public PathNode cameFromNode;
    //result of collision to check if a collider blocks the node
    private readonly Collider2D[] interactionResult = new Collider2D[5];
    //initialization(in grid when initializing tile map)
    public PathNode(TileMap<PathNode> tileMap_, int x_, int y_, string[] tags_, LayerMask mask_)
    {
        tileMap = tileMap_;
        x = x_;
        y = y_;
        isWalkable = getStatus(tags_, mask_);
    }
    public void CalculateFCost()
    {
        fCost = hCost + gCost;
    }
    //check if node is lokated in collider(in this project "Ground")
    private bool getStatus(string[] tags, LayerMask mask)
    {
        //places a point in the node and gets overlap results with the layer
        var size = Physics2D.OverlapPointNonAlloc(
            tileMap.GetWorldPosition(x, y),
            interactionResult,
            mask);
        //it checks if any of the results has the tag("Ground")
        for (var i = 0; i < size; i++)
        {
            var overlapResult = interactionResult[i];
            var isInTags = tags.Any(tag => overlapResult.CompareTag(tag));
            if (isInTags)
            {
                return false;
            }
            else return true;
        }
        return true;
    }
    //set the value
    public void SetIsWalkable(bool walkable)
    {
        isWalkable = walkable;
    }
}
