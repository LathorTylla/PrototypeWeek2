using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterMov : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int yunquesCollected = 0;
    public float horizontalBoundary = 8.5f;
    public float smoothSpeed = 0.125f;
    public GameObject botonSalida;
    public TMP_Text scoreText;

    private int score;

    private bool canMove = true; // Nueva: Bandera para controlar si Pululu puede moverse

    void Start() 
    {
        botonSalida.gameObject.SetActive(false);
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
            worldPosition.y = transform.position.y;

            float clampedX = Mathf.Clamp(worldPosition.x, -horizontalBoundary, horizontalBoundary);
            Vector3 desiredPosition = new Vector3(clampedX, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Object1"))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();
        }
        else if (other.CompareTag("Object2"))
        {
            yunquesCollected++;
            if (yunquesCollected >= 4)
            {
                GameOver();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over - 3 yunques recogidos");
        Time.timeScale = 0f;
        canMove = false; // Deshabilita el movimiento de Pululu
        // Puedes agregar aqu� la l�gica adicional para mostrar un mensaje o cargar una escena de Game Over

        botonSalida.gameObject.SetActive(true);

    }
}
