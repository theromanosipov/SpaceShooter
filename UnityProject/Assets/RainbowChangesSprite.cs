using UnityEngine;
using System.Collections;

public class RainbowChangesSprite : RainbowChanges {

    private SpriteRenderer spriteRenderer;

    public override void Start() {
        base.Start();
        spriteRenderer = renderer as SpriteRenderer;
    }

    public override void assignColor(Color newColor) {
        spriteRenderer.color = newColor;
    }
}
