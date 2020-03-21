using System.Collections.Generic;
using Google.Protobuf;

namespace MokomoGames
{
    public static class DictionaryExtensions
    {
        public static Dictionary<string, string> JsonDictionary<T>(this Dictionary<string, string> self,IMessage<T> message) where T: class,IMessage<T>
        {
            var jsonMessage = JsonFormatter.Default.Format(message);
            return new Dictionary<string, string>{{"json",jsonMessage}};
        }
    }
}