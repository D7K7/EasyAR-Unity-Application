using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaPicker : MonoBehaviour
{
    public TargetManager targetManager;

    public void ChooseImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                targetManager.CreateNewTarget(path);
            }
        }, "Select a PNG image");
    }

    public void ChooseVideo()
    {
        NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) =>
        {
            
            TargetBehavior target = FindObjectOfType<TargetBehavior>();
            if (path != null && target != null)
            {
                target.OnVideoChosen(path);
            }
        }, "Select a video'");
    }
}
