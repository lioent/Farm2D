using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items
{
    private string name; 
    private int quantity;

    public string Name { get => name; private set => name = value; }
    public int Quantity { get => quantity; set => quantity = value; }

    public Properties Props { get; set; }

    //Metodo construtor
    public items(string name, int quantity)
    {
        this.name = name;
        this.quantity = quantity;
    }

}

public class Properties //Coloque aqui as propriedades adicionais
{ 

}

