using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoutonHabit : MonoBehaviour
{

    public Button boutonSwitchD;
    public Button boutonSwitchG;

    public int valeurTableau;
    public int valeurTableauMax;
    public int valeurTableauMin;


    public GameObject habitBouton;
    public bool habiller;

    public GameObject[] lesHabits;

    // Start is called before the first frame update
    void Start()
    {
        habiller = false;

        boutonSwitchD.onClick.AddListener(SwitchVetementD);
        boutonSwitchG.onClick.AddListener(SwitchVetementG);
    }

    // Update is called once per frame
    void Update()
    {
      if(valeurTableau > valeurTableauMax)
        {
            valeurTableau = 0;
        }

        if (valeurTableau < valeurTableauMin)
        {
            valeurTableau = valeurTableauMax;
        }
    }


    void SwitchVetementD()
    {/*
        if (habiller == false)
        {
            habitBouton.SetActive(true);
            habiller = true;
        }

        else
        {
            habitBouton.SetActive(false);
            habiller = false;
        }*/

        /*
        for(int i = 0; i < lesHabits.Length ; i++)
        {
            
            lesHabits[i].SetActive(true);
        }*/


        foreach (GameObject vetement in lesHabits)
        {
            
            vetement.SetActive(false);
            
            
        }


        lesHabits[valeurTableau].SetActive(true);
        valeurTableau += 1;
    }

    void SwitchVetementG()
    {/*
        if (habiller == false)
        {
            habitBouton.SetActive(true);
            habiller = true;
        }

        else
        {
            habitBouton.SetActive(false);
            habiller = false;
        }*/

        /*
        for(int i = 0; i < lesHabits.Length ; i++)
        {
            
            lesHabits[i].SetActive(true);
        }*/


        foreach (GameObject vetement in lesHabits)
        {

            vetement.SetActive(false);


        }


        lesHabits[valeurTableau].SetActive(true);
        valeurTableau -= 1;
    }


}
