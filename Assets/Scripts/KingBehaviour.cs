using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingBehaviour : MonoBehaviour
{
    public Slider laughMetter;
    public GameObject KingSpriteNeutral;
    public GameObject KingSpriteHappy;
    public GameObject KingSpriteVeryHappy;
     public float laughter = 10;
    private bool stolePan = false;



    void Start()
    {
        KingSpriteHappy.SetActive(false);
        KingSpriteVeryHappy.SetActive(false);
        laughMetter.value = laughter;

    }

    void Update()
    {
        if(laughter >= 30)
        {
            KingSpriteHappy.SetActive(true);
            KingSpriteNeutral.SetActive(false);
        }
        else if (laughter <= 30)
        {
            KingSpriteHappy.SetActive(false);
            KingSpriteNeutral.SetActive(true);
        }


        if (laughter >= 70)
        {
            KingSpriteVeryHappy.SetActive(true);
            KingSpriteHappy.SetActive(false);

        }
        else if (laughter <= 70)
        {
            KingSpriteVeryHappy.SetActive(false);
            KingSpriteHappy.SetActive(true);
        }
        laughMetter.value = laughter;

    }

}
