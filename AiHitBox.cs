using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiHitBox : MonoBehaviour
{
    public Slider EleteroCsik;
    Animator Animacio;
    public string ellenfel;
    private float meghal = 0;

    public AudioClip MeghalHang;
    public AudioClip UtestKap;
    private AudioSource HangForras;
    public float nemitas = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != ellenfel)
        {
            return;
        }
        EleteroCsik.value -= 5;
        if (EleteroCsik.value >= 1)
        {
            HangForras.PlayOneShot(UtestKap);
        }
        else
        {
            HangForras.PlayOneShot(UtestKap, nemitas);
        }
        if (EleteroCsik.value <= 0)
        {
            Animacio.SetBool("Meghal", true);
            if (meghal == 0)
            {
                HangForras.PlayOneShot(MeghalHang);
                meghal++;
            }
            else if (meghal <= 1)
            {
                HangForras.PlayOneShot(MeghalHang, nemitas);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Animacio = GetComponent<Animator>();
        HangForras = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
