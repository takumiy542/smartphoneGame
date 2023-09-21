using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03_Seed : MonoBehaviour
{
    //  敵シード速度
    Vector3 speed;

    //  発生させる敵のプレハブ
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //  敵シード速度決定
        speed = new Vector3(0.0f, -0.001f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //  敵シード移動
        transform.position += speed;
    }

    //  画面外に出た場合のOnBecameInvisible()の逆
    //  画面内に入った瞬間に呼び出される関数

    private void OnBecameVisible()
    {
        //  敵生成
        GameObject emy =
        Instantiate(EnemyPrefab, transform.position, transform.rotation);

        //  自分を消去する
        Destroy(this.gameObject);
    }
}
