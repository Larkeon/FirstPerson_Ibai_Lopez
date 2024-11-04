using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    bool ventanaAbierta;
    bool puedoDanhar = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FPerson>();
        anim = GetComponent<Animator>();
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
}