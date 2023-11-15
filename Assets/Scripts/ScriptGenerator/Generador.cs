using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] private GameObject generator;
    [SerializeField] private float initTime;
    [SerializeField] private float repeatTime;
    [SerializeField] private float speedXGenerator;
    void Start()
    {
            InvokeRepeating("Generate", initTime, repeatTime);
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveGenerator();
    }

    public void Generate()
    {
            Instantiate(generator, transform.position, transform.rotation); 
        
    }

    public void MoveGenerator()
    {
        transform.Translate(speedXGenerator * Time.deltaTime ,0 ,0);
        
        if(transform.position.x < -7f || transform.position.x > 8.5f)
            {
                speedXGenerator *= -1;
            }
    }
}
