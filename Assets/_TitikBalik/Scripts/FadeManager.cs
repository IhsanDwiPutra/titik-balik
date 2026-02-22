using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeManager : MonoBehaviour
{
    public CanvasGroup layarHitam;
    public TextMeshProUGUI teksDiTengah;
    public float kecepatanFade = 1f;
    public TextMeshProUGUI teksInteraksi;

    [Header("Referensi Pintu")]
    public Transform player;
    public CharacterController playerController;
    public Transform titikLuarKontrakan;

    public void FadeInteraksiBarng(string monolog) { 
        StartCoroutine(ProsesFadeBarang(monolog));
    }

    IEnumerator ProsesFadeBarang(string monolog) {
        while (layarHitam.alpha < 1) {
            layarHitam.alpha += Time.deltaTime * kecepatanFade; yield return null;
        }

        teksInteraksi.enabled = false;
        teksDiTengah.text = monolog;
        yield return new WaitForSeconds(3f);
        teksDiTengah.text = "";
        teksInteraksi.enabled = true;

        while (layarHitam.alpha > 0) {
            layarHitam.alpha -= Time.deltaTime * kecepatanFade; yield return null;
        }
    }

    public void FadePintuKeluar() {
        StartCoroutine(ProsesFadePintu());
    }

    IEnumerator ProsesFadePintu() {
        while (layarHitam.alpha < 1) {
            layarHitam.alpha += Time.deltaTime * kecepatanFade; yield return null;
        }

        teksDiTengah.text = "Pemanasan dulu...\nSemoga lutut aman.";
        playerController.enabled = false;
        player.position = titikLuarKontrakan.position;
        player.rotation = titikLuarKontrakan.rotation;
        playerController.enabled = true;

        yield return new WaitForSeconds(3.5f);
        teksDiTengah.text = "";

        while (layarHitam.alpha > 0) { 
            layarHitam.alpha -= Time.deltaTime * kecepatanFade; yield return null;
        }
    }


}
