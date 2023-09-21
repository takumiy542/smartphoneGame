using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03 : MonoBehaviour
{
    //  敵弾用プレハブ
    public GameObject EShotPrefab;

    //  敵の状況遷移管理
    int mode;

    //  移動用タイマー
    float moveTimer;

    //  攻撃用タイマー
    float shotTimer;

    //  角度進行用
    float deg;

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
            case 1:     //  左下へ移動
                //  移動
                transform.Translate(-0.01f, -0.03f, 0.0f);

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
                    shotTimer = 0.1f;
                }
                break;
            case 2:     //  弾を掃射
                //  タイマーカウントダウン
                shotTimer -= Time.deltaTime;

                //  弾タイマーチェック
                if (shotTimer <= 0.0f)
                {
                    //  全方位に弾を掃射
                    if(deg <= 720.0f)
                    {
                        //  弾を発生、初期座標を設定
                        GameObject eshot = Instantiate(EShotPrefab,
                                                       transform.position,
                                                       transform.rotation);

                        //  弾情報を取得
                        EShot es = eshot.GetComponent<EShot>();

                        //  移動量を設定
                        //  発射角度をディグリーからラジアンに変換
                        float rad = deg * Mathf.Deg2Rad;

                        //  弾の速度を設定
                        float spd = 0.07f;

                        //  三角関数 * 速度
                        es.SetVec(Mathf.Cos(rad) * spd, Mathf.Sin(rad) * spd, 0.0f);

                        //  次の発射までのタイマーを設定
                        shotTimer = 0.1f;

                        //  角度を進める
                        deg += 45.0f;
                    }
                    else    //  360度を超えたら
                    {
                        //  モードを進める
                        mode = 3;

                        //  移動用タイマーを設定
                        moveTimer = 0.0f;

                        //  弾発射タイマーを設定
                        shotTimer = 0.0f;
                    }

                }
                
                break;
            case 3:         //  真上へ移動
                //  移動
                transform.Translate(0.0f, 0.02f, 0.0f);
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
