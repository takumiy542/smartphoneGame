using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MyShipManager : MonoBehaviour
{
    //  ���@�~�X�t���O
    public static bool MyShipMissFlg;

    //  static �N���X�֐��̌Ăяo�����ƂɃ������N���A�����p���g�p

    //  �V�[���J�ڃJ�E���g�_�E���^�C�}�[
    float GameOverTimer;

    // Start is called before the first frame update
    void Start()
    {
        //  �����̓t���OOFF
        MyShipMissFlg = false;

        //  �Q�[���I�[�o�[��ʂɈڍs����܂�3�b�ԑҋ@
        GameOverTimer = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //  �~�X�t���O���`�F�b�N���A�~�X�ɂȂ��Ă�����
        if (MyShipMissFlg)
        {
            //  �^�C�}�[����o�ߎ��Ԃ����Z
            GameOverTimer -= Time.deltaTime;

            //  �^�C�}�[��0�ȉ��ɂȂ����� = �ݒ莞�Ԃ��o�߂�����
            if (GameOverTimer <= 0.0f)
            {
                // �Q�[���I�[�o�[�V�[����ǂݍ���ŃV�[���ύX
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
