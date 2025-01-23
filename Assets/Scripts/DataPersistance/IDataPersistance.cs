using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance
{
    void LoadData(GameState state);

    void SaveData(ref GameState state);
}
