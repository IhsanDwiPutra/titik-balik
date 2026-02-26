using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoopManager : MonoBehaviour
{
    [Header("Pengaturan Pemain")]
    public Transform player;
    public CharacterController playerController;
    public PlayerMovement playerMovement;
    public Transform titikBangun;
    public GameObject playerAsli;
    public OpeningCutscene openingCutscene;
    public TaskManager taskManager;
    public Image crosshair;

    [Header("Sistem Cutscene")]
    public OpeningCutscene scriptCutscene;
    public FadeManager fadeManager;

    [Header("Atmosfer & Lingkungan")]
    public Light matahari;
    public GameObject grupPagarNormal;
    public GameObject grupTembokHorror;
    public GameObject kamar;
    public GameObject jalanBelakang;
    public GameObject pagarDepan;

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
            StartCoroutine(ResetPosisiPemain());

            //openingCutscene.Bangun();
        }
    }

    IEnumerator ResetPosisiPemain() {
        fadeManager.FadeLoop();
        taskManager.isInKamar = true;
        yield return new WaitForSeconds(3f);


        playerController.enabled = false;
        player.position = titikBangun.position;
        player.rotation = titikBangun.rotation;
        playerController.enabled = true;

        scriptCutscene.gameObject.SetActive(true);
        scriptCutscene.PutarUlangCutscene(hariKe);

        taskManager.ResetTugas();
        
        UpdateLingkungan();
    }

    private void UpdateLingkungan() {
        if (hariKe == 1) {
            matahari.color = Color.white;
            matahari.intensity = 1f;
            playerMovement.jalan = 4f;
            playerMovement.lari = 5f;

            //grupPagarNormal.SetActive(true);
            //grupTembokHorror.SetActive(false);

            narasiManager.TampilkanTeks("Hari ini sama seperti kemarin...");
        } else if (hariKe == 2) {
            matahari.color = Color.gray;
            matahari.intensity = 0.5f;
            playerMovement.jalan = 3f;
            playerMovement.lari = 4f;

            narasiManager.TampilkanTeks("Kenapa rasanya lelah sekali... padahal baru membuka mata.");
        } else if (hariKe == 3) {
            narasiManager.kecepatanKetik = 0;
            narasiManager.teksUI.color = Color.red;
            narasiManager.teksUI.fontStyle = FontStyles.Bold;
            narasiManager.teksUI.fontSize = 50;
            crosshair.color = Color.red;

            pagarDepan.SetActive(false);
            matahari.intensity = 0f;
            playerMovement.jalan = 1f;
            playerMovement.lari = 2f;

            //grupPagarNormal.SetActive(false);
            grupTembokHorror.SetActive(true);

            narasiManager.TampilkanTeks("Napas... Sesak... Udara di kamar ini habis...");
        } else if (hariKe == 4) { 
            narasiManager.teksUI.color = Color.white;
            narasiManager.teksUI.fontSize = 36;
            narasiManager.teksUI.fontStyle = FontStyles.Normal;
            narasiManager.kecepatanKetik = 0.04f;
            crosshair.color = Color.white;

            grupTembokHorror.SetActive(false);
            pagarDepan.SetActive(true);
            jalanBelakang.SetActive(true);
        }
    }

}
