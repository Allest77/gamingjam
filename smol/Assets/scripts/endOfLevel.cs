using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endOfLevel : MonoBehaviour {
    public gameManager manageGame;

    void OnTriggerEnter() {
        manageGame.CompleteLevel();
        StartCoroutine("TakeMeBack");
    }

    IEnumerator TakeMeBack() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main Menu");
    }
}
