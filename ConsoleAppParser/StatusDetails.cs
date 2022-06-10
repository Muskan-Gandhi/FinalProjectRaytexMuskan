using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppParser
{
    internal class StatusDetails
    {
        public string id { get; set; } 
        [JsonProperty("status")]
        public List<StatusDetails> status { get; set; }
        [JsonProperty("Isa")]
        public List<Interchange_Control_Header> Isa { get; set; }
        [JsonProperty("Gs")]
        public List<Functional_Group_Header> Gs { get; set; }
        [JsonProperty("St")]
        public List<Transaction_Set_Header> St { get; set; }
        [JsonProperty("B4")]
        public Beginning_Segment_for_Inquiry B4 { get; set; }
        [JsonProperty("N9")]
        public List<N9> N9 { get; set; }
        [JsonProperty("Se")]
        public List<Transation_Set_Trailer> Se { get; set; }
        [JsonProperty("Q2")]
        public List<status_details> Q2 { get; set; }
        [JsonProperty("Sg")]
        public List<Shipment_Status> Sg { get; set; }
        [JsonProperty("R4")]
        public List<Port_Terminal> R4 { get; set; }
        [JsonProperty("Dtm")]
        public List<Date_Time_Reference> Dtm { get; set; }
        [JsonProperty("Iea")]
        public List<Interchange_Control_Trailer> Iea { get; set; }
        [JsonProperty("Ge")]
        public List<Functinal_Group_Trailer> Ge { get; set; }
        public float amount { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

}
