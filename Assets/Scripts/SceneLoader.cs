using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        if (GameManager.instance.fading == true)
        {
            PlayerPrefsManager.SetPlayerHealth(PlayerPrefsManager.GetPlayerMaxHealth());
            GameManager.instance.fading = false;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
