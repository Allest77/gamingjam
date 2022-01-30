using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu2 : MonoBehaviour {
    public GameObject panel;
    public Canvas page;
    bool gameStart;

    public void LoadLevel(int levelIndex) {
        SceneManager.LoadScene("Sam's"); }

    public void DisplayText() {
        page.gameObject.SetActive(true);
        panel.gameObject.SetActive(true); }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("BYE"); 
    } 
}
