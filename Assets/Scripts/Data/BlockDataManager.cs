using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "BlockDataManager", menuName = "BlockDataManager")]
public class BlockDataManager: ScriptableObject
{
    public List<BlockData> Data;
}

[Serializable]
public class BlockData
{
    public List<Sprite> sprites;
}