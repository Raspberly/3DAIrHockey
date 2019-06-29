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

    /// <summary>
    /// 当たり判定
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag =="ball")
        {
            Instantiate(outParticle, other.gameObject.transform);
            Destroy(other.gameObject);
            //ポイントを加算
            systemController.SetPoint(pointGetTarget);
        }
    }
}
