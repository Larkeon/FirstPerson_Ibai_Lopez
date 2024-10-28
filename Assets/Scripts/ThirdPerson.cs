using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;
    [SerializeField] float smoothTimer;
    float velocidadRotacion;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
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
        

        if (input.magnitude > 0)
        {
        
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, smoothTimer);
            
            transform.eulerAngles = new Vector3(0,anguloSuave,0);
           
            Vector3 movimiento = Quaternion.Euler(0,anguloRotacion,0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);

            anim.SetBool("walking", true);
        }

        else
        {
            anim.SetBool("walking", false);
        }
    }
}
