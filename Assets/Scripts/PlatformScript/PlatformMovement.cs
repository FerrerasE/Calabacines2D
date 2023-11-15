using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speedY;

    //private Rigidbody2D rb; //referencia al componente Rigibody2D de la plataforma
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>(); //Obtenemos la referencia al Rigibody2D del personaje
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        

        //rb.velocity = new Vector2(rb.velocity.x,velocity * Time.deltaTime);
        transform.Translate(0, speedY * Time.deltaTime,0);

        if (transform.position.y <= -3.80)
            {
                Destroy(gameObject);
            }
    }

    /**private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Fin"))
        {
            Destroy(gameObject);
        }
    }*/
}
