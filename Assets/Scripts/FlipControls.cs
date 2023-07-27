using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipControls : MonoBehaviour
{
    [SerializeField] private GameObject controlsToShow;
    [SerializeField] private GameObject controlsToHide;

    public void ToggleControls()
    {
        controlsToHide.SetActive(false);
        controlsToShow.SetActive(true);
    }
}
