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
    public Transform player;
    public CharacterController playerController;
    public Transform titikBangun;
    public GameObject crosshair;
    public TaskManager taskManager;
    public TextMeshProUGUI teksTodo;

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
