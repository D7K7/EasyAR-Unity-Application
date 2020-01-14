using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TargetBehavior : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    MeshRenderer videoRenderer;
    float videoRotation;
 
    private void Awake()
    {
        videoRenderer = videoPlayer.GetComponent<MeshRenderer>();
    }

    public void OnVideoChosen(string filePath)
    {
        videoRotation = NativeGallery.GetVideoProperties(filePath).rotation;
        string videoURL = "file://" + filePath;
        videoPlayer.url = filePath;
        videoPlayer.Prepare();
    }

    public float GetRotation()
    {
        return videoRotation;
    }
    public void OnTrackingFound()
    {
        StartCoroutine(TrackingFoundRoutine());
    }

    IEnumerator TrackingFoundRoutine()
    {
        videoRenderer.enabled = false;
        videoPlayer.Play();
        while (!videoPlayer.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        videoRenderer.enabled = true;
    }

    public void OnTrackingLost()
    {
        videoPlayer.Pause();
    }
}
