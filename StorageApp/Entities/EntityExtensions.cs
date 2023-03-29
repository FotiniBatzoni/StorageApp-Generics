using Newtonsoft.Json;


namespace StorageApp.Entities
{
    public static class EntityExtensions
    {
        public static T Copy<T>(this T itemToCopy) where T : IEntity
        {
            var json = System.Text.Json.JsonSerializer.Serialize(itemToCopy);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
