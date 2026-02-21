using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarasiManager : MonoBehaviour
{
    public TextMeshProUGUI teksUI;
    public float kecepatanKetik = 0.05f;
    public GameObject latarTeks;

    public void TampilkanTeks(string kalimat) {
        StopAllCoroutines();
        latarTeks.SetActive(false);
        StartCoroutine(KetikTeks(kalimat));
    }

    IEnumerator KetikTeks(string kalimat) {
        latarTeks.SetActive(true);
        teksUI.text = "";

        foreach (char huruf in kalimat.ToCharArray()) {
            teksUI.text += huruf;
            yield return new WaitForSeconds(kecepatanKetik);
        }

        yield return new WaitForSeconds(3f);
        latarTeks.SetActive(false);
        teksUI.text = "";
    }


}
