using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03_Seed : MonoBehaviour
{
    //  �G�V�[�h���x
    Vector3 speed;

    //  ����������G�̃v���n�u
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //  �G�V�[�h���x����
        speed = new Vector3(0.0f, -0.001f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //  �G�V�[�h�ړ�
        transform.position += speed;
    }

    //  ��ʊO�ɏo���ꍇ��OnBecameInvisible()�̋t
    //  ��ʓ��ɓ������u�ԂɌĂяo�����֐�

    private void OnBecameVisible()
    {
        //  �G����
        GameObject emy =
        Instantiate(EnemyPrefab, transform.position, transform.rotation);

        //  ��������������
        Destroy(this.gameObject);
    }
}
