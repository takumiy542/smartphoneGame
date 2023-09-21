using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObj : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 prevPos; //�ۑ����Ă�������position
    private RectTransform rectTransform; // �ړ��������I�u�W�F�N�g��RectTransform
    private RectTransform parentRectTransform; // �ړ��������I�u�W�F�N�g�̐e(Panel)��RectTransform

    public Skill.SkillKind skillkind; // �I�u�W�F�N�g��D&D�Ŏw�肵�����X�L����

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = rectTransform.parent as RectTransform;
    }


    // �h���b�O�J�n���̏���
    public void OnBeginDrag(PointerEventData eventData)
    {
        // �h���b�O�O�̈ʒu���L�����Ă���
        // RectTransform�̏ꍇ��position�ł͂Ȃ�anchoredPosition���g��
        prevPos = rectTransform.anchoredPosition;

    }

    // �h���b�O���̏���
    public void OnDrag(PointerEventData eventData)
    {
        // eventData.position����A�e�ɏ]��localPosition�ւ̕ϊ����s��
        // �I�u�W�F�N�g�̈ʒu��localPosition�ɕύX����

        Vector2 localPosition = GetLocalPosition(eventData.position);
        rectTransform.anchoredPosition = localPosition;
    }

    // �h���b�O�I�����̏���
    public void OnEndDrag(PointerEventData eventData)
    {
        // �h���b�v�n�_�� DropAra ���������炻���ɓ����
        var dropArea = GetRaycastArea((PointerEventData)eventData);
        if (dropArea != null)
        {
            //  �R���|�[�l���g�擾
            DropArea area = dropArea.GetComponent<DropArea>();
            //  ���O�ύX�֐������s
            area.SetName(skillkind);
        }
        
        // �I�u�W�F�N�g���h���b�O�O�̈ʒu�ɖ߂�
        rectTransform.anchoredPosition = prevPos;
    }

    // ScreenPosition����localPosition�ւ̕ϊ��֐�
    private Vector2 GetLocalPosition(Vector2 screenPosition)
    {
        Vector2 result = Vector2.zero;

        // screenPosition��e�̍��W�n(parentRectTransform)�ɑΉ�����悤�ϊ�����.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, screenPosition, Camera.main, out result);

        return result;
    }

    // �C�x���g�����n�_�� DropArea ���擾����
    private static DropArea GetRaycastArea(PointerEventData eventData)
    {
        //  ���C�L���X�g�𔭎�
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        //  ���C�ɓ�������DropArea�����I�u�W�F�N�g��ԋp
        return results.Select(x => x.gameObject.GetComponent<DropArea>())
            .FirstOrDefault(x => x != null);
    }
}
