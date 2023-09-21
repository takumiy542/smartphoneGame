using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �V�[���ɕύX�ɕK�v
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public AudioSource asSelect;    //  ���莞SE
    public AudioSource asBGM;       //  �^�C�g�����BGM

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(asSelect);
        asBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    Application.Quit();
        //}
    }
    public void ChangeGame()
    {
        //  �Q�[���V�[���֑J��
        SceneManager.LoadScene("Stage1");
        //  SE�Đ�
        asSelect.Play();
    }
    public void ChangeDeck()
    {
        //  �X�e�[�^�X������ʂ֑J��
        SceneManager.LoadScene("DeckScene");
        //  SE�Đ�
        asSelect.Play();
    }
}
