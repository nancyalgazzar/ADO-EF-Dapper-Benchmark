using BenchmarkSuiteADO_Dapper_EF.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkSuiteADO_Dapper_EF.Fakers
{
    public  class InstructorFaker:Faker<Instructor>
    {
        public InstructorFaker()
        {
            RuleFor(i => i.Address, f => { string s = f.Address.FullAddress(); return s.Length > 50? s.Substring(0, 49):s; });
            RuleFor(i => i.Age, faker => faker.Random.Number(12, 40));
            RuleFor(i => i.Bdate, faker => { DateTime s = faker.Date.Recent(); return DateOnly.FromDateTime(s); });
            RuleFor(i => i.Fname, faker => faker.Name.FirstName());
            RuleFor(i => i.Lname, faker => faker.Name.LastName());
            RuleFor(i => i.Salary, faker => faker.Random.Double(1000,5000));
            RuleFor(i => i.OverTime, faker => faker.Random.Number());
            RuleFor(i => i.Netsalary, faker => faker.Random.Double());
            RuleFor(i => i.Hiredate, faker => { DateTime s = faker.Date.Recent(); return DateOnly.FromDateTime(s); });
            RuleFor(i => i.CIds,faker => new CourseFaker().Generate(faker.Random.Int(1, 3)));
        }
    }
}
