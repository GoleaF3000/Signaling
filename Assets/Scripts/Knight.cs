using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _home;
    [SerializeField] private Transform _enemy;
    [SerializeField] private Signaling _signaling;
    private Transform _target;

    private void Start()
    {
        _target = _home;
    }

    private void Update()
    {
        if (_signaling.IsAlarmWorks)
        {            
            _target = _enemy;
        }
        else
        {            
            _target = _home;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}