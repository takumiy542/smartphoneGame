using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeed : MonoBehaviour
{
    ////=====出現させる敵のプレハブ=====================================================
    //[SerializeField]
    //private GameObject Enemy1Prefab;
    //[SerializeField]
    //private GameObject Enemy2Prefab;
    //[SerializeField]
    //private GameObject Enemy3Prefab;
    //[SerializeField]
    //private GameObject Enemy4Prefab;
    //[SerializeField]
    //private GameObject Enemy5Prefab;
    ////===============================================================================


    // 出現させる敵のPrefab
    public GameObject[] EnemyPrefab = new GameObject[5];

    //**********敵の出現する幅保存用**********
    [SerializeField]
    private float rangeA;   //  右端のx座標保存
    [SerializeField]
    private float rangeB;   //  左端のx座標保存
    //****************************************

    // 経過時間
    private float time;
    // ゲーム内経過時間
    public static float WorldTime;


    private void Awake()
    {
        //// Prefabを配列にまとめる
        //EnemyPrefab[0] = Enemy1Prefab;
        //EnemyPrefab[1] = Enemy2Prefab;
        //EnemyPrefab[2] = Enemy3Prefab;
        //EnemyPrefab[3] = Enemy4Prefab;
        //EnemyPrefab[4] = Enemy5Prefab;

        //  time初期化
        time = 0.0f;
        WorldTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;
        WorldTime = WorldTime + Time.deltaTime;

        // 約1秒置きにランダムに生成されるようにする。
        if (time > 3.0f)
        {
            // WorldTimeが長くなるほど、生成される敵が増える
            for (int i = 0; i < WorldTime/60.0f ; i++)
            {
                int rand = Random.Range(0, 5);

                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x = Random.Range(rangeA, rangeB);

                // GameObjectを上記で決まったランダムな場所に生成
                GameObject enemy = Instantiate(EnemyPrefab[rand], 
                    new Vector3(x, 5.5f, 0.0f), EnemyPrefab[rand].transform.rotation);

                // 経過時間でenemyを強くする
                enemy.GetComponent<Enemy>().SetEnemyHP(100*(int)((WorldTime/30.0f) + 1));
            }

            // 経過時間リセット
            time = 0f;
        }
    }
}
