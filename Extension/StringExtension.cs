using System.Linq;

namespace AoiHosizora.Swagger.Extension {

    internal static class StringExtension {
        public static string ToSnakeCase(this string str) {
            return string.Concat(str.Select((character, index) =>
                index > 0 && char.IsUpper(character) ? "_" + character : character.ToString()
            )).ToLower();
        }
    }
}
