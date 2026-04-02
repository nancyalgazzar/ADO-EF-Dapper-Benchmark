using BenchmarkSuiteADO_Dapper_EF.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSuiteADO_Dapper_EF.Fakers
{
    public class CourseFaker:Faker<Course>
    {
        public CourseFaker()
        {
            RuleFor(c => c.Cname, f =>{string s =  f.Name.JobTitle();return s.Length > 20 ? s.Substring(0, 20) : s; });
            RuleFor(c => c.Duration, f => f.Random.Number(0,2000));
            RuleFor(c => c.IIds,f=> null);
        }
    }
}
