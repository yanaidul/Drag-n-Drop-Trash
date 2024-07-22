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
                        GameManager.GetInstance().OnIncorrectAnswer();
                        return;
                    }

                    Debug.Log("Correct");
                    GameManager.GetInstance().OnCorrectAnswer(eventData.pointerDrag.gameObject);
                }
                else
                {
                    Debug.Log("Correct");
                    GameManager.GetInstance().OnCorrectAnswer(eventData.pointerDrag.gameObject);
                }
            }
            else
            {
                Debug.Log("Incorrect");
                draggableTrash.ReturnToOriginalPos();
                GameManager.GetInstance().OnIncorrectAnswer();
                return;
            }

            eventData.pointerDrag.gameObject.SetActive(false);
        }
    }
}
