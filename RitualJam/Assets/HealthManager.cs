using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
  
    public int health = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (health == 0)
        {
            RestartGame();
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("intento_1"); // RENOMBRAR EN EL ORIGINAL
    }
}
