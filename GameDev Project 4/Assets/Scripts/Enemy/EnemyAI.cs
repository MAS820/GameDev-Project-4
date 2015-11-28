using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    //Editables //some variables will be used later for animation and navigational mesh
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;

    public Vector3[] patrolWayPoints;
    public GameObject[] wayPoints;

    public Vector3 waypoint;
    private EnemySight enemySight;
    private NavMeshAgent nav;
    private GameObject player;
    private GameObject enemy;

    private int wayPointIndex;
	// Use this for initialization
	void Start () {
        //Field of View Script / Player Detection
        enemySight = GetComponent<EnemySight>();
        
        //Nav Mesh agent sets up the mesh that our characters can move on.
        nav = GetComponent<NavMeshAgent>();
        
        //autobraking causes the character to pause before each waypoint
        nav.autoBraking = false;
        
        //char references
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");

        //Set the first waypoint
        wayPointIndex = 0;
        //Get the list of waypoint objects.
        wayPoints = GameObject.FindGameObjectsWithTag("CyclopsWaypoint");


    }

    // Update is called once per frame
    void Patrolling()
    {
        //Get the position of the first waypoint
        waypoint = wayPoints[wayPointIndex].transform.position;
        
        //Point the enemy at that waypoint
        transform.LookAt(waypoint);

        //Move enemy towards the point
        transform.position += transform.TransformDirection(Vector3.forward) * patrolSpeed * Time.deltaTime;
        Debug.Log(wayPointIndex);

        //IF enemy is close to point, begin to move to next point
        float distance = Vector3.Distance(waypoint, enemy.transform.position);
        if (distance <= 3)
        {
            //If we reach the end of the list, start over
            if (wayPointIndex == wayPoints.Length - 1)
            {
                wayPointIndex = 0;
            }
            //Otherwise, we go through the list.
            else {
                wayPointIndex++;
            }
        }
    }
   
    void Update()
    {
        Patrolling();

    }

}

