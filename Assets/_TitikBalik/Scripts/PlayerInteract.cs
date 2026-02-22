using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public float jarakAmbil = 2.5f;
    public NarasiManager narasiManager;
    public TaskManager taskManager;

    [Header("UI Bantuan")]
    public TextMeshProUGUI teksTombolE;

    private void Update() {
        Ray laserGaib = new Ray(transform.position, transform.forward);
        RaycastHit sasaran;
        teksTombolE.text = "";

        if (Physics.Raycast(laserGaib, out sasaran, jarakAmbil)) {
            PintuController pintu = sasaran.collider.GetComponent<PintuController>();
            Barang barangDilihat = sasaran.collider.GetComponent<Barang>();

            if (pintu != null) {
                if (taskManager.BisaKeluar()) {
                    teksTombolE.text = "[E] Buka Pintu (Mulai Jogging)";
                } else {
                    teksTombolE.text = "Selesaikan persiapan dulu!";
                }

                if (Input.GetKeyDown(KeyCode.E) && taskManager.BisaKeluar()) {
                    pintu.Interaksi();
                }

            } else if (barangDilihat != null) {
                teksTombolE.text = "[E] Interaksi";

                if (Input.GetKeyDown(KeyCode.E)) {
                    narasiManager.TampilkanTeks(barangDilihat.monologBarang);
                    barangDilihat.Diambil(taskManager);

                }
            }
        }
    }
}
