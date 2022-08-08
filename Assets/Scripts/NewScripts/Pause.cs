using UnityEngine.UI;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Sprite _pauseSprite;
    [SerializeField] Sprite _playSprite;
    bool _paused;
    private void Start()
    {
        _paused = false;
    }
    public void Press()
    {
        _paused = !_paused;

        if (_paused) PauseGame();
        else UnPauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        _image.sprite = _playSprite;
    }

    void UnPauseGame()
    {
        Time.timeScale = 1f;
        _image.sprite = _pauseSprite;
    }
}
