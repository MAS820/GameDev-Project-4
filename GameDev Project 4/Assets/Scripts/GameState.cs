using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour {

	private float TimeRemaining;
	public Text countDown;

	// Use this for initialization
	void Start () {
		TimeRemaining = 100.0f;
		countDown.text = TimeRemaining.ToString ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		TimeRemaining -= Time.deltaTime; 
		countDown.text = ((int)TimeRemaining).ToString ();
	}
}
