using UnityEngine;
using System.Collections;
public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 3f;

    public void MoveTo(Vector3 targetPosition)
    {
        StartCoroutine(MoveToCoroutine(targetPosition));
    }

    private IEnumerator MoveToCoroutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}