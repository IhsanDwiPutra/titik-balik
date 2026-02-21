using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GelasController : MonoBehaviour
{
    public Image layarHitam;

    public void Interaksi() {
        layarHitam.gameObject.SetActive(true);
        StartCoroutine(Minum());
    }

    IEnumerator Minum() {
        layarHitam.CrossFadeAlpha(0, 3f, false);

        yield return new WaitForSeconds(3f);
    }

}
