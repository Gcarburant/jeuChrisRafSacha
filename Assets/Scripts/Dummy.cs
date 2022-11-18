using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dummy : MonoBehaviour
{
    public int dmgBlade;
    public int dmgBullet;
    private int dmgSubit;


    public static int vieDummy;

    public GameObject objTextDmg;
    public TMP_Text textDmg;

    public Slider VieEnnemi;



    // Start is called before the first frame update
    void Start()
    {
        //vieDummy = GetComponent<Animator>().GetInteger("LifeDummy");
        vieDummy = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        VieEnnemi.value = vieDummy;
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (vieDummy > 0)
        {
            if (other.GetComponent<Collider>().tag == "Blade")
            {
                dmgSubit = dmgBlade;
                textDmg.text = "" + dmgSubit;
                afficheDmg();

                GetComponent<Animator>().SetTrigger("Hit");
                vieDummy -= dmgSubit;
                Debug.Log(vieDummy);

                

              /*    if (vieDummy <= 0)
                {
                    GetComponent<Animator>().SetBool("Mort", true);
                }
              */
            }

            if (other.GetComponent<Collider>().tag == "Bullet")
            {
                dmgSubit = dmgBullet;
                textDmg.text = "" + dmgSubit;
                afficheDmg();

                GetComponent<Animator>().SetTrigger("Hit");
                vieDummy -= dmgSubit;
                Debug.Log(vieDummy);

            /* if (vieDummy <= 0)
                {
                    GetComponent<Animator>().SetBool("Mort", true);
                }
            */
            }

            else if (vieDummy <= 0)
            {
                GetComponent<Animator>().SetBool("Mort", true);
                GetComponent<Collider>().enabled = false;
            }
        }

        void afficheDmg()
        {
            GameObject leClone = Instantiate(objTextDmg, objTextDmg.transform, true);
            leClone.SetActive(true);
            leClone.transform.SetParent(this.transform, true);
            Destroy(leClone, 0.9f);
        }
    }
}
