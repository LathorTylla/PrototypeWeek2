using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject fresaPrefab;
    public GameObject yunquePrefab;
    public Transform spawnPoint;
    public float minYSpawn = 7.0f; // Posici�n en el eje Y desde donde los objetos caen
    public float maxYSpawn = 10.0f; // Altura m�xima en la que aparecer�n objetos
    public float spawnInterval = 2.0f;
    public float horizontalBoundary = 8.5f;

    private int score = 0;
    private int yunquesCollected = 0;
    private bool gameOver = false;

    void Start()
    {
        ResetGame();
        StartCoroutine(SpawnObjects());
    }

    void Update()
    {
        if (gameOver)
        {
            // Implementa aqu� la l�gica para mostrar un panel de fin de juego o reiniciar el juego.
        }
    }

    IEnumerator SpawnObjects()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnInterval);

            GameObject objectToSpawn = Random.Range(0, 2) == 0 ? fresaPrefab : yunquePrefab;
            Vector3 spawnPosition = new Vector3(
                Random.Range(-horizontalBoundary, horizontalBoundary),
                Random.Range(minYSpawn, maxYSpawn),
                0f
            );

            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    public void CollectFresa()
    {
        if (!gameOver)
        {
            score += 10;
            // Actualiza la puntuaci�n en la interfaz de usuario.
            // Implementa aqu� la l�gica para mostrar la puntuaci�n en pantalla.
            if (score >= 100)
            {
                // Has ganado el juego. Implementa la l�gica de victoria aqu�.
                gameOver = true;
            }
        }
    }

    public void CollectYunque()
    {
        if (!gameOver)
        {
            score -= 10;
            yunquesCollected++;
            // Actualiza la puntuaci�n en la interfaz de usuario.
            // Implementa aqu� la l�gica para mostrar la puntuaci�n en pantalla.
            if (yunquesCollected >= 3 || score < 0)
            {
                // Has perdido el juego. Implementa la l�gica de derrota aqu�.
                gameOver = true;
            }
        }
    }

    void ResetGame()
    {
        score = 0;
        yunquesCollected = 0;
        gameOver = false;
    }

}
