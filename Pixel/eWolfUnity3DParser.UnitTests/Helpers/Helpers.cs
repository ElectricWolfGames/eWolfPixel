using System.IO;
using System.Reflection;

namespace eWolfUnity3DParser.UnitTests.Helpers
{
    public static class Helpers
    {
        public static string LoadFile(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNameFullPath = $"eWolfUnity3DParser.UnitTests.TestingData.{resourceName}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceNameFullPath))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}