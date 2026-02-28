using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JalanBelakang : MonoBehaviour
{
    public GameObject kamarPlayer;
    public GameObject jalanBelakang;
    public GameObject penghalang;
    public GameObject titikTengahJalan;
    public NarasiManager narasiManager;
    public GameObject dindingBelakang;
    public GameObject progressJalan;

    private void Start() {
        kamarPlayer.SetActive(true);
        jalanBelakang.SetActive(false);
        penghalang.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        kamarPlayer.SetActive(false);
        penghalang.SetActive(true);
        jalanBelakang.SetActive(true);
        titikTengahJalan.SetActive(false);
        dindingBelakang.SetActive(false);
        progressJalan.SetActive(false);

        narasiManager.TampilkanTeks("Buntu?! Tembok apa ini... 'EKSPEKTASI'? Jadi selama ini aku berlari cuma buat nabrak ini?");
    }

}
