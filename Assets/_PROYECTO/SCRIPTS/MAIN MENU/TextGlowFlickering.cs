using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextGlowFlickering : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Update()
    {
        text.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, Random.Range(0.5f, 0.8f));
    }
}
