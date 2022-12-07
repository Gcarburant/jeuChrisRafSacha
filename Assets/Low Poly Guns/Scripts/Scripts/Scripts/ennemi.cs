using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemi : MonoBehaviour
{

    public GameObject joueur; //Le joueur

    Vector3 positionDepart; // Position initital

    public float distanceAttaque;

    public float vitesseDeplacement;

    int currentState = 0;

    Vector3 currentSetDestination;

    Animator animator;

    NavMeshAgent navMeshAgent;

    Vector3 distanceJoueur;

    // VieJoueur vieJoueur; // À EFFACER QUAND SCRIPT VIE EXISTERA

    //  Dummy vie;

    bool alive = true;

   



    // Start is called before the first frame update
    void Start()
    {
        currentState = 0;

        joueur = GameObject.FindGameObjectWithTag("Player");

        animator = GetComponent<Animator>();
        currentSetDestination = positionDepart;

        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.stoppingDistance = 1f;

        

        //===== SECTION À COMPLETER PLUS TARD ============//


        // vie = GetComponent<Dummy>();
        // vieJoueur = GetComponent<VieJoueur>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(joueur.transform.position);
        navMeshAgent.stoppingDistance = 3f;

        if(Vector3.Distance(joueur.transform.position, transform.position) <= 3.5 ) {

            GetComponent<Animator>().SetTrigger("attack1");
        
        }
    }



    // Ajouter cette fonction avec Event au debut de l'animation d'attaque
    // Permet de changer le transform pour regarder le joueur
    public void RegarderJoueur()
    {
        transform.LookAt(joueur.transform);
    }





}
