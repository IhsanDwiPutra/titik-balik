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

    [Header("Teks barang")]
    string t1;
    string t2;
    string t3;
    string t4;
    string t5;
    string t6;

    [Header("Reset Looping")]
    public GameObject[] daftarBarang;
    public GameObject pintuKontrakan;

    [Header("Anim Kipas Angin")]
    public Animator animKipas;

    [Header("Status Pemain")]
    public bool isInKamar = true;
    public LoopManager loopManager;

    public bool BisaKeluar() {
        if (loopManager.hariKe == 4) return true;
        else { 
            return alarmMati && sudahMinum && cekLaptop && ambilSepatu && kipasMati && gantiPakaian;
        }
    }

    public void UpdateUI() {
        if (loopManager.hariKe == 1) {
            t1 = alarmMati ? "<s>1. Matikan alarm</s>" : "1. Matikan alarm";
            t2 = kipasMati ? "<s>2. Matikan kipas angin</s>" : "2. Matikan kipas angin";
            t3 = sudahMinum ? "<s>3. Minum air</s>" : "3. Minum air";
            t4 = cekLaptop ? "<s>4. Cek laptop</s>" : "4. Cek Laptop";
            t5 = gantiPakaian ? "<s>5. Ganti pakaian</s>" : "5. Ganti pakaian";
            t6 = ambilSepatu ? "<s>6. Ambil sepatu</s>" : "6. Ambil sepatu";
        } else if (loopManager.hariKe == 2) {
            t1 = alarmMati ? "<s>1. Matikan suara bising itu</s>" : "1. Matikan suara bising itu";
            t2 = kipasMati ? "<s>2. Matikan putaran pusing itu</s>" : "2. Matikan putaran pusing itu";
            t3 = sudahMinum ? "<s>3. Tenggorokanku kering</s>" : "3. Tenggorokanku kering";
            t4 = cekLaptop ? "<s>4. Beban tugas lagi</s>" : "4. Beban tugas lagi";
            t5 = gantiPakaian ? "<s>5. Jaket ini berat sekali</s>" : "5. Jaket ini berat sekali";
            t6 = ambilSepatu ? "<s>6. Paksa kakimu melangkah</s>" : "6. Paksa kakimu melangkah";
        } else if (loopManager.hariKe == 3) {
            t1 = alarmMati ? "<s><color=red><b>1. HANCURKAN ALARM!</b></color></s>" : "<color=red><b>1. HANCURKAN ALARM!</b></color>";
            t2 = kipasMati ? "<s><color=red><b>2. HENTIKAN SUARA ITU!</b></color></s>" : "<color=red><b>2. HENTIKAN SUARA ITU!</b></color>";
            t3 = sudahMinum ? "<s><color=red><b>3. AKU TERCEKIK!</b></color></s>" : "<color=red><b>3. AKU TERCEKIK!</b></color>";
            t4 = cekLaptop ? "<s><color=red><b>4. JANGAN TATAP LAYARNYA!</b></color></s>" : "<color=red><b>4. JANGAN TATAP LAYARNYA!</b></color>";
            t5 = gantiPakaian ? "<s><color=red><b>5. KULITKU PANAS!</b></color></s>" : "<color=red><b>5. KULITKU PANAS!</b></color>";
            t6 = ambilSepatu ? "<s><color=red><b>6. KAKIKU HANCUR!</b></color></s>" : "<color=red><b>6. KAKIKU HANCUR!</b></color>";
        } else {
            t1 = "LARI";
            t2 = "LARI";
            t3 = "LARI";
            t4 = "LARI";
            t5 = "LARI";
            t6 = "LARI";
        }

        if (isInKamar) {
            if (loopManager.hariKe == 1) {
                teksTodoList.text = "<b>Persiapan Jogging:</b>\n" + t1 + "\n" + t2 + "\n" + t3 + "\n" + t4 + "\n" + t5 + "\n" + t6;
            } else if (loopManager.hariKe == 2) {
                teksTodoList.text = "<b>Rutinitas Berat:</b>\n" + t1 + "\n" + t2 + "\n" + t3 + "\n" + t4 + "\n" + t5 + "\n" + t6;
            } else if (loopManager.hariKe == 3) {
                teksTodoList.fontSize = 38;
                teksTodoList.text = "<color=red><b>MEREKA MENGHAKIMIMU:</b></color>\n" + t1 + "\n" + t2 + "\n" + t3 + "\n" + t4 + "\n" + t5 + "\n" + t6;
            } else {
                teksTodoList.fontSize = 40;
                teksTodoList.text = "<b>ERROR</b>\n" + t1 + "\n" + t2 + "\n" + t3 + "\n" + t4 + "\n" + t5 + "\n" + t6;
            }
        } else {
            if (loopManager.hariKe == 3) {
                teksTodoList.fontSize = 38;
                teksTodoList.text = "<color=red><b>Jogging sampai ke gerbang</b></color>";
            } else { 
                teksTodoList.text = "Jogging sampai ke gerbang";
            }
        }
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
