namespace News.Tests
{
    using AutoMapper;
    using News.Api.Infrastructure.Mapping;

    public class TestStartup
    {
        private static bool testInitilized = false;

        public static void Initilize()
        {
            if (!testInitilized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testInitilized = true;
            }
        }
    }
}