using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuController : MonoBehaviour
{
    public FadeManager fadeManager;
    public LoopManager loopManager;

    public void Interaksi() {
        fadeManager.FadePintuKeluar();
    }
}
