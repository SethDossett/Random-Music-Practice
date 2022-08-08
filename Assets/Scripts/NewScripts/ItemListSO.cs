using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemList")]
public class ItemListSO : ScriptableObject
{
    public List<Item> items;
    public List<string> itemNames;
    public float tempo;
}
