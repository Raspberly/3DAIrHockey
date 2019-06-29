using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの残り時間
/// </summary>
public class GameTimer : MonoBehaviour
{
    //ゲームマネージャー
    [SerializeField]
    private SystemController systemController;

    //時間表示
    [SerializeField]
    private TextMesh gameTimer;

    // Start is called before the first frame update
    void Start(){
        TimeTextSet();
    }

    // Update is called once per frame
    void Update()
    {
        TimeTextSet();
    }

    /// <summary>
    /// テキストを今の時間にする
    /// </summary>
    private void TimeTextSet()
    {
        int time = (int)systemController.GetGameTime();
        int minutes=time / 60;
        gameTimer.text = string.Format("{0:D2}:{1:D2}", minutes, time - minutes*60);
    }
}
