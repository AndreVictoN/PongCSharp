using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public SpriteRenderer paddleReference;

    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        SaveController.instance.colorPlayer = paddleReference.color;
    }
}
