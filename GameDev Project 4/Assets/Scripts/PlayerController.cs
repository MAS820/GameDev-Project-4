using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Editable in editor
	public float speed = 3.0f;			//Adjust player walking speed
	public float rotateSpeed = 3.0f;	//Adjust camera rotation speed/sensitivity

	//Local Variables
	private bool isSprinting;
	private bool isCrouching;

	//Might come back and initialize all variables in Start
	void Start() {

	}

	// Update is called once per frame
	void Update () {
	
		CharacterController controller = GetComponent<CharacterController>();

		//Camera controlls
		transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);		//Moving the mouse left and right turns the whole object
		Camera.main.transform.Rotate (-1*Input.GetAxis ("Mouse Y"), 0, 0);	//Moving the mouse up and down only tilts the camera

		//Movement
		Vector3 forward = transform.TransformDirection(Vector3.forward);	//Used to set movement relative to current orientation
		Vector3 right = transform.TransformDirection (Vector3.right);		//Used to set movement relative to current orientation
		float verticalSpeed = Input.GetAxis ("Vertical") * speed;
		float horizontalSpeed = Input.GetAxis ("Horizontal") * speed;
		isSprinting = false;


		//Crouching
		if (Input.GetButtonUp ("Crouch")) {
			if(isCrouching){
				isCrouching = false;
			}else{
				isCrouching = true;
			}	
		}


		//Sprinting															//If left shift is held down 
		if (Input.GetButton ("Sprint") && !isCrouching) {					//and the player is not crouching, they will move twice
			verticalSpeed = verticalSpeed * 2;								//their normal speed and isSprinting = true
			horizontalSpeed = horizontalSpeed * 2;							//otherwise isSprinting = false
			isSprinting = true;
		}


		controller.SimpleMove (forward * verticalSpeed);					//Foward and backward movement
		controller.SimpleMove (right * horizontalSpeed);					//Side to side movement

	}
}
