using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ennemi : MonoBehaviour
{

    int currentState = 0;

    GameObject joueur;

    Vector3 currentPosition;

    public float distanceAttaque;

    public float vitesseDeplacement;

    Animator animator;

    Vector3 positionDepart;
    Vector3 currentSetDestination;

   

    NavMeshAgent navAgent;
    
    Vector3 destination; // la destination du nav mesh


    bool enVie = true;

    // Start is called before the first frame update
    void Start()
    {

        currentState = 0;
        joueur = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        navAgent = GetComponent<NavMeshAgent>();

        positionDepart = transform.position;

        navAgent.stoppingDistance = distanceAttaque;



        destination = joueur.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        int previousState = currentState;
        Vector3 previousSetDestination = currentSetDestination;
        Vector3 positionJoueur = joueur.transform.position;

        if (enVie)
        {
            if (Vector3.Distance(currentPosition, positionJoueur) > distanceAttaque)
            {
                currentSetDestination = positionJoueur;
                // currentState = ? 
            }

            if (Vector3.Distance(currentPosition, positionJoueur) <= distanceAttaque)
            {
                // currentState = ? 

            }

            // if(vie < vieMax) {
            // currentState = ? ;
            // enVie = false;
            // }

        }
    }
}
