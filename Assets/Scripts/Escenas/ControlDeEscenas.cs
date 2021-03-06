﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace cetikart.controlescenas
{
    public class ControlDeEscenas : MonoBehaviour
    {

        public void EscenaAnterior(int index)
        {
            if (index == 0) index = 1;
            var EscenaActual = SceneManager.GetActiveScene();
            Debug.Log("Index: Escena Actual" + EscenaActual.buildIndex);
            SceneManager.LoadScene(EscenaActual.buildIndex - index);
        }

        public void EscenaMenuPrincipal()
        {
            SceneManager.LoadScene("Menu_Principal");
        }

        public void IrAEscena(int index)
        {
            switch (index)
            {
                case 0: SceneManager.LoadScene("Seleccion_Dificultad"); break;
                case 1: SceneManager.LoadScene("Multijugador"); break;
                case 2: SceneManager.LoadScene("Custom"); break;
                case 3: Application.Quit(); break;
                case 4: SceneManager.LoadScene("Seleccion_Dificultad"); break;
                default: Debug.Log("No se puede ir a la escena " + index); break;
            }
        }
    }
}
