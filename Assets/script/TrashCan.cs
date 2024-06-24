using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashCan : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool _isOrganicTrashCan;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("OnDrop");
            if (!eventData.pointerDrag.TryGetComponent(out DraggableTrash draggableTrash)) return;
            if(_isOrganicTrashCan == draggableTrash.IsThisOrganicTrash)
            {
                if (eventData.pointerDrag.TryGetComponent(out TrashContainer trashContainer))
                {
                    if(trashContainer.ListOfTrashInside.Count > 0)
                    {
                        draggableTrash.ReturnToOriginalPos();
                        Debug.Log("Incorrect");
                        return;
                    }
                }
                else
                {
                    Debug.Log("Correct");
                }
                    
            }
            else
            {
                Debug.Log("Incorrect");
                draggableTrash.ReturnToOriginalPos();
                return;
            }

            eventData.pointerDrag.gameObject.SetActive(false);
        }
    }

    //IEnumerator DelayBeforeDisplayResult(DraggableTrash draggableAnswer)
    //{
    //    yield return new WaitForSeconds(0.5F);
    //    if(draggableAnswer.IsThisRightAnswer)
    //    {

    //    }
    //    else
    //    {

    //    }
    //    draggableAnswer.ReturnToOriginalPos();
    //}
}
