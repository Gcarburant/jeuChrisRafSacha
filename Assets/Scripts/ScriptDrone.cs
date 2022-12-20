using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScriptDrone : MonoBehaviour
{
    public int vieDrone;

    private int dmgSubit;
    public int dmgBlade;
    public int dmgBullet;

    public GameObject objTextDmg;
    public TMP_Text textDmg;

    public Slider VieEnnemi;

    public GameObject joueur;
    public GameObject world;
    public GameObject objetClone;
    public GameObject droneT;
    public Transform droneTransform;

    public GameObject gestionnaireEvenement;


    // Bool d'attaques
    public bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        vieDrone = 50;
        dmgBlade = 20;
        dmgBullet = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(joueur.transform);

        if (shooting == false)
        {
            shooting = true;
            Invoke("Tir", 3f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (vieDrone > 0)
        {
            if (other.GetComponent<Collider>().tag == "Blade")
            {
                dmgSubit = dmgBlade;
                textDmg.text = "" + dmgSubit;
                afficheDmg();

                GetComponent<Animator>().SetTrigger("Hit");
                vieDrone -= dmgSubit;

                Debug.Log(vieDrone);
            }

            if (other.GetComponent<Collider>().tag == "Bullet")
            {
                dmgSubit = dmgBullet;
                textDmg.text = "" + dmgSubit;
                afficheDmg();

                GetComponent<Animator>().SetTrigger("Hit");
                vieDrone -= dmgSubit;

                Debug.Log(vieDrone);
            }

            else if (vieDrone <= 0)
            {
                GetComponent<Animator>().SetBool("Mort", true);
                GetComponent<Collider>().enabled = false;

                gestionnaireEvenement.GetComponent<ScriptVagueEnnemi>().droneRestant = gestionnaireEvenement.GetComponent<ScriptVagueEnnemi>().droneRestant - 1;
            }
        }
    }

    void afficheDmg()
    {
        GameObject leClone = Instantiate(objTextDmg, objTextDmg.transform, true);
        leClone.SetActive(true);
        leClone.transform.SetParent(this.transform, true);
        Destroy(leClone, 0.9f);
    }

    void Tir()
    {
        GameObject clone = Instantiate(objetClone, droneT.transform.position, droneT.transform.rotation);

        clone.SetActive(true);
        //clone.transform.localScale = new Vector3(0.25f, .25f, .25f);
        clone.GetComponent<Rigidbody>().AddForce(0, 0, 10);
        clone.GetComponent<Rigidbody>().velocity = (joueur.transform.position - clone.transform.position).normalized * 1;
        shooting = false;
    }
}

