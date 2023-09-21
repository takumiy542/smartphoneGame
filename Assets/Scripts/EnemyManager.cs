using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // public��GameObject��錾�@�ˁ@�C���X�y�b�N�^�ɕϐ��ݒ肪�o��
    public GameObject EnemyPrefab;

    // ����ɓG����������܂ł̑҂�����
    float startInterval = 3.0f;

    // �Q�[�����ɓG����������܂ł̑҂�����
    float createInterval = 1.0f;

    // �G�����p�J�E���g�^�C�}�[
    float enemyTimer;


    // Start is called before the first frame update
    void Start()
    {
        // ����^�C�}�[��ݒ�
        enemyTimer = startInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // �^�C�}�[����o�ߎ��Ԃ����Z
        enemyTimer -= Time.deltaTime;

        // deltaTime�́A�Ō�̃t���[������������̂ɂ�����������

        // �^�C�}�[��0�ȉ��ɂȂ�����
        if (enemyTimer <= 0.0f)
        {
            enemyTimer += createInterval;

            // �v���n�u�ɐݒ肪�����
            if (EnemyPrefab != null)
            {
                // �V���ɃQ�[���I�u�W�F�N�g�𔭐�������
                GameObject enemy = Instantiate(EnemyPrefab);

                // �������W�������_���Ȉʒu�ɂ���
                enemy.transform.position = new Vector3(Random.Range(-7.0f, 0.0f), 5.7f, 0.0f);
            }
        }
    }
}
