using System.Reflection;
using DataFlowAuthorizationMapper.Attributes;

namespace DataFlowAuthorizationMapper
{
    public static class DataFlowAuthorizationMapper
    {
        private static readonly Dictionary<(Type, Type), Dictionary<string, PropertyInfo>> PropertyMappings = new();

        public static U Map<T, U>(string[] roles, T source, U? destination = null) where T : class where U : class
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            destination ??= Activator.CreateInstance<U>();

            var sourceProperties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var destinationProperties = GetDestinationProperties<T, U>();

            foreach (var sourceProperty in sourceProperties)
            {
                var mapToAttr = sourceProperty.GetCustomAttribute<MapToAttribute>();
                var fieldName = mapToAttr is not null ? mapToAttr.PropertyName : sourceProperty.Name;

                if (destinationProperties.TryGetValue(fieldName, out var destinationProperty) &&
                    IsAuthorized(sourceProperty, roles))
                {
                    var sourceValue = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, sourceValue);
                }
            }

            return destination;
        }

        private static bool IsAuthorized(PropertyInfo sourceProperty, string[] roles)
        {
            var customAttr = sourceProperty.GetCustomAttribute<DataFlowAuthorizeAttribute>();
            return customAttr is null || customAttr.IsValid(roles);
        }

        private static Dictionary<string, PropertyInfo> GetDestinationProperties<T, U>()
        {
            var cacheKey = (typeof(T), typeof(U));

            if (!PropertyMappings.TryGetValue(cacheKey, out var destinationProperties))
            {
                destinationProperties = typeof(U).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .ToDictionary(p => p.GetCustomAttribute<MapToAttribute>()?.PropertyName ?? p.Name, p => p);

                PropertyMappings[cacheKey] = destinationProperties;
            }

            return destinationProperties;
        }
    }
}