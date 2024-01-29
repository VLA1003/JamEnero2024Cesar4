using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public bool isClicked = false;
    public GameObject muteButton;
    public AudioMixer audioMixer;

    private void Start()
    {
        isClicked = false;
        muteButton.GetComponent<Image>().color = Color.grey;
    }

    public void ButtonToggle()
    {
        if (isClicked)
        {
            isClicked = false;
            muteButton.GetComponent<Image>().color = Color.grey;
            audioMixer.SetFloat("MasterVolume", 0);
        }
        else
        {
            isClicked = true;
            muteButton.GetComponent<Image>().color = new Color32(18, 255, 0, 255);
            audioMixer.SetFloat("MasterVolume", -80);
        }
    }
}
