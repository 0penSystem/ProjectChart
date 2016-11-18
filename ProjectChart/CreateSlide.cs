using Microsoft.Office.Interop.PowerPoint;
using System;
using Microsoft.Office.Core;
using System.Data;
using System.Collections.Generic;
using ProjectChart.DataObjects;
using System.Diagnostics;

namespace ProjectChart
{



    public class CreateModule
    {
        static double daysInAQuarter = 91.25;
        static double TIME_TO_WIDTH;
        static DateTime P_START;

        public static void CreateChart (Presentation ppt, DataSet data)
        {
            CreateNewSlide (ppt);
            CreateTimescale (ppt, data);
            CreateBars (ppt, data);
            CreateEvents (ppt, data);

        }

        private static void CreateNewSlide (Presentation ppt)
        {
            ppt.Slides.Add (1, PpSlideLayout.ppLayoutBlank);
        }

        public static void CreateTimescale (Presentation ppt, DataSet data)
        {
            var width = ppt.SlideMaster.Width;
            DateTime start, end;
            var pptShapes = ppt.Slides[1].Shapes;


            start = data.Tables["Project"].Rows[0].Field<DateTime> ("Start Date");
            end = data.Tables["Project"].Rows[0].Field<DateTime> ("End Date");
            P_START = start;

            int startQ = 0, endQ = 0;
            TimeSpan fromQuarterStart = new TimeSpan(), fromQuarterEnd = new TimeSpan();


            //Console.Write((int)Math.Ceiling(start.Month / 3.0));

            switch ( (int) Math.Ceiling (start.Month / 3.0))
            {

                case 1:
                {
                    //jan,feb,mar - Q2
                    startQ = 2;
                    fromQuarterStart = start - DateTime.Parse ($"January 1, {start.Year}");
                    break;
                }

                case 2:
                {
                    //apr,may,jun - Q3
                    startQ = 3;
                    fromQuarterStart = start - DateTime.Parse ($"April 1, {start.Year}");
                    break;
                }

                case 3:
                {
                    //jul,aug,sep - Q4
                    startQ = 4;
                    fromQuarterStart = start - DateTime.Parse ($"July 1, {start.Year}");
                    break;
                }

                case 4:
                {
                    //oct,nov,dec - Q1
                    startQ = 1;
                    fromQuarterStart = start - DateTime.Parse ($"October 1, {start.Year}");
                    break;
                }
            }

            switch ( (int) Math.Ceiling (end.Month / 3.0))
            {

                case 1:
                {
                    //jan,feb,mar - Q2
                    endQ = 2;
                    fromQuarterEnd = DateTime.Parse ($"Mar 31, {end.Year}") - end;
                    break;
                }

                case 2:
                {
                    //apr,may,jun - Q3
                    endQ = 3;
                    fromQuarterEnd = DateTime.Parse ($"June 30, {end.Year}") - end;
                    break;
                }

                case 3:
                {
                    //jul,aug,sep - Q4
                    endQ = 4;
                    fromQuarterEnd = DateTime.Parse ($"September 30, {end.Year}") - end;
                    break;
                }

                case 4:
                {
                    //oct,nov,dec - Q1
                    endQ = 1;
                    fromQuarterEnd = DateTime.Parse ($"December 31, {end.Year}") - end;
                    break;
                }
            }



            TimeSpan span = end - start;

            TIME_TO_WIDTH = (width / span.TotalSeconds);

            int quarters = (int) Math.Ceiling ( (span.Days / daysInAQuarter));
            quarters -= 2; // for the first and last

            //first box, special
            var firstWidth = (TimeSpan.FromDays (91.25) - fromQuarterStart).TotalSeconds * TIME_TO_WIDTH;

            //last box, also special
            var lastWidth = (TimeSpan.FromDays (91.25) - fromQuarterEnd).TotalSeconds * TIME_TO_WIDTH;

            List<object> Lines = new List<object>();


            if (startQ == endQ && firstWidth + lastWidth >= width)
            {
                var only = pptShapes.AddShape (MsoAutoShapeType.msoShapeRectangle, 0, 20, width, 20);
                only.Tags.Add ("Timescale", "true");
            }
            else if (firstWidth + lastWidth >= width)
            {
                lastWidth = width - firstWidth;

                var first = pptShapes.AddShape (MsoAutoShapeType.msoShapeRectangle, 0, 20, (float) firstWidth, 20);
                first.Tags.Add ("Timescale", "true");

                var last = pptShapes.AddShape (MsoAutoShapeType.msoShapeRectangle, (float) (width - lastWidth), 20, (float) lastWidth, 20);
                last.Tags.Add ("Timescale", "true");


                var lastLine = pptShapes.AddLine ( (float) (firstWidth), 0, (float) (firstWidth), ppt.SlideMaster.Height);

                lastLine.Tags.Add ("Timescale", "true");
                lastLine.Line.ForeColor.RGB = System.Drawing.Color.Gray.ToArgb();
                lastLine.Line.DashStyle = MsoLineDashStyle.msoLineDash;
                lastLine.ZOrder (MsoZOrderCmd.msoSendToBack);

                Lines.Add (lastLine);
            }
            else
            {

                var first = pptShapes.AddShape (MsoAutoShapeType.msoShapeRectangle, 0, 20, (float) firstWidth, 20);
                first.Tags.Add ("Timescale", "true");

                var last = pptShapes.AddShape (MsoAutoShapeType.msoShapeRectangle, (float) (width - lastWidth), 20, (float) lastWidth, 20);
                last.Tags.Add ("Timescale", "true");



                var boxWidth = TimeSpan.FromDays (91.25).TotalSeconds * TIME_TO_WIDTH;

                for (int i = 0; i < quarters; i++)
                {
                    //timescale box
                    var ts = pptShapes.AddShape (MsoAutoShapeType.msoShapeRectangle, (float) ( (i * boxWidth) + firstWidth), 20, (float) boxWidth, 20);
                    ts.Tags.Add ("Timescale", "true");

                    //lines
                    var line = pptShapes.AddLine ( (float) ( (i * boxWidth) + firstWidth), 0, (float) ( (i * boxWidth) + firstWidth), ppt.SlideMaster.Height);
                    line.Tags.Add ("Timescale", "true");
                    line.Line.ForeColor.RGB = System.Drawing.Color.Gray.ToArgb();
                    line.Line.DashStyle = MsoLineDashStyle.msoLineDash;
                    line.ZOrder (MsoZOrderCmd.msoSendToBack);

                    Lines.Add (line);
                }

                var lastLine = pptShapes.AddLine ( (float) ( (quarters * boxWidth) + firstWidth), 0, (float) ( (quarters * boxWidth) + firstWidth), ppt.SlideMaster.Height);

                lastLine.Tags.Add ("Timescale", "true");
                lastLine.Line.ForeColor.RGB = System.Drawing.Color.Gray.ToArgb();
                lastLine.Line.DashStyle = MsoLineDashStyle.msoLineDash;
                lastLine.ZOrder (MsoZOrderCmd.msoSendToBack);

                Lines.Add (lastLine);

            }

            if (Lines.Count > 0)
            {
                List<string> names = new List<string>();

                foreach (Microsoft.Office.Interop.PowerPoint.Shape l in Lines)
                {
                    names.Add (l.Name);
                }

                pptShapes.Range (names.ToArray()).Group();
            }

        }

        private static void CreateBars (Presentation ppt, DataSet data)
        {


            int i = 0;

            var query = from DataRow d in data.Tables["Bars"].AsEnumerable() select new { Start = d.Field<DateTime> ("Start Date"), End = d.Field<DateTime> ("End Date"), ID = d.Field<int> ("BarID"), Name = d.Field<string> ("Bar Name"), Data = d, Shape = d.Field < int?> ("Shape") };

            foreach (var bar in query)
            {
                TimeSpan barSpan = bar.End - bar.Start;
                double barWidth = barSpan.TotalSeconds * TIME_TO_WIDTH;
                double barOffset = (bar.Start - P_START).TotalSeconds * TIME_TO_WIDTH;

                var b = ppt.Slides[1].Shapes.AddShape (MsoAutoShapeType.msoShapeRectangle, (float) (barOffset), (40 * i) + 60, (float) barWidth, 20);

                b.Name = "Bar_" + bar.ID;
                b.Tags.Add ("Bar", "true");
                b.Tags.Add ("ID", "" + bar.ID);

                b.TextFrame.TextRange.Text = bar.Name;

                if (bar.Shape != null)
                {
                    switch (bar.Shape)
                    {

                        case 0:
                            b.AutoShapeType = MsoAutoShapeType.msoShapeRectangle; break;

                        case 1:
                            b.AutoShapeType = MsoAutoShapeType.msoShapeRoundedRectangle;
                            break;

                        case 2:
                            b.AutoShapeType = MsoAutoShapeType.msoShapeRightTriangle;
                            b.Flip (MsoFlipCmd.msoFlipHorizontal);
                            break;

                        default:
                            b.AutoShapeType = MsoAutoShapeType.msoShapeRectangle; break;
                    }
                }



                i++;



                bar.Data.BeginEdit();
                bar.Data.SetField ("InChart", true);
                bar.Data.EndEdit();

            }
        }



        private static void CreateEvents (Presentation ppt, DataSet data)
        {

            var query = from DataRow d in data.Tables["Events"].AsEnumerable() select new { Date = d.Field<DateTime> ("Event Date"), ID = d.Field<int> ("EventID"), Name = d.Field<string> ("Event Name"), Data = d, Shape = d.Field < int?> ("Shape"), Location = d.Field < int?> ("Location") };

            foreach (var @event in query)
            {
                double eventOffset = (@event.Date - P_START).TotalSeconds * TIME_TO_WIDTH;
                double eventWidth = 20;
                double eventTop = 0;
                double eventHeight = 20;
                MsoAutoShapeType shape;
                float rotation = 0;



                switch (@event.Shape)
                {
                    case 0:
                    {
                        shape = MsoAutoShapeType.msoShapeDownArrow;

                        if (@event.Location == (int) Event.EventLocation.Below)
                        {
                            rotation += 180;
                        }

                        break;
                    }

                    case 1:
                    {
                        shape = MsoAutoShapeType.msoShapeIsoscelesTriangle;
                        rotation += 180;

                        if (@event.Location == (int) Event.EventLocation.Below)
                        {
                            rotation += 180;
                        }

                        break;
                    }

                    case 2:
                    {
                        shape = MsoAutoShapeType.msoShapeDiamond;
                        break;
                    }

                    case 3:
                    {
                        shape = MsoAutoShapeType.msoShape5pointStar;
                        break;
                    }

                    default:
                    {
                        shape = MsoAutoShapeType.msoShapeDownArrow;

                        if (@event.Location == (int) Event.EventLocation.Below)
                        {
                            rotation += 180;
                        }

                        break;
                    }
                }


                if (!DBNull.Value.Equals (@event.Data["ParentBar"]))
                {
                    //has a parent bar?
                    eventTop = ppt.Slides[1].Shapes["Bar_" + @event.Data.Field<int> ("ParentBar")].Top - eventHeight;

                    if (@event.Location == (int) Event.EventLocation.Below)
                    {
                        eventTop = ppt.Slides[1].Shapes["Bar_" + @event.Data.Field<int> ("ParentBar")].Top + ppt.Slides[1].Shapes["Bar_" + @event.Data.Field<int> ("ParentBar")].Height;
                    }
                }




                var e = ppt.Slides[1].Shapes.AddShape (shape, (float) (eventOffset - (eventWidth / 2)), (float) eventTop, (float) eventWidth, 20);
                e.Name = "Event_" + @event.ID;

                e.Tags.Add ("Event", "true");
                e.Tags.Add ("ID", "" + @event.ID);

                e.Rotation = rotation;

                var t = ppt.Slides[1].Shapes.AddTextbox (MsoTextOrientation.msoTextOrientationHorizontal, (float) (eventOffset + (eventWidth / 2)), (float) eventTop, 100, 20);


                t.Tags.Add ("EventText", "true");
                t.Tags.Add ("ID", "" + @event.ID);
                t.TextFrame.TextRange.Text = @event.Name;


                @event.Data.BeginEdit();
                @event.Data.SetField ("InChart", true);
                @event.Data.EndEdit();
            }


        }

    }

}
