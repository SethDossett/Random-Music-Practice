using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Event/GeneralEvent")]
public class GeneralEventSO : ScriptableObject
{
    public UnityAction OnRaiseEvent;
    public UnityAction<GameObject> OnRaiseEventGO;

    public void RaiseEvent() => OnRaiseEvent?.Invoke();
    public void RaiseEventGO(GameObject go) => OnRaiseEventGO?.Invoke(go);
}
