using System.ComponentModel;

namespace Scaffold.Domain.Dtos.Users.GetToken;

public record UserClaims(int Id, string Name, string Document)
{
    public IDictionary<string, object> ToDictionary()
    {
        var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            
        GetValues("", this, dict);

        return dict;
    }
    
    private static void GetValues(string prefix, object obj, Dictionary<string, object> dict)
    {
        var properties = TypeDescriptor.GetProperties(obj);
            
        if (properties.Count == 0) 
            return;

        foreach (PropertyDescriptor property in properties)
        {
            var nextObject = property.GetValue(obj);
            var nextPrefix = (String.IsNullOrEmpty(prefix) ? property.Name : $"{prefix}.{property.Name}");

            if (nextObject.GetType().IsGenericType)
                GetValues(nextPrefix, nextObject, dict);
            else
                dict.Add(nextPrefix, nextObject);
        }
    }
}