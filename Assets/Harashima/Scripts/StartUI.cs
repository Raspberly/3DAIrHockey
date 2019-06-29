using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public GameObject startUI;
    private bool isStart = true;

    [SerializeField]
    private float speed = 10f;

    void Update() {
        startUI.transform.Translate(Vector3.right * (-1) * Time.deltaTime * speed);
    }

    /*
    public void DisplayStartUI() {
        Color color = startText.color;
        color.a = color.a <= 0 ? 1 : color.a - 0.01f;
        startText.color = color;
        if (color.a == 0) isStart = false;
    }*/
}
