using IronPython.Hosting;
using Logistic.Models;
using Microsoft.Scripting.Hosting;
namespace Logistic.Code
{
    public class BuildingMap
    {
        public string FiltrMap(List<RangePoint> points)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            engine.ExecuteFile("Code/buildMap.py", scope);
            dynamic square = scope.GetVariable("parse");
            return square(points);

        }
        
    }
}
