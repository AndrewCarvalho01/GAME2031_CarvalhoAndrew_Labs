using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTests
{ 

    private const string SceneName = "SampleScene";

    [UnityTest]
    public IEnumerator TestPlayerSetup()
    {
        SceneManager.LoadScene(SceneName);

        Debug.Log("Waiting for scene to load...");

        yield return null;

        PlayerController playerController = GameObject.FindFirstObjectByType<PlayerController>();
        GameObject playerGO = playerController.gameObject;

        // Player Rigidbody 2d
        Rigidbody2D rigidbody2D = playerGO.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rigidbody2D, "Player GameObject has no Rigidbody2D component.");

        // Collider
        Collider2D collider2D = playerGO.GetComponent<Collider2D>();
        Assert.IsNotNull(collider2D, "Player GameObject has no Collider2D component.");

        // rb2d is dyamic
        Assert.AreEqual(RigidbodyType2D.Dynamic, rigidbody2D.bodyType, "Rigidbody2D is not Dynamic.");

        // gravity == 0
        Assert.AreEqual(0f, rigidbody2D.gravityScale, "Gravity scale is not 0.");

        // PlayerController is null

    }
}
