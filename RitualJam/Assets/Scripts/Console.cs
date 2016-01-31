using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Console : MonoBehaviour {
	public Text consoleText;
	public Text consoleText_1;
	public Text consoleText_2;
	public Text promptText;
	public GameObject player;
    public GameObject twitchListener;
	public GameObject menuManager;
	public GameObject gameManager;
	public int flickerTime;
	public string prompt;
	public bool controlRemoto;

	private string command;
	private int time;
	private bool promptShown;
    private TwitchListener remoteConsole;

    private Vector2 movementVector;
    private string activeCommand;

	// Use this for initialization
	void Start () {
		command = "";
		promptText.text = prompt;
		consoleText.text = "";
		consoleText_1.text = "";
		consoleText_2.text = "";
		time = 0;
		promptShown = false;
        Vector2 movementVector=new Vector2(0,0);
        activeCommand = "stop";
    	remoteConsole = twitchListener.GetComponent<TwitchListener>();
		//controlRemoto = menuManager.GetComponent<SettingsManager>().IsStreamingModeOn();
		if (controlRemoto) {
			InvokeRepeating("ReadTwitchCommand", 0, 1);
		}
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
		if (!controlRemoto) {
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
						command = "";
						consoleText.text = "";
					} else {
						command += c;
						if ((promptShown) && (consoleText.text.Length > 0)) {
							consoleText.text = consoleText.text.Substring(0, consoleText.text.Length - 1);
							consoleText.text += c;
							consoleText.text += "-";
						} else {
							consoleText.text += c;
						}
					}
				}
			}
		}
	}

	void ExecUserCommand () {
		bool correcto;

		correcto = true;

         switch (command.ToLower())
        {
		    case "up":
                activeCommand = command;
            break;
            case "down":
                activeCommand = command;
            break;
            case "left":
                activeCommand = command;
            break;
            case "right":
                activeCommand = command;
            break;
            case "stop":
                activeCommand = command;
            break;
            default:
            	correcto = false;
				gameManager.GetComponent<GameManager>().PlayWrongCommandSound();
                break;
        }
    
		if (correcto) {
			ManagePreviousCommands();
		}
	}

	void FlickerChange () {
		promptShown = !promptShown;
		FlickerUpdate();
	}

	void FlickerUpdate () {
		if (promptShown) {
			consoleText.text += "-";
		} else if (consoleText.text.Length > 0) {
			consoleText.text = consoleText.text.Substring(0, consoleText.text.Length - 1);
		}
	}

	void ManagePreviousCommands () {
		consoleText_2.text = consoleText_1.text;
		consoleText_1.text = command;
		FlickerUpdate();
	}

	void ReadTwitchCommand () {
        // Leer el comando de Twitch y almacenarlo en command
        command = remoteConsole.getCommand();
		ExecUserCommand();
	}

    public string getActiveCommand()
    {
        return activeCommand;
    }
}