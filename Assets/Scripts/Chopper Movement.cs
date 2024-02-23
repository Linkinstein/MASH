
using System;
using UnityEngine;

public class ChopperMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 0;

    [SerializeField] public Boolean playing = true;
    [SerializeField] public int holding = 0;

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(x, y, 0);
            move = Vector3.ClampMagnitude(move, 1f);

            gameObject.transform.position += (move * speed);
            if (gameObject.transform.position.x > 6) gameObject.transform.position = new Vector3(6, gameObject.transform.position.y, gameObject.transform.position.z);
            if (gameObject.transform.position.x < -6) gameObject.transform.position = new Vector3(-6, gameObject.transform.position.y, gameObject.transform.position.z);
            if (gameObject.transform.position.y > 3.5) gameObject.transform.position = new Vector3(gameObject.transform.position.x, 3.5f, gameObject.transform.position.z);
            if (gameObject.transform.position.y < -3.5) gameObject.transform.position = new Vector3(gameObject.transform.position.x, -3.5f, gameObject.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            playing = false;
        }
        if (other.gameObject.CompareTag("Soldier"))
        {
            Debug.Log("Soldier!");
        }
        if (other.gameObject.CompareTag("Tent"))
        {
            Debug.Log("Tent!");
        }
    }
}
