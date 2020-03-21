using MokomoGames.Protobuf;

namespace MokomoGames
{
    public static class AttributeEnumExtensions
    {
        public static string GetName(this Attribute self)
        {
            switch (self)
            {
                case Attribute.Fire:
                    return "火属性";
                case Attribute.Water:
                    return "水属性";
                case Attribute.Wood:
                    return "木属性";
                case Attribute.Light:
                    return "光属性";
                case Attribute.Shadow:
                    return "闇属性";
                case Attribute.Unknown:
                default:
                    return "???";
            }
        }
    }
}