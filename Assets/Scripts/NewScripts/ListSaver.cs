using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TemplateList
{
    public List<TMP_Dropdown.OptionData> dropdowTemplates;
    public List<Template> Lists;
    public List<string> listValues01;
    public bool hasSavedFile;

}
public class ListSaver : MonoBehaviour
{
    private TemplateList newTemplate = new TemplateList();

    [SerializeField] ItemListSO itemList;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] List<string> dropdownList;
    [SerializeField] ItemEventSO errorMessage;
    [SerializeField] GeneralEventSO clearSavedTemplates;
    [SerializeField] GeneralEventSO StartGame;
    [SerializeField] GeneralEventSO newFIle;
    [SerializeField] GameObject createTemplate;
    [SerializeField] TextMeshProUGUI createTemplateText;
    [SerializeField] ItemListSO savedLists;
    [SerializeField] int _maxTemplates = 5;

    [SerializeField] GameObject _note;
    GameObject n;
    [SerializeField] Transform _parent;

    bool StartGameButtonPressed;
    [SerializeField] List<Template> list = new List<Template>();

    private void OnEnable()
    {
        newFIle.OnRaiseEvent += NewFile;
        clearSavedTemplates.OnRaiseEvent += ClearSavedEntries;
    }
    private void OnDisable()
    {
        newFIle.OnRaiseEvent += NewFile;
        clearSavedTemplates.OnRaiseEvent -= ClearSavedEntries;
    }
    void NewFile()
    {
        SaveGameManager.CurrentSaveData.templateList = newTemplate;
        SaveGameManager.SaveGame();
    }
    private void Start()
    {
        StartGameButtonPressed = false;

        Time.timeScale = 1f;
        SaveGameManager.LoadGame();
        newTemplate = SaveGameManager.CurrentSaveData.templateList;
        if(newTemplate.dropdowTemplates.Count < 1)
        {
            dropdown.options.Clear();
            dropdownList.Clear();
            list.Clear();
            print("none");
            //dropdownList.Add("No Saved Templates");
            //dropdown.AddOptions(dropdownList);
            /*for (int i = 0; i < 10; i++)
            {
                dropdownList.Add("Template " + (i + 1));
                CreateTemplate();
            }
            if (dropdown.options.Count == 0)
            {
                //dropdownList.Add(_default);
                dropdown.AddOptions(dropdownList);
            }*/
        }
        else
        {
            dropdown.options = newTemplate.dropdowTemplates;
            foreach(var option in dropdown.options)
            {
                dropdownList.Add(option.text);
            }
            foreach(var temp in newTemplate.Lists)
            {
                list.Add(temp);
            }
            
            print("bugg");
        }
        /*for(int i = 0; i < itemList.items.Count; i++)
        {
            itemList.items[i].temp.templates = newTemplate.Lists[i].templates;
        }*/

    }

    public void CheckToBeSaved()
    {
        OpenCreateTemp();
        StartGameButtonPressed = true;
        
        

        
    }
    public void CloseCreateTemp()
    {
        if (StartGameButtonPressed)
        {
            StartGameButtonPressed = false;
            createTemplate.SetActive(false);
            StartGame.RaiseEvent();
            return;
        }

        createTemplate.SetActive(false);
    }
    public void OpenCreateTemp()
    {
        if (itemList.itemNames.Count == 0)
        {
            errorMessage.RaiseEvent("No Entries to be Saved, Please Add Entry");
            return;
        }

        createTemplate.SetActive(true);
        createTemplateText.text = "Save Entries as New Template?";

    }
    public void AddTemplate(TMP_InputField inputField)
    {
        if (itemList.itemNames.Count == 0)
        {
            errorMessage.RaiseEvent("No Entries to be Saved, Please Add Entry");
            return;
        }

        if (inputField.text == "")
        {
            errorMessage.RaiseEvent("Please Enter Template Name");
            return;
        }
        dropdown.options.Clear();
        dropdownList.Add(inputField.text);
        dropdown.AddOptions(dropdownList);
        //dropdown.options[dropdown.value].text = inputField.text;
        //dropdown.captionText.text = inputField.text;

        CreateTemplate();



        //SaveList();
    }
    public void RemoveTemplate()
    {
        if (dropdown.value == 0)
        {
            errorMessage.RaiseEvent("Cannot Delete Default Template");
        }
        else
        {
            dropdown.options.RemoveAt(dropdown.value);
            dropdown.value = 0;
        }

    }
    void CreateTemplate()
    {
        Template temp = new Template();
        foreach(var name in itemList.itemNames)
        {
            temp.templates.Add(name);
        }

        list.Add(temp);
        newTemplate.Lists = list;


        newTemplate.dropdowTemplates = dropdown.options;
        SaveGameManager.CurrentSaveData.templateList = newTemplate;
        SaveGameManager.SaveGame();

        errorMessage.RaiseEvent("New Template Created");

        CloseCreateTemp();
    }
    

    public void SaveList()
    {
        int index;
        index = dropdown.value;
        //itemList.templateIndex = dropdown.value;
        newTemplate.dropdowTemplates = dropdown.options;
        itemList.items[index].temp.templates = itemList.itemNames;
        //newTemplate.Lists[index].templates = itemList.items[index].temp.templates;
        newTemplate.listValues01 = itemList.itemNames;
        
        SaveGameManager.CurrentSaveData.templateList = newTemplate;
        SaveGameManager.SaveGame();

        errorMessage.RaiseEvent("Saved");
        CloseCreateTemp();
        return;
    }
    public void LoadList()
    {
        SaveGameManager.LoadGame();
        newTemplate = SaveGameManager.CurrentSaveData.templateList;

        if(newTemplate.Lists.Count == 0)
        {
            errorMessage.RaiseEvent("Zero List of Templates");
            return;
        }
        itemList.itemNames = newTemplate.Lists[dropdown.value].templates;


        if(newTemplate.Lists[dropdown.value].templates.Count == 0)
        {
            errorMessage.RaiseEvent("Template is Empty");
        }
        else
        {
            InstantiateObjects();
            errorMessage.RaiseEvent("Loaded");
        }
        
    }
    void ClearSavedEntries()
    {
        print("Clear Saved Entries Called");
        itemList.items.Clear();
        itemList.itemNames.Clear();
        newTemplate.dropdowTemplates.Clear();
        newTemplate.Lists.Clear();
        newTemplate.listValues01.Clear();

        SaveGameManager.CurrentSaveData.templateList = newTemplate;
        SaveGameManager.SaveGame();

        //dropdown.options.Clear();
        dropdown.ClearOptions();
        dropdownList.Clear();

        list.Clear();

        errorMessage.RaiseEvent("Templates Cleared");
    }

    void InstantiateObjects()
    {
        DestroyEntries();

       foreach (var item in itemList.itemNames)
        {
            n = Instantiate(_note, _parent);
            n.GetComponentInChildren<TextMeshProUGUI>().text = item;
        }
    }

    void DestroyEntries()
    {
        foreach (Transform child in _parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    
}


    

