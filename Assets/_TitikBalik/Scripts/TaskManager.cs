using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI teksTodoList;

    [Header("Status Tugas")]
    public bool alarmMati = false;
    public bool sudahMinum = false;
    public bool cekLaptop = false;
    public bool gantiPakaian = false;
    public bool ambilSepatu = false;

    private void Start() {
        UpdateUI();
    }

    public bool BisaKeluar() { 
        return alarmMati && sudahMinum && cekLaptop && ambilSepatu;
    }

    public void UpdateUI() {
        string t1 = alarmMati ? "<s>1. Matikan alarm</s>" : "1. Matikan alarm";
        string t2 = sudahMinum ? "<s>2. Minum air</s>" : "2. Minum air";
        string t3 = cekLaptop ? "<s>3. Cek laptop</s>" : "3. Cek Laptop";
        string t4 = ambilSepatu ? "<s>4. Ambil sepatu</s>" : "4. Ambil sepatu";

        teksTodoList.text = "<b>Persiapan Jogging:</b>\n" + t1 + "\n" + t2 + "\n" + t3 + "\n" + t4; ;
    }

}
