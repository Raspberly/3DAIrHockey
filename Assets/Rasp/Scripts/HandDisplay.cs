using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HandDisplay : MonoBehaviour
{
    [SerializeField] private SystemController systemController;
    [SerializeField] private Image[] scoreImage;

    private int displayScorePoint = 0;
    private float displayScoreDuration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        displayScorePoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PointCheck();
    }

    //ReactiveProperyでやりたい感
    public void PointCheck(){
        if(!systemController) return;
        if(systemController.GetMePoint() != displayScorePoint)
        {
            displayScorePoint = systemController.GetMePoint();
            if(scoreImage.Length > displayScorePoint)
            {
                scoreImage[displayScorePoint].transform.DOScale(new Vector2(1, 1), displayScoreDuration);
            }
        }
    }

}
