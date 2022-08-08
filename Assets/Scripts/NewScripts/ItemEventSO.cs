using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Event/ItemEvent")]
public class ItemEventSO : ScriptableObject
{
    public UnityAction<string> OnRaiseEvent;

    public void RaiseEvent(string text) => OnRaiseEvent?.Invoke(text);
}
