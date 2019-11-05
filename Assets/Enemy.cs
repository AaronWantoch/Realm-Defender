using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {
            gameObject.transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
            print("Visiting " + waypoint.name);
        }
        print("Patrol Ended");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
