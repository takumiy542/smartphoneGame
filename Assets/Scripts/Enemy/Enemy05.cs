using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy05 : MonoBehaviour
{
    //  敵弾用プレハブ
    public GameObject EShotPrefab;
    //  速度
    public float speed;


    //  敵の状況遷移管理
    int mode;

    //  移動用タイマー
    float moveTimer;

    //  攻撃用タイマー
    float shotTimer;

    // Start is called before the first frame update
    void Start()
    {
        //  モードを初期化
        mode = 0;

        //  タイマー類を初期化
        moveTimer = 0.0f;
        shotTimer = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  モードにより行動を分岐
        switch (mode)
        {
            case 0:     //  敵発生時の初期化
                //  移動用タイマーを設定する
                moveTimer = 1.2f;

                //  モードを進める
                mode = 1;
                break;

            case 1:     //  真下へ移動
                //  移動
                transform.Translate(0.0f, -0.02f, 0.0f);

                //  タイマーカウントダウン
                moveTimer -= Time.deltaTime;

                //  タイマーチェック
                if (moveTimer <= 0.0f)
                {
                    //  モードを進める
                    mode = 2;

                    //  移動用タイマーを設定
                    moveTimer = 3.0f;

                    //  弾発射タイマーを設定
                    shotTimer = 0.5f;
                }

                break;

            case 2:     //  プレイヤーに特攻
                //  タイマーカウントダウン
                shotTimer -= Time.deltaTime;

                //  弾タイマーチェック
                if (shotTimer <= 0.0f)
                {
                    //  自機狙い特攻
                    //  ゲームシーン中の自機を探す
                    GameObject jk = GameObject.Find("Player");

                    //  現在位置から自機までの、移動速度分離れた座標から
                    //  現在地を減算することで1回分の移動ベクトルを算出
                    Vector3 mv = Vector3.MoveTowards(transform.position,
                        jk.transform.position, speed) - transform.position;

                    transform.position += mv;
                }
                
                break;
                
            default:
                break;
        }

    }


    //  画面外処理
    private void OnBecameInvisible()
    {
        //  ゲームオブジェクト消滅
        Destroy(gameObject);
    }
}
