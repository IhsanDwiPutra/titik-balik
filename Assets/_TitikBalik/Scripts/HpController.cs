using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : MonoBehaviour
{
    public AudioSource suaraAlarm;
    // Start is called before the first frame update
    void Start()
    {
        suaraAlarm.Play();   
    }

    public void Interaksi() {
        suaraAlarm.Stop();
    }

}
