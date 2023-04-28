namespace UrzisoftCarflowBackendApp.UseCases.Utils
{
    public class AzureBlobFileNameBuilder
    {
        public static string GetBrandFileName(string brandName)
        {
            return brandName;
        }

        public static string GetCarFileName(string brandName, string modelName, string licensePlate)
        {
            return brandName + "-" + modelName + "-" + licensePlate;
        }
    }
}
