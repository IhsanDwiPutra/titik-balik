using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitikAkhir : MonoBehaviour
{

    public EndingManager endingManager;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            endingManager.MulaiEnding();
        }
    }


}
