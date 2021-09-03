using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InteractableObject.PointerClick += UpdatePosition;
    }

    private void OnDisable()
    {
        InteractableObject.PointerClick -= UpdatePosition;
    }

    // Update is called once per frame
    void UpdatePosition(Vector3 position)
    {
        transform.position = position;
    }
}
