using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public AudioSource asBGM;   //  BGM�ۊǕϐ�
    public Text coins;          //  �Q�[���I�����̃R�C�����ۊǗp
    public Text sec;            //  �Q�[���I�����̕b���ۊǗp

    private int nCoins;     //  �Q�[���I�����̃R�C�����ۊǗp
    private int nSec;       //  �Q�[���I�����̕b���ۊǗp
    private int nMin;       //  �Q�[���I�����̕����ۊǗp

    // Start is called before the first frame update
    void Start()
    {
        //  BGM�Đ�
        asBGM.Play();

        //  �Q�[���I�����̒l���擾����
        nCoins = Player.nCoins;         //  �R�C�����擾
        nSec = (int)Player.WorldTime;   //  �o�ߎ��Ԏ擾
                                        //  �o�ߎ��ԁF�b �Ōv�Z����Ă���A���ɕ�����v�Z���K�v
                                        //  �i��@453�b -> 7��33�b�j

        //  ���b�ɕ�����
        nMin = nSec / 60;
        nSec = nSec % 60;
    }

    // Update is called once per frame
    void Update()
    {
        //**********�e�L�X�g�ύX**********
        //  �R�C�����\��
        coins.text = "�l�������R�C���F" + string.Format("{0}", nCoins) + "��";

        //  �o�ߎ��ԕ\��
        sec.text = "�o�ߎ��ԁF" + string.Format("{0}", nMin) + "��" + string.Format("{0}", nSec) + "�b";
        //********************************

    }
    //  �^�C�g����ʂɑJ��
    public void ChangeTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
