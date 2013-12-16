//THIS IS MY PROGRAM THAT I HAVE DESIGNED AND CODED FOR MY SECOND YEAR, FIRST TERM ASSIGNMENT IN CNT2
//THIS HAS BEEN CODED BY JAMES FLETCHER (11033350)

//-----NAMESPACES THAT I WILL BE USING WITHIN MY PROGRAM-----
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Assignment_Data_Analyser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //THIS ALLOWS MY EXTERNAL NAMESPACES TO BE INCLUDING IN MY PROJECT WHEN IT IS EXECUTED INTO AN EXECUTABLE FILE
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };

            InitializeComponent();
        }

        //-----THESE ARE MY VARIABLES FOR USE WITHIN MY PROGRAM-----
        string fileName, fileExtension;
        int counter = 0;
        int counter1 = 0;
        double dataSum1 = 0;
        double dataAve;

        string[,] dataArray = new string[53000, 6];  //CREATING THE ARRAY BIG ENOUGH TO STORE ALL OF THE PIECES OF DATA

        Series series1 = new Series();  //SERIES FOR USE WITH THE CHART WHEN PLOTTING DATA
        Series series2 = new Series();

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
        }

        //-----METHOD FOR WHEN BROWSE BUTTON IS CLICKED-----
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_Browse.Text = "" + openFileDialog1.FileName + "";  //ALLOWING THE USER TO SEARCH FOR THEIR FILE
            }
        }

        //-----METHOD FOR WHEN OPEN BUTTON IS CLICKED-----
        private void btn_Open_Click(object sender, EventArgs e)
        {
            fileName = txt_Browse.Text;  //ASSIGNING THE FILE PATH TO THE VARIABLE FILE NAME

            if (cb_FileType.Text == "CSV")  //IF USER HAS STATED THEY WISH TO OPEN A CSV FILE
            {                
                fileExtension = Path.GetExtension(fileName);  //MAKES SURE THE USER HAS SELECTED THE CORRECT FILE
                
                if (fileExtension == ".csv")  //IF THE USER HAS SELECTED CORRECT FILE, THEN PERFORM FOLLOWING
                {
                    using (StreamReader dataStream = new StreamReader(fileName))  //STREAMREADER FOR DATA
                    {
                        int i = 1;

                        dataStream.ReadLine();  //READ TITLE OF DOCUMENT, SO ISNT STORED IN ARRAY

                        while (dataStream.Peek() >= 0)  //WHILE END OF FILE HAS NOT BEEN REACHED
                        {
                            var split = dataStream.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);  //SPLITTING BITS OF DATA WITH A COMMA

                            for (int j = 0; j < split.Length; j++) //WHEN J IS LESS THAN LENGHT OF ARRAY, 1 IS ADDED TO J
                            {
                                dataArray[i, j] = split[j];     //this for loop is assigning each string to the row i within the array, each string after this is assigned to collumn j in order
                            }

                            counter = counter + 1;

                            i++;  //ADD 1 TO I                    
                        }
                        dataStream.Close();  //STREAMREADER CLOSED 
                    }

                    MessageBox.Show("File Loaded");  //FILE LOADED SUCCESSFULLY INTO ARRAY

                    btn_Browse.Enabled = false;  //SO THAT THE USER CAN'T TRY AND LOAD IN ANOTHER FILE INTO THE PROGRAM
                    btn_Open.Enabled = false;
                }

                else
                {
                    MessageBox.Show("Please select correct file format");  //USER HAS SELECTED WRONG FILE FORMAT
                }
            }

            else if (cb_FileType.Text == "XML")  //IF USER WISHES TO OPEN AN XML FILE
            {
                fileExtension = Path.GetExtension(fileName);


                if (fileExtension == ".xml")  //CHECKING THE SELECTED FILE IS AN XML
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(fileName);  //SETTING UP AND LOADING THE XML DOCUMENT READY FOR DATA HANDLING

                    XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/root/row");  //GOING TO THE NODES WITHIN THE ROOT AND ROW NODES WITHIN THE FILE
                                                                                //SO THAT DATA CAN BE EASILY ACCESSED

                    foreach (XmlNode xmlNode in xmlNodeList)  //FOR EACH NODE PRESENT WITHIN THE FILE DO THE FOLLOWING
                    {
                        string millis = xmlNode["millis"].InnerText;
                        dataArray[counter, 0] = millis;  //ASSIGNING THE DATA WITHIN THE "MILLIS" TAG TO THE ARRAY
                                                         //COUNTER PROVIDES THE ROW THE DATA WILL BE STORED IN
                        string stamp = xmlNode["stamp"].InnerText;
                        dataArray[counter, 1] = stamp;  //DOING THE SAME BUT WITHIN THE NEXT COLLUM

                        string datetime = xmlNode["datetime"].InnerText;
                        dataArray[counter, 2] = datetime;

                        string light = xmlNode["light"].InnerText;
                        dataArray[counter, 3] = light;

                        string temp = xmlNode["temp"].InnerText;
                        dataArray[counter, 4] = temp;

                        string vcc = xmlNode["vcc"].InnerText;
                        dataArray[counter, 5] = vcc;

                        counter = counter + 1;  //ITERATES THROUGH THE FILE AND PERFORMS THIS FOR EVERY BIT OF DATA UNTIL END OF FILE HAS BEEN REACHED

                    }
                  
                    MessageBox.Show("File Loaded");  //FILE LOADED SUCCESSFULLY INTO ARRAY

                    btn_Browse.Enabled = false;
                    btn_Open.Enabled = false;
                }

                else
                {
                    MessageBox.Show("Please select the correct file format");  //IF THE USER HAS NOT SELECTED THE CORRECT FILE FORMAT, SHOW THIS ERROR MESSAGE
                }



            }

            else if (cb_FileType.Text == "JSON")  //USER WISHED TO LOAD JSON FILE
            {
                fileExtension = Path.GetExtension(fileName);  //GETTING FILE EXTENSION

                if (fileExtension == ".json")  //IS FILE EXTENSION CORRECT?
                {
                    fileName = txt_Browse.Text;                    

                    JsonSerializer jsonSerialiser = new JsonSerializer();  //GETTING READY TO SERIALIZE DATA SO THAT IT CAN BE HANDLED

                    using (StreamReader reader = File.OpenText(fileName))  //OPENING STREAMREADER AND STORING FILE TEXT WITHIN IT
                    {
                        JArray jsonArray = (JArray)JToken.ReadFrom(new JsonTextReader(reader));  //READING THE FILE TEXT INTO A JSON ARRAY READY TO HANDLE AND SORT

                            foreach (JObject jsonData in jsonArray)  //FOR EVERY OBJECT WITHIN THE CREATED ARRAY PERFORM THE FOLLOWING
                            {
                                dataArray[counter, 0] = (jsonData["millis"].ToString());  //ASSIGNING THE DATA WITHIN "MILLIS" TAG TO THE ARRAY SIMILAR TO EARLIER WITH XML
                                dataArray[counter, 1] = (jsonData["stamp"].ToString());  //PERFORMING THE SAME FOR THE REST OF THE DATA
                                dataArray[counter, 2] = (jsonData["datetime"].ToString());
                                dataArray[counter, 3] = (jsonData["light"].ToString());
                                dataArray[counter, 4] = (jsonData["temp"].ToString());
                                dataArray[counter, 5] = (jsonData["vcc"].ToString());


                                counter = counter + 1;  //ITERATING THROUGH THE DATA AND ARRAY USING THE COUNTER
                            }
                        
                    }                 
                    
                    MessageBox.Show("File Loaded");

                    btn_Browse.Enabled = false;
                    btn_Open.Enabled = false;
                }

                else
                {
                    MessageBox.Show("Please select the correct file format");
                }
            }

            else
            {
                MessageBox.Show("Please select the current file format!");
            }
        }

        private void btn_Plot_Click(object sender, EventArgs e)
        {
            int clickCount = 0;  //COUNT FOR COUNTING HOW MANY TIMES PLOT BUTTON IS PRESSED

            clickCount = clickCount + 1;  //WHENEVER PLOT BUTTON IS PRESSED ADD 1 TO CLICKCOUNT

            if (clickCount >= 1)  //IF PLOT BUTTON IS CLICKED AGAIN, CLEAR CHART SO THAT IT DOESNT PLOT IT TWICE ON THE SCREEN, KEEPS IT PROFESSIONAL
            {
                series1.Points.Clear();  //CLEARING THE SERIES OF ANY VALUES THAT HAVE BEEN PLOTTED
                series2.Points.Clear();
            }

            if (cb_Plot.Text == "Average Temperature/Hour")
            {
                //THESE IF STATEMENTS RESET THE NAMES OF THE SERIES WHENEVER THE USER WISHES TO PLOT SOMETHING, THIS ALLOWS THEM TO BE NAMED AGAIN WITH NO ERRORS
                if (series1.Name != "")  //IF SERIES1 NAME DOES NOT EQUAL THIS
                {
                    series1.Name = "";  //THEN RENAME SERIES1 THIS
                }
                if (series2.Name != " ")  //IF SERIES2 NAME DOES NOT EQUAL THIS
                {
                    series2.Name = " ";  //THEN RENAME SERIES2 THIS
                }

                chartAverage(4);  //RUNNING CHARTAVERAGE METHOD AND ASSIGNING "CHOICE" AS 4 WHICH IS TEMP COLLUMN IN ARRAY
                series1.Name = "Temperature";  //NOW NAMING THE PREVIOUSLY RENAMED SERIES TO THIS SO THE USER CAN UNDERSTAND THE CHART EASILY
            }
            else if (cb_Plot.Text == "Average Temp vs Average Light/Hour")
            {
                if (series1.Name != "")
                {
                    series1.Name = "";
                }
                if (series2.Name != " ")
                {
                    series2.Name = " ";
                }

                chartAverage(4);                
                chartAverage1(3);  //3 IS LIGHT COLLUMN IN ARRAY 
                series1.Name = "Temperature";
                series2.Name = "Light";
            }
            else if (cb_Plot.Text == "Average Voltage/Hour")
            {
                if (series1.Name != "")
                {
                    series1.Name = "";
                }
                if (series2.Name != " ")
                {
                    series2.Name = " ";
                }

                chartAverage(5);                   
                series1.Name = "Voltage";
                
            }
            else if (cb_Plot.Text == "Average Voltage vs Average Light/Hour")
            {
                if (series1.Name != "")
                {
                    series1.Name = "";
                }
                if (series2.Name != " ")
                {
                    series2.Name = " ";
                }

                chartAverage(5);
                chartAverage1(3);
                series1.Name = "Light";
                series2.Name = "Voltage";
            }
            else if (cb_Plot.Text == "Average Light/Hour")
            {
                if (series1.Name != "")
                {
                    series1.Name = "";
                }
                if (series2.Name != " ")
                {
                    series2.Name = " ";
                }

                chartAverage(3);                
                series1.Name = "Light";
                
            }
            else if (cb_Plot.Text == "Average Temp vs Average Voltage/Hour")
            {
                if (series1.Name != "")
                {
                    series1.Name = "";
                } 
                if (series2.Name != " ")
                {
                    series2.Name = " ";
                }

                chartAverage(4);
                chartAverage1(5);
                series1.Name = "Temperature";
                series2.Name = "Voltage";
            }
            else
            {
                MessageBox.Show("Please select a valid entry from the menu");
            }
        }

        //-----METHOD FOR GETTING DATA AVERAGE AND THEN PLOTTING THESE VALUES ON THE GRAPH-----
        public void chartAverage(int choice)
        {
            try  //TRY AND PERFORM THE FOLLOWING
            {
                double dataAve1 = calcAverage(choice, 1, 3600000);  //CALLING THE METHOD TO CALCULATE AVERAGE FOR THE 1ST HOUR
                double dataAve2 = calcAverage(choice, 3600001, 7200000); //2ND HOUR
                double dataAve3 = calcAverage(choice, 7200001, 10800000);  //3RD HOUR
                double dataAve4 = calcAverage(choice, 10800001, 14400000);  //SO ON....
                double dataAve5 = calcAverage(choice, 14400001, 18000000);
                double dataAve6 = calcAverage(choice, 18000001, 21600000);
                double dataAve7 = calcAverage(choice, 21600001, 25200000);
                double dataAve8 = calcAverage(choice, 25200001, 28800000);
                double dataAve9 = calcAverage(choice, 28800001, 32400000);
                double dataAve10 = calcAverage(choice, 32400001, 36000000);
                double dataAve11 = calcAverage(choice, 36000001, 39600000);
                double dataAve12 = calcAverage(choice, 39600001, 43200000);
                double dataAve13 = calcAverage(choice, 43200001, 46800000);
                double dataAve14 = calcAverage(choice, 46800001, 50400000);

                series1.Points.Add(dataAve1);  //PLOTTING 1ST HOUR AVERAGE ON GRAPH
                series1.Points.Add(dataAve2);  //2ND
                series1.Points.Add(dataAve3);  //3RD
                series1.Points.Add(dataAve4);  //SO ON....
                series1.Points.Add(dataAve5);
                series1.Points.Add(dataAve6);
                series1.Points.Add(dataAve7);
                series1.Points.Add(dataAve8);
                series1.Points.Add(dataAve9);
                series1.Points.Add(dataAve10);
                series1.Points.Add(dataAve11);
                series1.Points.Add(dataAve12);
                series1.Points.Add(dataAve13);
                series1.Points.Add(dataAve14);
            }

            catch
            {
                MessageBox.Show("Chart can't be plotted!");  //ERROR MESSAGE TO BE DISPLAYED IF THE ABOVE CAN'T BE PERFORMED
            }
        }

        //-----METHOD FOR GETTING DATA AVERAGE AND PLOTTING THEM, IF MORE THAN ONE AVERAGE IS NEEDED-----
        public void chartAverage1(int choice)
        {
            try
            {
                double DataAve1 = calcAverage(choice, 1, 3600000);
                double DataAve2 = calcAverage(choice, 3600001, 7200000);
                double DataAve3 = calcAverage(choice, 7200001, 10800000);
                double DataAve4 = calcAverage(choice, 10800001, 14400000);
                double DataAve5 = calcAverage(choice, 14400001, 18000000);
                double DataAve6 = calcAverage(choice, 18000001, 21600000);
                double DataAve7 = calcAverage(choice, 21600001, 25200000);
                double DataAve8 = calcAverage(choice, 25200001, 28800000);
                double DataAve9 = calcAverage(choice, 28800001, 32400000);
                double DataAve10 = calcAverage(choice, 32400001, 36000000);
                double DataAve11 = calcAverage(choice, 36000001, 39600000);
                double DataAve12 = calcAverage(choice, 39600001, 43200000);
                double DataAve13 = calcAverage(choice, 43200001, 46800000);
                double DataAve14 = calcAverage(choice, 46800001, 50400000);

                series2.Points.Add(DataAve1);
                series2.Points.Add(DataAve2);
                series2.Points.Add(DataAve3);
                series2.Points.Add(DataAve4);
                series2.Points.Add(DataAve5);
                series2.Points.Add(DataAve6);
                series2.Points.Add(DataAve7);
                series2.Points.Add(DataAve8);
                series2.Points.Add(DataAve9);
                series2.Points.Add(DataAve10);
                series2.Points.Add(DataAve11);
                series2.Points.Add(DataAve12);
                series2.Points.Add(DataAve13);
                series2.Points.Add(DataAve14);
            }
            
            catch
            {
                MessageBox.Show("Chart can't be plotted!");
            }
        }

        //-----METHOD ALLOWING THE USER TO SEE CERTAIN VALUES FOR A GIVEN HOUR-----
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cb_Hour.Text == "1")  //IF USER HAS SELECTED THE HOUR 1
            {
                lblMinLight.Text = calcMinValue(3, 1, 3600000).ToString();  //CALLING METHOD TO RETRIEVE MINUMUM VALUE FOR LIGHT COLLUMN, 1ST HOUR AND DISPLAYING IT TO USER
                lblMaxLight.Text = calcMaxValue(3, 1, 3600000).ToString();  //CALLING METHOD TO RETRIEVE MAXIMUM VALUE FOR LIGHT COLLUMN, 1ST HOUR AND DISPLAYING IT TO USER
                lblMinTemp.Text = calcMinValue(4, 1, 3600000).ToString();  //DISPLAYING MIN TEMP TO USER
                lblMaxTemp.Text = calcMaxValue(4, 1, 3600000).ToString();  //DISPLAYING MAX TEMP TO USER
                lblMinVolt.Text = calcMinValue(5, 1, 3600000).ToString();  //DISPLAYING MIN VOLTAGE TO USER
                lblMaxVolt.Text = calcMaxValue(5, 1, 3600000).ToString();  //DISPLAYING MAX VOLTAGE TO USER

                lblAveLight.Text = Math.Round(calcAverage(3, 1, 3600000), 2).ToString();  //CALLING METHOD TO WORK OUT AVERAGE WITHIN THE LIGHT COLLUMN, 1ST HOUR, ROUNDING TO 2 DP AND DISPLAYING TO USER
                lblAveTemp.Text = Math.Round(calcAverage(4, 1, 3600000), 2).ToString();  //DISPLAYING AVERAGE TEMP TO 2 DP TO USER
                lblAveVolt.Text = Math.Round(calcAverage(5, 1, 3600000), 2).ToString();  //DISPLAYING AVERAGE VOLTAGE TO 2 DP TO USER
            }

            else if (cb_Hour.Text == "2")  //SAME FOR HOUR 2 AND SO ON...
            {
                lblMinLight.Text = calcMinValue(3, 3600001, 7200000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 3600001, 7200000).ToString();
                lblMinTemp.Text = calcMinValue(4, 3600001, 7200000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 3600001, 7200000).ToString();
                lblMinVolt.Text = calcMinValue(5, 3600001, 7200000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 3600001, 7200000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 3600001, 7200000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 3600001, 7200000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 3600001, 7200000), 2).ToString();
            }

            else if (cb_Hour.Text == "3")
            {
                lblMinLight.Text = calcMinValue(3, 7200001, 10800000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 7200001, 10800000).ToString();
                lblMinTemp.Text = calcMinValue(4, 7200001, 10800000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 7200001, 10800000).ToString();
                lblMinVolt.Text = calcMinValue(5, 7200001, 10800000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 7200001, 10800000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 7200001, 10800000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 7200001, 10800000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 7200001, 10800000), 2).ToString();
            }

            else if (cb_Hour.Text == "4")
            {
                lblMinLight.Text = calcMinValue(3, 10800001, 14400000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 10800001, 14400000).ToString();
                lblMinTemp.Text = calcMinValue(4, 10800001, 14400000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 10800001, 14400000).ToString();
                lblMinVolt.Text = calcMinValue(5, 10800001, 14400000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 10800001, 14400000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 10800001, 14400000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 10800001, 14400000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 10800001, 14400000), 2).ToString();
            }

            else if (cb_Hour.Text == "5")
            {
                lblMinLight.Text = calcMinValue(3, 14400001, 18000000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 14400001, 18000000).ToString();
                lblMinTemp.Text = calcMinValue(4, 14400001, 18000000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 14400001, 18000000).ToString();
                lblMinVolt.Text = calcMinValue(5, 14400001, 18000000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 14400001, 18000000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 14400001, 18000000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 14400001, 18000000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 14400001, 18000000), 2).ToString();
            }

            else if (cb_Hour.Text == "6")
            {
                lblMinLight.Text = calcMinValue(3, 18000001, 21600000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 18000001, 21600000).ToString();
                lblMinTemp.Text = calcMinValue(4, 18000001, 21600000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 18000001, 21600000).ToString();
                lblMinVolt.Text = calcMinValue(5, 18000001, 21600000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 18000001, 21600000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 18000001, 21600000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 18000001, 21600000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 18000001, 21600000), 2).ToString();
            }
            else if (cb_Hour.Text == "7")
            {
                lblMinLight.Text = calcMinValue(3, 21600001, 25200000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 21600001, 25200000).ToString();
                lblMinTemp.Text = calcMinValue(4, 21600001, 25200000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 21600001, 25200000).ToString();
                lblMinVolt.Text = calcMinValue(5, 21600001, 25200000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 21600001, 25200000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 21600001, 25200000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 21600001, 25200000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 21600001, 25200000), 2).ToString();
            }

            else if (cb_Hour.Text == "8")
            {
                lblMinLight.Text = calcMinValue(3, 25200001, 28800000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 25200001, 28800000).ToString();
                lblMinTemp.Text = calcMinValue(4, 25200001, 28800000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 25200001, 28800000).ToString();
                lblMinVolt.Text = calcMinValue(5, 25200001, 28800000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 25200001, 28800000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 25200001, 28800000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 25200001, 28800000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 25200001, 28800000), 2).ToString();
            }
            else if (cb_Hour.Text == "9")
            {
                lblMinLight.Text = calcMinValue(3, 28800001, 32400000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 28800001, 32400000).ToString();
                lblMinTemp.Text = calcMinValue(4, 28800001, 32400000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 28800001, 32400000).ToString();
                lblMinVolt.Text = calcMinValue(5, 28800001, 32400000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 28800001, 32400000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 28800001, 32400000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 28800001, 32400000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 28800001, 32400000), 2).ToString();
            }

            else if (cb_Hour.Text == "10")
            {
                lblMinLight.Text = calcMinValue(3, 32400001, 36000000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 32400001, 36000000).ToString();
                lblMinTemp.Text = calcMinValue(4, 32400001, 36000000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 32400001, 36000000).ToString();
                lblMinVolt.Text = calcMinValue(5, 32400001, 36000000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 32400001, 36000000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 32400001, 36000000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 32400001, 36000000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 32400001, 36000000), 2).ToString();
            }

            else if (cb_Hour.Text == "11")
            {
                lblMinLight.Text = calcMinValue(3, 36000001, 39600000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 36000001, 39600000).ToString();
                lblMinTemp.Text = calcMinValue(4, 36000001, 39600000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 36000001, 39600000).ToString();
                lblMinVolt.Text = calcMinValue(5, 36000001, 39600000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 36000001, 39600000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 36000001, 39600000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 36000001, 39600000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 36000001, 39600000), 2).ToString();
            }

            else if (cb_Hour.Text == "12")
            {
                lblMinLight.Text = calcMinValue(3, 39600001, 43200000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 39600001, 43200000).ToString();
                lblMinTemp.Text = calcMinValue(4, 39600001, 43200000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 39600001, 43200000).ToString();
                lblMinVolt.Text = calcMinValue(5, 39600001, 43200000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 39600001, 43200000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 39600001, 43200000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 39600001, 43200000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 39600001, 43200000), 2).ToString();
            }

            else if (cb_Hour.Text == "13")
            {
                lblMinLight.Text = calcMinValue(3, 43200001, 46800000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 43200001, 46800000).ToString();
                lblMinTemp.Text = calcMinValue(4, 43200001, 46800000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 43200001, 46800000).ToString();
                lblMinVolt.Text = calcMinValue(5, 43200001, 46800000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 43200001, 46800000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 43200001, 46800000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 43200001, 46800000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 43200001, 46800000), 2).ToString();
            }

            else if (cb_Hour.Text == "14")
            {
                lblMinLight.Text = calcMinValue(3, 46800001, 50400000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 46800001, 50400000).ToString();
                lblMinTemp.Text = calcMinValue(4, 46800001, 50400000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 46800001, 50400000).ToString();
                lblMinVolt.Text = calcMinValue(5, 46800001, 50400000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 46800001, 50400000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 46800001, 50400000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 46800001, 50400000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 46800001, 50400000), 2).ToString();
            }
            else if (cb_Hour.Text == "Overall")
            {
                lblMinLight.Text = calcMinValue(3, 1, 50400000).ToString();
                lblMaxLight.Text = calcMaxValue(3, 1, 50400000).ToString();
                lblMinTemp.Text = calcMinValue(4, 1, 50400000).ToString();
                lblMaxTemp.Text = calcMaxValue(4, 1, 50400000).ToString();
                lblMinVolt.Text = calcMinValue(5, 1, 50400000).ToString();
                lblMaxVolt.Text = calcMaxValue(5, 1, 50400000).ToString();

                lblAveLight.Text = Math.Round(calcAverage(3, 1, 50400000), 2).ToString();
                lblAveTemp.Text = Math.Round(calcAverage(4, 1, 50400000), 2).ToString();
                lblAveVolt.Text = Math.Round(calcAverage(5, 1, 50400000), 2).ToString();
            }
            else
            {
                MessageBox.Show("Please select a valid entry from the menu");  //IF THE USER HAS NOT SELECTED A VALID OPTION, SHOW THIS ERROR MESSAGE
            }                 
        }

        //-----METHOD FOR RETRIEVING THE MINIMUM VALUE WITHIN A GIVEN PART OF THE ARRAY AND RETURNING IT TO THE PROGRAM-----
        public double calcMinValue(int choice, int choiceMin, int choiceMax)
        {
            double minValue = 10000; //SET AS THIS SO THERE ARE NO READINGS HIGHER
            try
            {
                for (int i = 1; i < counter; i++)
                {
                    double dataValue = double.Parse(dataArray[i, choice]);  //CONVERTING LIGHT AND MILLIS DATA FROM ARRAY TO AN INT
                    int millisValue = int.Parse(dataArray[i, 0]);

                    if (millisValue > choiceMin && millisValue < choiceMax)  //IF DATA IS WITHIN GIVEN VALUE IN MILLIS COLLUMN(HOUR)
                    {
                        if (dataValue < minValue)  //IF THE PIECE OF DATA READ IS LESS THAN THE CURRENT MINUMUM
                        {
                            minValue = dataValue;  //SET THIS PIECE OF DATA AS THE NEW MINIMUM
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Minimum value can't be found, please try again");
            }
            return minValue;
        }

        //-----METHOD FOR RETRIEVING THE MAXIMUM VALUE WITHIN A GIVEN PART OF THE ARRAY AND RETURNING IT TO THE PROGRAM-----
        public double calcMaxValue(int choice, int choiceMin, int choiceMax)
        {
            double maxValue = 0; //SET AS THIS SO THEIR ARE NO READINGS LOWER
            try
            {
                for (int i = 1; i < counter; i++)
                {
                    double dataValue = double.Parse(dataArray[i, choice]);
                    int millisValue = int.Parse(dataArray[i, 0]);  //CONVERING LIGHT AND MILLIS VALUES FROM ARRAY INTO INTS

                    if (millisValue > choiceMin && millisValue < choiceMax)  //IF DATA IS WITHIN THE STATED HOUR
                    {
                        if (dataValue > maxValue)  //IF DATA IS HIGHER THAN CURRENT HIGHEST
                        {
                            maxValue = dataValue;  //SET AS MAXVALUE
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Maximum value can't be found, please try again");
            }
                return maxValue;          
        }

        //-----METHOD FOR CALCULATING THE AVERAGE VALUE OF A GIVEN PART OF ARRAY AND RETURNING THE VALUE-----
        public double calcAverage(int choice, int dataMin, int dataMax)
        {
            try
            {
                for (int i = 1; i < counter; i++)  //ITERATES THROUGH ARRAY
                {
                    int dataTime = int.Parse(dataArray[i, 0]);  //MILLIS COLLUM
                    double dataChoice = double.Parse(dataArray[i, choice]);  //COLLUM OF CHOICE(EG TEMP) STATED WHEN METHOD IS CALLED UPON 

                    if (dataTime >= dataMin && dataTime <= dataMax)  //IF DATATIME IS INBETWEEN THE GIVEN VALUES STATED, LETS ME LOCATED CERTAIN HOURS WITHIN THE ARRAY AND GET AVERAGES
                    {
                        counter1++;

                        dataSum1 = dataSum1 + dataChoice;

                        dataAve = dataSum1 / counter1;  //ADDING ALL VALUES TOGETHER AND DIVIDING THEM BY TOTAL NUMBER OF DATA TO GET AVERAGE
                    }
                }
            }
            catch
            {
                MessageBox.Show("Average value can't be found, please try again!");
            }
            dataSum1 = 0;
            counter1 = 0;
            return dataAve;  //RESETTING VARIABLES FOR WHEN METHOD IS USED AGAIN AND RETURNING RETRIEVED AVERAGE
        }

        //-----METHOD FOR CHANGING GRAPH TO A BOX PLOT GRAPH-----
        private void btn_BoxPlot_Click(object sender, EventArgs e)
        {
            series1.ChartType = SeriesChartType.BoxPlot;
            series2.ChartType = SeriesChartType.BoxPlot;
        }

        //-----METHOD FOR CHANGING GRAPH TO A COLLUMN GRAPH-----
        private void btn_Collumn_Click(object sender, EventArgs e)
        {
            series1.ChartType = SeriesChartType.Column;
            series2.ChartType = SeriesChartType.Column;
        }

        //-----METHOD FOR CHANGING GRAPH TO A LINE GRAPH-----
        private void btn_Line_Click(object sender, EventArgs e)
        {
            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Line;
        }

        //-----METHOD FOR CHANGING GRAPH TO A POINT GRAPH-----
        private void btn_Point_Click(object sender, EventArgs e)
        {
            series1.ChartType = SeriesChartType.Point;
            series2.ChartType = SeriesChartType.Point;
        }

        //-----METHOD TO EXIT THE PROGRAM WHEN USER SELECTS EXIT FROM THE FILE MENU-----
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //-----METHOD TO RESTART THE PROGRAM WHEN USER SELECTS RESTART FROM THE FILE MENU-----
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}