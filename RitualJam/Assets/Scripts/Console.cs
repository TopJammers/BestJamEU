using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Console : MonoBehaviour {
	public Text consoleText;
	private string command;
	public GameObject player;
    public GameObject PlayerManager;

	// Use this for initialization
	void Start () {
		command = "";
	}
	
	// Update is called once per frame
	void Update () {
		foreach (char c in Input.inputString) {
			if (c == "\b"[0]) {
				// User wants to delete
				if (consoleText.text.Length > 0) {
					consoleText.text = consoleText.text.Substring(0, consoleText.text.Length - 1);
					command = command.Substring(0, consoleText.text.Length - 1);
				}
			} else {
				if (c == "\n"[0] || c == "\r"[0]) {
					// User entered command
					Debug.Log("User entered: " + command);
					ExecUserCommand();
					command = "";
					consoleText.text = "";
				} else {
					command += c;
					consoleText.text += c;
				}
			}
		}
	}

	void ExecUserCommand () {
		switch (command.ToLower()) {
		case "up":
                PlayerManager.GetComponent<GridMove>().isMoving = false;
                PlayerManager.GetComponent<GridMove>().setComponents(new Vector2(0, 1));
               
			break;
		//case "down":
			//player.GetComponent<PlayerController>().MoveDown();
			//break;
		case "left":
                PlayerManager.GetComponent<GridMove>().isMoving = false;
                PlayerManager.GetComponent<GridMove>().setComponents(new Vector2(-1, 0));
               
                break;
		case "right":
                PlayerManager.GetComponent<GridMove>().isMoving = false;
                PlayerManager.GetComponent<GridMove>().setComponents(new Vector2(1, 0));
               
                break;
		case "stop":
                PlayerManager.GetComponent<GridMove>().isMoving = true;
                PlayerManager.GetComponent<GridMove>().setComponents(new Vector2(0, 0));
               
                break;
		}
	}
}