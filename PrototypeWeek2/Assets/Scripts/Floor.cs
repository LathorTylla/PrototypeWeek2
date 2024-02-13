using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Object1"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Object2"))
        {
            Destroy(other.gameObject);
        }
    }
}
