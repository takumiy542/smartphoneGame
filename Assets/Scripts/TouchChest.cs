using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchChest : MonoBehaviour
{
    Animator anim;  //  �A�j���[�V�����ۊǗp

    void Start()
    {
        //  Live2D�̃L�����ɂ��Ă���A�j���[�V�������擾
        anim = gameObject.GetComponentInParent<Animator>();
    }

    //  �L�����N�^�[�̋���G�����Ƃ��A
    //  ����G�����Ƃ��̃A�j���[�V�������s�킹��
    //  �L�����N�^�[�̋��t�߂ɂ���I�u�W�F�N�g�ɃC�x���g�t�^���Ďg�p
    public void OnClickChest()
    {
        //  �A�j���[�V�����Đ�
        anim.SetTrigger("TouchChest");
    }
}
