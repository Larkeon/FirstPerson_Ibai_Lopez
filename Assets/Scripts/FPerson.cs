using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPerson : MonoBehaviour
{
    [Header ("Movimiento")]
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float alturaSalto;

    [Header ("Deteccion Suelo")]
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;
    CharacterController controller;
    private Vector3 movimientoVertical;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MoverYRotar();

        AplicarGravedad();

        if (EnSuelo())
        {
            movimientoVertical.y = 0;
            Saltar();
        }
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2*factorGravedad*alturaSalto);
        }
    }

    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(h,v,0).normalized;
        
        float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0, anguloRotacion, 0);

        if (h != 0 || v != 0)
        {
        
           
            Vector3 movimiento = Quaternion.Euler(0,anguloRotacion,0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
    }

    private void AplicarGravedad()
    {
        movimientoVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }

    private bool EnSuelo()
    {
        bool resultado = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        return resultado;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
}
