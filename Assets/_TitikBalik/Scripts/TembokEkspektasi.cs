using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TembokEkspektasi : MonoBehaviour
{
    public NarasiManager NarasiManager;
    public GameObject spawnJalanBelakang;


    private void OnTriggerEnter(Collider other) {
        spawnJalanBelakang.SetActive(false);
        NarasiManager.TampilkanTeks("Nggak bisa tembus. Semakin keras aku paksa maju, rasanya makin hancur. Lari terus-menerus memaksakan diri ternya bukan jawabannya...");
    }
}
