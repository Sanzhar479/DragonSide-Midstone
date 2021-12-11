using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private TileMap<PathNode> tileMap;
    [SerializeField] private int width, height, size;
    [SerializeField] private Transform origin;
    [SerializeField] private string[] tags;
    [SerializeField] private LayerMask mask;
    public TileMap<PathNode> GetMap()
    {
        return tileMap;
    }
    [ContextMenu("Create")]
    public void Awake()
    {
        tileMap = new TileMap<PathNode>(origin.position, width, height, size, (TileMap<PathNode> g, int x, int y) => new PathNode(g, x, y, tags, mask));
    }
}
