using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // publicなGameObjectを宣言　⇒　インスペックタに変数設定が出現
    public GameObject EnemyPrefab;

    // 初回に敵が発生するまでの待ち時間
    float startInterval = 3.0f;

    // ゲーム中に敵が発生するまでの待ち時間
    float createInterval = 1.0f;

    // 敵発生用カウントタイマー
    float enemyTimer;


    // Start is called before the first frame update
    void Start()
    {
        // 初回タイマーを設定
        enemyTimer = startInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーから経過時間を減算
        enemyTimer -= Time.deltaTime;

        // deltaTimeは、最後のフレームを完了するのにかかった時間

        // タイマーが0以下になったら
        if (enemyTimer <= 0.0f)
        {
            enemyTimer += createInterval;

            // プレハブに設定があれば
            if (EnemyPrefab != null)
            {
                // 新たにゲームオブジェクトを発生させる
                GameObject enemy = Instantiate(EnemyPrefab);

                // 初期座標をランダムな位置にする
                enemy.transform.position = new Vector3(Random.Range(-7.0f, 0.0f), 5.7f, 0.0f);
            }
        }
    }
}
