using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCoin : MonoBehaviour
{
    //  �R�C���̗������x
    public float fGravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  �R�C�����ォ�牺�ɗ���������
        this.transform.position = new Vector3(transform.position.x,transform.position.y - fGravity,0.0f);
    }

    private void OnBecameInvisible()
    {
        //  �I�u�W�F�N�g�����ł�����
        Destroy(gameObject);
    }
}
