using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GeneralEventSO clearTemps;
    [SerializeField] GameObject _options_menu;
    Image _image;
    [SerializeField] float _fillSpeed = 1f;
    Animator _animator;
    int openAnim = Animator.StringToHash("Open");
    int closeAnim = Animator.StringToHash("Close");
    private void Awake()
    {
        _image = _options_menu.GetComponent<Image>();
        _animator = _options_menu.GetComponent<Animator>();
    }
    private void Start()
    {
        if (_image.fillAmount > 0) _image.fillAmount = 0;
        if (_options_menu.activeInHierarchy)
        {
            _options_menu.SetActive(false);
        }
        
    }
    private void Update()
    {
    }
    public void OpenOptions()
    {
        if(_image.fillAmount != 1)
        {
            if (!_options_menu.activeInHierarchy)
            {
                _options_menu.SetActive(true);
            }

            _animator.Play(openAnim);
        }
        else CloseOptions();
        
    }

    public void CloseOptions()
    {
        _animator.Play(closeAnim);
        if (_image.fillAmount == 0)
        {
            if (_options_menu.activeInHierarchy)
            {
                _options_menu.SetActive(false);
            }
        }
    } 
}
