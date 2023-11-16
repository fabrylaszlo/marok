using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitbox : MonoBehaviour
{
    public Slider ÉleterőCsík;
    Animator Animáció;
    public string ellenfel;
    private float meghal = 0;

    private float nemitas = 0;
    public bool meghalzenemegall = false;
    public AudioClip MeghalHang;
    public AudioClip UtestKap;
    private AudioSource HangForras;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != ellenfel)
        {
            return;
        }
        ÉleterőCsík.value -= 20;
        HangForras.PlayOneShot(UtestKap);
        if (ÉleterőCsík.value <= 0)
        {
            Animáció.SetBool("Meghal", true);
            if (meghal == 0)
            {
                meghalzenemegall = true;
                HangForras.PlayOneShot(MeghalHang);
                meghal++;
            }
            else if(meghal <= 1)
            {
                HangForras.PlayOneShot(MeghalHang, nemitas);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Animáció = GetComponent<Animator>();
        HangForras = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
