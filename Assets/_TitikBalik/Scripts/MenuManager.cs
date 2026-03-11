using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void MulaiGame() {
        SceneManager.LoadScene("GameLoop");
    }

    public void KeluarGame() {
        Debug.Log("Keluar dari game");
        Application.Quit();
    }
}
