using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set;}
    private void Awake() {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    public void LoadScene(int buildIndex) {
        SceneManager.LoadScene(buildIndex);
    }

    public void Quit() {
        Application.Quit();
    }
}
