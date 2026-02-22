using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Barang : MonoBehaviour
{
    [Header("Pengaturan Interaksi")]
    public string monologBarang = "Ini barang.";
    public bool hilangSetelahDiambil = false;

    [Tooltip("Centang kalau barang ini butuh waktu/layar gelap")]
    public bool pakaiFade = false;

    public enum JenisBarang { Biasa, Alarm, Minum, Laptop, Sepatu };
    public JenisBarang jenis;
    public FadeManager fadeManager;


    public void Diambil(TaskManager taskManager) {
        if (jenis == JenisBarang.Alarm) taskManager.alarmMati = true;
        if (jenis == JenisBarang.Minum) taskManager.sudahMinum = true;
        if (jenis == JenisBarang.Laptop) taskManager.cekLaptop = true;
        if (jenis == JenisBarang.Sepatu) taskManager.ambilSepatu = true;

        taskManager.UpdateUI();

        if (pakaiFade) {
            //fadeManager.FadeInteraksiBarng(monologBarang);
        }

        if (hilangSetelahDiambil) {
            gameObject.SetActive(false);
        }
    }
}
