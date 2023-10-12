using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleTransition : MonoBehaviour
{
    private Canvas canvas;
    private Image blackScreen;

    private void Awake(){
        canvas = GetComponent<Canvas>();
        blackScreen = GetComponentInChildren<Image>();
    }

    private void Start(){
        DrawBlackScreen();
    }

    private void DrawBlackScreen(){
        var canvasRect = canvas.GetComponent<RectTransform>();
        var canvasWidth = canvasRect.rect.width;  
        var canvasHeight = canvasRect.rect.height;

        blackScreen.rectTransform.sizeDelta = new Vector2(canvasWidth, canvasHeight);
}

}
