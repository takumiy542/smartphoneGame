using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObj : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 prevPos; //保存しておく初期position
    private RectTransform rectTransform; // 移動したいオブジェクトのRectTransform
    private RectTransform parentRectTransform; // 移動したいオブジェクトの親(Panel)のRectTransform

    public Skill.SkillKind skillkind; // オブジェクトのD&Dで指定したいスキル名

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = rectTransform.parent as RectTransform;
    }


    // ドラッグ開始時の処理
    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置を記憶しておく
        // RectTransformの場合はpositionではなくanchoredPositionを使う
        prevPos = rectTransform.anchoredPosition;

    }

    // ドラッグ中の処理
    public void OnDrag(PointerEventData eventData)
    {
        // eventData.positionから、親に従うlocalPositionへの変換を行う
        // オブジェクトの位置をlocalPositionに変更する

        Vector2 localPosition = GetLocalPosition(eventData.position);
        rectTransform.anchoredPosition = localPosition;
    }

    // ドラッグ終了時の処理
    public void OnEndDrag(PointerEventData eventData)
    {
        // ドロップ地点に DropAra があったらそこに入れる
        var dropArea = GetRaycastArea((PointerEventData)eventData);
        if (dropArea != null)
        {
            //  コンポーネント取得
            DropArea area = dropArea.GetComponent<DropArea>();
            //  名前変更関数を実行
            area.SetName(skillkind);
        }
        
        // オブジェクトをドラッグ前の位置に戻す
        rectTransform.anchoredPosition = prevPos;
    }

    // ScreenPositionからlocalPositionへの変換関数
    private Vector2 GetLocalPosition(Vector2 screenPosition)
    {
        Vector2 result = Vector2.zero;

        // screenPositionを親の座標系(parentRectTransform)に対応するよう変換する.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, screenPosition, Camera.main, out result);

        return result;
    }

    // イベント発生地点の DropArea を取得する
    private static DropArea GetRaycastArea(PointerEventData eventData)
    {
        //  レイキャストを発射
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        //  レイに当たったDropAreaを持つオブジェクトを返却
        return results.Select(x => x.gameObject.GetComponent<DropArea>())
            .FirstOrDefault(x => x != null);
    }
}
