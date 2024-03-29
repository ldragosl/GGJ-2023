using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableMeat : MonoBehaviour
{
    public float ditanceToCook = 1f;
    public Color rawColor;
    public Color cookColor;
    public GameObject meatExteriour;
    public float cookTime = 5f;
    [SerializeField]
    private GameObject particles;

    float cookValue = 0f;
    Material meatMat;

    // Start is called before the first frame update
    void Start()
    {
        meatMat = new Material(meatExteriour.GetComponent<MeshRenderer>().material);
        meatMat.color = rawColor;
        meatExteriour.GetComponent<MeshRenderer>().material = meatMat;
       // particles.SetActive(false);
        
    }

    public bool isFullyCooked() {
        return cookValue > 1f; 
    }

    // Update is called once per frame
    void Update()
    {
        GameObject stove = GameObject.FindGameObjectWithTag("Stove");
        if(stove != null) { 
            if(Vector3.Distance(stove.transform.position, transform.position) < ditanceToCook)
            {
                if (transform.parent != null && transform.parent.tag == "Pan")
                {
                    cookValue += Time.deltaTime / cookTime;
                    if(cookValue >= 1f && cookValue < 1.2f)
                        particles.SetActive(true);
                    else
                    {
                        particles.SetActive(false);
                    }
                    meatMat.color = Color.Lerp(rawColor, cookColor, cookValue);
                }
            }
        }
    }
}
