using UnityEngine;
using System.Collections;

public class LightToggle : MonoBehaviour {

    private Light light1;
    private Vector3 pos_player;
    private Vector3 pos_light;
    private float distance;

	// Use this for initialization
	void Start () {
        light1 = GetComponent<Light>();





    }

    // Update is called once per frame
    void Update () {
        //Couldn't figure out how to initialize the player reference without using var keyword
        //keeping the reference this way for now until I find a more elegant solution.
        var playerObject = GameObject.Find("Player");

        //get the positions of the player object and light object.
        pos_player = playerObject.transform.position;
        pos_light = light1.transform.position;


        //Debug.Log("Distance to other: " + distance);

        //calculate the distance from player to light
        distance = Vector3.Distance(pos_player, pos_light);

        //If within distance of light, then
        if (distance <= 3.0)
        {
            // If player presses "E", enable light;
            //Possible implementation: Light turns decreases in intensity over time and eventually turns off if untouched.
            if (Input.GetKeyUp(KeyCode.E))
            {
                light1.enabled = !light1.enabled;
            }
        }
	}
    void PlayerWithinRadius(float dist)
    {
        //using  distance = Vector3.Distance(pos_player, pos_light);
        //it will allow us to flag the player to be hidden/non-hidden;
        if (dist < 10)
        {
            //flag player visible
        }
        else
        {
            //flag invisible
        }

    }

}
