using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
//used code from https://www.youtube.com/watch?v=alU04hvz6L4&t=1059s
//In tileMap you can add any class or variable type like boolean or string
//but in this project we use PathNode 
public class TileMap<TGridObject>
{
    //tile map has an origin(it is located at the bottom left corner of tileMap),
    //how many rows and colums it should have, size for nodes and the list of all nodes with the coordinates
    private Vector2 origin;
    private int width, heigh;
    private float size;
    private TGridObject[,] nodes;
    //this code initializes all the variables in Grid
    public TileMap(Vector2 origin_, int width_, int heigh_, float size_, Func<TileMap<TGridObject>, int, int, TGridObject> createTileMapObject)
    {
        origin = origin_;
        width = width_;
        heigh = heigh_;
        size = size_;
        nodes = new TGridObject[width, heigh];
        //this part of code visualizes the map
        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            for (int j = 0; j < nodes.GetLength(1); j++)
            {
                //this one initiazes the node
                nodes[i, j] = createTileMapObject(this, i, j);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.white, 100);
            }
            Debug.DrawLine(GetWorldPosition(0, heigh), GetWorldPosition(width, heigh), Color.white, 100);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, heigh), Color.white, 100);
        }
    }
    //each node has its coordinates and this function converts the coordinate into position
    public Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(x, y) * size + origin;
    }
    //setting any value depending on their type of variable
    private void SetValue(Vector2 worldPosition, TGridObject value)
    {
        int i, j;
        GetXY(worldPosition, out i, out j);
        SetValue(i, j, value);
    }
    private void SetValue(int i, int j, TGridObject value)
    {
        if (i < width && j < heigh && i >= 0 && j >= 0)
        nodes[i, j] = value;
    }
    //it converts worlds position to coordinate if is there
    public void GetXY(Vector2 worldPosition, out int i, out int j)
    {
        i = Mathf.FloorToInt((worldPosition - origin).x / size);
        j = Mathf.FloorToInt((worldPosition - origin).y / size);
    }
    //get status or value of the node both based on coordinates annd position
    public TGridObject GetValue(int i, int j)
    {
        //the coordinate have to be in the range otherwise return any defalt value
        if (i < width && j < heigh && i >= 0 && j >= 0)
            return nodes[i, j];
        else return default(TGridObject);
    }
    public TGridObject GetValue(Vector2 worldPosition)
    {
        int i, j;
        GetXY(worldPosition, out i, out j);
        return GetValue(i, j);
    }
    public int GetWidth()
    {
        return width;
    }
    public int GetHeigh()
    {
        return heigh;
    }
    public float GetSize()
    {
        return size;
    }
}
