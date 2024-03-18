using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    private bool leftTouch = false;
    private bool rightTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
            //矢印キー
            //左矢印キーを押した時左フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //右矢印キーを押した時右フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //矢印キー離された時フリッパーを元に戻す
            if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

        //タッチ操作
        // 左右のフリッパーが同時にタッチされた場合、両方を動かす
        if (leftTouch && rightTouch)
        {
            SetAngle(this.flickAngle);
        }
        else
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                        {
                            rightTouch = true;
                            SetAngle(this.flickAngle);
                        }
                        else if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                        {
                            leftTouch = true;
                            SetAngle(this.flickAngle);
                        }
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag")
                        {
                            rightTouch = false;
                            SetAngle(this.defaultAngle);
                        }
                        else if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                        {
                            leftTouch = false;
                            SetAngle(this.defaultAngle);
                        }
                    }
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
