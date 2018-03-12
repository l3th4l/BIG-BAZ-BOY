using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject continueButton;

    private void Start()
    {
        this.continueButton.SetActive(CheckpointManager.HasSave);
    }
}