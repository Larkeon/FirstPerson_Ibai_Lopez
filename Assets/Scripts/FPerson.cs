using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverYRotar();
    }
    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 Movimiento = new Vector3(h,0,v).normalized;
        float anguloRotacion = Mathf.Atan2(Movimiento.x, Movimiento.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        
        if (Movimiento.magnitude > 0)
        {

            transform.eulerAngles = new Vector3(0, anguloRotacion,0);
            controller.Move(Movimiento * velocidadMovimiento * Time.deltaTime);
        }
    }
}
