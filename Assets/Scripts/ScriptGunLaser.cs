using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptGunLaser : MonoBehaviour
{
    public bool isGrabbed = false;
    public bool peutTirer;

    public GameObject boutFusil;

    public GameObject MainG;
    public GameObject MainD;

    public GameObject BalleOG;
    public GameObject BalleClone;
    public AudioClip sonTir;

    // RedDot
    public bool actif;

    [SerializeField] InputActionReference shootInputAction;


    // Start is called before the first frame update
    void Start()
    {
        peutTirer = true;

        actif = false;
    }


    // Update is called once per frame
    void Update()
    {
        //  Debug.Log(MainD.GetComponent<Animator>().GetFloat("Trigger"));
        if (isGrabbed == true)
        {
            if (MainD.GetComponent<Animator>().GetFloat("Trigger") >= 0.5f || MainG.GetComponent<Animator>().GetFloat("Trigger") >= 0.5f)
                {
                if (peutTirer)
                {
                    peutTirer = false;
                    Debug.Log("BANG");
                    Invoke("Shoot", 0);
                }

            }
        }
    }



private void OnTriggerStay(Collider other)
{
    if (other.tag == "Main")
    {
        isGrabbed = true;
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.tag == "Main")
    {
        isGrabbed = false;
    }
}

    void Shoot()
{
    BalleClone = Instantiate(BalleOG, boutFusil.transform.position, boutFusil.transform.rotation);
    BalleClone.SetActive(true);
    BalleClone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 100);
    GetComponent<AudioSource>().PlayOneShot(sonTir, 0.1f);

    Invoke("ShootAgain", 1);
}

void ShootAgain()
{
    peutTirer = true;
}

void redDot()
{
    var ligneLaser = GetComponent<LineRenderer>();


    if (Input.GetKeyDown(KeyCode.Q))
    {
        actif = (!actif);
    }

    if (actif == true)
    {
        RaycastHit infoCollision;
        if (Physics.Raycast(boutFusil.transform.position, boutFusil.transform.forward, out infoCollision, 50f))
        {

        }

        ligneLaser.enabled = true;
        ligneLaser.SetPosition(0, boutFusil.transform.position);
        ligneLaser.SetPosition(1, infoCollision.point);
    }       

    if (actif == false)
    {
        ligneLaser.enabled = false;
    }
}
}
