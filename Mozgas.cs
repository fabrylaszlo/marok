using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mozgas : MonoBehaviour
{
    public Slider Életcsúszka;

    public static int HealPoti = 0;
    public static int Lelkek = 0;
    public static int FelvettKulcsok = 0;

    float Seta = 2;
    float Futas = 5;
    float ForgásiSebesseg = 500;
    float Forgas = 0f;
    float Gravitacio = 8;
    int AlapUtesHash;
    int UgrasosTamadasHash;
    int GyogyitasHash;

    Vector3 Mozog = Vector3.zero;
    CharacterController controller;
    Animator Animacio;

    public static bool HealHang = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Animacio = GetComponent<Animator>();
        AlapUtesHash = Animator.StringToHash("AlapUtes");
        UgrasosTamadasHash = Animator.StringToHash("UgrasosTamadas");
        GyogyitasHash = Animator.StringToHash("Gyogyitas");
    }

    // Update is called once per frame
    void Update()
    {
        bool alapUtes = Animacio.GetBool(AlapUtesHash);
        bool alapUtesNyomas = Input.GetMouseButtonDown(0);
        bool ugrasosTamadas = Animacio.GetBool(UgrasosTamadasHash);
        bool gyogyitas = Animacio.GetBool(GyogyitasHash);
        bool gyogyitasnyomas = Input.GetKey(KeyCode.G);
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Mozog = new Vector3(0, 0, 1);
                Mozog *= Seta;
                Mozog = transform.TransformDirection(Mozog);

            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                Mozog = new Vector3(0, 0, 1);
                Mozog *= Futas;
                Mozog = transform.TransformDirection(Mozog);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                Mozog = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                Mozog = new Vector3(-1, 0, 0);
                Mozog *= Seta;
                Mozog = transform.TransformDirection(Mozog);
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                Mozog = new Vector3(-1, 0, 0);
                Mozog *= Futas;
                Mozog = transform.TransformDirection(Mozog);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                Mozog = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Mozog = new Vector3(1, 0, 0);
                Mozog *= Seta;
                Mozog = transform.TransformDirection(Mozog);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                Mozog = new Vector3(1, 0, 0);
                Mozog *= Futas;
                Mozog = transform.TransformDirection(Mozog);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                Mozog = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Mozog = new Vector3(0, 0, -1);
                Mozog *= Seta;
                Mozog = transform.TransformDirection(Mozog);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                Mozog = new Vector3(0, 0, 0);
            }

            if (!alapUtes && alapUtesNyomas)
            {
                Animacio.SetBool(AlapUtesHash, true);
            }
            if (alapUtes && !alapUtesNyomas)
            {
                Animacio.SetBool(AlapUtesHash, false);
            }
            if (!ugrasosTamadas && alapUtes && Input.GetKey(KeyCode.Space))
            {
                Animacio.SetBool(UgrasosTamadasHash, true);
                Animacio.SetBool(AlapUtesHash, false);
                Mozog = new Vector3(0, 0, 0);
            }
            if (ugrasosTamadas && !alapUtes && !Input.GetKey(KeyCode.Space))
            {
                Animacio.SetBool(UgrasosTamadasHash, false);
                Mozog = new Vector3(0, 0, 0);
            }
            if (HealPoti >= 1)
            {
                if (!gyogyitas && gyogyitasnyomas)
                {
                    Animacio.SetBool(GyogyitasHash, true);
                      HealPoti--;
                      HealHang = true;
                   Életcsúszka.value += 20; 
                }
            }
            if (gyogyitas && !gyogyitasnyomas)
            {
                Animacio.SetBool(GyogyitasHash, false);
            }
// || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) )
            {
                // Forgas += Input.GetAxis("Horizontal") * ForgásiSebesseg * Time.deltaTime;
                Forgas=45;
                 Mozog = new Vector3(1, 0, 1);
                Mozog *= Seta;
                Mozog = transform.TransformDirection(Mozog);
            }
             if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                // Forgas += Input.GetAxis("Horizontal") * ForgásiSebesseg * Time.deltaTime;
                Forgas=-45;
                 Mozog = new Vector3(-1, 0, 1);
                Mozog *= Seta;
                Mozog = transform.TransformDirection(Mozog);
            }
             if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                // Forgas += Input.GetAxis("Horizontal") * ForgásiSebesseg * Time.deltaTime;
                Forgas=-135;
                 Mozog = new Vector3(-1, 0, -1);
                Mozog *= Seta;
                Mozog = transform.TransformDirection(Mozog);
            }
             if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                // Forgas += Input.GetAxis("Horizontal") * ForgásiSebesseg * Time.deltaTime;
                Forgas=135;
                 Mozog = new Vector3(1, 0, -1);
                Mozog *= Seta;
                Mozog = transform.TransformDirection(Mozog);
            }
        }
        transform.eulerAngles = new Vector3(0, Forgas, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
        Mozog.y -= Gravitacio * Time.deltaTime;
        controller.Move(Mozog * Time.deltaTime);
    }
}
