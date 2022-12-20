
using System;
using UnityEngine;

  [RequireComponent(typeof(Rigidbody))]
  public class TowerRotator : MonoBehaviour
{
    
    private Vector3 _oldposit;
    

    private Quaternion positionY;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldposit = Input.mousePosition;
        }
        
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = _oldposit - Input.mousePosition;
            positionY = Quaternion.Euler(0,delta.x * .1f * Time.timeScale ,0);
            transform.rotation *= positionY;
            _oldposit = Input.mousePosition;
        }

    }
    
   
}
