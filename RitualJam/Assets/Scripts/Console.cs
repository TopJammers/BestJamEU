using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Console : MonoBehaviour {
	public Text consoleText;
	private string command;
	public GameObject player;

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
			player.GetComponent<PlayerController>().MoveUp();
			break;
		case "down":
			player.GetComponent<PlayerController>().MoveDown();
			break;
		case "left":
			player.GetComponent<PlayerController>().MoveLeft();
			break;
		case "right":
			player.GetComponent<PlayerController>().MoveRight();
			break;
		case "stop":
			player.GetComponent<PlayerController>().Stop();
			break;
		}
	}
}