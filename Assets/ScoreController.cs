using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    //スコアを表示するテキスト
    private GameObject ScoreText;
    //得点の変数（０に初期化）
    private int score_num = 0; 

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");
        //スコア表示
        this.ScoreText.GetComponent<Text>().text = "Score " + score_num;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        string objectTag = collision.gameObject.tag;

        if (objectTag == "SmallStarTag")
        {

            Debug.Log("SmallStar");
            score_num += 10;
        }
        else if (objectTag == "LargeStarTag")
        {
            Debug.Log("LargeStar");
            score_num += 50;
        }
        else if (objectTag == "SmallCloud")
        {
            Debug.Log("SmallCloud");
            score_num += 30;
        }
        else if (objectTag == "LargeCloud")
        {
            Debug.Log("LargeCloud");
            score_num += 100;
        }

        //スコア表示
        this.ScoreText.GetComponent<Text>().text = "Score " + score_num;
    }
}
