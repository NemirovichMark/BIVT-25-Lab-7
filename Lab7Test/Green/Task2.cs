using System.Reflection;
using System.Text.Json;

namespace Lab7Test.Green
{
    [TestClass]
    public sealed class Task2
    {
        record InputRow(string Name, string Surname, int[] Marks);
        record OutputRow(string Name, string Surname, double AverageMark, bool IsExcellent);

        private InputRow[] _input;
        private OutputRow[] _output;
        private Lab7.Green.Task2.Student[] _student;

        [TestInitialize]
        public void LoadData()
        {
            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            folder = Path.Combine(folder, "Lab7Test", "Green");

            var input = JsonSerializer.Deserialize<JsonElement>(
                File.ReadAllText(Path.Combine(folder, "input.json")))!;
            var output = JsonSerializer.Deserialize<JsonElement>(
                File.ReadAllText(Path.Combine(folder, "output.json")))!;

            _input = input.GetProperty("Task2").Deserialize<InputRow[]>();
            _output = output.GetProperty("Task2").Deserialize<OutputRow[]>();
            _student = new Lab7.Green.Task2.Student[_input.Length];
        }

        [TestMethod]
        public void Test_00_OOP()
        {
            var type = typeof(Lab7.Green.Task2.Student);
            Assert.IsTrue(type.IsValueType, "Student должен быть структурой");
        }
    }
}

