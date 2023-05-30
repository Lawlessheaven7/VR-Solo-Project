using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform waypoints;
    //public int waypointIndex;
    public Vector3 target;
    [Header("Set Speed of this enemy")]
    public float minSpeed;
    public float maxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("Waypoint1").transform;
        agent = GetComponent<NavMeshAgent>();
        updateDestination();
        agent.speed = Random.Range(minSpeed, maxSpeed);

 
    }

    // Update is called once per frame
    void Update()
    {
        
        updateDestination();

    }

    void updateDestination()
    {
        target = waypoints.position;
        agent.SetDestination(target);
    }

    /*void nextWaypoint()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }*/
}
