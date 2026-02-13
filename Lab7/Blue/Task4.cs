using System.Globalization;
using System.Runtime.CompilerServices;

namespace Lab7.Blue
{
    public class Task4
    {
        struct LiterallyAlmostNotAnUnefficientDynamicArrayListAndSomeThing()
        {
            int[] buffer = [];
            int len = 0, sum;
            bool sum_calculated = false;

            public int Sum
            {
                get
                {
                    if (sum_calculated) { return this.sum; }
                    this.sum_calculated = true;
                    return this.sum = this.buffer.Sum();
                }
            }

            public readonly bool Has(int target) => this.buffer.Any((item) => item == target);

            public readonly int[] View => (int[])this.buffer.Clone();

            public void Add(int value)
            {
                this.Realloc(extra_values: 1);
                this.Set(value, ^1);
            }

            void Set(int value, Index i) // класс Index не указан в разрешенных, но тут же можно? :)
            {
                this.buffer[i] = value;
                this.sum_calculated = false;
            }

            void Realloc(uint extra_values)
            {
                var new_buffer = new int[this.len + extra_values];
                if (this.len > 0)
                {
                    Array.Copy(this.buffer, new_buffer, this.len);
                }
                this.buffer = new_buffer;
                this.len = new_buffer.Length;
            }
        }

        public struct Team(string name)
        {
            readonly string name = name;
            LiterallyAlmostNotAnUnefficientDynamicArrayListAndSomeThing scores = new();

            public readonly string Name => this.name;
            public readonly int[] Scores => this.scores.View;

            public readonly int TotalScore => this.scores.Sum;

            public void PlayMatch(int result) => this.scores.Add(result);

            public readonly void Print() => Console.WriteLine(this.ToString()); // 0 refs -- метод такой типа: "Я никому не ужин"

            override public readonly string ToString() =>
                $"Team{{Name: \"{this.name}\", Scores: \"{this.Scores}\", TotalScore: {this.TotalScore}}}";
        }


        struct LiterallyAlmostNotAnUnefficientDynamicArrayListAndSomeThing2()
        {
            Team[] buffer = [];
            uint len = 0;

            public readonly Team[] View => (Team[])this.buffer.Clone();
            public readonly bool IsEmpty => 0 == buffer.Length;

            public void Add(params Team[] teams)
            {
                var tail_index = this.len;

                this.Realloc(this.len + (uint)teams.Length);

                for (var i = 0; i < teams.Length; i += 1)
                {
                    this.buffer[tail_index + i] = teams[i];
                }
            }

            void Realloc(uint new_len)
            {
                var new_buffer = new Team[new_len];
                if (this.len > 0)
                {
                    Array.Copy(this.buffer, new_buffer, this.len);
                }
                this.buffer = new_buffer;
                this.len = (uint)new_buffer.Length;
            }

            public readonly void Sort() => Array.Sort(this.buffer, (l, r) => l.TotalScore.CompareTo(r.TotalScore));
        }


        public struct Group(string name)
        {
            readonly string name = name;
            LiterallyAlmostNotAnUnefficientDynamicArrayListAndSomeThing2 teams = new();

            public readonly string Name => this.name;
            public readonly Team[] Teams => this.teams.View;

            public void Add(Team t) => teams.Add(t);

            public void Add(Team[]? t)
            {
                if (t != null) { teams.Add(t); }
            }

            struct Popper(Group g)
            {
                readonly Team[] teams = g.Teams;
                uint pops = 0;

                public Team? Pop()
                {
                    if (this.pops == (uint)teams.Length) { return null; }
                    var i = this.pops;
                    this.pops -= 1;
                    return this.teams[i];
                }

                public static Popper[] Make(params Group[] groups)
                {
                    var ret = new Popper[groups.Length];
                    for (var i = 0u; i < groups.Length; i += 1) { ret[i] = new Popper(groups[i]); }
                    return ret;
                }
            }

            public readonly void Sort() => this.teams.Sort();

            public readonly void Print() => Console.WriteLine(this.ToString()); // 0 refs -- метод такой типа: "Я никому не ужин"

            override public readonly string ToString() => $"Team{{Name: \"{this.name}\", Teams: {{{string.Join(", ", this.Teams)}}}}}";

            public static Group Merge(Group a, Group b, int max_size)
            {
                var ret = new Group("Финалисты");

                var poppers = Popper.Make(a, b);
                var pop_failed_count = 0;
                var current_popper_index = 0;
                for (var i = 0; i < max_size; current_popper_index = (current_popper_index + 1) % poppers.Length)
                {
                    var popped = poppers[current_popper_index].Pop();

                    if (null == popped)
                    {
                        pop_failed_count += 1;
                        continue;
                    }

                    if (poppers.Length == pop_failed_count) { break; }

                    ret.Add((Team)popped);

                    i += 1;
                    pop_failed_count = 0;
                }

                return ret;
            }
        }
    }
}