using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRacketController : MonoBehaviour
{

    private Vector3 _moveDistination = Vector3.zero;
    public float moveTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        var selfPos = this.transform.position;
        _moveDistination = new Vector3(0f, 0f, selfPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        var rate = Time.deltaTime / moveTime;
        transform.position = Vector3.Lerp(this.transform.position, _moveDistination, rate);
    }

    public void SetMoveDistination(float x, float y) {
        //
        _moveDistination.x = x;
        _moveDistination.y = y;
    }
}
