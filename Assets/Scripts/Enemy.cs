using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int health = 3;
    [SerializeField] float moveSpeed = 2f;

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
            yield return new WaitForSeconds(moveSpeed);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        health--;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
