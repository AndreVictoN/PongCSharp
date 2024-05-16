using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButtonEnemy : MonoBehaviour
{
    public Button uiButton;
    public SpriteRenderer paddleReferenceEnemy;

    public void OnButtonClick()
    {
        paddleReferenceEnemy.color = uiButton.colors.normalColor;

        SaveController.instance.colorEnemy = paddleReferenceEnemy.color;
    }
}
