using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashContainer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listOfTrashInside = new();

    public List<GameObject> ListOfTrashInside => _listOfTrashInside;
}
