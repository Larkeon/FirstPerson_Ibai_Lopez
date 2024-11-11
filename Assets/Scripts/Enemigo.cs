using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class Enemigo : MonoBehaviour
{
    NavMeshAgent agent;
    FPerson player;
    Animator anim;

    [SerializeField] float danhoEnemigo;

    [Header("Sistema Combate")]
    [SerializeField] Transform puntoAtaque;
    [SerializeField] float radio;
    [SerializeField] LayerMask Ataque;

    float vidas = 4;

    Rigidbody[] huesos;

    bool ventanaAbierta;
    bool puedoDanhar = true;

    public float Vidas { get => vidas; set => vidas = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FPerson>();
        anim = GetComponent<Animator>();
        huesos = GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();
        if(ventanaAbierta && puedoDanhar)
        {
            DetectarImpacto();
        }
        
    }

    private void DetectarImpacto()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(puntoAtaque.position, radio, Ataque);

        if(collsDetectados.Length > 0)
        {
            for(int i = 0; i < collsDetectados.Length; i++)
            {
                collsDetectados[i].GetComponent<FPerson>().RecibirDanho(danhoEnemigo);
            }

            puedoDanhar = false;
        }
    }

    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;

            anim.SetBool("attack", true);
        }
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            agent.isStopped = false;

            anim.SetBool("attack", false);
            
            agent.SetDestination(player.transform.position);
        }

        
    }

    private void CambiarEstadoHuesos(bool estado)
    {
        for(int i = 0;i < huesos.Length;i++)
        {
            huesos[i].isKinematic = true;
        }
    }

    private void FinAtaque()
    {
        agent.isStopped = false;

        anim.SetBool("attack", false);

        puedoDanhar = true;
    }

    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    } 
    
    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
    }

    public void Morir()
    {
        CambiarEstadoHuesos(false);
        anim.enabled = false;
        agent.enabled = false;
    }
}
