using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitikBalik : MonoBehaviour
{
    public NarasiManager narasiManager;

    private void OnTriggerEnter(Collider other) {
        narasiManager.TampilkanTeks("Ternyata... aku hanya perlu berhenti, merelakan, dan berbalik arah");
    }

}
