using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    //I just fixed this cause it was missing Collider2D collider and my game wouldn't run
    //You can delete these comments when you see them though! 
  void OnCollisionEnter2D (Collider2D collider)
    {
        if (collider.tag == "Button")
        {

        }
    }
}
