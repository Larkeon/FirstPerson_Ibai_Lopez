using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteDeEnemigo : MonoBehaviour
{
    [SerializeField] Enemigo mainScript;
    [SerializeField] float multiplicadorDanho;
    private void RecibirDanho(float danhoRecibido)
    {
        mainScript.Vidas -= danhoRecibido * multiplicadorDanho;
        
        if (mainScript.Vidas <= 0)
        {
            mainScript.Morir();
        }

    }
}
