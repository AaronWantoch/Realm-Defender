using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();

    Waypoint searchCenter;
    
    bool isRunning = true;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    [SerializeField] Waypoint startWaypoint, endWaypoint;

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count>0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;

            CreatePath();
            ExploreNeighbours();
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) return;
        foreach (Vector2Int direction in directions)
        {
            AddToQueue(direction);
        }
    }

    

    private void AddToQueue(Vector2Int direction)
    {
        Vector2Int neighbourCoordinates = direction + searchCenter.GetWaypointPosition();
        if (grid.ContainsKey(neighbourCoordinates))
        {
            Waypoint neighbour = grid[neighbourCoordinates];

            if (!neighbour.isExplored)
            {
                queue.Enqueue(neighbour);

                neighbour.isExplored = true;
                neighbour.previusWaypoint = searchCenter;
            }
        }
    }

    private void CreatePath()
    {
        if (searchCenter == endWaypoint)
        {
            Waypoint waypoint = searchCenter;
            while (waypoint.previusWaypoint != null)
            {
                path.Add(waypoint);
                waypoint = waypoint.previusWaypoint;
            }
            path.Add(startWaypoint);
            path.Reverse();

            isRunning = false;
        }
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = GetComponentsInChildren<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int coordinates = waypoint.GetWaypointPosition();

            if (grid.ContainsKey(coordinates))
            {
                Debug.LogWarning("Overlaping " + waypoint.name);
            }
            else
            {
                grid.Add(coordinates, waypoint);
            }
        }
    }

    public List<Waypoint> GetPath()
    {
        if (isRunning)
        {
            LoadBlocks();
            PathFind();
        }

        return path;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
