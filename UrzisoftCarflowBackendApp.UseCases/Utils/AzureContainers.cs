namespace UrzisoftCarflowBackendApp.UseCases.Utils
{
    public class AzureContainers
    {
        private readonly static string CarFlowCarsContainer = "carflow-cars";
        private readonly static string CarFlowBrandsContainer = "carflow-brands";
        private readonly static string CarFlowCarServicesContainer = "carflow-carservices";
        private readonly static string CarFlowCarWashStationsContainer = "carflow-carwashstations";
        private readonly static string CarFlowCitiesContainer = "carflow-cities";
        private readonly static string CarFlowGasStations = "carflow-gasstations";

        public static string GetCarFlowCarsContainer()
        {
            return CarFlowCarsContainer;
        }

        public static string GetCarFlowBrandsContainer()
        {
            return CarFlowBrandsContainer;
        }

        public static string GetCarFlowCarServicesContainer()
        {
            return CarFlowCarServicesContainer;
        }

        public static string GetCarFlowWashStationsContainer()
        {
            return CarFlowCarWashStationsContainer;
        }

        public static string GetCarFlowCitiesContainer()
        {
            return CarFlowCitiesContainer;
        }

        public static string GetCarFlowGasStations()
        {
            return CarFlowGasStations;
        }
    }
}
