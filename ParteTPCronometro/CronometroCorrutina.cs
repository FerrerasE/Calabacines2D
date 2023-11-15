using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CronometroCorrutina : MonoBehaviour
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

        
         /*
           if (Input.GetKeyDown(KeyCode.Space))
        { */
        if (Input.GetKeyDown(KeyCode.Space)== true)
         {   
        StartCoroutine("MiCronometro"); //inicia la corrutina
        corriendo = true;
        //tiempoPasado = 0;
         }

         if (Input.GetKeyUp(KeyCode.Space))
         {   
        StopCoroutine("MiCronometro"); //inicia la corrutina
        corriendo = false;
        Debug.Log("El tiempo transcurrido es " + tiempoPasado +" segundos");
        tiempoPasado = 0;
        
         }

    }

    IEnumerator MiCronometro(){
      tiempoPasado ++;
      //Debug.Log("calculando tiempo");
      yield return new WaitForSeconds(1f); // el yield return es algo que para el recorrido de codigos
      //Debug.Log("El tiempo transcurrido es " + tiempoPasado +" segundos");
      StartCoroutine("MiCronometro");
    Debug.Log("calculando tiempo " + tiempoPasado);
      
        
       
       
        
    }

    /**Quise utilizar el Time.time para sacar numeros decimales pero cuando pausaba la corrutina y el invoke, el Time.time
     continuaba reproduciendose y al volver a apretar Space, la cuenta no volvia a empezar de 0.
     Para elegir la cantida de decimales... Time.time.ToString(F2)*/
}
