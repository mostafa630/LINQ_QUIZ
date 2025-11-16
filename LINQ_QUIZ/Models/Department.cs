namespace LINQ_QUIZ.Models
{
    internal class Department
    {
        public readonly static Department IT = new(1, "IT");
        public readonly static Department SERVICE_GROUP = new(2, "ServiceGroups");
        public readonly static Department HR = new(3, "HR");
        public readonly static Department OIL_AND_GAS = new(4, "oil and gas");

        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<User> Users { get; private set; }
        private Department(int id, string name)
        {
            Id = id;
            Name = name;
            Users = new List<User>();
        }

        public static IEnumerable<string> GetAllDeptsNames()
        {
            return new List<string>()
            {
                IT.Name ,
                SERVICE_GROUP.Name ,
                HR.Name ,
                OIL_AND_GAS.Name
            };
        }
        public static Department GetDeptByName(string name)
        {
            var dept = name switch
            {
                "IT" => IT,
                "ServiceGroups" => SERVICE_GROUP,
                "HR" => HR,
                "oil and gas" => OIL_AND_GAS
            };

            return dept;
        }
        public override string ToString()
        {
            return $"Department Id = {Id} , Department Name = {Name}";
        }

    }
}
