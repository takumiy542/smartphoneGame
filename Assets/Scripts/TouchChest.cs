using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchChest : MonoBehaviour
{
    Animator anim;  //  アニメーション保管用

    void Start()
    {
        //  Live2Dのキャラについているアニメーションを取得
        anim = gameObject.GetComponentInParent<Animator>();
    }

    //  キャラクターの胸を触ったとき、
    //  胸を触ったときのアニメーションを行わせる
    //  キャラクターの胸付近にあるオブジェクトにイベント付与して使用
    public void OnClickChest()
    {
        //  アニメーション再生
        anim.SetTrigger("TouchChest");
    }
}
