namespace UrzisoftCarflowBackendApp.UseCases.Utils
{
    public class AzureBlobFileNameBuilder
    {
        public static string GetFileNameBasedOnValue(string value)
        {
            return value;
        }

        public static string GetFileNameBasedOnThreeValues(string firstValue, string secondValue, string thirdValue)
        {
            return firstValue + "-" + secondValue + "-" + thirdValue;
        }

        public static string GetFileNameBasedOnTwoValues(string firstValue, string secondValue)
        {
            return firstValue + "-" + secondValue;
        }
    }
}
