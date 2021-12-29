using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private string chestTag;

    private UnityAction<GameObject> _onTriggerAction;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Subscribe(UnityAction<GameObject> action)
    {
        _onTriggerAction = _onTriggerAction ?? action;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(chestTag))
        {
            _onTriggerAction?.Invoke(gameObject);
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
