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

        public static string GetCarServiceFileName(string serviceName, string serviceAddress)
        {
            return serviceName + "-" + serviceAddress;
        }
    }
}
