using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public float dmgInfligeJoueur;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
      //  GetComponent<Rigidbody>().AddExplosionForce(,transform.position,);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Blade")
        {
            Debug.Log("TINK");
            GetComponent<Rigidbody>().useGravity = true;
            Destroy(gameObject, 2f);
        }       
    }
}
