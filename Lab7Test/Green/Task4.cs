using System.Reflection;
using System.Text.Json;

namespace Lab7Test.Green
{
    [TestClass]
    public sealed class Task4
    {
        record InputRow(string Name, string Surname, double[] Jumps);
        record OutputRow(string Name, string Surname, double BestJump);

        private InputRow[] _input;
        private OutputRow[] _output;
        private Lab7.Green.Task4.Participant[] _student;

        [TestInitialize]
        public void LoadData()
        {
            var folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            folder = Path.Combine(folder, "Lab7Test", "Green");

            var input = JsonSerializer.Deserialize<JsonElement>(
                File.ReadAllText(Path.Combine(folder, "input.json")))!;
            var output = JsonSerializer.Deserialize<JsonElement>(
                File.ReadAllText(Path.Combine(folder, "output.json")))!;

            _input = input.GetProperty("Task4").Deserialize<InputRow[]>();
            _output = output.GetProperty("Task4").Deserialize<OutputRow[]>();
            _student = new Lab7.Green.Task4.Participant[_input.Length];
        }

        [TestMethod]
        public void Test_00_OOP()
        {
            var type = typeof(Lab7.Green.Task4.Participant);
            Assert.IsTrue(type.IsValueType, "Participant должен быть структурой");
        }
    }
}

