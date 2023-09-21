using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeed : MonoBehaviour
{
    ////=====�o��������G�̃v���n�u=====================================================
    //[SerializeField]
    //private GameObject Enemy1Prefab;
    //[SerializeField]
    //private GameObject Enemy2Prefab;
    //[SerializeField]
    //private GameObject Enemy3Prefab;
    //[SerializeField]
    //private GameObject Enemy4Prefab;
    //[SerializeField]
    //private GameObject Enemy5Prefab;
    ////===============================================================================


    // �o��������G��Prefab
    public GameObject[] EnemyPrefab = new GameObject[5];

    //**********�G�̏o�����镝�ۑ��p**********
    [SerializeField]
    private float rangeA;   //  �E�[��x���W�ۑ�
    [SerializeField]
    private float rangeB;   //  ���[��x���W�ۑ�
    //****************************************

    // �o�ߎ���
    private float time;
    // �Q�[�����o�ߎ���
    public static float WorldTime;


    private void Awake()
    {
        //// Prefab��z��ɂ܂Ƃ߂�
        //EnemyPrefab[0] = Enemy1Prefab;
        //EnemyPrefab[1] = Enemy2Prefab;
        //EnemyPrefab[2] = Enemy3Prefab;
        //EnemyPrefab[3] = Enemy4Prefab;
        //EnemyPrefab[4] = Enemy5Prefab;

        //  time������
        time = 0.0f;
        WorldTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // �O�t���[������̎��Ԃ����Z���Ă���
        time = time + Time.deltaTime;
        WorldTime = WorldTime + Time.deltaTime;

        // ��1�b�u���Ƀ����_���ɐ��������悤�ɂ���B
        if (time > 3.0f)
        {
            // WorldTime�������Ȃ�قǁA���������G��������
            for (int i = 0; i < WorldTime/60.0f ; i++)
            {
                int rand = Random.Range(0, 5);

                // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float x = Random.Range(rangeA, rangeB);

                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                GameObject enemy = Instantiate(EnemyPrefab[rand], 
                    new Vector3(x, 5.5f, 0.0f), EnemyPrefab[rand].transform.rotation);

                // �o�ߎ��Ԃ�enemy����������
                enemy.GetComponent<Enemy>().SetEnemyHP(100*(int)((WorldTime/30.0f) + 1));
            }

            // �o�ߎ��ԃ��Z�b�g
            time = 0f;
        }
    }
}
