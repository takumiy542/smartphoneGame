using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{
    //==========================================================
    //      現在のステータス値を表示するためのテキストUI
    //==========================================================
    private Text Text_Money;    //  現在のコイン数を表示するUI
    private Text Text_HP;       //  現在のHPを表示するUI
    private Text Text_Atk;      //  現在の攻撃力を表示するUI
    private Text Text_Def;      //  現在の防御力を表示するUI

    //==========================================================
    //      ボタンに書かれるテキストUI
    //==========================================================
    private Text Button_HP;     //  HPを強化するボタンのテキストUI
    private Text Button_Atk;    //  攻撃力を強化するボタンのテキストUI
    private Text Button_Def;    //  防御力を強化するボタンのテキストUI

    //  プレイヤーのステータス値保管用
    private player_State player;

    // Start is called before the first frame update
    void Start()
    {
        //**********現在のステータス値を表示するUIを取得**********
        Text_Money = GameObject.Find("Text_Money").GetComponent<Text>();
        Text_HP = GameObject.Find("Text_Health").GetComponent<Text>();
        Text_Atk = GameObject.Find("Text_Attack").GetComponent<Text>();
        Text_Def = GameObject.Find("Text_Defence").GetComponent<Text>();
        //*******************************************************

        //**********ボタンに書かれるテキストUIを取得**********
        Button_HP = GameObject.Find("Button_Health").GetComponentInChildren<Text>();
        Button_Atk = GameObject.Find("Button_Attack").GetComponentInChildren<Text>();
        Button_Def = GameObject.Find("Button_Defence").GetComponentInChildren<Text>();
        //****************************************************

        //  現在のプレイヤーのステータスを取得
        player = GameObject.Find("Player").GetComponent<player_State>();
    }

    // Update is called once per frame
    void Update()
    {
        //=========現在のプレイヤーのステータス値を取得===========

        //**********現在のステータス値を取得**********
        int money = player.GetPlayerCoins();
        int hp = player.GetPlayerHP();
        int atk = player.GetPlayerATK();
        int def = player.GetPlayerDEF();
        //********************************************

        //**********ボタンに書く値を取得**********
        int hpMoney = player.GetPlayerHPMoney();
        int atkMoney = player.GetPlayerATKMoney();
        int defMoney = player.GetPlayerDEFMoney();
        //****************************************
        //=========================================================


        //**********現在のステータス値を表示するUIを更新**********
        Text_Money.text =  " × " + string.Format("{0}", money);
        Text_HP.text = "体力:" + string.Format("{0}", hp);
        Text_Atk.text = "攻撃力:" + string.Format("{0}", atk);
        Text_Def.text = "防御力:" + string.Format("{0}", def);
        //*******************************************************

        //**********ボタンに書かれるテキストUIを更新**********
        Button_HP.text = "体力を強化する\n" + string.Format("{0}", hpMoney) + "枚";
        Button_Atk.text = "攻撃力を強化する\n" + string.Format("{0}", atkMoney) + "枚";
        Button_Def.text = "防御力を強化する\n" + string.Format("{0}", defMoney) + "枚";
        //****************************************************
    }
}
