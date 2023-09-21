using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_State : MonoBehaviour
{
    public static int player_HP = 100;
    public static int player_ATK = 30;
    public static int player_DEF = 20;

    public static int player_Coins = 0;

    public static int LvUP_HP = 100;
    public static int LvUP_ATK = 100;
    public static int LvUP_DEF = 100;

    public AudioSource asClick;
    public AudioSource asBGM;

    // Start is called before the first frame update
    void Start()
    {
        asBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetPlayerCoins()
    {
        return player_Coins;
    }
    public int GetPlayerHP()
    {
        return player_HP;
    }
    public int GetPlayerATK()
    {
        return player_ATK;
    }
    public int GetPlayerDEF()
    {
        return player_DEF;
    }
    public int GetPlayerHPMoney()
    {
        return LvUP_HP;
    }
    public int GetPlayerATKMoney()
    {
        return LvUP_ATK;
    }
    public int GetPlayerDEFMoney()
    {
        return LvUP_DEF;
    }

    public void LevelUP_HP()
    {
        //  ���x���A�b�v�ɕK�v�ȃR�C���ɑ���Ȃ������珈������
        if(LvUP_HP > player_Coins)
        {
            return;
        }
        //  HP�𑝂₷
        player_HP += 20;
        //  �R�C���̖��������炷
        player_Coins -= LvUP_HP;

        //  ���x���A�b�v�ɕK�v�ȃR�C�����𑝂₷
        LvUP_HP = (int)(LvUP_HP * 1.3f);

        //  SE�Đ�
        asClick.Play();
    }
    public void LevelUP_ATK()
    {
        //  ���x���A�b�v�ɕK�v�ȃR�C���ɑ���Ȃ������珈������
        if (LvUP_ATK > player_Coins)
        {
            return;
        }
        //  ATK�𑝂₷
        player_ATK = (int)(player_ATK * 1.2f);
        //  �R�C���̖��������炷
        player_Coins -= LvUP_ATK;

        //  ���x���A�b�v�ɕK�v�ȃR�C�����𑝂₷
        LvUP_ATK = (int)(LvUP_ATK * 1.3f);

        //  SE�Đ�
        asClick.Play();
    }
    public void LevelUP_DEF()
    {
        //  ���x���A�b�v�ɕK�v�ȃR�C���ɑ���Ȃ������珈������
        if (LvUP_DEF > player_Coins)
        {
            return;
        }
        //  HP�𑝂₷
        player_DEF = (int)(player_DEF * 1.2f);
        //  �R�C���̖��������炷
        player_Coins -= LvUP_DEF;

        //  ���x���A�b�v�ɕK�v�ȃR�C�����𑝂₷
        LvUP_DEF = (int)(LvUP_DEF * 1.3f);

        //  SE�Đ�
        asClick.Play();
    }
    public void AddCoin()
    {
        player_Coins += 3000;
    }
}
