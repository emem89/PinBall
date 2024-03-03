using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    //�X�R�A��\������e�L�X�g
    private GameObject ScoreText;
    //���_�̕ϐ��i�O�ɏ������j
    private int score_num = 0; 

    // Start is called before the first frame update
    void Start()
    {
        //�V�[������ScoreText�I�u�W�F�N�g���擾
        this.ScoreText = GameObject.Find("ScoreText");
        //�X�R�A�\��
        this.ScoreText.GetComponent<Text>().text = "Score " + score_num;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�Փˎ��ɌĂ΂��֐�
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

        //�X�R�A�\��
        this.ScoreText.GetComponent<Text>().text = "Score " + score_num;
    }
}
