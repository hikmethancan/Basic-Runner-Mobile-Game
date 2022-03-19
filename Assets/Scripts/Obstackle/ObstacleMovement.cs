using System.Collections;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float turningSpeed;
    
    public Vector3 startPos, endPos;
    public bool repeatable = false;
    public float speed = 1.0f;
    public float duration = 3.0f;

    private float startTime, totalDistance;

    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * turningSpeed);
    }

    //  for initialization and repeatable movement
    IEnumerator Start() {
        // startPos = new Vector3(4.5f,transform.position.y,transform.position.z);
        startPos = transform.position;
        endPos = new Vector3(-4.5f,transform.position.y,transform.position.z);
        startTime = Time.time;
        totalDistance = Vector3.Distance(startPos, endPos);
        //Movement Loop
        while(repeatable) {
            yield return RepeatLerp(startPos, endPos, duration);
            yield return RepeatLerp(endPos, startPos, duration);
        }
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time) {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            this.transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
