using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{

    public Rigidbody RB;

    public bool stunned = false;



    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "BulletEnnemi")
        {
            RB.AddExplosionForce(100, collision.transform.position, 10f);
            Debug.Log("Yay");
        }
    }
}
