namespace UrzisoftCarflowBackendApp.UseCases.Utils
{
    public class AzureContainers
    {
        private readonly static string CarFlowCarsContainer = "carflow-cars";

        public static string GetCarFlowCarsContainer()
        {
            return CarFlowCarsContainer;
        }
    }
}
