using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableTrash : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _pickedUpTrashParent;
    [SerializeField] private bool _isThisOrganicTrash;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Vector2 _initPos;

    #region PROPERTIES
    public bool IsThisOrganicTrash => _isThisOrganicTrash;
    #endregion


    private void Awake()
    {
        if (!TryGetComponent(out CanvasGroup canvasGroup)) return;
        _canvasGroup = canvasGroup;

        if (!TryGetComponent(out RectTransform rectTransform)) return;
        _rectTransform = rectTransform;

        _initPos = _rectTransform.anchoredPosition;
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        _canvasGroup.blocksRaycasts = false;

        if (transform.parent.TryGetComponent(out TrashContainer trashContainerParent))
        {
            trashContainerParent.ListOfTrashInside.Remove(gameObject);
        }

        if (!TryGetComponent(out TrashContainer trashContainer))
        {
            gameObject.transform.SetParent(_pickedUpTrashParent);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        _initPos = _rectTransform.anchoredPosition;
        _canvasGroup.blocksRaycasts = true;
    }

    public void ReturnToOriginalPos()
    {
        _rectTransform.anchoredPosition = _initPos;
    }
}
