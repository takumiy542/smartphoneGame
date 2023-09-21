using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{
    //==========================================================
    //      ���݂̃X�e�[�^�X�l��\�����邽�߂̃e�L�X�gUI
    //==========================================================
    private Text Text_Money;    //  ���݂̃R�C������\������UI
    private Text Text_HP;       //  ���݂�HP��\������UI
    private Text Text_Atk;      //  ���݂̍U���͂�\������UI
    private Text Text_Def;      //  ���݂̖h��͂�\������UI

    //==========================================================
    //      �{�^���ɏ������e�L�X�gUI
    //==========================================================
    private Text Button_HP;     //  HP����������{�^���̃e�L�X�gUI
    private Text Button_Atk;    //  �U���͂���������{�^���̃e�L�X�gUI
    private Text Button_Def;    //  �h��͂���������{�^���̃e�L�X�gUI

    //  �v���C���[�̃X�e�[�^�X�l�ۊǗp
    private player_State player;

    // Start is called before the first frame update
    void Start()
    {
        //**********���݂̃X�e�[�^�X�l��\������UI���擾**********
        Text_Money = GameObject.Find("Text_Money").GetComponent<Text>();
        Text_HP = GameObject.Find("Text_Health").GetComponent<Text>();
        Text_Atk = GameObject.Find("Text_Attack").GetComponent<Text>();
        Text_Def = GameObject.Find("Text_Defence").GetComponent<Text>();
        //*******************************************************

        //**********�{�^���ɏ������e�L�X�gUI���擾**********
        Button_HP = GameObject.Find("Button_Health").GetComponentInChildren<Text>();
        Button_Atk = GameObject.Find("Button_Attack").GetComponentInChildren<Text>();
        Button_Def = GameObject.Find("Button_Defence").GetComponentInChildren<Text>();
        //****************************************************

        //  ���݂̃v���C���[�̃X�e�[�^�X���擾
        player = GameObject.Find("Player").GetComponent<player_State>();
    }

    // Update is called once per frame
    void Update()
    {
        //=========���݂̃v���C���[�̃X�e�[�^�X�l���擾===========

        //**********���݂̃X�e�[�^�X�l���擾**********
        int money = player.GetPlayerCoins();
        int hp = player.GetPlayerHP();
        int atk = player.GetPlayerATK();
        int def = player.GetPlayerDEF();
        //********************************************

        //**********�{�^���ɏ����l���擾**********
        int hpMoney = player.GetPlayerHPMoney();
        int atkMoney = player.GetPlayerATKMoney();
        int defMoney = player.GetPlayerDEFMoney();
        //****************************************
        //=========================================================


        //**********���݂̃X�e�[�^�X�l��\������UI���X�V**********
        Text_Money.text =  " �~ " + string.Format("{0}", money);
        Text_HP.text = "�̗�:" + string.Format("{0}", hp);
        Text_Atk.text = "�U����:" + string.Format("{0}", atk);
        Text_Def.text = "�h���:" + string.Format("{0}", def);
        //*******************************************************

        //**********�{�^���ɏ������e�L�X�gUI���X�V**********
        Button_HP.text = "�̗͂���������\n" + string.Format("{0}", hpMoney) + "��";
        Button_Atk.text = "�U���͂���������\n" + string.Format("{0}", atkMoney) + "��";
        Button_Def.text = "�h��͂���������\n" + string.Format("{0}", defMoney) + "��";
        //****************************************************
    }
}
