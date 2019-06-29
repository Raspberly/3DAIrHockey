using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    //ゲームの状態
    public enum STATE
    {
        START,
        GAME,
        RESULT
    };

    //プレイヤーの番号
    public enum PLAYER
    {
        PLAYER_1 = 0,
        PLAYER_2 = 1
    };
}

/// <summary>
/// ゲーム自体を制御
/// </summary>
public class GameController : MonoBehaviour
{
    //獲得したポイント
    private int[] point=new int[2];
    //ゲームの残り時間
    private float time = 0.0f;
    //ゲームの状態

    //ゲームの時間
    public const float GAME_TIME = 180;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        point[(int)GAME.PLAYER.PLAYER_1] = 0;
        point[(int)GAME.PLAYER.PLAYER_2] = 0;

        time = GAME_TIME;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        time -= 1.0f * Time.deltaTime;


    }

    /// <summary>
    /// ゲーム時間の獲得
    /// </summary>
    /// <returns>現在のゲーム時間を返す</returns>
    public float GetGameTime() { return time; }
}
