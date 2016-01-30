using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Console : MonoBehaviour {
	public Text consoleText;
	public Text consoleText_1;
	public Text consoleText_2;
	public Text promptText;
	public GameObject player;
	public int flickerTime;
	public string prompt;

	private string command;
	private int time;
	private bool promptShown;

	// Use this for initialization
	void Start () {
		command = "";
		promptText.text = prompt;
		consoleText.text = "";
		consoleText_1.text = "";
		consoleText_2.text = "";
		time = 0;
		promptShown = false;
	}

	void FixedUpdate () {
		if (time >= flickerTime) {
			time = 0;
			FlickerChange();
		} else {
			time++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (char c in Input.inputString) {
			if (c == "\b"[0]) {
				// User wants to delete
				if (command.Length > 0) {
					consoleText.text = consoleText.text.Substring(0, consoleText.text.Length - 1);
					command = command.Substring(0, command.Length - 1);
				}
			} else {
				if (c == "\n"[0] || c == "\r"[0]) {
					// User entered command
					Debug.Log("User entered: " + command);
					ExecUserCommand();
					ManagePreviousCommands();
					command = "";
					consoleText.text = "";
				} else {
					command += c;
					if ((promptShown) && (consoleText.text.Length > 0)) {
						consoleText.text = consoleText.text.Substring(0, consoleText.text.Length - 1);
						consoleText.text += c;
						consoleText.text += "_";
					} else {
						consoleText.text += c;
					}
				}
			}
		}
	}

	void FlickerChange () {
		promptShown = !promptShown;
		FlickerUpdate();
	}

	void FlickerUpdate () {
		if (promptShown) {
			consoleText.text += "_";
		} else if (consoleText.text.Length > 0) {
			consoleText.text = consoleText.text.Substring(0, consoleText.text.Length - 1);
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

	void ManagePreviousCommands () {
		consoleText_2.text = consoleText_1.text;
		consoleText_1.text = command;
		FlickerUpdate();
	}
}