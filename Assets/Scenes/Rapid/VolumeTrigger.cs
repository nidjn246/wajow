using UnityEngine;
using UnityEngine.Rendering;

public class VolumeTrigger : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] private float transitionSpeed = 1f;
    private float targetWeight = 1f;
    private void OnTriggerEnter(Collider other)
    {

        targetWeight = 1;

    }
    private void OnTriggerExit(Collider other)
    {

        targetWeight = 0f;

    }

    private void Update()
    {
        volume.weight = Mathf.Lerp(volume.weight, targetWeight, Time.deltaTime);
    }
}
