using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestConfig : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Exclamation; //A exclamação em cima do bau

    private bool OpenChest = false;

    void Awake()
    {
        Exclamation.enabled = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OpenChest == true)
        {
            Exclamation.enabled = true;
        }
        else
        {
            Exclamation.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D chestCol)
    {
        //Verifica se o player esta proximo ao bau
        if (chestCol.tag == "Player")
        {
            OpenChest = true;
        }
    }
    private void OnTriggerExit2D(Collider2D chestCol)
    {
        //Verifica se o persnagem saiu de perto do bau
        if (chestCol.tag == "Player")
        {
            OpenChest = false;
        }
    }

    private void openingChest()
    {

    }
}
