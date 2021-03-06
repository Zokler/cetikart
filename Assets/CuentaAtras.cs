﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CuentaAtras : MonoBehaviour
{

    public Sprite[] numeros;

    public GameObject contadorNumerosGO;
    public SpriteRenderer contadorNumerosComp;

    //public GameObject movimiento_camaraGO;
    public GameObject mobileStickGO;
    public KartController velocidad;
  

    // Use this for initialization
    void Start()
    {
        InicioComponentes();
        velocidad = FindObjectOfType<KartController>();
    }

    void InicioComponentes()
    {
        contadorNumerosGO = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();
        //movimiento_camaraGO = GameObject.Find("Main Camera");
        mobileStickGO = GameObject.Find("MobileSingleStickControl");
        
        InicioCuentaAtras();

    }

    void InicioCuentaAtras()
    {
        StartCoroutine(Contando());
    }

    IEnumerator Contando()
    {
        //linea que desactiva cositos
       // movimiento_camaraGO.GetComponent<movimiento_camara>().enabled = false;
        mobileStickGO.SetActive(false);
        contadorNumerosComp.sprite = numeros[0];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        /*if (CrossPlatformInputManager.GetButton("Run"))
        {
            velocidad.speed = 2000f;
        }*/
        contadorNumerosComp.sprite = numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[3];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
       // movimiento_camaraGO.GetComponent<movimiento_camara>().enabled = true;
        mobileStickGO.SetActive(true);
        contadorNumerosGO.SetActive(false);


    }

}
