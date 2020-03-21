using System.Collections.Generic;
using MokomoGames.Protobuf;
using UnityEngine;

public class SpriteResourcesProvider
{
    private static readonly Dictionary<Attribute, string> attributeSpriteTable = new Dictionary<Attribute, string>
    {
        {Attribute.Fire, "FireIcon"},
        {Attribute.Water, "WaterIcon"},
        {Attribute.Wood, "WoodIcon"},
        {Attribute.Light, "LightIcon"},
        {Attribute.Shadow, "ShadowIcon"}
    };

    public static Sprite GetAttributeIcon(Attribute attribute)
    {
        attributeSpriteTable.TryGetValue(attribute, out var path);
        var sprite = Resources.Load<Sprite>(path);
        return sprite;
    }

    public static Sprite GetCharacterIcon(string spriteName)
    {
        var sprite = Resources.Load<Sprite>(spriteName);
        return sprite;
    }
}