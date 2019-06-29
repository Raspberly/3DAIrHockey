using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResultWindow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SystemController systemController;
    public GameObject winImage;
    public GameObject loseImage;

    private bool onResult = false;

    void Start ()
    {
        onResult = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if(!onResult)
        {

            //マッチポイントの場合
            if(systemController.GetPoint((int) GAME.TARGET.YOU) >= 3)
            {
                Win();
                return;
            }
            else if(systemController.GetPoint((int) GAME.TARGET.ME) >= 3)
            {
                Lose();
                return;
            }


            //時間切れの場合
            if(systemController.GetSTATE() == GAME.STATE.RESULT)
            {
                if(systemController.GetPoint((int)GAME.TARGET.YOU) >= systemController.GetPoint((int) GAME.TARGET.ME))
                {
                    Win();
                }
                else 
                {
                    Lose();
                }
            }

        }
    }



    void Win ()
    {
        onResult = true;
        if(systemController.GetSTATE() != GAME.STATE.RESULT)
        {
            //systemController.SetSTATE(GAME.STATE.RESULT);
        }
        winImage.transform.DOScale(new Vector3(1, 1), 0.5f);
    }

    void Lose ()
    {
        onResult = true;
        if(systemController.GetSTATE() != GAME.STATE.RESULT)
        {
            //systemController.SetSTATE(GAME.STATE.RESULT);
        }
        loseImage.transform.DOScale(new Vector3(1, 1), 0.5f);
    }

    public void Reset()
    {
        onResult = false;
        winImage.transform.localScale = new Vector3(0,0,0);
        loseImage.transform.localScale = new Vector3(0, 0, 0);

    }

}
