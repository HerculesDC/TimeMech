using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparison : MonoBehaviour
{
    [SerializeField] private float m_speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(1, 0, 0) * m_speed * Time.deltaTime);
    }
}
