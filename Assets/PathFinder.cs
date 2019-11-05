using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2, Waypoint> grid = new Dictionary<Vector2, Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        SetColorStartAndEnd();
        LoadBlocks();
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
            Vector2 coordinates = waypoint.GetWaypointPosition();

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
