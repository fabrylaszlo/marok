using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Életerő : MonoBehaviour
{
    public Slider Életcsúszka;
    public Gradient Szinskála;
    public Image Kitöltés;
    public void SetÉlet(int élet)
    {
        Életcsúszka.value = élet;
        Kitöltés.color = Szinskála.Evaluate(Életcsúszka.normalizedValue);
    }

    public void SetMaxÉlet(int élet)
    {
        Életcsúszka.maxValue = élet;
        Életcsúszka.value = élet;
        Kitöltés.color = Szinskála.Evaluate(1f);
    }
}
