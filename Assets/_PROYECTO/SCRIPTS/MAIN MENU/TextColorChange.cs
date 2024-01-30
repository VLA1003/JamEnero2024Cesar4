using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class TextColorChange : MonoBehaviour
{
    public TextMeshProUGUI playText;
    public TextMeshProUGUI exitText;
    public TextMeshProUGUI creditText;
    public TextMeshProUGUI backText;

    public void PlayTextWhite()
    {
        playText.color = Color.white;
    }

    public void PlayTextBlack()
    {
        playText.color = Color.black;
    }

    public void ExitTextWhite()
    {
        exitText.color = Color.white;
    }

    public void ExitTextBlack()
    {
        exitText.color = Color.black;
    }

    public void CreditTextWhite()
    {
        creditText.color = Color.white;
    }

    public void CreditTextBlack()
    {
        creditText.color = Color.black;
    }

    public void BackTextWhite()
    {
        backText.color = Color.white;
    }

    public void BackTextBlack()
    {
        backText.color = Color.black;
    }
}
