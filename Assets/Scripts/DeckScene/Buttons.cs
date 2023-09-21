using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//  DeckScene内にあるボタンで使用している関数をまとめたスクリプト
public class Buttons : MonoBehaviour
{
    private player_State player;
    

    // Start is called before the first frame update
    void Start()
    {
        //  プレイヤーのステータスを管理する変数を取得
        player = GameObject.Find("Player").GetComponent<player_State>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //  ボタンを押したとき、コインを消費してHPの最大値を上げる変数を呼び出す
    public void OnClickHealth()
    {
        player.LevelUP_HP();
    }

    //  ボタンを押したとき、コインを消費してHPの最大値を上げる変数を呼び出す
    public void OnClickAttack()
    {
        player.LevelUP_ATK();
    }

    //  ボタンを押したとき、コインを消費してHPの最大値を上げる変数を呼び出す
    public void OnClickDefence()
    {
        player.LevelUP_DEF();
    }
}
