using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

  [SerializeField] GameObject player;
  private TextMeshProUGUI textMesh;
  private float maxDeltaTime = 0f;
  private Vector2 mousePos = Vector2.zero;

  // Start is called before the first frame update
  void Start()
  {
    textMesh = GameObject.Find("TestText").GetComponent<TextMeshProUGUI>();
  }

  // Update is called once per frame
  void Update()
  {
    if (textMesh)
    {
      if (Time.deltaTime > maxDeltaTime)
      {
        maxDeltaTime = Time.deltaTime;
      }
      string infoText = "@NOW:" + Time.deltaTime + "\n@MAX:" + maxDeltaTime;
      textMesh.SetText(infoText);
    }

    if (Input.GetMouseButtonDown(0))
      mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    // slowly move player to mouse position
    player.transform.position = Vector2.MoveTowards(player.transform.position, mousePos, 0.001f);
  }
}
