using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipOpeningScene : MonoBehaviour
{
    [Header("Pengaturan Pemain")]
    public GameObject pemainAsli;
    public GameObject kameraBangun;
    public Image layarHitam;
    public Transform player;
    public CharacterController playerController;
    public Transform titikBangun;
    public GameObject crosshair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            LewatiAnimasi();
        }
    }

    void LewatiAnimasi() {
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

