using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaSemiAuto : MonoBehaviour
{
    [SerializeField] ArmaSO misDatos;
    //[SerializeField] ParticleSystem system;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        misDatos.danhoAtaque = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           // system.Play();
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);
                }
            } 
        }
    }
}
