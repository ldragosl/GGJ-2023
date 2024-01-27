using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughSystem : MonoBehaviour
{
    [SerializeField] private float _maxLaughter = 100;
    [SerializeField] private float _minLaughter = 0;
    private float _currentLaughter;

    public LaughMeter laughMeter;

    // Start is called before the first frame update
    void Start()
    {
        _currentLaughter = _minLaughter;
        LaughMeter.SetMaxLAughter(_minLaughter);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _currentLaughter += Random.Range(0.6f, 1.5f);
            LaughterDamage = Random.Range(0.6f, 1.5f);
        }
    }

    // Update is called once per frame
    void LaughterDamage( float laughterDamage)
    {
       _currentLaughter -= laughterDamage;

        if( _currentLaughter < 0)
        {
            _currentLaughter = 0;
            Destroy(gameObject);
            LaughMeter.SetLAughter(_currentLaughter);

        }
    }
}
