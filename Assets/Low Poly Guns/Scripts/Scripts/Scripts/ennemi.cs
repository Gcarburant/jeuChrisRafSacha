using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemi : MonoBehaviour
{

    public bool enAttaque = false;
    public bool enBloque = false;
    public bool mort = false;



    public GameObject joueur; //Le joueur

    public float rotationY;

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

        navMeshAgent.stoppingDistance = 3f;

        rotationY = GetComponent<Transform>().rotation.y;



        //===== SECTION À COMPLETER PLUS TARD ============//


        // vie = GetComponent<Dummy>();
        // vieJoueur = GetComponent<VieJoueur>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!mort) { 

/*

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentState = 1;
            }


            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentState = 2;
            }


            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentState = 3;
            }


            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                currentState = 4;
            }
*/

            RegarderJoueur();
            animator.SetInteger("EtatEnnemi", currentState);

            if(currentState == 1)
            {
                // Variable
                // animator.SetBool("",true);
                navMeshAgent.SetDestination(joueur.transform.position);
            }


            navMeshAgent.SetDestination(joueur.transform.position);

            if (Vector3.Distance(joueur.transform.position, transform.position) <= 3.5)
            {

                
                GetComponent<Animator>().SetTrigger("attack1");


                


            }
            /*

                        if (Vector3.Distance(transform.position, joueur.transform.position) > 3.5)
                        {
                            currentState = 1;
                        }





                        if(enAttaque == false)
                        {
                            enAttaque = true;
                            Invoke("PasserAttaque", 10f);
                        }

                        navMeshAgent.isStopped = false;
                        RegarderJoueur();

            */
        }

    }



    // Ajouter cette fonction avec Event au debut de l'animation d'attaque
    // Permet de changer le transform pour regarder le joueur
    public void RegarderJoueur()
    {
        transform.LookAt(joueur.transform);
    }

    public void PasserAttaque()
    {
       
       


       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {

        }
    }

}
