using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRobotHealth : MonoBehaviour
{
    [SerializeField] private int _hp = 300;

    [Header("피격 색상")]
    [SerializeField] private Color _hitColor = Color.red;

    [Header("피격 시간")]
    [SerializeField] private float _hitTime = 0.2f;

    [Header("드랍 아이템")]
    [SerializeField] private GameObject[] _dropItems;

    [Header("드랍 확률")]
    [SerializeField] private float[] _dropPercent;

    [Header("피격사운드")]
    [SerializeField] private AudioSource _audioSource;
    [Header("사망사운드")]
    [SerializeField] private AudioClip _deathSound;

    private Renderer[] _renderers;
    private Color[] _originColors;


    private void Start()
    {
        _renderers = GetComponentsInChildren<Renderer>();

        _originColors = new Color[_renderers.Length];

        for (int i = 0; i < _renderers.Length; i++)
        {
            _originColors[i] = _renderers[i].material.color;
        }
    }


    public void MonsterHit(int damage)
    {
        _hp -= damage;

        _audioSource.Play();

        StartCoroutine(HitEffect());

        if (_hp <= 0)
        {
            for (int i = 0; i < _dropItems.Length; i++)
            {
                if (Random.value <= _dropPercent[i])
                {
                    Instantiate(_dropItems[i], transform.position + Vector3.up * 0.5f, transform.rotation);
                }
            }
            AudioSource.PlayClipAtPoint(_deathSound, transform.position);

            Destroy(gameObject);
        }
    }


    private IEnumerator HitEffect()
    {
        for (int i = 0; i < _renderers.Length; i++)
        {
            _renderers[i].material.color = _hitColor;
        }

        yield return new WaitForSeconds(_hitTime);

        for (int i = 0; i < _renderers.Length; i++)
        {
            _renderers[i].material.color = _originColors[i];
        }
    }
}