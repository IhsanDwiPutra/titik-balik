using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TatapanEkspektasi : MonoBehaviour
{
    public Transform targetPemain;

    [Header("Pengaturan Menoleh")]
    public float kecepatanMenoleh = 5f;

    //private void Start() {
    //    GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

    //    if (playerObj != null) {
    //        targetPemain = playerObj.transform;
    //        Debug.Log("Pemain ditemukan");
    //    } else {
    //        Debug.Log("Pemain tidak ditemukan");
    //    }
    //}

    private void Update() {
        if (targetPemain != null) {
            Vector3 arahPemain = targetPemain.position - transform.position;
            arahPemain.y = 0;

            if (arahPemain != Vector3.zero) {
                Quaternion rotasiBaru = Quaternion.LookRotation(arahPemain);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotasiBaru, kecepatanMenoleh * Time.deltaTime);
            }
        }
    }
}
