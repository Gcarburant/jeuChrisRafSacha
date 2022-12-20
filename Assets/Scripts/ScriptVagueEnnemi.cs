using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVagueEnnemi : MonoBehaviour
{
    public int compteurRound;
    public bool compteurOn;
    public int nbRound;

    public GameObject cibleDemarerRound;

    public GameObject drone1;
    public GameObject drone2;
    public GameObject drone3;
    public GameObject drone4;
    public GameObject drone5;

    public GameObject locDrone1;
    public GameObject locDrone2;
    public GameObject locDrone3;
    public GameObject locDrone4;
    public GameObject locDrone5;

    public GameObject lesDummy;

    public GameObject drone;
    public float droneRestant;
    public float scoreRound;

    // Start is called before the first frame update
    void Start()
    {
        compteurRound = 0;
        compteurOn = false;
        nbRound = 0;
        droneRestant = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (compteurOn == true)
        {
            compteurRound = compteurRound -1;
        }

        if(compteurOn == true && droneRestant <= 0)
        {
            Invoke("finRound", 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().name == "XR Origin")
        {
            nbRound = nbRound++;
            compteurRound = 36000;
            GetComponent<BoxCollider>().enabled = false;
            cibleDemarerRound.SetActive(false);
            Invoke("demarreCounter", 1f);
            Invoke("redemarageCompteur", 3600f);
        }
    }

    private void demarreCounter()
    {
        compteurOn = true;

        GameObject clone1 = Instantiate(drone1, locDrone1.transform);
        GameObject clone2 = Instantiate(drone2, locDrone2.transform);
        GameObject clone3 = Instantiate(drone3, locDrone3.transform);
        GameObject clone4 = Instantiate(drone4, locDrone4.transform);
        GameObject clone5 = Instantiate(drone5, locDrone5.transform);

        clone1.SetActive(true);
        clone2.SetActive(true);
        clone3.SetActive(true);
        clone4.SetActive(true);
        clone5.SetActive(true);

        Destroy(clone1, 3600f);
        Destroy(clone2, 3600f);
        Destroy(clone3, 3600f);
        Destroy(clone4, 3600f);
        Destroy(clone5, 3600f);

        lesDummy.SetActive(false);

        droneRestant = 5;

        Debug.Log("DEMARE COMPTEUR");
    }

    private void redemarageCompteur()
    {
        GetComponent<BoxCollider>().enabled = true;
        cibleDemarerRound.SetActive(true);
        compteurOn = false;
        Debug.Log("REDEMARAGE COMPTEUR");
    }

    private void finRound()
    {
        scoreRound = compteurRound;
        Invoke("redemarageCompteur", 5f);
        Debug.Log("FIN ROUND");
    }
}
