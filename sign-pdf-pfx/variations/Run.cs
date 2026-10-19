// web projects run from their own folder: write the output next to Program.cs, as the program does
if (Path.GetFileName(Environment.CurrentDirectory) == "variations") Environment.CurrentDirectory = Path.GetFullPath("..");
var name = args.Length > 0 ? args[0] : throw new ArgumentException("Name a variation, for example: dotnet run --project variations -- " + "<Name>");
var run = typeof(Program).Assembly.GetType(name)?.GetMethod("Run") ?? throw new ArgumentException($"No variation named {name}.");
if (run.Invoke(null, null) is Task task) await task;
