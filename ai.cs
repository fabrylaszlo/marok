using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ai : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Játékos;
    static Animator Animáció;
    private AudioSource HangForras;
    public AudioClip UvoltHang;
    private float uvolt = 0;
    void Start()
    {
         Animáció = GetComponent<Animator>();
        HangForras = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AlapAiHitBox.Élet <= 0)
        {
            return;
        }
        if (Vector3.Distance(Játékos.position, this.transform.position) < 15)
        {
            
            Vector3 Irány = Játékos.position - this.transform.position;
            Irány.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Irány), 0.1f);

            Animáció.SetBool("All", false);
            if (Irány.magnitude > 1.2)
            {
                this.transform.Translate(0, 0, 0.02f); // hogy kövessen minket ha 0,05 helyett 1 írunk darabos a követés (teleportál)
                Animáció.SetBool("Fut", true);
                Animáció.SetBool("AlapUtes", false);
            }
            else
            {
                this.transform.Translate(0, 0, 0.0f); 
                // nézni kell mikor van vége az animációnak addig meg kell állítani az ellenséget
                if (uvolt == 0)
                {
                    HangForras.PlayOneShot(UvoltHang);
                    uvolt++;
                }
                Animáció.SetBool("AlapUtes", true);
                Animáció.SetBool("Fut", false);
            }
            if (Irány.magnitude > 3)
            {
                uvolt = 0;
            }
        }
        else
        {
            Animáció.SetBool("All", true);
            Animáció.SetBool("Fut", false);
            Animáció.SetBool("AlapUtes", false);
        }
    }
}