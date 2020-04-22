using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableConfig : MonoBehaviour
{
    static public bool collectThisItem = false; //Interruptor para garantir que os itens serão coletados

    static public string tempNameItem = ""; //Garante que o dictionary e a lista saibam qual item esta sendo coletado

    static public int tempItemQuantityPerItem = 0; //Quantidade de itens a serem adicionados

 
    void Start()
    {

    }

    void Update()
    {
        
    }
}
