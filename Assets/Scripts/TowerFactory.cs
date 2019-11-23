using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int maxNumberOfTurets = 3;

    [SerializeField] Tower tower;

    Queue<Tower> towers = new Queue<Tower>();

    public void PlaceTower(Waypoint waypoint)
    {
        if (towers.Count >= maxNumberOfTurets)
        {
            MoveLastTower(waypoint);
        }
        else
        {
            InstantiateNewTower(waypoint);
        }

    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        Tower newTower = Instantiate(tower, waypoint.transform.position,
                        Quaternion.identity, this.transform);

        waypoint.isPlaceable = false;
        newTower.towerWaypoint = waypoint;
        towers.Enqueue(newTower);
    }

    private void MoveLastTower(Waypoint waypoint)
    {
        Tower lastTower = towers.Dequeue();

        lastTower.transform.position = waypoint.transform.position;
        lastTower.towerWaypoint.isPlaceable = true;
        lastTower.towerWaypoint = waypoint;

        towers.Enqueue(lastTower);
        waypoint.isPlaceable = false;
    }
}
