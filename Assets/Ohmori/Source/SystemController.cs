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
    public enum PLAYER_ID
    {
        PLAYER_1 = 0,
        PLAYER_2 = 1
    };

    //誰が
    public enum TARGET
    {
        YOU,
        ME
    }
}

/// <summary>
/// ゲーム自体を制御
/// </summary>
public class SystemController : MonoBehaviour
{
    //獲得したポイント
    private int[] point=new int[2];
    //ゲームの残り時間
    private float time = 0.0f;
    //ゲームの残り時間
    private float startTime = 0.0f;
    //ゲームの状態
    private GAME.STATE gameState = GAME.STATE.START;
    //自分のプレイヤーID
    private GAME.PLAYER_ID playerId = GAME.PLAYER_ID.PLAYER_1;

    //ゲームの時間
    public const float GAME_TIME = 180;

    //玉
    [SerializeField]
    private GameObject ball;
    //玉の出現場所
    [SerializeField]
    private GameObject createPoint;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        RetryInit();
    }

    /// <summary>
    /// 再挑戦の初期化
    /// </summary>
    public void RetryInit()
    {
        point[(int)GAME.PLAYER_ID.PLAYER_1] = 0;
        point[(int)GAME.PLAYER_ID.PLAYER_2] = 0;

        time = GAME_TIME;
        //TODO フェードインがないのでゲーム状態にする
        gameState = GAME.STATE.START;

        startTime = 0;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        if(gameState == GAME.STATE.START)
        {
            startTime += 1.0f * Time.deltaTime;
            if (startTime > 1.5f)
            {
                gameState = GAME.STATE.GAME;
                Instantiate(ball, createPoint.transform);
            }
        }

        if (gameState != GAME.STATE.GAME) return;

        time -= 1.0f * Time.deltaTime;

        if (time <= 0.0f){
            gameState = GAME.STATE.RESULT;
            time = 0.0f;
        }
    }

    /// <summary>
    /// ゲーム時間の獲得
    /// </summary>
    /// <returns>現在のゲーム時間を返す</returns>
    public float GetGameTime() { return time; }

    /// <summary>
    /// ポイントの獲得
    /// </summary>
    /// <param name="pointGetTarget">ポイントを獲得したユーザー</param>
    public void SetPoint(GAME.TARGET pointGetTarget)
    {
        //自分にポイントが入った
        if (pointGetTarget==GAME.TARGET.ME)
        {
            point[(int)GetMePlayer()] += 1;
            if (point[(int)GetMePlayer()] >= 3) SetSTATE(GAME.STATE.RESULT);
        }
        //相手にポイントが入った
        else
        {
            point[(int)GetYouPlayer()] += 1;
            if (point[(int)GetYouPlayer()] >= 3) SetSTATE(GAME.STATE.RESULT);
        }
        
    }

    /// <summary>
    /// 自分のプレイヤーIDを返す
    /// </summary>
    /// <returns></returns>
    public GAME.PLAYER_ID GetMePlayer(){ return playerId; }

    /// <summary>
    /// 相手のプレイヤーIDを返す
    /// </summary>
    /// <returns></returns>
    public GAME.PLAYER_ID GetYouPlayer()
    {
        if (playerId == GAME.PLAYER_ID.PLAYER_2) return GAME.PLAYER_ID.PLAYER_1;
        return GAME.PLAYER_ID.PLAYER_2;
    }

    /// <summary>
    /// 今の自分のポイント
    /// </summary>
    public int GetMePoint(){ return point[(int)GetMePlayer()]; }

    public int GetPoint (int num) { return point[num]; }

    /// <summary>
    /// 今のゲームの状態
    /// </summary>
    public GAME.STATE GetSTATE () { return gameState; }
    public void SetSTATE (GAME.STATE state) { gameState = state; }
}
