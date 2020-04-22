using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultCrops : MonoBehaviour
{
    //public  float GrowthTime = 4f; //Tempo para a crop crescer
    public  bool isGrowing = false; //Verifica se a planta deve crescer
    public  int TransitionPhase = 1; //Fases da crop

    //Primeiras crops
    Crop WheatCrop = new Crop("Wheat", 4f); //Criação da primeira semente
    public float TimeHolder ; //Segura o tempo das crops !!!REMOVER FUTURAMENTE!!!

    [Tooltip("Array que mudarão a sprite in game")]
    public Sprite[] SpriteCrops; //Array que segura as transições das crops

    [Tooltip("Sprite in Game")]
    public SpriteRenderer CropObjRenderer; //Objeto temporario que segura a crop

    #region "Awake, Start, Update, FixedUpdate"
    
    void Awake()
    {
        TimeHolder = WheatCrop.GrowthTime;
    }

    void Start()
    {
        

        
    }

    void Update()
    {
        GrowCrop();
    }

    private void FixedUpdate()
    {

    }
    #endregion

    //Funcao de crescimento da crop, mudar futuramente para dentro do objeto
    void GrowCrop()
    {
        if (Input.GetKeyDown(KeyCode.G)) //Ao apertar G starta o processo de crescimento
        {
            isGrowing = true;
            //print("Começou a crescer");
        }

        //Verifica se o espaço ja foi apertado
        if (isGrowing == true)
        {
            TimeHolder -= Time.deltaTime; //Contagem de segundos
        }

        //Calcula o tempo de crescimento
        if (TimeHolder <= 0)
        {
            //print("A planta cresceu");
            TimeHolder = WheatCrop.GrowthTime;
            isGrowing = false;
            TransitionPhase += 1;
        }

        if (TransitionPhase == 2)
        {
            CropObjRenderer.sprite = SpriteCrops[1]; //Muda a fase da planta
        }
        if (TransitionPhase == 3)
        {
            CropObjRenderer.sprite = SpriteCrops[2]; //Muda a fase da planta
        }
    }

    /// <summary>
    /// Metodo construtor de todas as crops, caso precise acelerar o crescimento de crops, utilizar o protected
    /// e a herança de Crop sobre a nova classe
    /// </summary>
    public class Crop
    {
        private string name; //Nome da crop
        private float growthTime; //Tempo de crescimento

        public string Name { get => name; private set => name = value; }
        public float GrowthTime { get => growthTime; private set => growthTime = value; }

        //Metodo construtor
        public Crop(string name, float growthTime)
        {
            Name = name;
            this.GrowthTime = growthTime;
        }

        //Funções
    }       
}
