using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private AudioSource source;
    [HideInInspector] public bool isDashing;
    [HideInInspector] public bool fading;
    [HideInInspector] public bool dashUnlock;
    [HideInInspector] public float dashCooldown = 0.3f;
    [HideInInspector] public float potionCooldown = 0.1f;
    public AudioClip clip;

    void Awake ()
    {
		if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Gold"))
        {
            PlayerPrefsManager.SetPlayerGold(2500);
        }
        if(!PlayerPrefs.HasKey("Moon Stone"))
        {
            PlayerPrefsManager.SetPlayerMoonStone(1);
        }
        if (!PlayerPrefs.HasKey("Unlock"))
        {
            PlayerPrefsManager.SetDashBool(0);
        }
    }
    private void Update()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Gameplay")
            source = GameObject.Find("SFX").GetComponent<AudioSource>();

        dashUnlock = Convert.ToBoolean(PlayerPrefsManager.GetDashBool());
        Debug.Log(PlayerPrefsManager.GetPlayerDamage());
    }
    public void PlayAudio(AudioClip aClip)
    {
        source.clip = aClip;
        source.Play();
    }
}
