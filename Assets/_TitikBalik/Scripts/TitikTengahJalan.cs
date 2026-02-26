using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitikTengahJalan : MonoBehaviour
{
    public NarasiManager narasiManager;
    public LoopManager loopManager;

    private void OnTriggerEnter(Collider other) {
        if (loopManager.hariKe == 1) {
            narasiManager.TampilkanTeks("Jalannya selalu sama... lurus tanpa ujung. Seenggaknya udara pagi lumayan bikin pikiran agak jernih dari coding-an.");
        } else if (loopManager.hariKe == 2) {
            narasiManager.TampilkanTeks("Aneh... kenapa jalan ini terasa makin panjang? Lututku mulai nyeri lagi... Sama kayak ekspektasi orang-orang, rasanya seberat langkah ini.");
        } else if (loopManager.hariKe == 3) {
            narasiManager.TampilkanTeks("MEREKA TERUS MENUNTUTKU! Tembok ini menghimpitku! Tolong... Aku cuma lari di tempat!");
        } else if (loopManager.hariKe == 4) {
            narasiManager.TampilkanTeks("Lari sejauh apapun... memaksakan diri sekeras apapun... aku tidak pernah sampai ke mana-mana");
        }

    }

}
