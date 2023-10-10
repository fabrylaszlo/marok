using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimációController : MonoBehaviour
{
    Animator Animacio;
    float SebessegZ = 0.0f;
    float SebessegX = 0.0f;
    public float gyorsulas = 2.0f;
    public float lassulas = 2.0f;
    public float MaxSetaSebesseg = 0.5f;
    public float MaxFtasiSebesseg = 2.0f;

    public float JatekosSebesseg = 0.3f;
    int SebessegZHash;
    int SebessegXHash;
    // Start is called before the first frame update
    void Start()
    {
        Animacio = GetComponent<Animator>();
        SebessegZHash = Animator.StringToHash("SebessegZ");
        SebessegXHash = Animator.StringToHash("SebessegX");
    }

    // Update is called once per frame
    void Update()
    {
        
        bool EloreNyomas = Input.GetKey(KeyCode.W);
        bool BalraNyomas = Input.GetKey(KeyCode.A);
        bool JobbraNyomas = Input.GetKey(KeyCode.D);
        bool FutasNyomasa = Input.GetKey(KeyCode.LeftShift);
        bool HatraSetalNyomas = Input.GetKey(KeyCode.S);
        float jelenlegiMaximumSebesseg = FutasNyomasa ? MaxFtasiSebesseg : MaxSetaSebesseg;

        if (EloreNyomas && SebessegZ < jelenlegiMaximumSebesseg)
        {
            SebessegZ += Time.deltaTime * gyorsulas;
        }
        if (BalraNyomas && SebessegX > -jelenlegiMaximumSebesseg)
        {
            SebessegX -= Time.deltaTime * gyorsulas;
        }
        if (JobbraNyomas && SebessegX < jelenlegiMaximumSebesseg)
        {
            SebessegX += Time.deltaTime * gyorsulas;
        }
        if (!EloreNyomas && SebessegZ > 0.0f)
        {
            SebessegZ -= Time.deltaTime * lassulas;
        }
        //Itt van a probléma !!!!
        if (!BalraNyomas && SebessegX < 0.0f)
        {
            SebessegX += Time.deltaTime * lassulas;
        }
        //A Jobbra Lassulás jó!
        if (!JobbraNyomas && SebessegX > 0.0f)
        {
            SebessegX -= Time.deltaTime * lassulas;
        }
        if (!EloreNyomas && SebessegX < 0.0f)
        {
            SebessegZ = 0.0f;
        }
        if (HatraSetalNyomas && SebessegZ > -jelenlegiMaximumSebesseg)
        {
            SebessegZ -= Time.deltaTime * gyorsulas;
        }
        if (!HatraSetalNyomas && SebessegZ < 0.0f)
        {
            SebessegZ += Time.deltaTime * lassulas;
        }



        if (!BalraNyomas && !JobbraNyomas && SebessegX != 0.0f && (SebessegX > -0.5f && SebessegX < 0.05f))
        {
            SebessegX = 0.0f;
        }
        if (EloreNyomas && FutasNyomasa && SebessegZ > jelenlegiMaximumSebesseg)
        {
            SebessegZ = jelenlegiMaximumSebesseg;
        }
        else if (EloreNyomas && SebessegZ > jelenlegiMaximumSebesseg)
        {
            SebessegZ -= Time.deltaTime * lassulas;
            if (SebessegZ > jelenlegiMaximumSebesseg && SebessegZ < (jelenlegiMaximumSebesseg - 0.05f))
            {
                SebessegZ = jelenlegiMaximumSebesseg;
            }
        }
        if (BalraNyomas && FutasNyomasa && SebessegX < -jelenlegiMaximumSebesseg)
        {
            SebessegX = -jelenlegiMaximumSebesseg;
        }
        else if (BalraNyomas && SebessegX < -jelenlegiMaximumSebesseg)
        {
            SebessegX += Time.deltaTime * lassulas;
            if (SebessegX < -jelenlegiMaximumSebesseg && SebessegX > (-jelenlegiMaximumSebesseg - 0.05f))
            {
                SebessegX = -jelenlegiMaximumSebesseg;
            }
        }
        else if (BalraNyomas && SebessegX > -jelenlegiMaximumSebesseg && SebessegX < (-jelenlegiMaximumSebesseg + 0.05f))
        {
            SebessegX = -jelenlegiMaximumSebesseg;
        }
        if (JobbraNyomas && FutasNyomasa && SebessegX > jelenlegiMaximumSebesseg)
        {
            SebessegX = jelenlegiMaximumSebesseg;
        }
        else if (JobbraNyomas && SebessegX > jelenlegiMaximumSebesseg)
        {
            SebessegX -= Time.deltaTime * lassulas;
            if (SebessegX > jelenlegiMaximumSebesseg && SebessegX < (jelenlegiMaximumSebesseg + 0.05f))
            {
                SebessegX = jelenlegiMaximumSebesseg;
            }
        }
        else if (JobbraNyomas && SebessegX < jelenlegiMaximumSebesseg && SebessegX > (jelenlegiMaximumSebesseg - 0.05f))
        {
            SebessegX = jelenlegiMaximumSebesseg;
        }

        Animacio.SetFloat(SebessegZHash, SebessegZ);
        Animacio.SetFloat(SebessegXHash, SebessegX);
    }
}
