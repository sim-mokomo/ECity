using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MokomoGames
{
    public static class CommonInput
    {
        public static TouchType GetTouch()
        {
            if(Application.isEditor)
            {
                if(Input.GetMouseButtonDown(0))
                    return TouchType.Began;
                if(Input.GetMouseButton(0))
                    return TouchType.Moved;
                if(Input.GetMouseButtonUp(0))
                    return TouchType.Ended;
                return TouchType.None;
            }

            if(Input.touchCount > 0)
            {
                return (TouchType)(int)Input.GetTouch(0).phase;
            }
            return TouchType.None;
        }

        public static Vector3 GetTouchPosition()
        {
            if(Application.isEditor)
            {
                if(GetTouch() != TouchType.None)
                    return Input.mousePosition;
                return Vector3.zero;
            }

            if(Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                return new Vector3(touch.position.x,touch.position.y,0f);
            }
            return Vector3.zero;
        }

        public static Vector3 GetTouchWorldPosition(Camera cam)
        {
            return cam.ScreenToWorldPoint(GetTouchPosition());
        }
    }

    public enum TouchType
    {
        None=99,
        Began=0,
        Moved=1,
        Stationaruy=2,
        Ended=3,
        Canceld=4,
    }
}
