using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shmup.Core;
using Shmup.Input;

namespace Shmup.Combat
{
    public class PlayerShooting : MonoBehaviour
    {
	[SerializeField] private float bulletsPerSecond;
	[SerializeField] private float bulletSpeed;
	[SerializeField] private string prefabName = "Bullet";
	[SerializeField] private Transform bulletSpawner;
	
	private float _frequency;
	private float _timer = .0f;
	private ObjectPool _pool;
	private PlayerInput _input;

	private void Start()
	{
	    GameObject manager = GameObject.FindGameObjectWithTag("GameController");
	    _pool = manager.GetComponent<ObjectPool>();
	    _input = GetComponent<PlayerInput>();
	    _frequency = 1.0f / bulletsPerSecond;
	}

	private void Update()
	{
	    if (_input.Attack)
	    {
		_timer += Time.deltaTime;
		if (_timer >= _frequency)
		{
		    GameObject bulletPrefab = _pool.PoolObject(prefabName);
		    bulletPrefab.transform.position = bulletSpawner.position;
		    Rigidbody bulletBody = bulletPrefab.GetComponent<Rigidbody>();
		    bulletBody.velocity = new Vector2(0, bulletSpeed);
		    _timer = .0f;
		}
	    }
	    _timer = .0f;
	}
    }
}
