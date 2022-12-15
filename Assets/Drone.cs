using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{

    // Bool d'attaques
    public bool shooting = false;



    public GameObject joueur;

    public GameObject objetClone;
    public GameObject droneT;






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
        GameObject clone = Instantiate(objetClone, droneT.transform);

        
        clone.SetActive(true);
        clone.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 10);
        shooting = false;

        
    }
}
