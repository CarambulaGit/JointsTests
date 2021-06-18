using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveZVelocity;
    private Vector3 oldVelocity = Vector3.zero;

    private bool _stop;
    private bool isStopValueChanged;

    private bool Stop {
        get => _stop;
        set {
            if (_stop.Equals(value)) {
                return;
            }

            _stop = value;
        }
    }

    private void Start() {
        if (!(rb is null)) return;
        if (!gameObject.TryGetComponent(out rb)) {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            _stop = true;
        }
        else if (Input.GetKeyDown(KeyCode.W)) {
            _stop = false;
        }
    }

    private void FixedUpdate() {
        if (!_stop) {
            // rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            // rb.AddForce(moveVelocity * Time.fixedDeltaTime);
            // var newVelocity = moveVelocity * Time.fixedDeltaTime;
            // rb.velocity += newVelocity - oldVelocity;
            // oldVelocity = newVelocity;
            // rb.velocity += newVelocity;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveZVelocity * Time.fixedDeltaTime);
        }
    }
}


public struct VarState<T> {
    private T _value;

    public T Value {
        get => _value;
        set {
            if (_value.Equals(value)) {
                StateChanged = false;
                return;
            }

            _value = value;
            StateChanged = true;
        }
    }

    public bool StateChanged { get; private set; }
}