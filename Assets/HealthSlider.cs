using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{

    public Slider barreVie;

    
   



    // Start is called before the first frame update
    void Start()
    {
        barreVie = GetComponent<Slider>();
        barreVie.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
      /*  barreVie.value = Dummy.vieDummy;*/
    }
}
