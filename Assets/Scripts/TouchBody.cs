using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBody : MonoBehaviour
{
    Animator anim;  //  アニメーション保管用

    void Start()
    {
        //  Live2Dのキャラについているアニメーションを取得
        anim = gameObject.GetComponentInParent<Animator>();
    }

    //  キャラクターの体を触ったとき、
    //  体を触ったときのアニメーションを行わせる
    //  キャラクターの体付近にあるオブジェクトにイベント付与して使用
    public void OnClickBody()
    {
        //  アニメーション再生
        anim.SetTrigger("TouchBody");
    }
}
