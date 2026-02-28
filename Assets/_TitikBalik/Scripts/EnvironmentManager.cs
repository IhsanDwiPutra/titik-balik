using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour {
    [Header("Referensi Cahaya Induk")]
    public Light matahari;

    [Header("Pengaturan Lingkungan (Isi 4 untuk Hari 1-4")]
    public Material[] skyboxPerHari;
    public Color[] warnaMatahari;
    public float[] intensitasMatahari;
    public Color[] warnaKabut;
    public float[] ketebalanKabut;

    //[Header("Objek Terror")]
    //public GameObject pasukanSosokGelap;

    private void Start() {
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
    }

    public void UbahSuasana(int hariKe) {
        int index = hariKe - 1;
        if (index >= 4) index = 3;

        if (skyboxPerHari.Length > 0 && skyboxPerHari[index] != null) {
            RenderSettings.skybox = skyboxPerHari[index];
            DynamicGI.UpdateEnvironment();
        }

        if (matahari != null && warnaMatahari.Length > 0) {
            matahari.color = warnaMatahari[index];
            matahari.intensity = intensitasMatahari[index];
        }

        if (warnaKabut.Length > 0) {
            RenderSettings.fogColor = warnaKabut[index];
            RenderSettings.fogDensity = ketebalanKabut[index];
        }

        //if (hariKe == 3) pasukanSosokGelap.SetActive(true);
        //else pasukanSosokGelap.SetActive(false);
    }



}
