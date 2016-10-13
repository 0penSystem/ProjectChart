using Microsoft.Office.Interop.PowerPoint;
using System;
using Microsoft.Office.Core;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace ProjectChart
{
    public class UpdateModule
    {
        static double daysInAQuarter = 91.25;
        static double TIME_TO_WIDTH;
        static DateTime P_START;

        public static void UpdateChart(Presentation ppt, DataSet data)
        {
            UpdateTimescale(ppt, data);
            UpdateBars(ppt, data);
            UpdateEvents(ppt, data);
        }

        public static void ReplaceMissing(Presentation ppt, DataSet data)
        {
            ReplaceBars(ppt, data);
            ReplaceEvents(ppt, data);
        }

        private static void ReplaceEvents(Presentation ppt, DataSet data)
        {
            foreach (DataRow d in data.Tables["Events"].Rows)
            {
                if (!d.Field<bool>("InChart"))
                {
                    double eventOffset = (d.Field<DateTime>("Event Date") - P_START).TotalSeconds * TIME_TO_WIDTH;
                    double eventWidth = 20;
                    double eventTop = 0;
                    double eventHeight = 20;

                    if (!DBNull.Value.Equals(d["ParentBar"]))
                    {
                        //has a parent bar?
                        eventTop = ppt.Slides[1].Shapes["Bar_" + d.Field<int>("ParentBar")].Top - eventHeight;

                    }

                    var e = ppt.Slides[1].Shapes.AddShape(MsoAutoShapeType.msoShapeDownArrow, (float)(eventOffset - (eventWidth / 2)), (float)eventTop, (float)eventWidth, 20);
                    e.Name = "Event_" + d.Field<int>("EventID");

                    e.Tags.Add("Event", "true");
                    e.Tags.Add("ID", "" + d.Field<int>("EventID"));

                    var t = ppt.Slides[1].Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, (float)(eventOffset + (eventWidth / 2)), (float)eventTop, 100, 20);


                    t.Tags.Add("EventText", "true");
                    t.Tags.Add("ID", "" + d.Field<int>("EventID"));
                    t.TextFrame.TextRange.Text = d.Field<string>("Event Name");

                    d.BeginEdit();
                    d.SetField("InChart", true);
                    d.EndEdit(); 
                }
            }
        }

        private static void ReplaceBars(Presentation ppt, DataSet data)
        {
            foreach (DataRow d in data.Tables["Bars"].Rows)
            {
                if (!d.Field<bool>("InChart"))
                {
                    TimeSpan barSpan = d.Field<DateTime>("End Date") - d.Field<DateTime>("Start Date");
                    double barWidth = barSpan.TotalSeconds * TIME_TO_WIDTH;
                    double barOffset = (d.Field<DateTime>("Start Date") - P_START).TotalSeconds * TIME_TO_WIDTH;

                    var bar = ppt.Slides[1].Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, (float)(barOffset), (40 * d.Field<int>("BarID")) + 60, (float)barWidth, 20);

                    bar.Name = "Bar_" + d.Field<int>("BarID");
                    bar.Tags.Add("Bar", "true");
                    bar.Tags.Add("ID", "" + d.Field<int>("BarID"));

                    bar.TextFrame.TextRange.Text = d.Field<string>("Bar Name");

                    d.BeginEdit();
                    d.SetField("InChart", true);
                    d.EndEdit();
                }
                
            }
        }

        private static void UpdateTimescale(Presentation ppt, DataSet data)
        {
            //delete old ones.
            int count = ppt.Slides[1].Shapes.Count;

            for (int i = count; i > 0; i--)
            {
                var s = ppt.Slides[1].Shapes[i];
                Debug.WriteLine("Testing...");
                if (s.Tags["Timescale"].Equals("true"))
                {
                    Debug.WriteLine("Deleting " + i);
                    s.Delete();
                }
            }


            //make new ones.
            var width = ppt.SlideMaster.Width;
            DateTime start, end;

            start = data.Tables["Project"].Rows[0].Field<DateTime>("Start Date");
            end = data.Tables["Project"].Rows[0].Field<DateTime>("End Date");
            P_START = start;

            TimeSpan span = end - start;

            TIME_TO_WIDTH = (width / span.TotalSeconds);

            int quarters = (int)(span.Days / daysInAQuarter);


            var boxWidth = width / quarters;

            for (int i = 0; i < quarters; i++)
            {
                var ts = ppt.Slides[1].Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, (float)(i * boxWidth), 20, (float)boxWidth, 20);
                ts.Tags.Add("Timescale", "true");
            }
        }

        private static void UpdateBars(Presentation ppt, DataSet data)
        {
            var shapes = ppt.Slides[1].Shapes;


            foreach (DataRow d in data.Tables["Bars"].Rows)
            {
                bool found = false;
                foreach (Microsoft.Office.Interop.PowerPoint.Shape s in shapes)
                {
                    if (s.Tags?["Bar"] == "true")
                    {
                        //is a bar
                        if (d.Field<int>("BarID") == int.Parse(s.Tags["ID"]))
                        {
                            found = true;
                            //matching shape, update it.
                            TimeSpan barSpan = d.Field<DateTime>("End Date") - d.Field<DateTime>("Start Date");
                            double barWidth = barSpan.TotalSeconds * TIME_TO_WIDTH;
                            double barOffset = (d.Field<DateTime>("Start Date") - P_START).TotalSeconds * TIME_TO_WIDTH;

                            s.Left = (float)barOffset;
                            s.Width = (float)barWidth;


                            s.TextFrame.TextRange.Text = d.Field<string>("Bar Name");
                        }
                    }


                }
                if (!found)
                {
                    d.BeginEdit();
                    d.SetField("InChart", false);
                    d.EndEdit();
                }

            }




        }



        private static void UpdateEvents(Presentation ppt, DataSet data)
        {

            var shapes = ppt.Slides[1].Shapes;

            foreach (DataRow d in data.Tables["Events"].Rows)
            {
                bool found = false;

                foreach (Microsoft.Office.Interop.PowerPoint.Shape s in shapes)
                {
                    if (s.Tags?["Event"] == "true")
                    {
                        //is an event
                        if (d.Field<int>("EventID") == int.Parse(s.Tags["ID"]))
                        {
                            //matching shape, update it.
                            double eventOffset = (d.Field<DateTime>("Event Date") - P_START).TotalSeconds * TIME_TO_WIDTH;
                            double eventHeight = 20;

                            if (!DBNull.Value.Equals(d["ParentBar"]))
                            {


                                //has a parent bar?
                                foreach (Microsoft.Office.Interop.PowerPoint.Shape S in ppt.Slides[1].Shapes)
                                {
                                    if (S.Tags?["Bar"] != "true")
                                    {
                                        continue;
                                    }

                                    if (int.Parse(S.Tags["ID"]) == d.Field<int>("ParentBar"))
                                    {
                                        s.Top = (float)(S.Top - eventHeight);
                                        break;
                                    }
                                }


                            }

                            s.Left = (float)eventOffset - (s.Width / 2);

                            foreach (Microsoft.Office.Interop.PowerPoint.Shape t in shapes)
                            {
                                if (t.Tags?["EventText"] == "true")
                                {
                                    //Debug.Print(t.Tags.ToString());
                                    if (d.Field<int>("EventID") == int.Parse(t.Tags["ID"]))
                                    {
                                        //found matching textbox
                                        t.Left = s.Left + s.Width;
                                        t.Top = s.Top;
                                        t.TextFrame.TextRange.Text = d.Field<string>("Event Name");
                                    }
                                }
                            }


                        }
                    }


                }

                if (!found)
                {
                    d.BeginEdit();
                    d.SetField("InChart", false);
                    d.EndEdit();
                }

            }

        }


    }
}
