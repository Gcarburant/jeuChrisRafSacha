using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVieJoueur : MonoBehaviour
{
    public float vieJoueur;
    public float dmgRecuJoueur;

    public bool invulnerable;

    // Start is called before the first frame update
    void Start()
    {
        vieJoueur = 10;
        invulnerable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(invulnerable == false) 
        {
            if (collision.gameObject.tag == "enemyBlade")
            {
                dmgRecuJoueur = collision.gameObject.GetComponent<Balle>().dmgInfligeJoueur;
                vieJoueur = vieJoueur - dmgRecuJoueur;
                invulnerable = true;

                Invoke("Invulnerabilite", 3);
            }

            if (collision.gameObject.tag == "BulletEnnemi")
            {
                dmgRecuJoueur = collision.gameObject.GetComponent<Balle>().dmgInfligeJoueur;
                vieJoueur = vieJoueur - dmgRecuJoueur;
                invulnerable = true;

                Invoke("Invulnerabilite", 3);
            }
        }        
    }

    private void Invulnerabilite()
    {
        if (invulnerable == true)
        {
            invulnerable = !invulnerable;
            Debug.Log("n<est plus vuklnerable");
        }

    }
}
