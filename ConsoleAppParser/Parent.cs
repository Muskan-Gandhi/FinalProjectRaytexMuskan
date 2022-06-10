using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppParser
{
    internal class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ContainerId { get; set; }
        public string? TreadType { get; set; }

        public string? Status { get; set; }
        public string? Holds { get; set; }
        public string? PreGateTickets { get; set; }
        public string? EmodelPreGateStatus { get; set; }

        public string? TerminalPreGateStatus { get; set; }

        public string? Origin { get; set; }

        public string? Destination { get; set; }
        public string? CurrentLocation { get; set; }
        public string? Line { get; set; }
        public string? VesselName { get; set; }
        public string? VesselCode { get; set; }
        public string? Voyage { get; set; }
        public string? SizeType { get; set; }
        public int Fees { get; set; }
        public string? LFG_GTD { get; set; }
        public string? Tags { get; set; }
    }
}
