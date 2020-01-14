using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : MonoBehaviour
{
    Vector3 desiredScale = Vector3.zero;

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * 10f);
        if (Input.GetMouseButtonUp(0))
        {
            ActivateMenu(desiredScale == Vector3.zero);
        }
    }

    public void ActivateMenu(bool active)
    {
        desiredScale = active ? Vector3.one : Vector3.zero;
    }
}
