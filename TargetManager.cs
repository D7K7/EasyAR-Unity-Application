using System.Collections;
using System.Collections.Generic;
using easyar;
using UnityEngine;


public class TargetManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public ImageTrackerBehaviour trackerBehavior;

    public void CreateNewTarget(string filePath)
    {
        GameObject target = Instantiate(targetPrefab);
        ImageTargetController controller = target.GetComponent<ImageTargetController>();
        controller.Type = PathType.Absolute;
        controller.TargetPath = filePath;
        controller.ImageTracker = trackerBehavior;
    }
}
