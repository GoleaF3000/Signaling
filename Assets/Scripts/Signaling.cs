using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private NinjaTrigger _ninjaTrigger;
    [SerializeField] private float _duration;
    public bool IsAlarmWorks { get; private set; }
    private bool _isVolumeUp = false;
    private bool _isVolumeDown = false;
    private bool _isUpdateTimer = false;
    private float _runningTime;
    private float volume = 0.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ninja>())
        {
            if (IsAlarmWorks)
            {
                Debug.Log("Alarm OFF");
                IsAlarmWorks = false;
                _isVolumeUp = false;
                _isVolumeDown = true;                
            }
            else
            {
                Debug.Log("Alarm ON");
                IsAlarmWorks = true;
                _isVolumeDown = false;
                _isVolumeUp = true;
            }

            _isUpdateTimer = true;
        }
    }

    private void Update()
    {        
        float minVolume = 0.0f;
        float maxVolume = 1.0f;

        _runningTime += Time.deltaTime;
        float volumeChange = _runningTime / _duration;

        if (_isUpdateTimer)
        {
            volume = _audio.volume;
            _runningTime = 0;
            _isUpdateTimer = false; 
            Debug.Log("Timer update");
        }

        if (_isVolumeUp)
        {            
            _audio.volume = Mathf.MoveTowards(volume, maxVolume, volumeChange);            
        }
        else if (_isVolumeDown)
        {            
            _audio.volume = Mathf.MoveTowards(volume, minVolume, volumeChange);            
        }
    }
}