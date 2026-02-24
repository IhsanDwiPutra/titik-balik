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

    public enum JenisBarang { Biasa, Alarm, KipasAngin, Minum, Laptop, Pakaian, Sepatu };
    public JenisBarang jenis;

    [Header("Kipas Angin")]
    public Animator animKipas;

    [Header("Memori Teks (Isi 4 untuk Hari 1-4)")]
    public string[] monologPerhari;

    [Header("Referensi Sistem")]
    public NarasiManager narasiManager;
    public FadeManager fadeManager;
    public LoopManager loopManager;

    public void Diambil(TaskManager taskManager) {
        if (jenis == JenisBarang.Alarm) taskManager.alarmMati = true;
        if (jenis == JenisBarang.KipasAngin) {
            taskManager.kipasMati = !taskManager.kipasMati;
            animKipas.enabled = !taskManager.kipasMati;
        }
        if (jenis == JenisBarang.Minum) taskManager.sudahMinum = true;
        if (jenis == JenisBarang.Laptop) taskManager.cekLaptop = true;
        if (jenis == JenisBarang.Pakaian) taskManager.gantiPakaian = true;
        if (jenis == JenisBarang.Sepatu) taskManager.ambilSepatu = true;

        taskManager.UpdateUI();

        //int indexHari = loopManager.hariKe - 1;

        //if (indexHari >= monologPerhari.Length) indexHari = monologPerhari.Length - 1;
        //string teksHariIni = monologPerhari[indexHari];

        if (pakaiFade) fadeManager.FadeInteraksiBarng(monologBarang);
        if (hilangSetelahDiambil) gameObject.SetActive(false);
    }
}
