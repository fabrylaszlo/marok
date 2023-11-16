using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyogyitásHang : MonoBehaviour
{
    public AudioClip Zenelejatszo;
    public float Hangero;
    AudioSource zene;
    public bool FolyamatosLejatszas = false;

    public bool healhangstop = false;

    // Start is called before the first frame update
    void Start()
    {
        zene = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mozgas.HealHang == true)
        {
            if (!FolyamatosLejatszas)
            {
                zene.PlayOneShot(Zenelejatszo, Hangero);
                FolyamatosLejatszas = true;
                Mozgas.HealHang = false;
            }
        }
        if (Mozgas.HealHang == false)
        {
            if (FolyamatosLejatszas == true)
            {
                zene.Stop();
                FolyamatosLejatszas = false;
            }
        } 
    }
}
