using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public float jarakAmbil = 2.5f;
    public NarasiManager narasiManager;
    public TaskManager taskManager;
    public LoopManager loopManager;
    public FadeManager fadeManager;

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
                    if (loopManager.hariKe == 1) {
                        teksTombolE.text = "[E] Buka Pintu (Mulai Jogging)";
                    } else if (loopManager.hariKe == 2) {
                        teksTombolE.text = "[E] Buka Pintu (Paksakan Diri)";
                    } else if (loopManager.hariKe == 3) {
                        teksTombolE.text = "<color=red><b>[E] DOBRAK PINTU! (KABUR!)</b></color>";
                    } else {
                        teksTombolE.text = "[E] Buka Pintu... (Aku Lelah)";
                    }
                } else {
                    if (loopManager.hariKe == 1) {
                        teksTombolE.text = "Persiapan belum selesai.";
                    } else if (loopManager.hariKe == 2) {
                        teksTombolE.text = "Rutinitas ini terasa sangat berat... tapi harus diselesaikan.";
                    } else if (loopManager.hariKe == 3) {
                        teksTombolE.text = "<color=red><b>CEPAT BERSIAP! RUANGAN INI MENCEKIKKU!</b></color>";
                    } else {
                        teksTombolE.text = "Nggak ada gunanya bersiap-siap...";
                    }
                }

                if (Input.GetKeyDown(KeyCode.E) && taskManager.BisaKeluar() && fadeManager.sedangFade == false) {
                    pintu.Interaksi();
                    taskManager.isInKamar = false;
                    taskManager.UpdateUI();
                }

            } else if (barangDilihat != null && fadeManager.sedangFade == false) {
                if (loopManager.hariKe == 3) {
                    teksTombolE.text = "<color=red><b>[E] INTERAKSI!</b></color>";
                } else if (loopManager.hariKe == 4) {
                    barangDilihat.pakaiFade = false;
                } else {
                    teksTombolE.text = "[E] Interaksi";
                }

                if (Input.GetKeyDown(KeyCode.E)) {
                    if (barangDilihat.isBerubahTiapLoop) {
                        if (loopManager.hariKe == 1) {
                            narasiManager.TampilkanTeks(barangDilihat.monologHari1);
                            barangDilihat.Diambil(taskManager);
                        } else if (loopManager.hariKe == 2) {
                            narasiManager.TampilkanTeks(barangDilihat.monologHari2);
                            barangDilihat.Diambil(taskManager);
                        } else if (loopManager.hariKe == 3) {
                            narasiManager.TampilkanTeks(barangDilihat.monologHari3);
                            barangDilihat.Diambil(taskManager);
                        } else {
                            narasiManager.TampilkanTeks(barangDilihat.monologHari4);
                            barangDilihat.Diambil(taskManager);
                        }
                    } else { 
                        narasiManager.TampilkanTeks(barangDilihat.monologBiasa);
                        barangDilihat.Diambil(taskManager);
                    }
                }
            }
        }
    }
}
