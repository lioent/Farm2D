using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmerConfig : MonoBehaviour
{
    private float MoveSpeed = 7.5f; //Define a velocidade
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Teclas permitidas: A B <- ->
        if (Input.GetKey(KeyCode.LeftShift)) //Correndo
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * 1.75f, 0f, 0f);
            transform.position += movement * Time.deltaTime * MoveSpeed;
   
        }
        else //Andando normal
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //Permite que ele se movimente horizontalmente
            transform.position += movement * Time.deltaTime * MoveSpeed;
        }       
    }
  
}
