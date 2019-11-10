using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    PathFinder pathFinder;
    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        StartCoroutine(FollowPath());
    }
 
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in pathFinder.GetPath())
        {
            gameObject.transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
