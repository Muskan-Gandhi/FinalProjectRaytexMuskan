using Newtonsoft.Json;

namespace Web1.Models
{
    public class EDI
    {
        
            public string id { get; set; }
            //public string status { get; set; }
            public List<Isa> isa { get; set; }
            public Dtm dtm { get; set; }
            //public List<Ge> ge { get; set; }
            public B4 b4 { get; set; }
            //public List<Gs> gs { get; set; }
            //public List<St> st { get; set; }
            public List<N9> n9 { get; set; }
            //public List<Se> se { get; set; }
            public Q2 q2 { get; set; }
            public List<R4> r4 { get; set; }
            //public List<Iea> iea { get; set; }
            public List<Sg> sg { get; set; }

            //public float amount { get; set; }




            public class B4
            {
                //[JsonProperty("Special_Handling_Code")]
                public string B401 { get; set; }
                //[JsonProperty("Inquery_Request_No")]

                public string B402 { get; set; }
                //[JsonProperty("Shipement_Status_Code")]

                public string B403 { get; set; }
                //[JsonProperty("ReleaseDate")]
                public string B404 { get; set; }
                //[JsonProperty("ReleaseTime")]
                public string B405 { get; set; }
                //[JsonProperty("Status_Location")]
                public string B406 { get; set; }
                //[JsonProperty("Equipment_Initial")]
                public string B407 { get; set; }
                //[JsonProperty("Equipment_Number")]
                public string B408 { get; set; }
                //[JsonProperty("Equipment_Status_Code")]
                public string B409 { get; set; }
                //[JsonProperty("Equipment_Type")]
                public string B410 { get; set; }
                public string B411 { get; set; }
                public string B412 { get; set; }

            }
            public class Dtm
            {
                //[JsonProperty("DTQ")]
                public string DTM01 { get; set; }
                //[JsonProperty("Date")]
                public string DTM02 { get; set; }
                //[JsonProperty("Time")]
                public string DTM03 { get; set; }
                public string DTM04 { get; set; }
                public string DTM05 { get; set; }
                public string DTM06 { get; set; }
            }
            public class Ge
            {
                //[JsonProperty("Number_Transaction_Set")]
                public string GE01 { get; set; }
                //[JsonProperty("GE2")]
                public string GE02 { get; set; }
            }

            public class Gs
            {
                //[JsonProperty("Functional_Identifier_Code")]
                public string GS01 { get; set; }
                //[JsonProperty("Sender_code")]
                public string GS02 { get; set; }
                //[JsonProperty("Reciever_Code")]
                public string GS03 { get; set; }

                //[JsonProperty("GroupDate")]
                public string GS04 { get; set; }
                //[JsonProperty("GorupTime")]
                public string GS05 { get; set; }
                //[JsonProperty("GCN")]
                public string GS06 { get; set; }
                //[JsonProperty("Agency_Code")]
                public string GS07 { get; set; }
                //[JsonProperty("Version")]
                public string GS08 { get; set; }
            }
            public class Iea
            {
                public string IEA01 { get; set; }
                public string IEA02 { get; set; }
            }
            public class Isa
            {
                //[JsonProperty("SenderID")]
                public string ISA01 { get; set; }
                //[JsonProperty("RecieverID")]
                public string ISA02 { get; set; }
                //[JsonProperty("Date")]
                public string ISA03 { get; set; }
                //[JsonProperty("Time")]
                public string ISA04 { get; set; }
                //[JsonProperty("ICSID")]
                public string ISA05 { get; set; }
                //[JsonProperty("InterchangeVersion")]
                public string ISA06 { get; set; }
                //[JsonProperty("ICN")]
                public string ISA07 { get; set; }
                //[JsonProperty("Acknow_request")]
                public string ISA08 { get; set; }
                //[JsonProperty("Test_Indicator")]
                public string ISA09 { get; set; }
                public string ISA10 { get; set; }
                public string ISA11 { get; set; }
                public string ISA12 { get; set; }
                public string ISA13 { get; set; }
                public string ISA14 { get; set; }
                public string ISA15 { get; set; }
                public string ISA16 { get; set; }
            }

            public class N9
            {
                //[JsonProperty("Ref_Id_Qualifier")]

                public string N901 { get; set; }
                //[JsonProperty("Ref_Id")]
                public string N902 { get; set; }

                //[JsonProperty("Fees")]
                public string N903 { get; set; }
                public string N904 { get; set; }
                public string N905 { get; set; }
                public string N906 { get; set; }
                

        }

            public class Q2
            {
                //[JsonProperty("Vessel_Code")]
                public string Q201 { get; set; }
                //[JsonProperty("Country_Code")]
                public string Q202 { get; set; }
                //[JsonProperty("voyage_Number")]
                public string Q203 { get; set; }
                //[JsonProperty("Vessel_Name")]
                public string Q204 { get; set; }
                //[JsonProperty("Weight")]
                public string Q205 { get; set; }
                //[JsonProperty("Weight_Qualifier")]
                public string Q206 { get; set; }
                public string Q207 { get; set; }
                public string Q208 { get; set; }
                public string Q209 { get; set; }
                public string Q210 { get; set; }
                public string Q211 { get; set; }
                public string Q212 { get; set; }
                public string Q213 { get; set; }
                public string Q214 { get; set; }
                public string Q215 { get; set; }
                public string Q216 { get; set; }
            }
            public class R4
            {
                //[JsonProperty("Port_Function_Code")]
                public string R401 { get; set; }
                //[JsonProperty("Location_Qualifier")]
                public string R402 { get; set; }
                //[JsonProperty("Location_Identifier")]
                public string R403 { get; set; }
                public string R404 { get; set; }
                public string R405 { get; set; }

            }
            public class Se
            {
                //[JsonProperty("Number_of_Segments")]
                public string SE01 { get; set; }

                //[JsonProperty("Transaction_Set_Control_Number")]
                public string SE02 { get; set; }

            }
            public class St
            {
                //[JsonProperty("Shipment_Status_Code")]
                public string ST01 { get; set; }
                //[JsonProperty("Date")]
                public string ST02 { get; set; }


            }
            public class Sg
            {
                public string SG01 { get; set; }
                public string SG02 { get; set; }
                public string SG03 { get; set; }
                public string SG04 { get; set; }
                public string SG05 { get; set; }
            }
        }
}
