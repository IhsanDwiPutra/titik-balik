using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    [Header("UI Ending")]
    public CanvasGroup panelPutih;
    public TextMeshProUGUI teksJudul;

    [Header("Pengaturan")]
    public float kecepatanFade = 0.5f;
    public string namaSceneMainMenu = "MainMenu";

    private bool endingMulai = false;

    public void MulaiEnding() {
        if (!endingMulai) {
            endingMulai = true;
            StartCoroutine(ProsesEndingDramatis());
        }
    }

    IEnumerator ProsesEndingDramatis() {
        while (panelPutih.alpha < 1) {
            panelPutih.alpha += Time.deltaTime * kecepatanFade;
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        while (teksJudul.color.a < 1) { 
            float alphaBaru = teksJudul.color.a + (Time.deltaTime * kecepatanFade);
            teksJudul.color = new Color(teksJudul.color.r, teksJudul.color.g, teksJudul.color.b, alphaBaru);
            yield return null;
        }

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(namaSceneMainMenu);
    }
}
