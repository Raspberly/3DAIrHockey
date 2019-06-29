using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 後ろの壁にあたった際の当たり判定
/// </summary>
public class Goal : MonoBehaviour
{
    //誰がポイントを獲得するか
   [SerializeField]
    private GAME.TARGET pointGetTarget;
    [SerializeField]
    private SystemController systemController;
    //玉がゴールに触れた際のパーティクル
    [SerializeField]
    private GameObject outParticle;
    //ボール
    [SerializeField]
    private GameObject ball;

    void Update()
    {

    }

    /// <summary>
    /// 当たり判定
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit:"+ other.transform.name);
        if (other.tag =="ball")
        {
            Instantiate(outParticle, other.gameObject.transform);
            Destroy(other.gameObject);
            //ポイントを加算
            systemController.SetPoint(pointGetTarget);
            ReStart();
        }
    }

    //再復帰
    void ReStart()
    {
        Instantiate(ball);
    }
    
}
