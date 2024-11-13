using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    Camera cam;
    [SerializeField] float distanciaInteraccion;
    private Transform interactuableActual;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        DeteccionInteractuable();


    }

    private void DeteccionInteractuable()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, distanciaInteraccion))
        {
            if (hitInfo.transform.TryGetComponent(out AmmoBox ammoBox))
            {
                interactuableActual = ammoBox.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;

                if(Input.GetKeyDown(KeyCode.E))
                {

                    ammoBox.AbrirCaja();
                }
            }
        }

        else if (interactuableActual != null)
        {
            interactuableActual.GetComponent<Outline>().enabled = false;
        }
    }
}
