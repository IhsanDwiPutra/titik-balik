using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarasiManager : MonoBehaviour
{
    public TextMeshProUGUI teksUI;
    public float kecepatanKetik = 0.05f;
    public float jedaTeks = 3f;

    public void TampilkanTeks(string kalimat) {
        StopAllCoroutines();
        StartCoroutine(KetikTeks(kalimat));
    }

    IEnumerator KetikTeks(string kalimat) {
        teksUI.text = "";

        foreach (char huruf in kalimat.ToCharArray()) {
            teksUI.text += huruf;
            yield return new WaitForSeconds(kecepatanKetik);
        }

        yield return new WaitForSeconds(jedaTeks);
        teksUI.text = "";
    }


}
