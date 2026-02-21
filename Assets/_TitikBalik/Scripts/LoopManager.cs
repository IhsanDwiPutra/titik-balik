using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    [Header("Pengaturan Pemain")]
    public Transform player;
    public CharacterController playerController;
    public PlayerMovement playerMovement;
    public Transform titikBangun;

    [Header("Atmosfer & Lingkungan")]
    public Light matahari;
    public GameObject grupPagarNormal;
    public GameObject grupTembokHorror;

    [Header("Narasi Sistem")]
    public NarasiManager narasiManager;

    [Header("Memori Hari")]
    public int hariKe = 1;

    private void Start() {
        UpdateLingkungan();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            hariKe++;
            Debug.Log("Pemain Reset! Sekarang masuk Loop Hari ke: " + hariKe);
            ResetPosisiPemain();
        }
    }

    private void ResetPosisiPemain() {
        playerController.enabled = false;

        player.position = titikBangun.position;
        player.rotation = titikBangun.rotation;

        playerController.enabled = true;

        UpdateLingkungan();
    }

    private void UpdateLingkungan() {
        if (hariKe == 1) {
            matahari.color = Color.white;
            matahari.intensity = 1f;
            playerMovement.speed = 4f;

            grupPagarNormal.SetActive(true);
            grupTembokHorror.SetActive(false);

            narasiManager.TampilkanTeks("Hari ini sama seperti kemarin...");
        } else if (hariKe == 2) {
            matahari.color = Color.gray;
            matahari.intensity = 0.5f;
            playerMovement.speed = 3f;

            narasiManager.TampilkanTeks("Kenapa jalannya terasa lebih jauh?");
        } else if (hariKe == 3) {
            matahari.intensity = 0f;
            playerMovement.speed = 1.5f;

            grupPagarNormal.SetActive(false);
            grupTembokHorror.SetActive(true);

            narasiManager.TampilkanTeks("Aku tidak bisa bernapas... Tolong...");
        }
    }

}
