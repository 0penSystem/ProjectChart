using Microsoft.Office.Interop.PowerPoint;
using System;
using Microsoft.Office.Core;
using System.Data;
using System.Diagnostics;

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
        }

        private static void UpdateTimescale(Presentation ppt, DataSet data)
        {
            //delete old ones.
            int count = ppt.Slides[1].Shapes.Count;

            for (int i = count; i > 0 ; i--)
            {
                var s = ppt.Slides[1].Shapes[i];
                Debug.WriteLine("Testing...");
                if (s.Tags["Timescale"].Equals("true")){
                    Debug.WriteLine("Deleting "+i);
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

        private static void CreateBars(Presentation ppt, DataSet data)
        {


            int i = 0;

            foreach (DataRow d in data.Tables["Bars"].Rows)
            {
                TimeSpan barSpan = d.Field<DateTime>("End Date") - d.Field<DateTime>("Start Date");
                double barWidth = barSpan.TotalSeconds * TIME_TO_WIDTH;
                double barOffset = (d.Field<DateTime>("Start Date") - P_START).TotalSeconds * TIME_TO_WIDTH;

                var bar = ppt.Slides[1].Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, (float)(barOffset), (40 * i) + 60, (float)barWidth, 20);

                bar.Name = "Bar_" + d.Field<int>("BarID");

                bar.TextFrame.TextRange.Text = d.Field<string>("Bar Name");
                i++;
            }




        }



        private static void CreateEvents(Presentation ppt, DataSet data)
        {


            foreach (DataRow d in data.Tables["Events"].Rows)
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

                var t = ppt.Slides[1].Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, (float)(eventOffset + (eventWidth / 2)), (float)eventTop, 100, 20);

                t.TextFrame.TextRange.Text = d.Field<string>("Event Name");



            }

        }

    
}
}
