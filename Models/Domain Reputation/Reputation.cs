using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeguridad.Models.Domain_Reputation
{
    public class DomainReputationResponse
    {
        public string mode { get; set; }
        public double reputationScore { get; set; }
        public List<TestResult> testResults { get; set; }
    }

    public class TestResult
    {
        public string test { get; set; }
        public int testCode { get; set; }
        public List<Warning> warnings { get; set; }
    }

    public class Warning
    {
        public string warningDescription { get; set; }
        public int warningCode { get; set; }
    }


}
