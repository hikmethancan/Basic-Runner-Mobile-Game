using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    public static bool swipedRight = false;
    public static bool swipedLeft = false;
    
    Vector2 startPos;

    public void Update()
    {
        swipedRight = false;
        swipedLeft = false;
        TouchControl();
        
    }

    void TouchControl()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = new Vector2(t.position.x / (float) Screen.width, t.position.y / (float) Screen.width);
            }

            if (t.phase == TouchPhase.Moved)
            {
                Vector2 endPos = new Vector2(t.position.x / (float) Screen.width, t.position.y / (float) Screen.width);

                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
                
                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                {
                    // Horizontal swipe
                    if (swipe.x > 0)
                    {
                        swipedRight = true;
                    }
                    else
                    {
                        swipedLeft = true;
                    }
                }
            }
            // if (t.phase == TouchPhase.Ended)
            // {
            //
            //     Vector2 endPos = new Vector2(t.position.x / (float) Screen.width, t.position.y / (float) Screen.width);
            //
            //     Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
            //     
            //     if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
            //     {
            //         // Horizontal swipe
            //         if (swipe.x > 0)
            //         {
            //             swipedRight = true;
            //         }
            //         else
            //         {
            //             swipedLeft = true;
            //         }
            //     }
            // }
        }
    }
}

