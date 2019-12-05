using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public bool isPlaceable = true;
    public bool isEnemyOn = false;

    public Waypoint previusWaypoint;

    [SerializeField] const int gridSize = 11;

    Vector2Int waypointPosition;

    private void Start()
    {
        
        
    }

    public Vector2Int GetWaypointPosition()
    {
        waypointPosition = new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
        return waypointPosition;
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable && Time.timeScale > Mathf.Epsilon)
        {
            FindObjectOfType<TowerFactory>().PlaceTower(this);
        }
    }
}
