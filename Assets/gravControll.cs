using UnityEditor;
using UnityEngine;

public class gravControll : MonoBehaviour
{
    public mcscript script;
    public Rigidbody2D thisRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 Scaler = transform.localScale;
            Scaler.y = script.gravChange;
            transform.localScale = Scaler;
            thisRigidbody.gravityScale = script.gravChange;
        
    }
}
