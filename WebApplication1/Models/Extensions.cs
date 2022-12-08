using NuGet.Configuration;

namespace mVehAuction.Models
{
    public static class Extensions
    {
        /// <summary>
        /// Returns the description of an enum decorated with a DescriptionAttribute
        /// </summary>
        /// <param name="value">An Enumeration value</param>
        /// <returns>The description of an enumeration value</returns>
        public static string GetDescription(this System.Enum value)
        {
            var description = value.ToString();
            var attribute = GetAttribute<System.ComponentModel.DescriptionAttribute>(value);
            if (attribute != null)
            {
                description = attribute.Description;
            }
            return description;
        }

        public static T GetAttribute<T>(System.Enum value) where T : System.Attribute
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = ((T[])field!.GetCustomAttributes(typeof(T), false)).FirstOrDefault();
            return attribute!;
        }
    }
}
