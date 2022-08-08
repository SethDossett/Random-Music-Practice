using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameStart : MonoBehaviour
{
    [SerializeField] ItemListSO itemList;
    [SerializeField] ItemEventSO errorMessage;
    [SerializeField] GeneralEventSO NewFile;
    [SerializeField] GeneralEventSO startGameEvent;
    [SerializeField] Animator _animator;
    int fadeToBlack = Animator.StringToHash("FadeToBlack");
    private float transitionTime = 1f;


    private void OnEnable()
    {
        startGameEvent.OnRaiseEvent += StartGame;
    }
    private void OnDisable()
    {
        startGameEvent.OnRaiseEvent -= StartGame;
    }

    private void Awake()
    {
        var dir = Application.persistentDataPath + SaveGameManager.SaveDirectory;

        if (!Directory.Exists(dir))
        {
            NewFile.RaiseEvent();
            print("NewFileCreated");
        }
    }
    public void StartGame()
    {
        if (itemList.itemNames.Count < 2)
        {
            errorMessage.RaiseEvent("Please Enter 2 or More Entries!");
            return;
        }


        if (itemList.itemNames.Count >= 2)
        {
            StartCoroutine(LoadLevel());
        }
    }

    

    IEnumerator LoadLevel()
    {
        _animator.Play(fadeToBlack);
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(1);
    }
}
