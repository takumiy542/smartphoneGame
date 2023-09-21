using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapParticle : MonoBehaviour
{
    ParticleSystem[] array;
    [SerializeField]
    private Camera _camera;

    private void Start()
    {
        //  パーティクル取得
        array = GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        //  画面が押されたとき、タップした箇所にエフェクトを再生する
        if (Input.GetMouseButtonDown(0))
        {
            //  タップされた場所取得
            var pos = Input.mousePosition;
            pos.z = 10f;

            transform.position = _camera.ScreenToWorldPoint(pos);
            array[0].Emit(1);
            array[1].Emit(1);
            array[2].Emit(1);
        }
    }
}
