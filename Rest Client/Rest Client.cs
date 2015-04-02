using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Rest_Client
{
 
    
    public partial class RestClient : Form
    {
        
        

        private List<string> lines = new List<string>();
        private List<string> resultLines = new List<string>();
        private string outputFile = "output.csv";
        
        private const string fileFilter = "Text Files (*.txt) |*.txt|Comma Separated Value (*.csv)|*.csv";
        private const string urlGeocode = "http://www.onemap.sg/API/services.svc/basicSearch?token=qo/s2TnSUmfLz+32CvLC4RMVkzEFYjxqyti1KhByvEacEdMWBpCuSSQ+IFRT84QjGPBCuz/cBom8PfSm3GjEsGc8PkdEEOEr&searchVal=";
        private const string optionsGeocode = "&otptFlds=SEARCHVAL,CATEGORY&returnGeom=1&rset=1";
        private const string urlReverseGeocode = "http://www.onemap.sg/API/services.svc/revgeocode?token=qo/s2TnSUmfLz+32CvLC4RMVkzEFYjxqyti1KhByvEacEdMWBpCuSSQ+IFRT84QjGPBCuz/cBom8PfSm3GjEsGc8PkdEEOEr&location="; //37949.0265,34465.7386
        private const string optionsReverseGeocode = "&buffer=1&addressType=HDB";
        public RestClient()
        {
            InitializeComponent();
        }

        private void CallRest_Click(object sender, EventArgs e)
        {
            callRest();
        }

        // parse result for Reversed Geocoding XY to address/postal

        private Tuple<string, string, string, string, string> parseReversedGeocodeResult(string x, string y, string result)
        {
            const string errorMessage = "ErrorMessage";

            if (result.Contains(errorMessage))
            {
                return Tuple.Create<string, string, string, string, string>(x, y, "NotFound", "NotFound", "NotFound");
            }
            else
            {
                JObject jobjResult = JObject.Parse(result);
                //{ "GeocodeInfo":[{"BUILDINGNAME":"PING YI GARDENS","BLOCK":"1","ROAD":"CHAI CHEE ROAD","POSTALCODE":"461001","XCOORD":"37949.02647326","YCOORD":"34465.73856911"}]}
                IList<JToken> searchResults = jobjResult["GeocodeInfo"].Children().ToList();

                PostalResult postalResult = JsonConvert.DeserializeObject<PostalResult>(searchResults[0].ToString());

                return Tuple.Create<string, string, string, string, string>(x, y, postalResult.block, postalResult.road, postalResult.postalCode);
                
            }
        }




        // parsing result for Geocoding postal code to XY
        private Tuple<string, string, string> parseResult(string postal ,string result)
        {
            const string errorMessage = "ErrorMessage";
            

            if (result.Contains(errorMessage))
            {
                return Tuple.Create<string, string, string>(postal, "NotFound", "NotFound");
            }
            else
            {
                
                // use json.net
                JObject jobjResult = JObject.Parse(result);
                //{"SearchResults":[{"PageCount":"0"},{"SEARCHVAL":"569830","CATEGORY":"Building","X":"29726.7712","Y":"40192.3482"}]}
                IList<JToken> searchResults = jobjResult["SearchResults"].Children().ToList();

                XYResult xyResult = JsonConvert.DeserializeObject<XYResult>(searchResults[1].ToString());

                return Tuple.Create<string, string, string>(postal, xyResult.xValue,  xyResult.yValue); ;

            }

            
        }

        private async void callRest()
        {
            // create a new http client
            HttpClient client = new HttpClient();
            
            //progressBar.Maximum = lines.Count - 1;
            /*
             * {"SearchResults":[{"PageCount":"0"},{"SEARCHVAL":"569830","CATEGORY":"Building","X":"29726.7712","Y":"40192.3482"}]}
             * 
             * {"SearchResults":[{"ErrorMessage":"No result(s) found."}]}
             */

            try
            {
               
                progressBar.Maximum =lines.Count;
                responseText.Text += "\r\nGetting data ...";


                if (radioPostalToXY.Checked == true) // postal to XY is geocoding
                {
                    resultLines.Add("Postal,X,Y");
                    int i = 0;

                    foreach (string postal in lines)
                    {

                        string completeUrl = urlGeocode + postal + optionsGeocode;
                        HttpResponseMessage response = await client.GetAsync(completeUrl);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        Tuple<string, string, string> restultTuple = parseResult(postal, responseBody);

                        resultLines.Add(restultTuple.Item1 + "," + restultTuple.Item2 + "," + restultTuple.Item3);
                        i++;
                        progressBar.Value = i;

                        progressBar.Update();
                    }
                }
                else  // XY to Postal is reversed geocoding
                {
                    resultLines.Add("X,Y,Block,Street,Postal");
                    int j = 0;

                    foreach (string xy in lines)
                    {
                        string x = xy.Split(',')[0];
                        string y = xy.Split(',')[1];

                        string completeUrl = urlReverseGeocode + xy + optionsReverseGeocode;
                        HttpResponseMessage response = await client.GetAsync(completeUrl);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        Tuple<string, string, string, string, string> resultTuple = parseReversedGeocodeResult(x, y, responseBody);

                        resultLines.Add(resultTuple.Item1 + "," + resultTuple.Item2 + "," + resultTuple.Item3 + "," + resultTuple.Item4 + "," + resultTuple.Item5);
                        j++;
                        progressBar.Value = j;
                        progressBar.Update();
                    }
                }
                
            }
            catch (HttpRequestException e)
            {
                responseText.Text += "\r\nError " + e.ToString();
            }
            client.Dispose();
            responseText.Text += "\r\nDone ...";
            writeToFile();
        }
            

       
        private void writeToFile()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFile))
            {
                foreach (string line in resultLines)
                {
                    file.WriteLine(line);
                }
            }
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = fileFilter;
            
            openFileDialog1.Multiselect = false;

            DialogResult dialogResult = openFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                int counter = 0;
                string line;
                string fileName = openFileDialog1.FileName;
                textBoxInput.Text = fileName;
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);

                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                    counter++;
                }
                file.Close();
                responseText.Text = "Total rows: " + counter;
                progressBar.Value = 0;
            }
        }

        private void buttonOutput_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = fileFilter;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFile = saveFileDialog1.FileName;
                responseText.Text += "\r\nOutput will be written to >>>> " + outputFile;
                textBoxOutput.Text = outputFile;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioPostalToXY_CheckedChanged(object sender, EventArgs e)
        {
            displayInstruction();
        }

        private void radioXYToPostal_CheckedChanged(object sender, EventArgs e)
        {
            displayInstruction();
        }

        private void displayInstruction()
        {
            if (radioPostalToXY.Checked)
            {
                label1.Text = "*Input file must have a column of Singapore postal codes";
            }
            else
            {
                label1.Text = "*Input file must have a column of XY values separated by comma";
            }
        }

        



       
    }

    [DataContract]
    public class PostalResult
    {
        // { "GeocodeInfo":[{"BUILDINGNAME":"PING YI GARDENS","BLOCK":"1","ROAD":"CHAI CHEE ROAD","POSTALCODE":"461001","XCOORD":"37949.02647326","YCOORD":"34465.73856911"}]}
        [DataMember(Name = "BUILDINGNAME")]
        public string buildingName { get; set; }

        [DataMember(Name = "BLOCK")]
        public string block { get; set; }

        [DataMember(Name = "ROAD")]
        public string road { get; set; }

        [DataMember(Name = "POSTALCODE")]
        public string postalCode { get; set; }

        [DataMember(Name = "XCOORD")]
        public string xcoord { get; set; }

        [DataMember(Name = "YCOORD")]
        public string ycoord { get; set; }

    }

    [DataContract]
    public class XYResult
    {
        //{"SearchResults":[{"PageCount":"0"},{"SEARCHVAL":"569830","CATEGORY":"Building","X":"29726.7712","Y":"40192.3482"}]}
        [DataMember(Name = "SEARCHVAL")]
        public string postalCode { get; set; }
        [DataMember(Name = "CATEGORY")]
        public string cat { get; set; }
        [DataMember(Name = "X")]
        public string xValue { get; set; }
        [DataMember(Name = "Y")]
        public string yValue { get; set; }
    }
       
}
