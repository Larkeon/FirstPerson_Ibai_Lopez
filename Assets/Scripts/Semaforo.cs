using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Semaforo : MonoBehaviour
{
    private bool yaEjecutado = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& yaEjecutado == false)
        {
            yaEjecutado = true;
            StartCoroutine(EjemploSemaforo());
        }
    }

    IEnumerator EjemploSemaforo()
    {
        while(true)
        {
            Debug.Log("Verde");
            yield return new WaitForSeconds(5);
            Debug.Log("Amarillo");
            yield return new WaitForSeconds(1);
            Debug.Log("Rojo");
            yield return new WaitForSeconds(5);
        }

    }
}
