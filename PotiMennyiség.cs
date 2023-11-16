using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotiMennyiség : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = $"{Mozgas.HealPoti}";
    }
}
