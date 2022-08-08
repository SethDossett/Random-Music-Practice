using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Randomizer : UnityEngine.MonoBehaviour
{
    /*[Header("Randomizer")]
    [SerializeField] float repeatTempo;
    private bool hasInvoked = false;
    private int currentIndex = 0;
    CrossScene crossScene;

    [Header("Metronome")]
    [SerializeField] bool metronomeEnabled = false;
    [SerializeField] float metroTempo;
    [SerializeField] int timeSignature;
    AudioSource audioSource;

    #region Singleton
    public static Randomizer instance;

    

    public void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        crossScene = CrossScene.instance;
       
        audioSource = GetComponent<AudioSource>();
        timeSignature = crossScene.halfOrQuarterNotes;

        repeatTempo = 240 / crossScene.tempo;
        metroTempo = timeSignature / crossScene.tempo;
        if (crossScene.metronomeOn == true)
            metronomeEnabled = true;
        else
            metronomeEnabled = false;

        
        InvokeRepeating("NewRandomNote", 0f , repeatTempo);
        if (metronomeEnabled == true)
            InvokeRepeating("Metronome", 0f, metroTempo);
        
    }
    void Metronome()
    {
        audioSource.Play();
    }*/


    [SerializeField] GeneralEventSO newRandomNote, startCountdown, startRandomizer, count;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] ItemListSO itemList;
    List<string> _items;
    int _currentIndex = 0;
    bool _startTimer = false;
    float _countDownTimer;


    private void OnEnable()
    {
        startCountdown.OnRaiseEvent += CountDown;
        count.OnRaiseEvent += Count;
        startRandomizer.OnRaiseEvent += NewRandomNote;
        newRandomNote.OnRaiseEvent += NewRandomNote;
    }
    private void OnDisable()
    {
        startCountdown.OnRaiseEvent -= CountDown;
        count.OnRaiseEvent -= Count;
        startRandomizer.OnRaiseEvent -= NewRandomNote;
        newRandomNote.OnRaiseEvent -= NewRandomNote;
    }
    void Start()
    {
        //_items = itemList.items;
        //text.text = _items[_currentIndex].name;

    }

    private void Update()
    {
        if (!_startTimer)
            return;


    }
    void CountDown()
    {
        _startTimer = true;
        _text.text = "Ready";
    }
    void Count()
    {
        if(_countDownTimer == 0)
        {
            _text.text = "3";
        }
        else if (_countDownTimer == 1)
        {
            _text.text = "2";
        }
        else if (_countDownTimer == 2)
        {
            _text.text = "1";
        }

        _countDownTimer++;
    }
    void NewRandomNote()
    {
        _items = itemList.itemNames;

        int newIndex = UnityEngine.Random.Range(0, _items.Count);

        if (newIndex == _currentIndex)
        {
            NewRandomNote();
        }
        else
        {
            _currentIndex = newIndex;
            _text.text = _items[_currentIndex];
        }

        

    }
}
