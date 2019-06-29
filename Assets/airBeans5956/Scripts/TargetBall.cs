using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBall : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private Vector3 _movementVolocity = Vector3.forward;
    private bool _enableRefrectBoost = true;

    public float moveSpeedPerSec = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody>();
        _movementVolocity = Vector3.Normalize(this.transform.forward + this.transform.right);
        var initialVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        Debug.Log(_movementVolocity);
        initialVelocity = Vector3.Normalize(this.transform.forward + this.transform.right + initialVelocity.normalized);
        _rigidbody.velocity = initialVelocity * moveSpeedPerSec;
        //this._rigidbody.AddForce(initialVelocity * moveSpeedPerSec, ForceMode.VelocityChange);
    }

    private void FixedUpdate() {
        //_rigidbody.velocity = _movementVolocity * moveSpeedPerSec * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(!this._enableRefrectBoost) { return; }
        this._rigidbody.velocity = _rigidbody.velocity * 1.0005f;
        //this._rigidbody.AddForce(this._rigidbody.velocity.normalized * 1.1f, ForceMode.VelocityChange);
        StartCoroutine(DisableRefrectBoost());
    }

    private IEnumerator DisableRefrectBoost() {
        this._enableRefrectBoost = false;
        yield return new WaitForSeconds(0.2f);
        this._enableRefrectBoost = true;
    }
}
