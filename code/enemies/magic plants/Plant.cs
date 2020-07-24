using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    protected GameObject _player;

    [SerializeField]
    [Range(0f, 1f)]
    protected float _startingSize;

    [SerializeField]
    protected float _timeTillFullyGrown = 30f;
    float _growTimer = 0;
    float _speed;

	private void Awake()
	{
        _player = GameObject.FindGameObjectWithTag("Player");
        _speed = 1 / _timeTillFullyGrown;
    }

	// Start is called before the first frame update
	void Start()
    {
        transform.localScale = Vector3.one * _startingSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (_growTimer <= _timeTillFullyGrown)
		{
            _growTimer += Time.deltaTime;
            Grow();
		}
    }

    void Grow()
	{
        transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one, _speed * Time.deltaTime);
    }
}
