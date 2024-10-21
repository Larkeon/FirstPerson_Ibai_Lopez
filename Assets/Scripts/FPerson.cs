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

        Vector3 input = new Vector3(h,v,0).normalized;
        
        float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        
        transform.eulerAngles = new Vector3(0,anguloRotacion,0);

        if (input.magnitude > 0)
        {
        
           
            Vector3 movimiento = Quaternion.Euler(0,anguloRotacion,0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }
    }
}
