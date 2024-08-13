using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScrollView : MonoBehaviour
{
    public GameObject scrollView; 
    private bool isVisible = false;

    void Start()
    {
        scrollView.SetActive(isVisible);
    }

    public void ToggleVisibility()
    {
        isVisible = !isVisible;
        scrollView.SetActive(isVisible);
    }
}
