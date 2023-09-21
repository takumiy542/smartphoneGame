using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public AudioSource asBGM;   //  BGM保管変数
    public Text coins;          //  ゲーム終了時のコイン数保管用
    public Text sec;            //  ゲーム終了時の秒数保管用

    private int nCoins;     //  ゲーム終了時のコイン数保管用
    private int nSec;       //  ゲーム終了時の秒数保管用
    private int nMin;       //  ゲーム終了時の分数保管用

    // Start is called before the first frame update
    void Start()
    {
        //  BGM再生
        asBGM.Play();

        //  ゲーム終了時の値を取得する
        nCoins = Player.nCoins;         //  コイン数取得
        nSec = (int)Player.WorldTime;   //  経過時間取得
                                        //  経過時間：秒 で計算されており、分に分ける計算が必要
                                        //  （例　453秒 -> 7分33秒）

        //  分秒に分ける
        nMin = nSec / 60;
        nSec = nSec % 60;
    }

    // Update is called once per frame
    void Update()
    {
        //**********テキスト変更**********
        //  コイン数表示
        coins.text = "獲得したコイン：" + string.Format("{0}", nCoins) + "枚";

        //  経過時間表示
        sec.text = "経過時間：" + string.Format("{0}", nMin) + "分" + string.Format("{0}", nSec) + "秒";
        //********************************

    }
    //  タイトル画面に遷移
    public void ChangeTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
