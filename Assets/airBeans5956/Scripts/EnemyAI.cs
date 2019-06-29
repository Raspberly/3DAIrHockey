using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRacketController))]
public class EnemyAI : MonoBehaviour
{
    private float thinkInterval = 0.01f;
    [SerializeField]
    private float addThinkIntervalSec = 0.001f;
    private EnemyRacketController _racketController;
    private GameObject _targetBall;

    private List<Vector2> _receivedPositions = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        _racketController = this.GetComponent<EnemyRacketController>();
        StartCoroutine(Think());
        StartCoroutine(RefreshThinkingWithInterval());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSuccessReceiveShot() {
        var tmpPos = new Vector2(this.transform.position.x, this.transform.position.y);
        _receivedPositions.Add(tmpPos);
        if(_receivedPositions.Count >= 2) {
            //打ち返したときのパドル移動距離に応じて反応速度を段々と遅める
            tmpPos = _receivedPositions[0];
            float totalMovements = 0f;
            for(int idx = 1; idx < _receivedPositions.Count; idx++) {
                totalMovements += Vector2.Dot(tmpPos, _receivedPositions[idx]);
                tmpPos = _receivedPositions[idx];
            }
            Debug.Log(totalMovements);
            thinkInterval = totalMovements * 0.01f;
        }
    }

    public void ResetThinkInterval() {
        thinkInterval = 0f;
        _receivedPositions.Clear();
        Debug.Log("Refresh!");
    }

    private IEnumerator Think() {
        if (_targetBall == null) {
            //対象のGameObjectが破棄されていた場合に備える
            _targetBall = null;
            var tmp = GameObject.FindGameObjectWithTag("Ball");
            if (tmp != null) {
                _targetBall = tmp;
            } else {
                _racketController.SetMoveDistination(0f, 0f);
                yield break;
            }
        }

        var targetPos = _targetBall.transform.position;
        _racketController.SetMoveDistination(targetPos.x, targetPos.y);

        yield return new WaitForSeconds(thinkInterval);
        StartCoroutine(Think());
    }

    private IEnumerator RefreshThinkingWithInterval() {
        ResetThinkInterval();

        var refreshRange = Random.Range(5f, 25f);
        yield return new WaitForSeconds(refreshRange);

        StartCoroutine(RefreshThinkingWithInterval());
    }

}
