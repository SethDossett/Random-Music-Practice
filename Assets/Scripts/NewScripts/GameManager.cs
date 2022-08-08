using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator _animator;
    int fadeToBlack = Animator.StringToHash("FadeToBlack");
    private float transitionTime = 1f;
    
    public void ToMenu()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        _animator.Play(fadeToBlack);
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(0);
    }
}
