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
        //  collision‚ğ‚È‚­‚·
        me.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        //  collision‚ªtrue‚É‚È‚Á‚½0.5•bŒã‚Éfalse‚É‚·‚é
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
        // “–‚½‚Á‚½‘Šè‚Ìƒ^ƒO‚ğŒ©‚ÄA“G’e‚¾‚Á‚½‚ç
        if (collision.gameObject.tag == "EnemyShot")
        {
            //  ’e‚ğÁ‚·
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
