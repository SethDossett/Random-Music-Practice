using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GeneralEventSO startRandomizer;
    [SerializeField] GeneralEventSO tick;
    AudioSource audioSource;
    [SerializeField] AudioClip metronome;
    [SerializeField] AudioClip startingClick;

    int tickValue;
    private void OnEnable()
    {
        startRandomizer.OnRaiseEvent += TickSoundFx;
        tick.OnRaiseEvent += TickSoundFx;
    }
    private void OnDisable()
    {
        startRandomizer.OnRaiseEvent += TickSoundFx;
        tick.OnRaiseEvent -= TickSoundFx;
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        tickValue = 0;
    }
    void TickSoundFx()
    {
        


        if (tickValue == 0)
        {
            audioSource.PlayOneShot(startingClick, 0.75f);
        }
        else
        {
            audioSource.PlayOneShot(metronome);
        }

        tickValue++;

        if (tickValue >= 4)
        {

            tickValue = 0;
        }



    }
    
}
