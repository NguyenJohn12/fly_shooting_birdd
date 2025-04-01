using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
  public SpriteRenderer sr;
  public BoxCollider2D coll;

  public int maxHP;
  public int curHP;
  public BlockData blockData;

  public void OnEnable()
  {
    curHP = maxHP;
    var listBlockData = GameManager.Instance.blockDataManager.Data;
    int random = UnityEngine.Random.Range(0, listBlockData.Count);
    blockData = listBlockData[random];
    ChangeSprite(blockData.sprites[curHP-1]);
  }

  public void TakeDamage(int damage)
  {
    curHP -= damage;
    if (curHP <= 0)
    {
      PoolingManager.Despawn(gameObject);
      return;
    }
    ChangeSprite(blockData.sprites[curHP-1]);
  }
  private void ChangeSprite(Sprite sprite)
  {
    sr.sprite = sprite;
  }

  public void SetSize(int width, int height)
  {
    sr.size = new Vector2(width, height);
  }

  public void SetPosY(float y)
  {
    transform.position = new Vector2(transform.position.x, y);
  }

  /// Tăng kích thước Collider
  public void SetColliderY(float y)
  {
    coll.size = new Vector2(coll.size.x,y);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Bullet"))
    {
      TakeDamage(1);
    }
  }
}
