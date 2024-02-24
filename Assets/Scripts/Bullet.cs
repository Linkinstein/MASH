using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    [SerializeField] private bool fired = false;
    private Vector2 direction;

    public void SetTarget(Transform heliTransform)
    {
        direction = (heliTransform.position - transform.position).normalized;
        fired = true;
    }

    void Update()
    {
        if (fired) transform.Translate(direction * speed * Time.deltaTime);
        if (!IsVisibleFromCamera())
        {
            Destroy(gameObject);
        }
    }

    bool IsVisibleFromCamera()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
