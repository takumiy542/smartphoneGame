using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy05 : MonoBehaviour
{
    //  �G�e�p�v���n�u
    public GameObject EShotPrefab;
    //  ���x
    public float speed;


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
                transform.Translate(0.0f, -0.02f, 0.0f);

                //  �^�C�}�[�J�E���g�_�E��
                moveTimer -= Time.deltaTime;

                //  �^�C�}�[�`�F�b�N
                if (moveTimer <= 0.0f)
                {
                    //  ���[�h��i�߂�
                    mode = 2;

                    //  �ړ��p�^�C�}�[��ݒ�
                    moveTimer = 3.0f;

                    //  �e���˃^�C�}�[��ݒ�
                    shotTimer = 0.5f;
                }

                break;

            case 2:     //  �v���C���[�ɓ��U
                //  �^�C�}�[�J�E���g�_�E��
                shotTimer -= Time.deltaTime;

                //  �e�^�C�}�[�`�F�b�N
                if (shotTimer <= 0.0f)
                {
                    //  ���@�_�����U
                    //  �Q�[���V�[�����̎��@��T��
                    GameObject jk = GameObject.Find("Player");

                    //  ���݈ʒu���玩�@�܂ł́A�ړ����x�����ꂽ���W����
                    //  ���ݒn�����Z���邱�Ƃ�1�񕪂̈ړ��x�N�g�����Z�o
                    Vector3 mv = Vector3.MoveTowards(transform.position,
                        jk.transform.position, speed) - transform.position;

                    transform.position += mv;
                }
                
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
