using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EShot : MonoBehaviour
{
    //  �ړ����������x
    Vector3 TargetVec;

    // Start is called before the first frame update
    void Start()
    {
        //  �G�e�̈ړ������Ƒ��x������
        //TargetVec = new Vector3(0.0f, -0.005f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  ���݂̓G�e���W�Ɉړ��ʂ����Z���ē�����
        transform.position += TargetVec;
        
    }

    //  �ړ��x�N�g������
    public void SetVec(float x,float y,float z)
    {
        //  public�Ȋ֐��́A���X�N���v�g�t�@�C������ł�
        //  �����������Q�[���I�u�W�F�N�g�o�R�ŌĂяo����
        //  ���̍ۂɈ����ňړ��ʂ�n���d�g��
        TargetVec = new Vector3(x, y, z);
    }

    //  ��ʊO�ɏo����
    private void OnBecameInvisible()
    {
        //  �e�����ł�����
        Destroy(gameObject);
    }
    
}
