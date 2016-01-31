using System.Collections;
using UnityEngine;

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

    //private string inputCommand;

    void Start()
    {
        console = consolePrefab.GetComponent<Console>();
        endPosition = new Vector3(0, 0, 0);
		isDead = false;
    }

    public void Update()
    {
		if (!isDead) {
			
	        if (!isMoving) // Para moverse hay que activar el movimiento
	        {

	            // input = new Vector2(componentA, componentB);
	            //input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	            command = console.getActiveCommand();
	            
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
                break;
            case "down":
                input = new Vector2(0, -1);
                break;
            case "left":
                input = new Vector2(-1, 0);
                break;
            case "right":
                input = new Vector2(1, 0);
                break;
            case "stop":
                input = new Vector2(0, 0);
                break;
            default:
                break;
        }
    }

	public void setIsDead(bool dead) {
		isDead = dead;
	}

    public Vector3 getObjectivePosition()
    {
        return endPosition;
    }

}