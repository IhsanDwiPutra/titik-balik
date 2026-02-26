using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeManager : MonoBehaviour
{
    public CanvasGroup layarHitam;
    //public TextMeshProUGUI teksDiTengah;
    public float kecepatanFade = 1f;
    public TextMeshProUGUI teksInteraksi;
    public NarasiManager narasiManager;
    public LoopManager loopManager;

    [Header("Referensi Pintu")]
    public Transform player;
    public CharacterController playerController;
    public Transform titikLuarKontrakan;
    public bool sedangFade = false;

    public void FadeInteraksiBarng() { 
        StartCoroutine(ProsesFadeBarang());
    }

    IEnumerator ProsesFadeBarang() {
        sedangFade =true;
        while (layarHitam.alpha < 1) {
            layarHitam.alpha += Time.deltaTime * kecepatanFade; yield return null;
        }

        teksInteraksi.enabled = false;
        //narasiManager.TampilkanTeks(monolog);
        yield return new WaitForSeconds(3f);
        //teksDiTengah.text = "";
        teksInteraksi.enabled = true;

        while (layarHitam.alpha > 0) {
            layarHitam.alpha -= Time.deltaTime * kecepatanFade; yield return null;
        }
        sedangFade = false;
    }

    public void FadePintuKeluar() {
        StartCoroutine(ProsesFadePintu());
    }

    IEnumerator ProsesFadePintu() {
        //Debug.Log("Fade barang");
        //sedangFade = true;

        while (layarHitam.alpha < 1) {
            layarHitam.alpha += Time.deltaTime * kecepatanFade; yield return null;
        }

        //if (hariKe == 1) teksDiTengah.text = "Pemanasan selesai. Waktunya cari keringat.";
        //else if (hariKe == 2) teksDiTengah.text = "Maksain diri dulu. Ayo jalan.";
        //else if (hariKe == 3) teksDiTengah.text = "Keluarkan aku dari rutinitas gila ini!!";
        //else if (hariKe == 4) teksDiTengah.text = "...Aku lelah.";

        //teksDiTengah.text = "Pemanasan dulu...\nSemoga lutut aman.";
        if (loopManager.hariKe == 1) {
            narasiManager.TampilkanTeks("Pemanasan sebentar... lutut masih agak ngilu. Semoga hari ini larinya lancar.");
        } else if (loopManager.hariKe == 2) {
            narasiManager.TampilkanTeks("Badanku rasanya berat banget... tapi aku harus tetap jalan. Harus kelihatan produktif.");
        } else if (loopManager.hariKe == 3) {
            narasiManager.TampilkanTeks("KELUARKAN AKU DARI KAMAR INI!! CEPAT!!");
        } else if (loopManager.hariKe == 4) {
            narasiManager.TampilkanTeks("...buat apa aku lari lagi?");
        }


        //narasiManager.TampilkanTeks("Pemanasan dulu...\nSemoga lutut aman.");
        playerController.enabled = false;
        player.position = titikLuarKontrakan.position;
        player.rotation = titikLuarKontrakan.rotation;
        playerController.enabled = true;

        yield return new WaitForSeconds(3.5f);
        //teksDiTengah.text = "";

        while (layarHitam.alpha > 0) { 
            layarHitam.alpha -= Time.deltaTime * kecepatanFade; yield return null;
        }
        //sedangFade = false;
    }

    public void FadeLoop() {
        StartCoroutine(ProsesFadeLoop());
    }

    IEnumerator ProsesFadeLoop() {
        while (layarHitam.alpha < 1) {
            layarHitam.alpha += Time.deltaTime * kecepatanFade; yield return null;
        }

        yield return new WaitForSeconds(7f);

        while (layarHitam.alpha > 0) {
            layarHitam.alpha -= Time.deltaTime * kecepatanFade; yield return null;
        }
    }
}
