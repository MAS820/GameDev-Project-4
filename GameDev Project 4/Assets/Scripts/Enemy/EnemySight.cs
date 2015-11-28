using UnityEngine;
using System.Collections;
//Still working on this one, will clean up.
public class EnemySight : MonoBehaviour {
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 playerLastSeen;
    public bool gameOver;

    Light currentLight;
    private NavMeshAgent nav;
    private CapsuleCollider col;
    private Animator anim;
    private GameObject player;
    private GameObject enemy;
    private Animator playerAnim;
    private Vector3 previousSighting;
    

    // Use this for initialization
    void Start () {
        gameOver = false;
        //nav = GetComponent<NavMeshAgent>();
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");


	
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
        }
        	
	}
    void OnTriggerStay (Collider other)
    {
        if (other.gameObject == player)
        {
            playerInSight = false;
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            if (angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.gameObject == player)
                    {
                        //player is seen
                        playerInSight = true;
                       // enemy.transform.position = player.transform.position;
                        previousSighting = player.transform.position;
                    }
                }
            }
        }
       /* else if (other.gameObject.CompareTag("Lamps") == true )
        {
            other.gameObject.GetComponent<Light>().enabled = false;

        }*/
    }
    void OnTriggerExit (Collider other)
    {
        if (other.gameObject == player)
        {
            playerInSight = false;
        }
    }
}
