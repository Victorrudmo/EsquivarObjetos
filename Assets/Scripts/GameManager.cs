using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obstaculoPrefabs; 
    public float minIntervaloPrefabs = 0.5f;
    public float maxIntervaloPrefabs = 2f;
    private float timer = 0f;
    private float nextIntervaloPrefabs;
    public float minX = -7.5f;
    public float maxX = 7.5f;
    public float spawnY = 10f;

    void Start()
    {
        // Inicializar el primer intervalo de generación
        nextIntervaloPrefabs = Random.Range(minIntervaloPrefabs, maxIntervaloPrefabs);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextIntervaloPrefabs)
        {
            // Generar un obstáculo en una posición aleatoria
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
            int randomIndex = Random.Range(0, obstaculoPrefabs.Length);
            Instantiate(obstaculoPrefabs[randomIndex], spawnPosition, Quaternion.identity);

            // Resetear el temporizador y calcular el próximo intervalo de generación
            timer = 0f;
            nextIntervaloPrefabs = Random.Range(minIntervaloPrefabs, maxIntervaloPrefabs);
        }
    }
}
