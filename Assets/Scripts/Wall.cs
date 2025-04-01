using UnityEngine;

public class Wall : MonoBehaviour
{
    public Block Blockprefab;
    public float speed;
    private int blockCount = 4;
    int [] height = new int[4];
    float [] posY = new float[4];
    
    private void Start()
    {
        InvokeRepeating(nameof(SpawnBlocks), 1f, 5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.left *( speed * Time.deltaTime));
    }

    private void RandomHeight()
    {
        height[0] = Random.Range(1,5);
        height[1] = 5-height[0];
        height[2] = Random.Range(1,5);
        height[3] = 5 - height[2];
    }

    private void SetPostY()
    {
        posY[1] = height[1]/2f;
        posY[0] = height[1] + height[0] / 2f;
        posY[2] = -height[2] / 2f;
        posY[3] = -height[2] - height[3] / 2f;
    }
    private void SpawnBlocks()
    {
        RandomHeight();
        SetPostY();
        for (int i=0; i<blockCount;i++)
        {
            SpawnBlock(i);
        }
    }

    private void SpawnBlock(int id)
    {
        var block = PoolingManager.Spawn(Blockprefab, transform.position, Quaternion.identity);
        block.transform.SetParent(transform);
        block.transform.position = new Vector3(15f, posY[id], 0f);
        block.name = "Block " + (id +1);
        block.SetSize(1, height[id]);
        block.SetColliderY(height[id]);
        block.SetPosY(posY[id]);
    }
}
