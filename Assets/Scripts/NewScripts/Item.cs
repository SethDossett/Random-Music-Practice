using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Items", menuName = "Note Items")]
public class Item : ScriptableObject
{
    public List<string> savedTemplates;
    public Template temp;

   
   
}
