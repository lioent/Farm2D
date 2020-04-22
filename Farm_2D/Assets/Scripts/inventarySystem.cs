using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class inventarySystem : MonoBehaviour
{
    /*[WIP]*/ //Dictionary<object, int> inventary = new Dictionary<object, int>(); //Inicialização do inventario 

    List<items> inventory = new List<items>(); //Sistema de inventario atualizado

    public Dictionary<string, Sprite> itemsListSprite = new Dictionary<string, Sprite>(); //Sprites no dicionario, serão usadas para pegar o nome associado e setar a sprite correta

    //-----------------------------------------------------------
    //SPRITES
    private Sprite breadSprite;
    //-----------------------------------------------------------

    //-----------------------------------------------------------
    //SLOTS
    //-----------------------------------------------------------
    [SerializeField] private SpriteRenderer slot1;

    [SerializeField] private Text slot1_txt;

    #region "Awake, Start, Update"
    void Awake() //Acorda antes do programa inicializar
    {
        breadSprite = Resources.Load<Sprite>("Sprites/bread");
        slot1_txt.enabled = false;

        //Dictionary

        /*Bread*/        itemsListSprite.Add("Bread", breadSprite);
    }
    void Start()
    {
        
    }

    void Update()
    {
        //Gatilho que coloca os itens dentro do inventario
        if(collectableConfig.tempNameItem != "" && collectableConfig.collectThisItem == true)
        {
            #region ("OLD")
            //[WIP]
            /*foreach (string itemInventory in inventary.Keys.ToList()) //Percorre o inventario
            {
                if(itemInventory.ToString() == collectableConfig.tempNameItem) //Compara os items ja preselecionados no dictionary
                {
                    inventary[itemInventory] += 1; //Adiciona um item ao item ja percorrido
                    cleanItemPickupTemp(); //Limpando o holder de pick de item

                    //print("Um item que ja existia foi acrescido"); //Debugger


                }
                else if(itemInventory.ToString() != collectableConfig.tempNameItem) //Verifica se o item ainda nao existe
                {
                    inventary.Add(collectableConfig.tempNameItem, 1);
                    cleanItemPickupTemp(); //Limpando o holder de pick de item

                    //print("Um item que nao existia foi adicionado"); //Debugger
                }
            }

            if(inventary.Count == 0) //Se o inventario ainda nao foi adicionado o primeiro
            {
                inventary.Add(collectableConfig.tempNameItem, 1);
                //print("Foi adicionado o primeiro item"); //Debugger

                
            }

            cleanItemPickupTemp(); //Limpando o holder de pick de item*/
            #endregion
            
            if (!inventory?.Any() ?? false) //Checa se a lista esta vazia 
            {
                // Adiciona novo item

                inventory.Add(make_a_TempItem(collectableConfig.tempNameItem, collectableConfig.tempItemQuantityPerItem));
                print("Foi adicionado um: " + collectableConfig.tempNameItem + " Quantidade : " + 1);
                slot1.sprite = itemsListSprite[collectableConfig.tempNameItem];//Pega o dicionario de lista e acha o nome da sprite adequada com o colect.conf.name
                slot1_txt.enabled = true;//Ativa o slot
                cleanItemPickupTemp(); //Limpa o pick temporario
            }

            int index = 0;
            foreach (var item in inventory.ToList()) //Se o item ja existe, ele seghue essas instruções
            {
                if(item.Name == collectableConfig.tempNameItem) //Verifica se o item ja existe
                {
                    print("Esse item ja foi coletado");
                    inventory[index].Quantity += 1;
                    print("Foi adicionado um: " + collectableConfig.tempNameItem + " Quantidade : " + inventory[index].Quantity);
                    cleanItemPickupTemp(); //Limpa o pick temporario

                    slot1_txt.text = inventory[index].Quantity.ToString("00");//Formata a quantidade de itens para duas casas decimais
                }

                index++;
            }
        }
    }
    #endregion

    void cleanItemPickupTemp() //Limpa o holder temporario que configura os items no dicionario
    {
        collectableConfig.tempNameItem = "";
        collectableConfig.collectThisItem = false;
    }

    items make_a_TempItem(string Name, int Quantity) //Cria um item temporario para ser adicionado a lista
    {
        items tempItem = new items(Name, Quantity);
        return tempItem;
    }
}
