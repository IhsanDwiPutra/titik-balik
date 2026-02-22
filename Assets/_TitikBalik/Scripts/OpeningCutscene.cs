using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCutscene : MonoBehaviour
{
    [Header("Pengaturan Pemain")]
    public GameObject pemainAsli;
    public GameObject kameraBangun;
    public Image layarHitam;
    public Transform player;
    public CharacterController playerController;
    public Transform titikBangun;
    public GameObject crosshair;

    [Header("Durasi Cutscene")]
    public float durasiCutsene;

    void Start()
    {
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

        Destroy(gameObject);
    }

}
