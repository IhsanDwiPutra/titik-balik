using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCutscene : MonoBehaviour {
    [Header("Pengaturan Pemain")]
    public GameObject pemainAsli;
    public GameObject kameraBangun;
    public Image layarHitam;
    public Image layarHitam2;
    public Transform player;
    public CharacterController playerController;
    public Transform titikBangun;
    public GameObject crosshair;
    public TaskManager taskManager;
    public TextMeshProUGUI teksTodo;
    public TextMeshProUGUI teksChapter;

    [Header("Durasi Cutscene")]
    public float durasiCutsene;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(false);


        pemainAsli.SetActive(false);
        kameraBangun.SetActive(true);
        layarHitam.gameObject.SetActive(true);

        StartCoroutine(BangunTidur());
        
    }

    IEnumerator BangunTidur() {
        teksChapter.text = "Hari 1";
        yield return new WaitForSeconds(3f);
        Debug.Log("Hilang");
        teksChapter.gameObject.SetActive(false);

        layarHitam.CrossFadeAlpha(0, 3f, false);

        yield return new WaitForSeconds(durasiCutsene);

        playerController.enabled = false;
        player.position = titikBangun.position;
        player.rotation = titikBangun.rotation;
        playerController.enabled = true;

        pemainAsli.SetActive(true);
        kameraBangun.SetActive(false);
        layarHitam.gameObject.SetActive(false);
        crosshair.SetActive(true);
        taskManager.UpdateUI();

        gameObject.SetActive(false);
    }

    public void PutarUlangCutscene(int hariKe) {
        StopAllCoroutines();
        StartCoroutine(ProsesCutsceneUlang(hariKe));
    }

    private System.Collections.IEnumerator ProsesCutsceneUlang(int hariKe) {
        teksChapter.gameObject.SetActive(true);
        if (hariKe == 2) teksChapter.text = "Hari 2";
        else if (hariKe == 3) teksChapter.text = "Hari 3";
        else teksChapter.text = "Hari 4";

        yield return new WaitForSeconds(3f);
        teksChapter.gameObject.SetActive(false);

        pemainAsli.SetActive(false);
        kameraBangun.SetActive(true);
        teksTodo.gameObject.SetActive(false);
        if (crosshair != null) { 
            crosshair.SetActive(false);
        }

        Animator anim = kameraBangun.GetComponent<Animator>();
        if (anim != null) {

            anim.Play("BangunTidur", -1, 0f);
        }

        yield return new WaitForSeconds(durasiCutsene);
        kameraBangun.SetActive(false);
        pemainAsli.SetActive(true);
        teksTodo.gameObject.SetActive(true);
        if (crosshair != null) crosshair.SetActive(true);

    }

}
