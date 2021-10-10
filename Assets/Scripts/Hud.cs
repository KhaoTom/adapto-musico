using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text interactionText;

    public void ShowInteractionText(string text)
    {
        interactionText.text = text;
    }
}
