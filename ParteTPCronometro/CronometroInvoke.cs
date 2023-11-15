using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CronometroInvoke : MonoBehaviour
{
    // Start is called before the first frame update

    float tiempoPasado = 0;
    bool corriendo = false; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)== true )
         {  
            if (corriendo == false)
            {   
             InvokeRepeating("Cronometrar",1.0f,1.0f);
             corriendo = true;
             //tiempoPasado = 0; 
            }
         } else if (Input.GetKeyUp(KeyCode.Space)== true)
         {
            CancelInvoke("Cronometrar");
            corriendo = false;
            tiempoPasado = 0; 
         }
    }

    void Cronometrar(){
      tiempoPasado ++;
      Debug.Log("El tiempo que paso es " + tiempoPasado);
    }



    /*Es mas facil usar el invoke para realizar cronometros simples. Pero si tenemos que hacer algo mas complejo como separar 
     mas metodos, es mejor y con mejor rendimiento la corrutina*/
}
