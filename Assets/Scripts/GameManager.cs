using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    private void OnEnable()
    {
        print(name + " created");
    }
}
