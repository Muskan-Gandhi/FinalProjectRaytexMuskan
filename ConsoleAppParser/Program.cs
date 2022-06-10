
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using Microsoft.SqlServer;
using System.Data;
using Database = Microsoft.Azure.Cosmos.Database;
using System.Data.SqlClient;

namespace ConsoleAppParser
{
    internal class Program
    {
        //private static IList<StatusDetails> gsList,isaList;
        public static List<StatusDetails> status = new List<StatusDetails>();
        public static List<Interchange_Control_Header> Isa = new List<Interchange_Control_Header>();
        public static List<Functional_Group_Header> Gs=new List<Functional_Group_Header>();
        public static List<Transaction_Set_Header> St = new List<Transaction_Set_Header>();
        public static Beginning_Segment_for_Inquiry B4 = new Beginning_Segment_for_Inquiry();
        public static List<N9> N9 = new List<N9>();
        
        public static List<Transation_Set_Trailer> Se = new List<Transation_Set_Trailer>();
        public static List<status_details> Q2 = new List<status_details>();
        public static List<Shipment_Status> Sg = new List<Shipment_Status>();
        public static List<Port_Terminal> R4 = new List<Port_Terminal>();
        public static List<Date_Time_Reference> Dtm = new List<Date_Time_Reference>();
        public static List<Interchange_Control_Trailer> Iea = new List<Interchange_Control_Trailer>();
        public static List<Functinal_Group_Trailer> Ge=new List<Functinal_Group_Trailer>();

        private static string assignValue(string[] Statementline, int index)
        {
            try
            {
                return Statementline[index];
            }
            catch (IndexOutOfRangeException)
            {
                return "";
            }
        }
        static void Main(string[] args)
        {

            string path = "C:/Users/Raytex/Desktop/EDI.txt";
            string text = System.IO.File.ReadAllText(path);
            var filePath = @"C:/Users/Raytex/Desktop/EDI-Parser.json";
            //var jsonData; = System.IO.File.ReadAllText(filePath);
            string[] Fees = { "22", "4I", "4I1", "4I2", "4I3", "4I4", "4I5", "4I6", "4I7", "4I8", "4I9", "4IV", "4IE", "TMF", "CTF", "HZP", "FCH", "BBC", "DVF", "USD", "GEN", "SCR", "WCR", "GEC", "DRC", "ATG", "EGF", "IGF", "OOG", "RF", "DWT" };
            string[] json = text.Split('~','>');
            string isa,gs,st,b4,n9,q2,sg,r4,se,ge,iea;
            CosmosConnect cosmosConnect = new CosmosConnect();
            cosmosConnect.CreateDatabaseAsync().Wait();
            cosmosConnect.CreateContainerAsync().Wait();
            //isa = Regex.Replace(isa, @"\s", "");
            //isa = isa.Replace("**", "*");
            //gs = Regex.Replace(gs, @"\s", "");
            //gs = gs.Replace("**", "*");
            //string[] isalist = isa.Split('*');
            double fees = 0;
            string id="";

            //To parse the file and store it in list
            foreach (string jsonStr in json)
            {
               
                if (jsonStr.Contains("ISA"))
                {
                    isa = jsonStr;
                    isa = Regex.Replace(isa, @"\s", "");
                    //isa = isa.Replace("**", "*");
                    Console.WriteLine("ISA");
                    string[] isalist = isa.Split('*');
                    /*for (int i = 0; i < isalist.Length; i++)
                    {
                        Console.WriteLine(isalist[i]);
                    }*/
                    Isa.Add(new Interchange_Control_Header()
                    {
                            ISA01 = isalist[0],
                            ISA02 = isalist[1],
                            ISA03 = isalist[2],
                            ISA04 = isalist[3],
                            ISA05 = isalist[4],
                            ISA06 = isalist[5],
                            ISA07 = isalist[6],
                            ISA08 = isalist[7],
                            ISA09 = isalist[8],
                            ISA10 = isalist[9],
                            ISA11 = isalist[10],
                            ISA12 = isalist[11],
                            ISA13 = isalist[12],
                            ISA14 = isalist[13],
                            ISA15 = isalist[14],
                            ISA16 = isalist[15],
                    });
                    //isaList = new List<Interchange_Control_Header>(){
                    //new Interchange_Control_Header() {  ISA01= isalist[1],ISA02= isalist[2]} };
                    

                }
                if (jsonStr.Contains("GS"))
                {
                    gs = jsonStr;
                    gs = Regex.Replace(gs, @"\s", "");
                    //gs = gs.Replace("**", "*");
                    Console.WriteLine("GS");
                    string[] gslist = gs.Split('*');
                    
                    Gs.Add(new Functional_Group_Header()
                    {
                        GS01 = gslist[0],
                        GS02 = gslist[1],
                        GS03 = gslist[2],
                        GS04 = gslist[3],
                        GS05 = gslist[4],
                        GS06 = gslist[5],
                        GS07 = gslist[6],
                        GS08 = gslist[7]
                    });
                    

                }
                if (jsonStr.Contains("ST"))
                {
                    st = jsonStr;
                    st = Regex.Replace(st, @"\s", "");
                    //st = st.Replace("**", "*");
                    Console.WriteLine("ST");
                    string[] stlist = st.Split('*');
                    
                    St.Add(new Transaction_Set_Header()
                    {
                        ST01 = stlist[0],
                        ST02 = stlist[1]
                    });

                }
                if (jsonStr.Contains("B4"))
                {
                    b4 = jsonStr;
                    b4 = Regex.Replace(b4, @"\s", "");
                    //b4 = b4.Replace("**", "*");
                    Console.WriteLine("B4");
                    string[] b4list = b4.Split('*');
                    /*for (int i = 0; i < b4list.Length; i++)
                    {
                        Console.WriteLine(b4list[i]);
                    }*/
                    
                    B4=(new Beginning_Segment_for_Inquiry()
                    {
                        
                        B401 = assignValue(b4list,0),
                        B402 = assignValue(b4list,1),
                        B403 = assignValue(b4list,2),
                        B404 = assignValue(b4list,3),
                        B405 = assignValue(b4list,4),
                        B406 = assignValue(b4list,5),
                        B407 = assignValue(b4list,6),
                        B408 = assignValue(b4list,7),
                        B409 = assignValue(b4list,8),
                        B4010 = assignValue(b4list,9),
                        B4011 = assignValue(b4list,10),
                        B4012 = assignValue(b4list,11),
                        B4013 = assignValue(b4list,12),
                        B4014= assignValue(b4list,13)
                        
                    });

                    id = assignValue(b4list, 7) + assignValue(b4list, 8);
                }

                if (jsonStr.Contains("N9"))
                {

                    n9 = jsonStr;
                    n9 = Regex.Replace(n9, @"\s", "");
                    //isa = isa.Replace("**", "*");
                    //Console.WriteLine("N9");
                    string[] n9list = n9.Split('*');
                    //for (int i = 0; i < n9list.Length; i++)
                    foreach(string n in n9list)
                    {
                        if (Fees.Contains(n))
                        {
                             fees = fees+ Convert.ToDouble(n9list[2]);
                            
                        }
                    }
                    if (n9list.Length == 3)
                    {
                        N9.Add(new N9()
                        {
                            N901 = n9list[0],
                            N902 = n9list[1],
                            N903 = n9list[2],
                            N904 = "",
                            N905 = "",
                            N906 = "",
                            fee=fees.ToString()
                        });
                        Console.WriteLine(fees);
                    }
                    else
                    {
                        N9.Add(new N9()
                        {
                            N901 = n9list[0],
                            N902 = n9list[1],
                            N903 = n9list[2],
                            N904 = n9list[3],
                            N905 = "",
                            N906 = "",
                            fee = fees.ToString()
                        });
                        Console.WriteLine(fees);
                    }
                   
                    

                }

                
                
                if (jsonStr.Contains("Q2"))
                {
                    q2 = jsonStr;
                    q2 = Regex.Replace(q2, @"\s", "");
                    //q2 = q2.Replace("**", "*");
                    Console.WriteLine("Q2");
                    string[] q2list = q2.Split('*');
                    
                    Q2.Add(new status_details()
                    {
                        Q201 = q2list[0],
                        Q202 = q2list[1],
                        Q203 = q2list[2],
                        Q204 = q2list[3],
                        Q205 = q2list[4],
                        Q206 = q2list[5],
                        Q207 = q2list[6],
                        Q208 = q2list[7],
                        Q209 = q2list[8],
                        Q2010 = q2list[9],
                        Q2011 = q2list[10],
                        Q2012 = q2list[11],
                        Q2013 = q2list[12],
                        Q2014 = q2list[13],
                        Q2015 = q2list[14],
                        Q2016 = q2list[15]
                    });
                    
                }
                
                if (jsonStr.Contains("SG"))
                {
                    sg = jsonStr;
                    sg = Regex.Replace(sg, @"\s", "");
                    //sg = sg.Replace("**", "*");
                    //Console.WriteLine("SG");
                    string[] sglist = sg.Split('*');
                    
                    Sg.Add(new Shipment_Status()
                    {
                        SG01 = sglist[0],
                        SG02 = sglist[1],
                        SG03 = sglist[2],
                        SG04 = sglist[3],
                        SG05 = sglist[4]
                    });
                    
                }

                if (jsonStr.Contains("R4"))
                {
                    r4 = jsonStr;
                    r4 = Regex.Replace(r4, @"\s", "");
                    //r4 = r4.Replace("**", "*");
                    //Console.WriteLine("R4");
                    string[] r4list = r4.Split('*');
                    
                        R4.Add(new Port_Terminal()
                        {
                            R401 = assignValue(r4list, 0),
                            R402 = assignValue(r4list, 1),
                            R403 = assignValue(r4list, 2),
                            R404 = assignValue(r4list, 3),
                            R405 = assignValue(r4list, 4),
                            R406 = assignValue(r4list, 5),
                            R407 = assignValue(r4list, 6),
                            R408 = assignValue(r4list, 7),
                            R409 = assignValue(r4list, 8)

                        });
                    
                }
                    
                    if (jsonStr.Contains("SE"))
                    {
                        se = jsonStr;
                        se = Regex.Replace(se, @"\s", "");
                        //se = se.Replace("**", "*");
                        //Console.WriteLine("SE");
                        string[] selist = se.Split('*');

                        Se.Add(new Transation_Set_Trailer()
                        {
                            SE01 = selist[1],
                            SE02 = selist[2],
                        });
                    StatusDetails edi = new StatusDetails()
                    {
                        id = id,
                        Isa = Isa,
                        Gs = Gs,
                        B4 = B4,
                        St = St,
                        Se = Se,
                        Sg = Sg,
                        N9 = N9,
                        Q2 = Q2,
                        R4 = R4,
                        Dtm = Dtm,
                        Iea = Iea,
                        Ge = Ge,
                        amount = (float)fees

                        };
                    try
                    {
                        
                        SqlConnection conn = new SqlConnection(@"server=.;database=eModalProject;trusted_connection=true;multipleactiveresultsets=true");
                        
                        conn.Open();
                        string insert_query = "insert into Payment (containerId,Amount) values (@containerId ,@Amount)";
                        SqlCommand cmd = new SqlCommand(insert_query, conn);
                        cmd.Parameters.AddWithValue("@containerid", edi.id);
                        cmd.Parameters.AddWithValue("@Amount", fees);


                     cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    fees = 0;
                    var jsonData = JsonConvert.SerializeObject(edi);
                        //System.IO.File.AppendAllText(filePath, jsonData);
                    System.IO.File.WriteAllText(filePath, jsonData);
                    cosmosConnect.AddItemsToContainerAsync().Wait();

                    N9.Clear();
                    Sg.Clear();
                    R4.Clear();

                    
                }
                
           
                

                if (jsonStr.Contains("GE"))
                {
                    ge = jsonStr;
                    ge = Regex.Replace(ge, @"\s", "");
                    //ge = ge.Replace("**", "*");
                    //Console.WriteLine("GE");
                    string[] gelist = ge.Split('*');
                    Ge.Add(new Functinal_Group_Trailer()
                    {
                        GE01= gelist[0],
                        GE02 = gelist[1]

                    });

                }
                if (jsonStr.Contains("IEA"))
                {
                    iea = jsonStr;
                    iea = Regex.Replace(iea, @"\s", "");
                    //iea = iea.Replace("**", "*");
                    //Console.WriteLine("IEA");
                    string[] iealist = iea.Split('*');
                    Iea.Add(new Interchange_Control_Trailer()
                    {
                        IEA01= iealist[0],
                        IEA02= iealist[1]
                    });
                }
            }

            /*for (int i = 0; i < isalist.Length; i++)
            {
                Console.WriteLine(isalist[i]);
            }
            Console.WriteLine("gslist\n");
            for (int i = 0; i < gslist.Length; i++)
            {
                Console.WriteLine(gslist[i]);
                gsList = new List<StatusDetails>(){
                       new StatusDetails() { Name = gslist[i], ContainerId="121" } };
            }
            */

            
            //Console.WriteLine("ISA-----------------");

            //var opt = new JsonSerializerOptions() { WriteIndented = true };
            //string strJson1 = JsonSerializer.Serialize<IList<Interchange_Control_Header>>(Isa, opt);
            
            /*Console.WriteLine("GE-----------------");
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string strJson2 = JsonSerializer.Serialize<IList<StatusDetails>>(gsList, opt);
                       var stList = new List<StatusDetails>(){
                       new StatusDetails() { Id = 101, ContainerId="121" } };

                       var opt = new JsonSerializerOptions() { WriteIndented = true };
                       string strJson = JsonSerializer.Serialize<IList<StatusDetails>>(stList, opt);
                       Console.WriteLine(strJson);*/


        }


        public class CosmosConnect
        {
            private static readonly string EndpointURI = "https://localhost:8081";
            private static readonly string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==   ";

            private CosmosClient cosmosClient;
            private Database database;
            private Container container;

            private string databaseId = "EDIDb";
            private string containerId = "EDIContainer";

            public CosmosConnect()
            {
                try
                {
                    Console.WriteLine("Establish Connection...");
                    this.cosmosClient = new CosmosClient(EndpointURI, PrimaryKey);
                }
                catch (CosmosException cosmosException)
                {
                    Console.WriteLine($"CosmosDb exception {cosmosException.StatusCode}: {cosmosException} ");
                }
                
                catch (AggregateException err)
                {
                    foreach (var errInner in err.InnerExceptions)
                    {
                        Console.WriteLine(errInner); //this will call ToString() on the inner execption and get you message, stacktrace and you could perhaps drill down further into the inner exception of it if necessary 
                    }
                }
                }

            public async Task CreateDatabaseAsync()
            {
                this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
                Console.WriteLine($"Created Database: {this.database.Id}");
                

            }
            public async Task CreateContainerAsync()
            {
                this.container = await this.database.CreateContainerIfNotExistsAsync(this.containerId, "/id");
                Console.WriteLine($"Created Container: {this.containerId}");
            }
            public async Task AddItemsToContainerAsync()
            {
                var filePath = @"C:/Users/Raytex/Desktop/EDI-Parser.json";
                var jsonData = System.IO.File.ReadAllText(filePath);

                JObject EDIObj = JObject.Parse(jsonData);

                Uri collectionUri = UriFactory.CreateDocumentCollectionUri(databaseId, containerId);

                using (DocumentClient DocumentDBclient2 = new DocumentClient(new Uri(EndpointURI), PrimaryKey))
                {
                    Document doc = await DocumentDBclient2.CreateDocumentAsync(collectionUri, EDIObj);
                }
            }
        }
    }
    }
