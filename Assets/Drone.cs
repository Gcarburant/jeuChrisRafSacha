using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{

    // Bool d'attaques
    public bool shooting = false;

    public GameObject world;



    public GameObject joueur;

    public GameObject objetClone;
    public GameObject droneT;

    public Transform droneTransform;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(joueur.transform);

        if(shooting == false)
        {
            shooting = true;
            Invoke("Tir", 3f);
        }

       
    }



    void Tir()
    {
        GameObject clone = Instantiate(objetClone, droneT.transform.position, droneT.transform.rotation);
       


        clone.SetActive(true);
        clone.transform.localScale = new Vector3(0.25f,.25f,.25f);
        clone.GetComponent<Rigidbody>().AddForce(0, 0, 10);
        clone.GetComponent<Rigidbody>().velocity = (joueur.transform.position - clone.transform.position).normalized * 1;
        shooting = false;

        
    }
}
