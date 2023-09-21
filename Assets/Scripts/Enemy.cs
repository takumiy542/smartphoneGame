using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //  �G�����̃v���n�u�p
    public GameObject EnemyExplosionPrefab;
    //  �R�C�������̃v���n�u�p
    public GameObject CoinPrefab;

    //  ����SE
    public AudioSource asExplosion;

    //  �G���e�𔭎˂���̂�2�`4�b�̃����_�����g�p
    //  ���̂��߂̎�������
    float shotInterval;

    //  �G��HP
    public int enemyHP;

    // Start is called before the first frame update
    void Start()
    {
        //enemyHP = 100;

        //  �e�𔭎˂���܂ł̑҂�����
        shotInterval = Random.Range(2.0f, 4.0f);

        //  SE���Đ�����ꏊ(�I�[�f�B�I�\�[�X)���擾
        asExplosion = GameObject.Find("EnemyManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //  �G��HP�����炷�֐�
    //  ����damage �c ���炷HP�̗ʂ��w��
    public void SubEnemyHP(int damage)
    {
        //  �G��HP����A�w�肳�ꂽ�_���[�W�̒l�����炷
        enemyHP -= damage;
        
        //  �G��HP��0�ȉ��ɂȂ�����A�G�̔j�󏈗����s��
        if(enemyHP <= 0)
        {
            //  ����SE�Đ�
            asExplosion.Play();

            //  �����A�j���p�Q�[���I�u�W�F�N�g����
            GameObject explo = Instantiate(EnemyExplosionPrefab);
            //  �����̈ʒu��G�ɍ��킹��
            explo.transform.position = transform.position;

            //  �G�̓|�ꂽ�ꏊ�ɁA�A�C�e���𐶐�
            //  CoinPrefab �c �R�C�� �Փ˂�����R�C�������ł���
            GameObject coin = Instantiate(CoinPrefab,transform.position,Quaternion.identity);
            
            //  �G�I�u�W�F�N�g����������
            Destroy(this.gameObject);
        }
    }

    //  �G��HP���w��
    //  ���Ԍo�߂ƂƂ��ɓG��HP����������V�X�e���Ŏg�p
    public void SetEnemyHP(int HP)
    {
        enemyHP = HP;
    }
}
