using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BotonSalida : MonoBehaviour
{
    public void botonSalida()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
