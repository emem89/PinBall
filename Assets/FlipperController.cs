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
/* ���L�[�i�^�b�`�m�F�̂��߃R�����g�A�E�g�j
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
�����܂�*/
            if(Input.touchCount > 0)
            {
                //�^�b�`���̎擾
                Touch touch = Input.GetTouch(0);

                //�������u��
                if(touch.phase == TouchPhase.Began)
                {
                    if(Input.mousePosition.x >= Screen.width / 2 &&
                       tag == "RightFripperTag") // �E����
                    {
                        Debug.Log("�E������");
                        SetAngle(this.flickAngle);

                    }
                    else if (Input.mousePosition.x <= Screen.width / 2 &&
                             tag == "LeftFripperTag") // ������
                    {
                        Debug.Log("��������");
                        SetAngle(this.flickAngle);
                    }
                }
                //�������ςȂ�
                if(touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("�������ςȂ��A�Ȃɂ����Ȃ�");
                }
                //�������u��
                if(touch.phase == TouchPhase.Ended)
                {
                
                    if (Input.mousePosition.x >= Screen.width / 2 &&
                        tag == "RightFripperTag") // �E����
                    {
                        Debug.Log("�E������");
                        SetAngle(this.defaultAngle);

                }
                    else if (Input.mousePosition.x <= Screen.width / 2 &&
                             tag == "LeftFripperTag") // ������
                    {
                        Debug.Log("��������");
                        SetAngle(this.defaultAngle);
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
