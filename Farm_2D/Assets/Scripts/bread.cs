using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bread : MonoBehaviour
{
    void Awake()
    {

    }
    void Start()
    {

    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colPlayer)
    {
        if(colPlayer.tag == "Player")
        {
            collectableConfig.collectThisItem = true; //Ativa o interruptor para ele coletar os itens

            collectableConfig.tempNameItem = "Bread"; //Nome do item

            collectableConfig.tempItemQuantityPerItem = 1;

            Destroy(this.gameObject); //Destroi o objeto
        }
    }
}
