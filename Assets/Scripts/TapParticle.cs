using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapParticle : MonoBehaviour
{
    ParticleSystem[] array;
    [SerializeField]
    private Camera _camera;

    private void Start()
    {
        //  �p�[�e�B�N���擾
        array = GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        //  ��ʂ������ꂽ�Ƃ��A�^�b�v�����ӏ��ɃG�t�F�N�g���Đ�����
        if (Input.GetMouseButtonDown(0))
        {
            //  �^�b�v���ꂽ�ꏊ�擾
            var pos = Input.mousePosition;
            pos.z = 10f;

            transform.position = _camera.ScreenToWorldPoint(pos);
            array[0].Emit(1);
            array[1].Emit(1);
            array[2].Emit(1);
        }
    }
}
