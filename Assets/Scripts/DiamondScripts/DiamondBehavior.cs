using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehavior : MonoBehaviour
{
    //[SerializeField] private GameObject efecto;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    [SerializeField] private float speedY = -0.5f;

    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            //Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        transform.Translate(0 ,speedY * Time.deltaTime ,0);

        if (transform.position.y <= -4.32)
            {
                Destroy(gameObject);
            }
    }
}
