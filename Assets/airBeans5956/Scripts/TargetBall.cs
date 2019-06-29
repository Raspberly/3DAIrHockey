using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBall : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private bool _enableRefrectBoost = true;

    public float moveSpeedPerSec = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody>();
        var initialVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        initialVelocity = Vector3.Normalize(this.transform.forward + this.transform.right + initialVelocity.normalized);
        _rigidbody.velocity = initialVelocity * moveSpeedPerSec;
    }

    private void FixedUpdate() {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(!this._enableRefrectBoost) { return; }
        this._rigidbody.velocity = _rigidbody.velocity * 1.01f;
    }
}
