using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class TileMap<TGridObject>
{
    private Vector2 center;
    private int width, heigh;
    private float size;
    private TGridObject[,] nodes;
    public TileMap(Vector2 center_, int width_, int heigh_, float size_, Func<TileMap<TGridObject>, int, int, TGridObject> createTileMapObject)
    {
        center = center_;
        width = width_;
        heigh = heigh_;
        size = size_;
        nodes = new TGridObject[width, heigh];
        
        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            for (int j = 0; j < nodes.GetLength(1); j++)
            {
                nodes[i, j] = createTileMapObject(this, i, j);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.white, 100);
            }
            Debug.DrawLine(GetWorldPosition(0, heigh), GetWorldPosition(width, heigh), Color.white, 100);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, heigh), Color.white, 100);
        }
    }
    private Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(x, y) * size + center;
    }
    private void SetValue(int i, int j, TGridObject value)
    {
        if (i <= width && j <= heigh && i >= 0 && j >= 0)
        nodes[i, j] = value;
    }
    public void GetXY(Vector2 worldPosition, out int i, out int j)
    {
        i = Mathf.FloorToInt((worldPosition - center).x / size);
        j = Mathf.FloorToInt((worldPosition - center).y / size);
    }
    private void SetValue(Vector2 worldPosition, TGridObject value)
    {
        int i, j;
        GetXY(worldPosition, out i, out j);
        SetValue(i, j, value);
    }
    public TGridObject GetValue(int i, int j)
    {
        if (i <= width && j <= heigh && i >= 0 && j >= 0)
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
