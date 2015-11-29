using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour {

	private float TimeRemaining;
	public Text countDown;
    public Image staminaBorder;
    public Image staminaBackground;
    public Image staminaBar;
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
		TimeRemaining = 100.0f;
		countDown.text = TimeRemaining.ToString ();
        staminaBorder.rectTransform.sizeDelta = new Vector2(playerController.staminaMax + 10, 50);
        staminaBackground.rectTransform.sizeDelta = new Vector2(playerController.staminaMax, 40);
        staminaBar.rectTransform.sizeDelta = new Vector2(playerController.stamina, 40);
    }
	
	// Update is called once per frame
	void Update () {
		TimeRemaining -= Time.deltaTime; 
		countDown.text = ((int)TimeRemaining).ToString ();
        staminaBar.rectTransform.sizeDelta = new Vector2(playerController.stamina, 40);
    }
}
