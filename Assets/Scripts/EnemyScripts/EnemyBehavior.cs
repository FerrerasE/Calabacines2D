using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float limitRangeX;
    [SerializeField] private float speedY = -4f;
    [SerializeField] private float speedY2 = -2f;

    [SerializeField] private float speedX2 = -1f;

    [SerializeField] private int enemyType; // 1: Enemigo1 ---------- 2: Enemigo2


    [SerializeField] private float randomTime =0f ;
    [SerializeField] private float tiempoMuerte= 1f;

    private void Start() 
    {
        limitRangeX = 8.50f;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }


    public void MoveEnemy()
    {
        if (transform.position.y <= -4.32)
            {
                Destroy(gameObject);
            }
      switch(enemyType)
        {
           case 1:
           {
            transform.Translate(0 ,speedY * Time.deltaTime ,0);
            break;
           }
           case 2:
           {
            transform.Translate(speedX2 * Time.deltaTime ,speedY2 * Time.deltaTime ,0);
            // Este if limita la posicion del enemigo hasta la izquierda
        if (gameObject.transform.position.x < -limitRangeX)
        {
            gameObject.transform.position = new Vector3(-limitRangeX * -1,
                                                         gameObject.transform.position.y,
                                                         gameObject.transform.position.z);
        }
         // Este if limita la posicion del enemigo hasta la derecha
         if (gameObject.transform.position.x > limitRangeX)
        {
            gameObject.transform.position = new Vector3(limitRangeX * -1,
                                                         gameObject.transform.position.y,
                                                         gameObject.transform.position.z);
        }
            break;
           }    
        }
    }

   
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                
            }
        }

    
}
