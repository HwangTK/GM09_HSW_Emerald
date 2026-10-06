using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealArea : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private Transform _area;

    [SerializeField] private int _healAmount = 1;



    void Start()
    {
        
    }



    void Update()
    {
        
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerHealth.Heal(_healAmount);
        }
    }


}
