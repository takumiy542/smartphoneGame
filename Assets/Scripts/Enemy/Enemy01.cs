using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    //  �G�e�p�v���n�u
    public GameObject EShotPrefab;

    //  �G�̏󋵑J�ڊǗ�
    int mode;

    //  �ړ��p�^�C�}�[
    float moveTimer;

    //  �U���p�^�C�}�[
    float shotTimer;

    // Start is called before the first frame update
    void Start()
    {
        //  ���[�h��������
        mode = 0;

        //  �^�C�}�[�ނ�������
        moveTimer = 0.0f;
        shotTimer = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  ���[�h�ɂ��s���𕪊�
        switch (mode)
        {
            case 0:     //  �G�������̏�����
                //  �ړ��p�^�C�}�[��ݒ肷��
                moveTimer = 1.2f;

                //  ���[�h��i�߂�
                mode = 1;
                break;

            case 1:     //  �^���ֈړ�
                //  �ړ�
                transform.Translate(0.0f, -0.03f, 0.0f);

                //  �^�C�}�[�J�E���g�_�E��
                moveTimer -= Time.deltaTime;

                //  �^�C�}�[�`�F�b�N
                if(moveTimer <= 0.0f)
                {
                    //  ���[�h��i�߂�
                    mode = 2;

                    //  �ړ��p�^�C�}�[��ݒ�
                    moveTimer = 3.0f;

                    //  �e���˃^�C�}�[��ݒ�
                    shotTimer = 0.5f;
                }

                break;

            case 2:     //  �e�𔭎�
                //  �^�C�}�[�J�E���g�_�E��
                shotTimer -= Time.deltaTime;

                //  �e�^�C�}�[�`�F�b�N
                if(shotTimer <= 0.0f)
                {
                    //  �e�𔭐��A�������W��ݒ�
                    GameObject eshot = Instantiate(EShotPrefab, 
                                                   transform.position,
                                                   transform.rotation);

                    //  �e�����擾
                    EShot es = eshot.GetComponent<EShot>();

                    //  �ړ��ʂ�ݒ�
                    es.SetVec(0.0f, -0.07f, 0.0f);

                    //  ���̔��˂܂ł̃^�C�}�[��ݒ�
                    shotTimer = 0.5f;
                }
                
                //  �ړ��^�C�}�[�J�E���g�_�E��
                moveTimer -= Time.deltaTime;

                //  �^�C�}�[�`�F�b�N
                if (moveTimer <= 0.0f)
                {
                    //  ���[�h��i�߂�
                    mode = 3;

                    //  �ړ��p�^�C�}�[��ݒ�
                    moveTimer = 0.0f;

                    //  �e���˃^�C�}�[��ݒ�
                    shotTimer = 0.0f;
                }
                break;
            
            case 3:         //  �^��ֈړ�
                //  �ړ�
                transform.Translate(0.0f, 0.02f, 0.0f);

                break;

            default:
                break;
        }

    }


    //  ��ʊO����
    private void OnBecameInvisible()
    {
        //  �Q�[���I�u�W�F�N�g����
        Destroy(gameObject);
    }
}
