using System.Collections;
using UnityEngine;

class GridMove : MonoBehaviour
{
    private float moveSpeed = 3f; // velocidad
    private float gridSize = 1f; // Tamaño del grid
    public float componentA;
    public float componentB;
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

    public void Update()
    {
        if (!isMoving) // Para moverse hay que activar el movimiento
        {
           
           // input = new Vector2(componentA, componentB);
           //input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (input != Vector2.zero)
            {
                Debug.Log("A moverse");
                StartCoroutine(move(transform));
            }
        }
    }

    public IEnumerator move(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal) // Moviento 
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize, startPosition.y + System.Math.Sign(input.y) * gridSize,startPosition.z); // Establecemos el vector objetivo
        }
        else {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize, startPosition.y + System.Math.Sign(input.y) * gridSize,startPosition.z);
        }

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
}