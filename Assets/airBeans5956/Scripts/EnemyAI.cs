using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRacketController))]
public class EnemyAI : MonoBehaviour
{
    private EnemyRacketController _racketController;
    private GameObject _targetBall;
    // Start is called before the first frame update
    void Start()
    {
        _racketController = this.GetComponent<EnemyRacketController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_targetBall == null) {
            var tmp = GameObject.FindGameObjectWithTag("Ball");
            if(tmp != null) {
                _targetBall = tmp;
            } else {
                return;
            }
        }

        var targetPos = _targetBall.transform.position;
        _racketController.SetMoveDistination(targetPos.x, targetPos.y);
    }
}
