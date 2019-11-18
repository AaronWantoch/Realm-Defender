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
            Tower lastTower = towers.Dequeue();
            lastTower.towerWaypoint.isPlaceable = true;
            Destroy(lastTower.gameObject);
        }

        Tower newTower = Instantiate(tower, waypoint.transform.position, 
            Quaternion.identity, this.transform);

        waypoint.isPlaceable = false;
        newTower.towerWaypoint = waypoint;
        towers.Enqueue(newTower);
    }
}
