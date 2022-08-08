using TMPro;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    [SerializeField] GeneralEventSO removeNameFromList;
    [SerializeField] ItemListSO itemList;
    public void DestroyNote()
    {
        removeNameFromList.RaiseEventGO(this.gameObject);
        Destroy(gameObject, 0.05f);
    }
    
    
}
