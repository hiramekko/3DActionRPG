using UnityEngine;

/// <summary>
/// アイテムの基底クラス
/// </summary>

public abstract class ItemBase : MonoBehaviour
{
    public abstract void Activate();

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("当たった");
            Activate();
        }
    }

    protected void Destroy() => Destroy(gameObject);
}
