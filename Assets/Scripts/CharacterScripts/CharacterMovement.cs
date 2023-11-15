using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2500f; //velocidad de movimiento del personaje
    [SerializeField] private float gravityY = -1; //velocidad de movimiento del personaje

    private float limitRangeX; // variable privada que marca los limites de movimiento del jugador en el eje x
    private float limitRangeY; // variable privada que marca los limites de movimiento del jugador en el eje y
    
    private bool isFacingRight = true; //respresenta el valor de mirar a la derecha
    private Rigidbody2D rb; //referencia al componente Rigibody2D del personaje

    private Puntaje punt; // referencia al gameObject puntaje
    

    [SerializeField] private float jumpForce; // fuerza que aplicamos al saltar
    private bool isGrounded; //banadera que indica si el personaje esta en la plataforma
    
    private AudioSource audioSource; // referencia al audio
    
    // Start is called before the first frame update
    void Start()
    {
        punt = GetComponent<Puntaje>();
        rb = GetComponent<Rigidbody2D>(); //Obtenemos la referencia al Rigibody2D del personaje
        limitRangeX = 8.50f;
        limitRangeY = 5.1f;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");//obtenemos la entrada del moviemnto hoizontal (-1 a 1) y la almacenamos en movementX
        Move(movementX * movementSpeed); //normalizamos al multiplicar por deltatime
        // giro del personaje si se mueve hacia la izquierda
        if (movementX < 0 && !isFacingRight)
        {
            Flip();
        }
        //giro del personaje si se mueve a la derecha
        else if (movementX >0 && isFacingRight)
        {
            Flip();
        }

        // llamamos a la funcion Jump () si el personaje esta en una plataforma y se presiona el boton de saltar
        if (isGrounded && Input.GetButtonDown("Jump")){
            Jump();
        }

    }

    public void Move(float velocity){

        // Este if limita la posicion del jugador hasta la izquierda
        if (gameObject.transform.position.x < -limitRangeX)
        {
            gameObject.transform.position = new Vector3(-limitRangeX,
                                                         gameObject.transform.position.y,
                                                         gameObject.transform.position.z);
        }
         // Este if limita la posicion del jugador hasta la derecha
         if (gameObject.transform.position.x > limitRangeX)
        {
            gameObject.transform.position = new Vector3(limitRangeX,
                                                         gameObject.transform.position.y,
                                                         gameObject.transform.position.z);
        }

        rb.velocity = new Vector2(velocity * Time.deltaTime, rb.velocity.y );

        if (transform.position.y <= -3.182)
            {
                Destroy(gameObject);
            }
    }
    // cambiamos la escala en el eje X para voltear el personaje
    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = !isFacingRight;
    }



    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Platform"))
        {
            //gameObject.transform.position = collision.transform.position;
            transform.parent = collision.transform;
            
        }
        
        // este if bajara un punto si el personaje colisiona con un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            punt.puntos -= 1;
        }

        isGrounded = true;
    }
    // cuando el personaje deja de colisionar con un objeto, se establece isGrounded como falso
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
           transform.parent = null;
        }

        isGrounded = false;
    }
    // funcion que aplica una fuerza vertical para ejecutar el salto. Normalizamos el salto con deltaTime
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        PlayJumpSound();
    }

    private void PlayJumpSound(){
        
        if (audioSource != null){
            audioSource.Play();
        }
    }

    


    
}
