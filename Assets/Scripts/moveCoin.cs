using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCoin : MonoBehaviour
{
    //  コインの落下速度
    public float fGravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  コインを上から下に落下させる
        this.transform.position = new Vector3(transform.position.x,transform.position.y - fGravity,0.0f);
    }

    private void OnBecameInvisible()
    {
        //  オブジェクトを消滅させる
        Destroy(gameObject);
    }
}
