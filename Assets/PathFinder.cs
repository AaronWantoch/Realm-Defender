using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
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

    // Start is called before the first frame update
    void Start()
    {
        if(isRunning)
        {
            SetColorStartAndEnd();
            LoadBlocks();
            PathFind();
        }
        
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count>0 && isRunning)
        {
           searchCenter = queue.Dequeue();
            print("Searching from " + searchCenter);

            searchCenter.SetTopColor(Color.red);
            searchCenter.isExplored = true;

            IsEndWaypointFound();
            ExploreNeighbours();
        }
    }

    private void IsEndWaypointFound()
    {
        if (searchCenter == endWaypoint)
        {
            Waypoint waypoint = searchCenter;
            while (waypoint.previusWaypoint != null)
            {
                print(waypoint);
                waypoint.SetTopColor(Color.yellow);
                waypoint = waypoint.previusWaypoint;
            }
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) return;
        foreach(Vector2Int direction in directions)
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
                neighbour.SetTopColor(Color.blue);
                print("Exploring " + neighbour);
                queue.Enqueue(neighbour);

                neighbour.isExplored = true;
                neighbour.previusWaypoint = searchCenter;
            }
        }
    }

    private void SetColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.yellow);
        endWaypoint.SetTopColor(Color.cyan);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
