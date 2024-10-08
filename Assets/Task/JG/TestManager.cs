using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject raisPanel;

    public void OnClickRais()
    {
        raisPanel.SetActive(!raisPanel.activeInHierarchy);
    }
}
