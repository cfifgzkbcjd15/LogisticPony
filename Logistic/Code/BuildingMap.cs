using IronPython.Hosting;
using Logistic.Models;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.Text.Json;

namespace Logistic.Code
{
    public class BuildingMap
    {
        public string FiltrMap(List<List<decimal>> points)
        {
            //            ScriptEngine engine = Python.CreateEngine();
            //            ScriptScope scope = engine.CreateScope();
            //            var libs = new[] {
            //    "C:/Program Files/IronPython 2.7/Lib",
            //    "C:/Program Files/IronPython 2.7/ExternalLib/site-packages",
            //    //"C:\\Program Files\\IronPython 2.7",
            //    //"C:\\Program Files\\IronPython 2.7\\lib\\site-packages"
            //};

            //            engine.SetSearchPaths(libs);
            //            engine.ExecuteFile(@"D:\Desktop\Proekts\Logistic\Logistic\bin\Debug\main.py", scope);
            //            dynamic square = scope.GetVariable("parse");
            //            return square(points);
            var jsonPoints = JsonSerializer.Serialize(points);
            var proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.WorkingDirectory = @"D:";
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.CreateNoWindow = false;

            proc.Start();
            proc.StandardInput.WriteLine(@"cd D:/Desktop/Proekts/Logistic/Logistic/bin/Debug");
            //proc.StandardInput.WriteLine($"python -c \"import main; print(main.parse({jsonPoints}))\"");
            var output = proc.StandardOutput.ReadToEnd();
            //proc.Close();
            proc.WaitForExit();
            return output.ToString();
            //
            //proc.Kill();
            //
            //

        }

    }
}
