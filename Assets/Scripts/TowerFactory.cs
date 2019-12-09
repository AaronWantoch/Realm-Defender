using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    Tower tower;

    List<Tower> towers = new List<Tower>();
    List<Tower> towerPrefabs = new List<Tower>();

    public void PlaceTower(Waypoint waypoint)
    {
        if (towerPrefabs.Contains(tower))
        {
            MoveTower(waypoint);
        }
        else
        {
            InstantiateNewTower(waypoint);
        }

    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        if (tower != null)
        {
            Tower newTower = Instantiate(tower, waypoint.transform.position,
                             Quaternion.identity, this.transform);

            waypoint.isPlaceable = false;
            newTower.towerWaypoint = waypoint;

            towerPrefabs.Add(tower);
            towers.Add(newTower);
        }
       
    }

    private void MoveTower(Waypoint waypoint)
    {
        int movedTowerIndex = towerPrefabs.IndexOf(tower);
        Tower movedTower = towers[movedTowerIndex];

        movedTower.transform.position = waypoint.transform.position;
        movedTower.towerWaypoint.isPlaceable = true;
        movedTower.towerWaypoint = waypoint;

        waypoint.isPlaceable = false;
    }

    public void SetTypeOfTower(Tower newTower)
    {
        tower = newTower;
    }
}
