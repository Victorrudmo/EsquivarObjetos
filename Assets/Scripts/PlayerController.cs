using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int vidas;
    public float velocidad;
    private float xMin = -7.5f, xMax = 7.5f;

    void Update()
    {
        // movimiento horizontal del jugador
        float move = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        transform.Translate(move, 0f, 0f);

        // limitar el movimiento izquierda - derecha
        Vector3 posicion = transform.position;
        posicion.x = Mathf.Clamp(posicion.x, xMin, xMax);
        transform.position = posicion;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                Destroy(collision.gameObject);
                vidas -= obstacle.damage;

                // lógica de game over
                if (vidas <= 0)
                {
                    Debug.Log("GAME OVER");
                    // pauso el juego
                    Time.timeScale = 0f;
                }
                else
                {
                    Debug.Log("Te quedan " + vidas + " vidas");
                }
            }
        }
    }
}
