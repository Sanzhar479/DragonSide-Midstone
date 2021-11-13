using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Pathfinding pathFinding;
    [SerializeField] private Vector3 center;
    [SerializeField] private int width, height;
    public Pathfinding GetMap()
    {
        return pathFinding;
    }
    private void Start()
    {
        pathFinding = new Pathfinding(center, width, height);
    }
    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        pathFinding.GetTileMap().GetXY(mouseWorldPosition, out int x, out int y);
    //        List<PathNode> path = pathFinding.FindPath(0, 0, x, y);
    //        if (path != null)
    //        {
    //            for (int i = 0; i < path.Count - 1; i++)
    //            {
    //                Debug.DrawLine(new Vector2(path[i].x, path[i].y), new Vector2(path[i + 1].x, path[i + 1].y), Color.green);
    //            }
    //        }
    //    }
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        Vector2 mouseWorldPosition = Camera.current.ScreenToWorldPoint(Input.mousePosition);
    //        pathFinding.GetTileMap().GetXY(mouseWorldPosition, out int x, out int y);
    //        pathFinding.GetNode(x, y).SetIsWalkable(!pathFinding.GetNode(x, y).isWalkable);
    //    }
    //}
}
