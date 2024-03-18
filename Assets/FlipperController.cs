using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;

    private bool leftTouch = false;
    private bool rightTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
            //���L�[
            //�����L�[�������������t���b�p�[�𓮂���
            if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //�E���L�[�����������E�t���b�p�[�𓮂���
            if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //���L�[�����ꂽ���t���b�p�[�����ɖ߂�
            if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

        //�^�b�`����
        // ���E�̃t���b�p�[�������Ƀ^�b�`���ꂽ�ꍇ�A�����𓮂���
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

    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
