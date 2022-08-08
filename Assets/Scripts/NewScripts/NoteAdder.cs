using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class NoteAdder : MonoBehaviour
{
    [SerializeField] ItemListSO itemList;
    [SerializeField] GeneralEventSO removeString;
    [SerializeField] ItemEventSO errorMessage;

    [SerializeField] TMP_InputField _inputField;
    [SerializeField] GameObject _note;
    GameObject n;
    [SerializeField] Transform _parent;
    [SerializeField] int _maxNotes = 60;

    private void Awake()
    {
       // _label.text = item.name;
        
    }
    private void OnEnable()
    {
        removeString.OnRaiseEventGO += Remove;
    }
    private void OnDisable()
    {
        removeString.OnRaiseEventGO += Remove;
    }
    private void Start()
    {
        ClearList();
    }
    public void AddNote()
    {
        if(_inputField.text == "")
        {
            errorMessage.RaiseEvent("Input Field Empty!");
            return;
        }
        else if (itemList.itemNames.Count >= _maxNotes)
        {
            errorMessage.RaiseEvent("Max Capacity Reached!");
        }
        else
        {
            n = Instantiate(_note, _parent);
            var ntext = n.GetComponentInChildren<TextMeshProUGUI>().text = _inputField.text;
            itemList.itemNames.Add(ntext);

        }

    }
    public void Remove(GameObject GO)
    {
        itemList.itemNames.Remove(GO.GetComponentInChildren<TextMeshProUGUI>().text);

    }
    public void ClearList()
    {
        foreach (Transform child in _parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (itemList.itemNames.Count < 1)
            return;

        itemList.itemNames.Clear();

        

    }
}
