using System;
using System.Collections.Generic;
using System.Text;

namespace BackendArchitecture.Entities
{
    public class AnalysisTagResult : EntityBase
    {
        public string Name { get; set; }

        public int Ocurrences { get; set; }
    }
}
