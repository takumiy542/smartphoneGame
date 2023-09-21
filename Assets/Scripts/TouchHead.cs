using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHead : MonoBehaviour
{

    Animator anim;  //  アニメーション保管用
    
    void Start()
    {
        //  Live2Dのキャラについているアニメーションを取得
        anim = gameObject.GetComponentInParent<Animator>();
    }
    //  キャラクターの頭を触ったとき、
    //  頭を触ったときのアニメーションを行わせる
    //  キャラクターの頭付近にあるオブジェクトにイベント付与して使用
    public void OnClickHead()
    {
        //  アニメーション再生
        anim.SetTrigger("TouchHead");
    }
}
