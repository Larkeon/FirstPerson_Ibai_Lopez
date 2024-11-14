using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemigoPrefab;
    [SerializeField] Transform[] puntosSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EjemploSemaforo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EjemploSemaforo()
    {
        while (true)
        {
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity); 
            yield return new WaitForSeconds(2);
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
        }

    }
}
