using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Utils.Input;
using Project.Gameplay.GameplayObjects.Character;
using Project.Interactive;

public class ClickableController : MonoBehaviour {

    [SerializeField] LayerMask clickableLayers;
    // Start is called before the first frame update
    void Start() {
        PlayerInputController.Instance.OnClick2D += OnClick;
    }


    private void OnDestroy() {
        PlayerInputController.Instance.OnClick2D -= OnClick;
    }

    private void OnClick(Vector2 clickPosition) {
        float maxDistance = 100;

        var hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(clickPosition), maxDistance, clickableLayers);

        foreach (RaycastHit hit in hits) {
            if (hit.transform.gameObject.TryGetComponent(out Interactive elem)) {
                if (elem.clickable.enabled) {
                    elem.clickable.Click(hit);
                }
            }
        }
    }
}