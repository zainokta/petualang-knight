using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public RawImage image;
    public VideoClip videoToPlay;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;
    
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        
        audioSource = gameObject.AddComponent<AudioSource>();
        
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);
        
        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();
        
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
        
        image.texture = videoPlayer.texture;
        
        videoPlayer.Play();
 
        audioSource.Play();
        
        while (videoPlayer.isPlaying)
        {
            if (Input.anyKey)
                SceneManager.LoadScene(1);
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}