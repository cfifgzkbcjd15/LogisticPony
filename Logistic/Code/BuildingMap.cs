using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
namespace Logistic.Code
{
    public class BuildingMap
    {
        public void FiltrMap()
        {
            int number = 5;
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();

            engine.ExecuteFile("Code/buildMap.py", scope);
            dynamic square = scope.GetVariable("square");
            // вызываем функцию и получаем результат
            int result = square(number);
            var a = result;

        }
        
    }
}
