using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressJalan : MonoBehaviour
{
    [Header("UI & Pemain")]
    public Slider progressBar;
    public Image warnaProgress;
    public Transform pemain;
    public LoopManager loopManager;

    [Header("Titik Acuan")]
    public Transform titikMulai;
    public Transform titikGerbang;

    private float jarakTotal;

    private void Start() {
        if (titikMulai != null & titikMulai != null) {
            jarakTotal = Vector3.Distance(titikMulai.position, titikGerbang.position);
            progressBar.minValue = 0;
            progressBar.maxValue = 1;
        }
    }

    private void Update() {
        if (pemain == null || titikMulai == null || titikGerbang == null) return;

        float jarakSekarang = Vector3.Distance(pemain.position, titikGerbang.position);
        float progress = 1f - (jarakSekarang / jarakTotal);

        progressBar.value = Mathf.Clamp01(progress);

        if (loopManager.hariKe == 3) warnaProgress.color = Color.red;
        else warnaProgress.color = Color.white;
    }


}
