﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectChart.DataObjects;

namespace ProjectChart.Interface
{
    public partial class EventEditor : Form
    {

        public Event selectedEvent { get; set; }

        public Database Database { get; set; }

        public EventEditor()
        {
            InitializeComponent();
        }

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);


            barsBinding.DataSource = Database.getBars();
            barsBinding.Insert (0, new Bar (-1) { Name = "(None)" });
            cbParent.DisplayMember = "Name";
            cbParent.ValueMember = "Id";

            if (selectedEvent != null)
            {
                txtText.Text = selectedEvent.Text;
                dtDate.Value = selectedEvent.Date;
                cbShape.SelectedIndex = (int) selectedEvent.Shape;
                cbLocation.SelectedIndex = (int) selectedEvent.Location;

                if (selectedEvent.ParentID >= 0)
                {
                    foreach (Bar b in cbParent.Items)
                    {
                        if (b.Id == selectedEvent.ParentID)
                        {
                            cbParent.SelectedItem = b;
                            break;
                        }
                    }


                }
                else
                {
                    cbParent.SelectedIndex = 0;
                }
            }
            else
            {

                cbParent.SelectedIndex = 0;
                cbLocation.SelectedIndex = 0;
                cbShape.SelectedIndex = 0;
            }

            ValidateChildren();

        }


        private void btnCancel_Click (object sender, EventArgs e)
        {
            Close();
        }

        private void txtText_Validating (object sender, CancelEventArgs e)
        {

        }

        private void dtDate_Validated (object sender, EventArgs e)
        {

        }

        private void btnSave_Click (object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var newEvent = new Event (selectedEvent?.Id ?? -1)
                {
                    Text = txtText.Text,
                    Location = (Event.EventLocation) cbLocation.SelectedIndex,
                    Shape = (Event.EventShape) cbShape.SelectedIndex,
                    Date = dtDate.Value,
                    ParentID = (int) cbParent.SelectedValue
                };

                if (newEvent.Id == -1)
                {

                    //add
                    Database.addEvent (newEvent);

                }
                else
                {
                    //edit
                    Database.updateEvent (newEvent);

                }

                Close();
            }
        }
    }
}
