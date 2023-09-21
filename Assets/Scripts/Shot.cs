using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //  弾の攻撃力
    //  高くなるほど、弾の当たった敵の体力が多く減る
    public static int shotATK;

    //  弾の移動速度
    public float ShotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //  プレイヤーの攻撃力取得
        shotATK = player_State.player_ATK;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 自動的に上方向へ移動する
        transform.Translate(0.0f, ShotSpeed, 0.0f);
        
    }

    // 敵との当たり判定
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 当たった相手のタグを見て、敵だったら
        if (collision.gameObject.tag == "Enemy")
        {
            //  コンポーネント取得
            Enemy enemy = collision.GetComponent<Enemy>();
            
            //  敵のHPを攻撃力分減らす
            enemy.SubEnemyHP(shotATK);
            
            //  弾を消す
            Destroy(gameObject);

        }
    }

    //  画面外に出たら
    private void OnBecameInvisible()
    {
        //  弾を消滅させる
        Destroy(gameObject);

    }

}
