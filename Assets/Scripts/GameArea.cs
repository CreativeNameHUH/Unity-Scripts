using UnityEngine;

public class GameArea : Variables
{
    public Component Room;

    private void Update()
    {
        if (GameAreaUpdate)
        {
            Vector3 size = new Vector3 { x = GameAreaSize, y = 1, z = GameAreaSize };

            Room = GetComponent<Component>();
            Room.transform.localScale = size;
            GameAreaUpdate = false;
        }
    }
}
