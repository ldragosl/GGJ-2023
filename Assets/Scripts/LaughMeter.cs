using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaughMeter : MonoBehaviour
{
    public Slider _laughterbar;

    public void SetMaxLaughter(float laughter)
    {
        _laughterbar.maxValue = laughter;
        _laughterbar.value = laughter;
    }

    public void SetLaughter(float aughter)
    {
        _laughterbar.value = laughter;
    }
}
