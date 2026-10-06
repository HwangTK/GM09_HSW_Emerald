using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : MonoBehaviour
{

    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private Transform _area;

    [SerializeField] private int _healAmount = 10;



    void Start()
    {

    }



    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerHealth.Heal(_healAmount);
            Destroy(gameObject);
        }
    }

}
