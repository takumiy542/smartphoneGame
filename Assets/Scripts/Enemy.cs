using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //  敵爆発のプレハブ用
    public GameObject EnemyExplosionPrefab;
    //  コイン生成のプレハブ用
    public GameObject CoinPrefab;

    //  爆発SE
    public AudioSource asExplosion;

    //  敵が弾を発射するのに2～4秒のランダムを使用
    //  そのための持ち時間
    float shotInterval;

    //  敵のHP
    public int enemyHP;

    // Start is called before the first frame update
    void Start()
    {
        //enemyHP = 100;

        //  弾を発射するまでの待ち時間
        shotInterval = Random.Range(2.0f, 4.0f);

        //  SEを再生する場所(オーディオソース)を取得
        asExplosion = GameObject.Find("EnemyManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //  敵のHPを減らす関数
    //  引数damage … 減らすHPの量を指定
    public void SubEnemyHP(int damage)
    {
        //  敵のHPから、指定されたダメージの値分減らす
        enemyHP -= damage;
        
        //  敵のHPが0以下になったら、敵の破壊処理を行う
        if(enemyHP <= 0)
        {
            //  爆発SE再生
            asExplosion.Play();

            //  爆発アニメ用ゲームオブジェクト生成
            GameObject explo = Instantiate(EnemyExplosionPrefab);
            //  爆発の位置を敵に合わせる
            explo.transform.position = transform.position;

            //  敵の倒れた場所に、アイテムを生成
            //  CoinPrefab … コイン 衝突したらコインを入手できる
            GameObject coin = Instantiate(CoinPrefab,transform.position,Quaternion.identity);
            
            //  敵オブジェクトを消去する
            Destroy(this.gameObject);
        }
    }

    //  敵のHPを指定
    //  時間経過とともに敵のHPを強化するシステムで使用
    public void SetEnemyHP(int HP)
    {
        enemyHP = HP;
    }
}
