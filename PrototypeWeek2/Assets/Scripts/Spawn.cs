using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnPrefabs;
    public float spawnRate = 2f;
    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            if (spawnPrefabs.Length > 0)
            {
                SpawnObject();
                nextSpawnTime += 1f / spawnRate;
            }
            else
            {
                Debug.LogError("Error: No hay prefabs asignados en spawnPrefabs array.");
            }
        }
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnPrefabs.Length);

        // Verifica si el índice está dentro del rango
        if (randomIndex >= 0 && randomIndex < spawnPrefabs.Length)
        {
            float randomX = Random.Range(-8.5f, 8.5f);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

            Instantiate(spawnPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Error: El índice aleatorio está fuera del rango del array.");
        }
    }
}
