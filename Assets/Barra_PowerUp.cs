﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Barra_PowerUp : MonoBehaviour
{
    public Propiedades cargasDeJugador;
    public Sprite cargas_0 = Resources.Load<Sprite>("loading_powerup_0");
    public Sprite cargas_1 = Resources.Load<Sprite>("loading_powerup_1");
    public Sprite cargas_2 = Resources.Load<Sprite>("loading_powerup_2");
    public Sprite cargas_3 = Resources.Load<Sprite>("loading_powerup_3");

    // Start is called before the first frame update
    void Start()
    {
        cargasDeJugador = FindObjectOfType<Propiedades>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cargasDeJugador.cargas == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = cargas_1;
        }

        if (cargasDeJugador.cargas == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = cargas_2;
        }

        if (cargasDeJugador.cargas == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = cargas_3;
        }
    }


}