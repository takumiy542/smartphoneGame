using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MyShipManager : MonoBehaviour
{
    //  自機ミスフラグ
    public static bool MyShipMissFlg;

    //  static クラス関数の呼び出しごとにメモリクリアせず継続使用

    //  シーン遷移カウントダウンタイマー
    float GameOverTimer;

    // Start is called before the first frame update
    void Start()
    {
        //  初期はフラグOFF
        MyShipMissFlg = false;

        //  ゲームオーバー画面に移行するまで3秒間待機
        GameOverTimer = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //  ミスフラグをチェックし、ミスになっていたら
        if (MyShipMissFlg)
        {
            //  タイマーから経過時間を減算
            GameOverTimer -= Time.deltaTime;

            //  タイマーが0以下になったら = 設定時間が経過したら
            if (GameOverTimer <= 0.0f)
            {
                // ゲームオーバーシーンを読み込んでシーン変更
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
