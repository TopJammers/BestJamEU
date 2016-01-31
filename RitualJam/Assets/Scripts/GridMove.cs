using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

class GridMove : MonoBehaviour
{
    public float moveSpeed = 3f; // velocidad
    public float gridSize = 0.5f; // Tamaño del grid
    private enum Orientation // Orientacion del grid
    {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation = Orientation.Horizontal; // Definimos la orientación del grid
    private Vector2 input;
    public bool isMoving = false; // Para moverse hay que activarlo
    private Vector3 startPosition; // Posición de inicio del jugador
    private Vector3 endPosition;
    private float t;
    private float factor;
    public GameObject consolePrefab;
    private Console console;
    private string command;
	private bool isDead;
    Quaternion newRotation;

    Animator anim_player;
    Vector2 moveDirection;
    float angle;

//private string inputCommand;

    void Start()
    {
        console = consolePrefab.GetComponent<Console>();

        anim_player =this.GetComponent<Animator>();

        endPosition = new Vector3(0, 0, 0);

		isDead = false;
        command = "stop";
    }

    public void Update()
    {
		if (!isDead) {
			
	        if (!isMoving) // Para moverse hay que activar el movimiento
	        {

	            // input = new Vector2(componentA, componentB);
	            //input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                string aux= console.getActiveCommand();
                if(aux.ToLower().Equals("exit"))
                {
                    Application.Quit();
                }
                else if(aux.ToLower().Equals("menu"))
                {
                    SceneManager.LoadScene("Menu Scene");
                }

                if (command.ToLower().Equals("up") && !aux.ToLower().Equals("down"))
                {
                    command = aux;
                }
                else if(command.ToLower().Equals("right") && !aux.ToLower().Equals("left"))
                {
                    command = aux;
                }
                else if (command.ToLower().Equals("left") && !aux.ToLower().Equals("right"))
                {
                    command = aux;
                }
                else if (command.ToLower().Equals("down") && !aux.ToLower().Equals("up"))
                {
                    command = aux;
                }
                else if(command.ToLower().Equals("stop"))
                {
                    command = aux;
                }



                if (!command.ToUpper().Equals("STOP"))
	            {
                    
	                setMovement(command);
	                Debug.Log("A moverse");
	                StartCoroutine(move(transform));
	            }
	        }
		}
    }

    public IEnumerator move(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;

       
        
        endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize, startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z); // Establecemos el vector objetivo



        factor = 1;

        while (t < 1f) // Hasta que no acabe el frame no permite otro movimiento
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t); // interpola el movimiento entre dos puntos
            yield return null;
        }


        isMoving = false;
        yield return 0;
    }

    public void setComponents (Vector2 input)
    {
        this.input = input;

    }

    void setMovement(string command)
    {
        switch (command.ToLower())
        {
            case "up":
                input = new Vector2(0, 1);
                anim_player.SetBool("IsWalking", true);
                anim_player.SetFloat("Direction", 0.0f);

                break;
            case "down":
                input = new Vector2(0, -1);
                anim_player.SetBool("IsWalking", true);
                anim_player.SetFloat("Direction", 1.0f);
                break;
            case "left":
                input = new Vector2(-1, 0);
                anim_player.SetBool("IsWalking", true);
                anim_player.SetFloat("Direction", 2.0f);
                break;
            case "right":
                input = new Vector2(1, 0);
                anim_player.SetBool("IsWalking", true);
                anim_player.SetFloat("Direction", 3.0f);
                break;
            case "stop":
                input = new Vector2(0, 0);
                anim_player.SetBool("IsWalking", false);
                break;
            default:
                break;
        }
                
    }

	public void setIsDead(bool dead) {
		isDead = dead;
        anim_player.SetBool("IsWalking", false);
	}

    public Vector3 getObjectivePosition()
    {
        return endPosition;
    }

    public string getActiveCommand()
    {
        return command;
    }

}