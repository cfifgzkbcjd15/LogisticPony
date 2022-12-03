using IronPython.Hosting;
using Logistic.Models;
using Microsoft.Scripting.Hosting;
namespace Logistic.Code
{
    public class BuildingMap
    {
        public string FiltrMap(List<RangePoint> points,string path)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            var libs = new[] {
    "C:/Program Files/IronPython 2.7/Lib",
    "C:/Program Files/IronPython 2.7/ExternalLib/site-packages",
    //"C:\\Program Files\\IronPython 2.7",
    //"C:\\Program Files\\IronPython 2.7\\lib\\site-packages"
};

            engine.SetSearchPaths(libs);
            engine.ExecuteFile(@"D:\Desktop\Proekts\Logistic\Logistic\bin\Debug\main.py", scope);
            dynamic square = scope.GetVariable("parse");
            return square(points);

        }
        
    }
}
