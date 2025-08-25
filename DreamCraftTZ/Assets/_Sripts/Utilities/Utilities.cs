using UnityEngine;

namespace  HelpUtilities
{
    public static class Utilities 
    {
        public static Vector3 GetWorldMousePosition()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            return mousePosition;
        }

        public static Vector3 GetInvisiblePoint()
        {
            Camera cam = Camera.main;

            Vector3 topLeft     = cam.ViewportToWorldPoint(new Vector3(0, 1, cam.nearClipPlane));
            Vector3 topRight    = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
            Vector3 bottomLeft  = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
            Vector3 bottomRight = cam.ViewportToWorldPoint(new Vector3(1, 0, cam.nearClipPlane));

            int side = Random.Range(0, 4);
            float randomX = 0f;
            float randomY = 0f;

            switch (side)
            {
                case 0: 
                    randomX = bottomLeft.x - Random.Range(0.5f, 1f);
                    randomY = Random.Range(bottomLeft.y, topLeft.y);
                    break;

                case 1: 
                    randomX = bottomRight.x + Random.Range(0.5f, 1f);
                    randomY = Random.Range(bottomRight.y, topRight.y);
                    break;

                case 2:
                    randomX = Random.Range(topLeft.x, topRight.x);
                    randomY = topLeft.y + Random.Range(0.5f, 1f);
                    break;

                case 3: 
                    randomX = Random.Range(bottomLeft.x, bottomRight.x);
                    randomY = bottomLeft.y - Random.Range(0.5f, 1f);
                    break;
            }
            return new Vector3(randomX, randomY, 0);
        }
    }
}