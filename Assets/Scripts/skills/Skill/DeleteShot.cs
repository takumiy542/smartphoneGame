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
        //  collision���Ȃ���
        me.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        //  collision��true�ɂȂ���0.5�b���false�ɂ���
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
        // ������������̃^�O�����āA�G�e��������
        if (collision.gameObject.tag == "EnemyShot")
        {
            //  �e������
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
