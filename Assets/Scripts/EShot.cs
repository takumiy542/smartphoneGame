using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EShot : MonoBehaviour
{
    //  移動方向＆速度
    Vector3 TargetVec;

    // Start is called before the first frame update
    void Start()
    {
        //  敵弾の移動方向と速度を決定
        //TargetVec = new Vector3(0.0f, -0.005f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  現在の敵弾座標に移動量を加算して動かす
        transform.position += TargetVec;
        
    }

    //  移動ベクトル決定
    public void SetVec(float x,float y,float z)
    {
        //  publicな関数は、他スクリプトファイルからでも
        //  発生させたゲームオブジェクト経由で呼び出せる
        //  その際に引数で移動量を渡す仕組み
        TargetVec = new Vector3(x, y, z);
    }

    //  画面外に出たら
    private void OnBecameInvisible()
    {
        //  弾を消滅させる
        Destroy(gameObject);
    }
    
}
