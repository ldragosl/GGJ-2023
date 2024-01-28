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
    private float _laughTime = 20.0f;
    private float _currentTime = 0.0f;


    void Start()
    {
        KingSpriteHappy.SetActive(false);
        KingSpriteVeryHappy.SetActive(false);
        laughMetter.value = laughter;
      //  StartCoroutine(RemoveLaughter());


    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _laughTime)
        {
            AddLaughter(-10);
            _currentTime = 0;
        }
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
    public void AddLaughter(int modify)
    {
        laughter = laughter + modify;
        if (laughter < 0)
            laughter = 0;
        if (laughter > 100)
            laughter = 100;
    }
   /* IEnumerator RemoveLaughter()
    {
        
        yield return new WaitForSeconds(10);
        Debug.Log("The king is bored");
        laughter = laughter - 10;
    }*/

}
