using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography.X509Certificates;

public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI teksTodoList;

    [Header("Status Tugas")]
    public bool alarmMati = false;
    public bool kipasMati = false;
    public bool sudahMinum = false;
    public bool cekLaptop = false;
    public bool gantiPakaian = false;
    public bool ambilSepatu = false;

    [Header("Reset Looping")]
    public GameObject[] daftarBarang;
    public GameObject pintuKontrakan;

    [Header("Anim Kipas Angin")]
    public Animator animKipas;

    public bool BisaKeluar() { 
        return alarmMati && sudahMinum && cekLaptop && ambilSepatu && kipasMati && gantiPakaian;
    }

    public void UpdateUI() {
        string t1 = alarmMati ? "<s>1. Matikan alarm</s>" : "1. Matikan alarm";
        string t2 = kipasMati ? "<s>2. Matikan kipas angin</s>" : "2. Matikan kipas angin";
        string t3 = sudahMinum ? "<s>3. Minum air</s>" : "3. Minum air";
        string t4 = cekLaptop ? "<s>4. Cek laptop</s>" : "4. Cek Laptop";
        string t5 = gantiPakaian ? "<s>5. Ganti pakaian</s>" : "5. Ganti pakaian";
        string t6 = ambilSepatu ? "<s>6. Ambil sepatu</s>" : "6. Ambil sepatu";

        teksTodoList.text = "<b>Persiapan Jogging:</b>\n" + t1 + "\n" + t2 + "\n" + t3 + "\n" + t4 + "\n" + t5 + "\n" + t6;
    }

    public void ResetTugas() {
        alarmMati = false;
        kipasMati = false;
        sudahMinum = false;
        cekLaptop = false;
        gantiPakaian = false;
        ambilSepatu = false;
        animKipas.enabled = true;

        foreach (GameObject barang in daftarBarang) {
            if (barang != null) {
                barang.SetActive(true);
            }
        }

        if (pintuKontrakan != null) {
            pintuKontrakan.SetActive(true);
        }

        UpdateUI();
    }

}
