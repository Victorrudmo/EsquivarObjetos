using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float fallSpeed;
    public float minY = -15f;
    public int damage; // Cantidad de daño 


    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
