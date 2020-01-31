using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextControler : MonoBehaviour
{
    private static GameObject canvas;
    private static FloatingText popupText;
    public static void Initialize()
    {
        if(!popupText)
            popupText = Resources.Load<FloatingText>("Prefabs/PopupTextParent");
        canvas = GameObject.Find("Canvas");
    }
    public static void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupText);
        instance.transform.SetParent(canvas.transform, false);
        Debug.Log(location.position.x);
        instance.SetText(text);
    }
}
