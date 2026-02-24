using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JalanBelakang : MonoBehaviour
{
    public GameObject kamarPlayer;
    public GameObject jalanBelakang;
    public GameObject penghalang;

    private void Start() {
        kamarPlayer.SetActive(true);
        jalanBelakang.SetActive(false);
        penghalang.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        kamarPlayer.SetActive(false);
        penghalang.SetActive(true);
        jalanBelakang.SetActive(true);
    }

}
