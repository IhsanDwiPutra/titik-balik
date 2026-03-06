using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuaraLangkah : MonoBehaviour
{
    [Header("Referensi Audio")]
    public AudioSource speakerKaki;
    public AudioClip sfxJalan;
    public AudioClip sfxLari;

    [Header("Pengaturan Tempo (Detik")]
    public float tempoJalan = 0.5f;
    public float tempoLari = 0.3f;

    private float timerLangkah;

    private void Update() {
        float gerakX = Input.GetAxis("Horizontal");
        float gerakZ = Input.GetAxis("Vertical");
        bool sedangJalan = Mathf.Abs(gerakX) > 0.1f || Mathf.Abs(gerakZ) > 0.1f;

        if (sedangJalan) {
            bool sedangLari = Input.GetKey(KeyCode.LeftShift);
            timerLangkah -= Time.deltaTime;

            if (timerLangkah <= 0f) {
                if (sedangLari) {
                    speakerKaki.PlayOneShot(sfxLari);
                    timerLangkah = tempoLari;
                } else {
                    speakerKaki.PlayOneShot(sfxJalan);
                    timerLangkah = tempoJalan;
                }
            }
        } else {
            timerLangkah = 0f;
        }
    }
}
