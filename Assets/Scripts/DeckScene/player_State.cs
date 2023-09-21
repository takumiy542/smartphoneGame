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
        //  レベルアップに必要なコインに足らなかったら処理無効
        if(LvUP_HP > player_Coins)
        {
            return;
        }
        //  HPを増やす
        player_HP += 20;
        //  コインの枚数を減らす
        player_Coins -= LvUP_HP;

        //  レベルアップに必要なコイン数を増やす
        LvUP_HP = (int)(LvUP_HP * 1.3f);

        //  SE再生
        asClick.Play();
    }
    public void LevelUP_ATK()
    {
        //  レベルアップに必要なコインに足らなかったら処理無効
        if (LvUP_ATK > player_Coins)
        {
            return;
        }
        //  ATKを増やす
        player_ATK = (int)(player_ATK * 1.2f);
        //  コインの枚数を減らす
        player_Coins -= LvUP_ATK;

        //  レベルアップに必要なコイン数を増やす
        LvUP_ATK = (int)(LvUP_ATK * 1.3f);

        //  SE再生
        asClick.Play();
    }
    public void LevelUP_DEF()
    {
        //  レベルアップに必要なコインに足らなかったら処理無効
        if (LvUP_DEF > player_Coins)
        {
            return;
        }
        //  HPを増やす
        player_DEF = (int)(player_DEF * 1.2f);
        //  コインの枚数を減らす
        player_Coins -= LvUP_DEF;

        //  レベルアップに必要なコイン数を増やす
        LvUP_DEF = (int)(LvUP_DEF * 1.3f);

        //  SE再生
        asClick.Play();
    }
    public void AddCoin()
    {
        player_Coins += 3000;
    }
}
