using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
    public SystemController systemController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 当たり判定
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Hand")
        {
            systemController.RetryInit();
            gameObject.SetActive(false);
        }
    }
}
