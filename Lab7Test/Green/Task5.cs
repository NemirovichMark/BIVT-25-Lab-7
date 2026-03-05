using System.Reflection;
using System.Text.Json;

namespace Lab7Test.Green
{
    [TestClass]
    public sealed class Task5
    {
        record InputStudent(string Name, string Surname, int[] Marks);
        record InputGroup(string Name, InputStudent[] Students);
        record OutputGroup(string Name, double AverageMark);

        private InputGroup[] _inputGroups;
        private OutputGroup[] _outputGroups;

        private Lab7.Green.Task5.Student[] _studentS;
        private Lab7.Green.Task5.Group[] _studentG;

        [TestInitialize]
        public void LoadData()
        {
            var folder = Directory.GetParent(Directory.GetCurrentDirectory())
                                  .Parent.Parent.Parent.FullName;
            folder = Path.Combine(folder, "Lab7Test", "Green");

            var input = JsonSerializer.Deserialize<JsonElement>(
                File.ReadAllText(Path.Combine(folder, "input.json")))!;
            var output = JsonSerializer.Deserialize<JsonElement>(
                File.ReadAllText(Path.Combine(folder, "output.json")))!;

            _inputGroups = input.GetProperty("Task5").Deserialize<InputGroup[]>();
            _outputGroups = output.GetProperty("Task5").Deserialize<OutputGroup[]>();

            _studentS = _inputGroups.SelectMany(g => g.Students)
                                     .Select(s => new Lab7.Green.Task5.Student(s.Name, s.Surname))
                                     .ToArray();
