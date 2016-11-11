using Microsoft.Office.Interop.PowerPoint;
using System;
using Microsoft.Office.Core;
using System.Data;
using System.Diagnostics;
using System.Linq;
using ProjectChart.DataObjects;

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
            var query = from DataRow d in data.Tables["Events"].AsEnumerable() where !d.Field<bool>("InChart") select new { Date = d.Field<DateTime>("Event Date"), ID = d.Field<int>("EventID"), Name = d.Field<string>("Event Name"), Data = d, Shape = d.Field<int>("Shape"), Location = d.Field<int>("Location") };

            foreach (var @event in query)
            {

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
                                if (@event.Location == (int)Event.EventLocation.Below)
                                {
                                    rotation += 180;
                                }
                                break;
                            }
                        case 1:
                            {
                                shape = MsoAutoShapeType.msoShapeIsoscelesTriangle;
                                rotation += 180;
                                if (@event.Location == (int)Event.EventLocation.Below)
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
                                if (@event.Location == (int)Event.EventLocation.Below)
                                {
                                    rotation += 180;
                                }
                                break;
                            }
                    }


                    if (!DBNull.Value.Equals(@event.Data["ParentBar"]))
                    {
                        //has a parent bar?
                        eventTop = ppt.Slides[1].Shapes["Bar_" + @event.Data.Field<int>("ParentBar")].Top - eventHeight;
                        if (@event.Location == (int)Event.EventLocation.Below)
                        {
                            eventTop = ppt.Slides[1].Shapes["Bar_" + @event.Data.Field<int>("ParentBar")].Top + ppt.Slides[1].Shapes["Bar_" + @event.Data.Field<int>("ParentBar")].Height;
                        }
                    }




                    var e = ppt.Slides[1].Shapes.AddShape(shape, (float)(eventOffset - (eventWidth / 2)), (float)eventTop, (float)eventWidth, 20);
                    e.Name = "Event_" + @event.ID;

                    e.Tags.Add("Event", "true");
                    e.Tags.Add("ID", "" + @event.ID);

                    e.Rotation = rotation;

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

        private static void ReplaceBars(Presentation ppt, DataSet data)
        {
            var query = from d in data.Tables["Bars"].AsEnumerable()
                        where !d.Field<bool>("InChart")
                        select new { Start = d.Field<DateTime>("Start Date"), End = d.Field<DateTime>("End Date"), ID = d.Field<int>("BarID"), Name = d.Field<string>("Bar Name"), Data = d };


            foreach (var bar in query)
            {
                TimeSpan barSpan = bar.End - bar.Start;
                double barWidth = barSpan.TotalSeconds * TIME_TO_WIDTH;
                double barOffset = (bar.Start - P_START).TotalSeconds * TIME_TO_WIDTH;

                var b = ppt.Slides[1].Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle, (float)(barOffset), (40 * bar.ID) + 60, (float)barWidth, 20);

                b.Name = "Bar_" + bar.ID;
                b.Tags.Add("Bar", "true");
                b.Tags.Add("ID", "" + bar.ID);

                b.TextFrame.TextRange.Text = bar.Name;

                if (false) //TODO: implement shapetype for bars
                { b.AutoShapeType = MsoAutoShapeType.msoShapeRoundedRectangle; }

                bar.Data.BeginEdit();
                bar.Data.SetField("InChart", true);
                bar.Data.EndEdit();

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

            CreateModule.CreateTimescale(ppt, data);

        }

        private static void UpdateBars(Presentation ppt, DataSet data)
        {
            var shapes = ppt.Slides[1].Shapes;

            foreach (DataRow d in data.Tables["Bars"].Rows)
            {
                d.BeginEdit();
                d.SetField<bool>("InChart", false);
                d.EndEdit();
            }

            var query = from Microsoft.Office.Interop.PowerPoint.Shape s in shapes
                        where s.Tags?["Bar"] == "true"
                        join d in data.Tables["Bars"].AsEnumerable() on int.Parse(s.Tags["ID"]) equals d.Field<int>("BarID")
                        select new { End = d.Field<DateTime>("End Date"), Start = d.Field<DateTime>("Start Date"), Name = d.Field<string>("Bar Name"), Shape = s, Data = d };

            foreach (var x in query)
            {
                TimeSpan barSpan = x.End - x.Start;
                double barWidth = barSpan.TotalSeconds * TIME_TO_WIDTH;
                double barOffset = (x.Start - P_START).TotalSeconds * TIME_TO_WIDTH;

                x.Shape.Left = (float)barOffset;
                x.Shape.Width = (float)barWidth;


                x.Shape.TextFrame.TextRange.Text = x.Name;

                x.Data.BeginEdit();
                x.Data.SetField<bool>("InChart", true);
                x.Data.EndEdit();
            }





        }



        private static void UpdateEvents(Presentation ppt, DataSet data)
        {

            var shapes = ppt.Slides[1].Shapes;


            foreach (DataRow d in data.Tables["Events"].Rows)
            {
                d.BeginEdit();
                d.SetField<bool>("InChart", false);
                d.EndEdit();
            }

            var query = from Microsoft.Office.Interop.PowerPoint.Shape s in shapes
                        where s.Tags?["Event"] == "true"
                        join Microsoft.Office.Interop.PowerPoint.Shape s2 in shapes on s.Tags["ID"] equals s2.Tags["ID"]
                        where s2.Tags?["EventText"] == "true"
                        join d in data.Tables["Events"].AsEnumerable() on int.Parse(s.Tags["ID"]) equals d.Field<int>("EventID")

                        select new { Date = d.Field<DateTime>("Event Date"), Name = d.Field<string>("Event Name"), Shape = s, Text = s2, Data = d, ID = d.Field<int>("EventID"), ShapeType = d.Field<int>("Shape"), Location = d.Field<int>("Location") };


            foreach (var x in query)
            {
                double eventOffset = (x.Date - P_START).TotalSeconds * TIME_TO_WIDTH;
                double eventHeight = 20;
                float textOffsetTop = x.Text.Top - x.Shape.Top;
                float textOffsetLeft = x.Text.Left - x.Shape.Left;
                float rotation = 0;
                MsoAutoShapeType type;

                switch (x.ShapeType)
                {
                    case 0:
                        {
                            type = MsoAutoShapeType.msoShapeDownArrow;
                            if (x.Location == (int)Event.EventLocation.Below)
                            {
                                rotation += 180;
                            }
                            break;
                        }
                    case 1:
                        {
                            type = MsoAutoShapeType.msoShapeIsoscelesTriangle;
                            rotation = 180;
                            if (x.Location == (int)Event.EventLocation.Below)
                            {
                                rotation += 180;
                            }
                            break;
                        }
                    case 2:
                        {
                            type = MsoAutoShapeType.msoShapeDiamond;
                            if (x.Location == (int)Event.EventLocation.Below)
                            {
                                rotation += 180;
                            }
                            break;
                        }
                    case 3:
                        {
                            type = MsoAutoShapeType.msoShape5pointStar;
                            if (x.Location == (int)Event.EventLocation.Below)
                            {
                                rotation += 180;
                            }
                            break;
                        }
                    default:
                        {
                            type = MsoAutoShapeType.msoShapeDownArrow;
                            if (x.Location == (int)Event.EventLocation.Below)
                            {
                                rotation += 180;
                            }
                            break;
                        }
                }


                if (!DBNull.Value.Equals(x.Data["ParentBar"]))
                {


                    //has a parent bar?
                    foreach (Microsoft.Office.Interop.PowerPoint.Shape S in ppt.Slides[1].Shapes)
                    {
                        if (S.Tags?["Bar"] != "true")
                        {
                            continue;
                        }

                        if (int.Parse(S.Tags["ID"]) == x.Data.Field<int>("ParentBar"))
                        {
                            x.Shape.Top = (float)(S.Top - eventHeight);

                            if (x.Location == (int)Event.EventLocation.Below)
                            {
                                x.Shape.Top = ppt.Slides[1].Shapes["Bar_" + x.Data.Field<int>("ParentBar")].Top + ppt.Slides[1].Shapes["Bar_" + x.Data.Field<int>("ParentBar")].Height;
                            }
                            break;
                        }
                    }


                }

                x.Shape.Left = (float)eventOffset - (x.Shape.Width / 2);

                x.Text.Left = x.Shape.Left + textOffsetLeft;
                x.Text.Top = x.Shape.Top + textOffsetTop;
                x.Text.TextFrame.TextRange.Text = x.Name;
                x.Shape.AutoShapeType = type;
                x.Shape.Rotation = rotation;

                x.Data.BeginEdit();
                x.Data.SetField<bool>("InChart", true);
                x.Data.EndEdit();
            }
        }
    }
}



