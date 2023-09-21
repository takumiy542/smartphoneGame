using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//  DeckScene���ɂ���{�^���Ŏg�p���Ă���֐����܂Ƃ߂��X�N���v�g
public class Buttons : MonoBehaviour
{
    private player_State player;
    

    // Start is called before the first frame update
    void Start()
    {
        //  �v���C���[�̃X�e�[�^�X���Ǘ�����ϐ����擾
        player = GameObject.Find("Player").GetComponent<player_State>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //  �{�^�����������Ƃ��A�R�C���������HP�̍ő�l���グ��ϐ����Ăяo��
    public void OnClickHealth()
    {
        player.LevelUP_HP();
    }

    //  �{�^�����������Ƃ��A�R�C���������HP�̍ő�l���グ��ϐ����Ăяo��
    public void OnClickAttack()
    {
        player.LevelUP_ATK();
    }

    //  �{�^�����������Ƃ��A�R�C���������HP�̍ő�l���グ��ϐ����Ăяo��
    public void OnClickDefence()
    {
        player.LevelUP_DEF();
    }
}
