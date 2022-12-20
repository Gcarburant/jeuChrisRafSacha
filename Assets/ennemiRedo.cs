using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemiRedo : MonoBehaviour
{

    NavMeshAgent nav;

    public GameObject joueur;

    public Transform positionJoueur;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        nav.SetDestination(positionJoueur.position);

        if(Vector3.Distance(joueur.transform.position, transform.position) <= 3.5)
        {
            nav.isStopped = true;
            anim.SetTrigger("attack1");
            
        }



    }
}
