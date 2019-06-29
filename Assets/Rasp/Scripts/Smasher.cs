using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Smasher : MonoBehaviour
{
    public Transform smaherTransform;
    public Transform touchR;
    public Transform touchL;
    public Transform cameraRig;

    public TMP_Text debugText;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(touchR.position, touchL.position);
        //debugText.text = distance.ToString();
        //Debug.Log(distance);
        smaherTransform.position = (touchR.transform.position + touchL.transform.position) * 0.5f;
        smaherTransform.rotation = Quaternion.Lerp(touchR.rotation, touchL.rotation, 0.5f);
        //smaherTransform.rotation.eulerAngles = new Vector3(touchR.transform.rotation.eulerAngles + touchL.transform.rotation.eulerAngles) * 0.5f;
        smaherTransform.localScale = new Vector3(distance, distance, 1);
    }
}
