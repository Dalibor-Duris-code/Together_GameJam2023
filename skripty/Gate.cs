using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    [ContextMenu("open")]
    public void open()
    {
        _animator.SetTrigger("open");
    }
}
