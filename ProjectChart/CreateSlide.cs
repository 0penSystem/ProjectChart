using Microsoft.Office.Interop.PowerPoint;
using System;
using Microsoft.Office.Core;
using System.Data;

namespace ProjectChart
{



    public class CreateModule
    {

        static double daysInAQuarter = 91.25;
        static double TIME_TO_WIDTH;
        static DateTime P_START;

        public static void CreateChart(Presentation ppt, DataSet data)
        {
            CreateNewSlide(ppt);
            CreateTimescale(ppt, data);
            CreateBars(ppt, data);
            CreateEvents(ppt, data);
        }

        private static void CreateNewSlide(Presentation ppt)
        {
            ppt.Slides.Add(1, PpSlideLayout.ppLayoutBlank);
        }

        private static void CreateTimescale(Presentation ppt, DataSet data)
        {
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
                bar.Tags.Add("Bar", "true");
                bar.Tags.Add("ID", "" + d.Field<int>("BarID"));

                bar.TextFrame.TextRange.Text = d.Field<string>("Bar Name");
                i++;

                d.BeginEdit();
                d.SetField("InChart", true);
                d.EndEdit();
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

}
