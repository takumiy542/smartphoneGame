using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //  �e�̍U����
    //  �����Ȃ�قǁA�e�̓��������G�̗̑͂���������
    public static int shotATK;

    //  �e�̈ړ����x
    public float ShotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //  �v���C���[�̍U���͎擾
        shotATK = player_State.player_ATK;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �����I�ɏ�����ֈړ�����
        transform.Translate(0.0f, ShotSpeed, 0.0f);
        
    }

    // �G�Ƃ̓����蔻��
    void OnTriggerEnter2D(Collider2D collision)
    {
        // ������������̃^�O�����āA�G��������
        if (collision.gameObject.tag == "Enemy")
        {
            //  �R���|�[�l���g�擾
            Enemy enemy = collision.GetComponent<Enemy>();
            
            //  �G��HP���U���͕����炷
            enemy.SubEnemyHP(shotATK);
            
            //  �e������
            Destroy(gameObject);

        }
    }

    //  ��ʊO�ɏo����
    private void OnBecameInvisible()
    {
        //  �e�����ł�����
        Destroy(gameObject);

    }

}
