using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuController : MonoBehaviour
{
    //private Animator anim;
    //private bool isOpen = false;
    //public string teksMonolog = "Jogging dulu ah";
    public FadeManager fadeManager;

    private void Start() {
        //anim = GetComponent<Animator>();
    }

    public void Interaksi() {
        //isOpen = !isOpen;
        //anim.SetBool("isBuka", isOpen);
        fadeManager.FadePintuKeluar();
    }
}
