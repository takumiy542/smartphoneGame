using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteShot : MonoBehaviour
{
    public BoxCollider2D me;
    private bool Flag;

    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        //  collisionをなくす
        me.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        //  collisionがtrueになった0.5秒後にfalseにする
        float elapsed = (float)sw.Elapsed.TotalSeconds;

        if(elapsed > 0.5f)
        {
            TriggerFalse();

            //  reset
            sw.Restart();
            sw.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 当たった相手のタグを見て、敵弾だったら
        if (collision.gameObject.tag == "EnemyShot")
        {
            //  弾を消す
            Destroy(collision.gameObject);

            Flag = true;
        }
        if(Flag == false)
        {
            TriggerFalse();
        }
    }

    public void TriggerTrue()
    {
        me.enabled = true;
        sw.Start();
    }
    public void TriggerFalse()
    {
        me.enabled = false;
    }
}
