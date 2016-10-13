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

            var query = from DataRow d in data.Tables["Bars"].AsEnumerable() select new { Start = d.Field<DateTime>("Start Date"), End = d.Field<DateTime>("End Date"), ID = d.Field<int>("BarID"), Name = d.Field<string>("Bar Name"), Data = d };

            foreach (var bar in query)
            {
                TimeSpan barSpan = bar.End - bar.Start;
                double barWidth = barSpan.TotalSeconds * TIME_TO_WIDTH;
                double barOffset = (bar.Start - P_START).TotalSeconds * TIME_TO_WIDTH;

                var b = ppt.Slides[1].Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, (float)(barOffset), (40 * i) + 60, (float)barWidth, 20);

                b.Name = "Bar_" + bar.ID;
                b.Tags.Add("Bar", "true");
                b.Tags.Add("ID", "" + bar.ID);

                b.TextFrame.TextRange.Text = bar.Name;
                i++;

                bar.Data.BeginEdit();
                bar.Data.SetField("InChart", true);
                bar.Data.EndEdit();

            }
        }



        private static void CreateEvents(Presentation ppt, DataSet data)
        {

            var query = from DataRow d in data.Tables["Events"].AsEnumerable() select new { Date = d.Field<DateTime>("Event Date"), ID = d.Field<int>("EventID"), Name = d.Field<string>("Event Name"), Data = d };

            foreach (var @event in query)
            {
                double eventOffset = (@event.Date - P_START).TotalSeconds * TIME_TO_WIDTH;
                double eventWidth = 20;
                double eventTop = 0;
                double eventHeight = 20;


                if (!DBNull.Value.Equals(@event.Data["ParentBar"]))
                {
                    //has a parent bar?
                    eventTop = ppt.Slides[1].Shapes["Bar_" + @event.Data.Field<int>("ParentBar")].Top - eventHeight;
                }


                var e = ppt.Slides[1].Shapes.AddShape(MsoAutoShapeType.msoShapeDownArrow, (float)(eventOffset - (eventWidth / 2)), (float)eventTop, (float)eventWidth, 20);
                e.Name = "Event_" + @event.ID;

                e.Tags.Add("Event", "true");
                e.Tags.Add("ID", "" + @event.ID);

                var t = ppt.Slides[1].Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, (float)(eventOffset + (eventWidth / 2)), (float)eventTop, 100, 20);


                t.Tags.Add("EventText", "true");
                t.Tags.Add("ID", "" + @event.ID);
                t.TextFrame.TextRange.Text = @event.Name;


                @event.Data.BeginEdit();
                @event.Data.SetField("InChart", true);
                @event.Data.EndEdit();
            }


        }

    }

}
