using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class EnemyRacketController : MonoBehaviour
{
    private EnemyAI _selfAI;
    private Vector3 _moveDistination = Vector3.zero;
    [SerializeField]
    private float _moveSec = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        _selfAI = GetComponent<EnemyAI>();
        var selfPos = this.transform.position;
        _moveDistination = new Vector3(0f, 0f, selfPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        var rate = Time.deltaTime / _moveSec;
        transform.position = Vector3.Lerp(this.transform.position, _moveDistination, rate);
    }

    public void SetMoveDistination(float x, float y) {
        //
        _moveDistination.x = x;
        _moveDistination.y = y;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ball") {
            _selfAI.OnSuccessReceiveShot();
        }
    }

    //ゴールを決められたら呼んでもらう
    private void OnTakenGoal() {
        _selfAI.ResetThinkInterval();
    }
}
