namespace RandomDataGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ValueTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ReservationButton = new System.Windows.Forms.Button();
            this.UsersButton = new System.Windows.Forms.Button();
            this.RegionButton = new System.Windows.Forms.Button();
            this.FlightsButton = new System.Windows.Forms.Button();
            this.HotelsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbookelement_cb = new System.Windows.Forms.CheckBox();
            this.tbooking_cb = new System.Windows.Forms.CheckBox();
            this.tbookingpax_cb = new System.Windows.Forms.CheckBox();
            this.tbookstate_cb = new System.Windows.Forms.CheckBox();
            this.tgroup_cb = new System.Windows.Forms.CheckBox();
            this.tflight_cb = new System.Windows.Forms.CheckBox();
            this.tcustomer_cb = new System.Windows.Forms.CheckBox();
            this.tcountry_cb = new System.Windows.Forms.CheckBox();
            this.tusergroup_cb = new System.Windows.Forms.CheckBox();
            this.tuser_cb = new System.Windows.Forms.CheckBox();
            this.tregion_cb = new System.Windows.Forms.CheckBox();
            this.tlanguage_cb = new System.Windows.Forms.CheckBox();
            this.thotelinfo_cb = new System.Windows.Forms.CheckBox();
            this.thotel_cb = new System.Windows.Forms.CheckBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ImportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(233, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generator danych do bazy biura podróży";
            // 
            // ValueTextbox
            // 
            this.ValueTextbox.Location = new System.Drawing.Point(328, 129);
            this.ValueTextbox.Name = "ValueTextbox";
            this.ValueTextbox.Size = new System.Drawing.Size(100, 23);
            this.ValueTextbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Podaj liczbe elementów do dodania";
            // 
            // ReservationButton
            // 
            this.ReservationButton.Location = new System.Drawing.Point(211, 184);
            this.ReservationButton.Name = "ReservationButton";
            this.ReservationButton.Size = new System.Drawing.Size(124, 51);
            this.ReservationButton.TabIndex = 4;
            this.ReservationButton.Text = "Generuj rezerwacje";
            this.ReservationButton.UseVisualStyleBackColor = true;
            this.ReservationButton.Click += new System.EventHandler(this.ReservationButton_Click);
            // 
            // UsersButton
            // 
            this.UsersButton.Location = new System.Drawing.Point(369, 184);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(152, 51);
            this.UsersButton.TabIndex = 8;
            this.UsersButton.Text = "Generuj użytkowników";
            this.UsersButton.UseVisualStyleBackColor = true;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // RegionButton
            // 
            this.RegionButton.Location = new System.Drawing.Point(54, 184);
            this.RegionButton.Name = "RegionButton";
            this.RegionButton.Size = new System.Drawing.Size(123, 51);
            this.RegionButton.TabIndex = 9;
            this.RegionButton.Text = "Generuj kraje i regiony";
            this.RegionButton.UseVisualStyleBackColor = true;
            this.RegionButton.Click += new System.EventHandler(this.RegionButton_Click);
            // 
            // FlightsButton
            // 
            this.FlightsButton.Location = new System.Drawing.Point(553, 184);
            this.FlightsButton.Name = "FlightsButton";
            this.FlightsButton.Size = new System.Drawing.Size(104, 51);
            this.FlightsButton.TabIndex = 10;
            this.FlightsButton.Text = "Generuj samoloty";
            this.FlightsButton.UseVisualStyleBackColor = true;
            this.FlightsButton.Click += new System.EventHandler(this.FlightsButton_Click);
            // 
            // HotelsButton
            // 
            this.HotelsButton.Location = new System.Drawing.Point(684, 184);
            this.HotelsButton.Name = "HotelsButton";
            this.HotelsButton.Size = new System.Drawing.Size(103, 51);
            this.HotelsButton.TabIndex = 11;
            this.HotelsButton.Text = "Generuj hotele";
            this.HotelsButton.UseVisualStyleBackColor = true;
            this.HotelsButton.Click += new System.EventHandler(this.HotelsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Eksport danych";
            // 
            // tbookelement_cb
            // 
            this.tbookelement_cb.AutoSize = true;
            this.tbookelement_cb.Location = new System.Drawing.Point(12, 297);
            this.tbookelement_cb.Name = "tbookelement_cb";
            this.tbookelement_cb.Size = new System.Drawing.Size(100, 19);
            this.tbookelement_cb.TabIndex = 13;
            this.tbookelement_cb.Text = "tbookelement";
            this.tbookelement_cb.UseVisualStyleBackColor = true;
            // 
            // tbooking_cb
            // 
            this.tbooking_cb.AutoSize = true;
            this.tbooking_cb.Location = new System.Drawing.Point(12, 322);
            this.tbooking_cb.Name = "tbooking_cb";
            this.tbooking_cb.Size = new System.Drawing.Size(74, 19);
            this.tbooking_cb.TabIndex = 14;
            this.tbooking_cb.Text = "tbooking";
            this.tbooking_cb.UseVisualStyleBackColor = true;
            // 
            // tbookingpax_cb
            // 
            this.tbookingpax_cb.AutoSize = true;
            this.tbookingpax_cb.Location = new System.Drawing.Point(122, 296);
            this.tbookingpax_cb.Name = "tbookingpax_cb";
            this.tbookingpax_cb.Size = new System.Drawing.Size(93, 19);
            this.tbookingpax_cb.TabIndex = 15;
            this.tbookingpax_cb.Text = "tbookingpax";
            this.tbookingpax_cb.UseVisualStyleBackColor = true;
            // 
            // tbookstate_cb
            // 
            this.tbookstate_cb.AutoSize = true;
            this.tbookstate_cb.Location = new System.Drawing.Point(122, 321);
            this.tbookstate_cb.Name = "tbookstate_cb";
            this.tbookstate_cb.Size = new System.Drawing.Size(82, 19);
            this.tbookstate_cb.TabIndex = 16;
            this.tbookstate_cb.Text = "tbookstate";
            this.tbookstate_cb.UseVisualStyleBackColor = true;
            // 
            // tgroup_cb
            // 
            this.tgroup_cb.AutoSize = true;
            this.tgroup_cb.Location = new System.Drawing.Point(343, 320);
            this.tgroup_cb.Name = "tgroup_cb";
            this.tgroup_cb.Size = new System.Drawing.Size(62, 19);
            this.tgroup_cb.TabIndex = 20;
            this.tgroup_cb.Text = "tgroup";
            this.tgroup_cb.UseVisualStyleBackColor = true;
            // 
            // tflight_cb
            // 
            this.tflight_cb.AutoSize = true;
            this.tflight_cb.Location = new System.Drawing.Point(343, 295);
            this.tflight_cb.Name = "tflight_cb";
            this.tflight_cb.Size = new System.Drawing.Size(58, 19);
            this.tflight_cb.TabIndex = 19;
            this.tflight_cb.Text = "tflight";
            this.tflight_cb.UseVisualStyleBackColor = true;
            // 
            // tcustomer_cb
            // 
            this.tcustomer_cb.AutoSize = true;
            this.tcustomer_cb.Location = new System.Drawing.Point(233, 321);
            this.tcustomer_cb.Name = "tcustomer_cb";
            this.tcustomer_cb.Size = new System.Drawing.Size(80, 19);
            this.tcustomer_cb.TabIndex = 18;
            this.tcustomer_cb.Text = "tcustomer";
            this.tcustomer_cb.UseVisualStyleBackColor = true;
            // 
            // tcountry_cb
            // 
            this.tcountry_cb.AutoSize = true;
            this.tcountry_cb.Location = new System.Drawing.Point(233, 296);
            this.tcountry_cb.Name = "tcountry_cb";
            this.tcountry_cb.Size = new System.Drawing.Size(71, 19);
            this.tcountry_cb.TabIndex = 17;
            this.tcountry_cb.Text = "tcountry";
            this.tcountry_cb.UseVisualStyleBackColor = true;
            // 
            // tusergroup_cb
            // 
            this.tusergroup_cb.AutoSize = true;
            this.tusergroup_cb.Location = new System.Drawing.Point(653, 319);
            this.tusergroup_cb.Name = "tusergroup_cb";
            this.tusergroup_cb.Size = new System.Drawing.Size(84, 19);
            this.tusergroup_cb.TabIndex = 26;
            this.tusergroup_cb.Text = "tusergroup";
            this.tusergroup_cb.UseVisualStyleBackColor = true;
            // 
            // tuser_cb
            // 
            this.tuser_cb.AutoSize = true;
            this.tuser_cb.Location = new System.Drawing.Point(653, 294);
            this.tuser_cb.Name = "tuser_cb";
            this.tuser_cb.Size = new System.Drawing.Size(52, 19);
            this.tuser_cb.TabIndex = 25;
            this.tuser_cb.Text = "tuser";
            this.tuser_cb.UseVisualStyleBackColor = true;
            // 
            // tregion_cb
            // 
            this.tregion_cb.AutoSize = true;
            this.tregion_cb.Location = new System.Drawing.Point(543, 320);
            this.tregion_cb.Name = "tregion_cb";
            this.tregion_cb.Size = new System.Drawing.Size(64, 19);
            this.tregion_cb.TabIndex = 24;
            this.tregion_cb.Text = "tregion";
            this.tregion_cb.UseVisualStyleBackColor = true;
            // 
            // tlanguage_cb
            // 
            this.tlanguage_cb.AutoSize = true;
            this.tlanguage_cb.Location = new System.Drawing.Point(543, 295);
            this.tlanguage_cb.Name = "tlanguage_cb";
            this.tlanguage_cb.Size = new System.Drawing.Size(79, 19);
            this.tlanguage_cb.TabIndex = 23;
            this.tlanguage_cb.Text = "tlanguage";
            this.tlanguage_cb.UseVisualStyleBackColor = true;
            // 
            // thotelinfo_cb
            // 
            this.thotelinfo_cb.AutoSize = true;
            this.thotelinfo_cb.Location = new System.Drawing.Point(432, 320);
            this.thotelinfo_cb.Name = "thotelinfo_cb";
            this.thotelinfo_cb.Size = new System.Drawing.Size(78, 19);
            this.thotelinfo_cb.TabIndex = 22;
            this.thotelinfo_cb.Text = "thotelinfo";
            this.thotelinfo_cb.UseVisualStyleBackColor = true;
            // 
            // thotel_cb
            // 
            this.thotel_cb.AutoSize = true;
            this.thotel_cb.Location = new System.Drawing.Point(432, 295);
            this.thotel_cb.Name = "thotel_cb";
            this.thotel_cb.Size = new System.Drawing.Size(57, 19);
            this.thotel_cb.TabIndex = 21;
            this.thotel_cb.Text = "thotel";
            this.thotel_cb.UseVisualStyleBackColor = true;
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(308, 345);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(159, 23);
            this.ExportButton.TabIndex = 27;
            this.ExportButton.Text = "Eksportuj do XML";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Import danych";
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(308, 415);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(159, 23);
            this.ImportButton.TabIndex = 29;
            this.ImportButton.Text = "Importuj plik XML";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.tusergroup_cb);
            this.Controls.Add(this.tuser_cb);
            this.Controls.Add(this.tregion_cb);
            this.Controls.Add(this.tlanguage_cb);
            this.Controls.Add(this.thotelinfo_cb);
            this.Controls.Add(this.thotel_cb);
            this.Controls.Add(this.tgroup_cb);
            this.Controls.Add(this.tflight_cb);
            this.Controls.Add(this.tcustomer_cb);
            this.Controls.Add(this.tcountry_cb);
            this.Controls.Add(this.tbookstate_cb);
            this.Controls.Add(this.tbookingpax_cb);
            this.Controls.Add(this.tbooking_cb);
            this.Controls.Add(this.tbookelement_cb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HotelsButton);
            this.Controls.Add(this.FlightsButton);
            this.Controls.Add(this.RegionButton);
            this.Controls.Add(this.UsersButton);
            this.Controls.Add(this.ReservationButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ValueTextbox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ValueTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ReservationButton;
        private System.Windows.Forms.Button UsersButton;
        private System.Windows.Forms.Button RegionButton;
        private System.Windows.Forms.Button FlightsButton;
        private System.Windows.Forms.Button HotelsButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox tbookelement_cb;
        private System.Windows.Forms.CheckBox tbooking_cb;
        private System.Windows.Forms.CheckBox tbookingpax_cb;
        private System.Windows.Forms.CheckBox tbookstate_cb;
        private System.Windows.Forms.CheckBox tgroup_cb;
        private System.Windows.Forms.CheckBox tflight_cb;
        private System.Windows.Forms.CheckBox tcustomer_cb;
        private System.Windows.Forms.CheckBox tcountry_cb;
        private System.Windows.Forms.CheckBox tusergroup_cb;
        private System.Windows.Forms.CheckBox tuser_cb;
        private System.Windows.Forms.CheckBox tregion_cb;
        private System.Windows.Forms.CheckBox tlanguage_cb;
        private System.Windows.Forms.CheckBox thotelinfo_cb;
        private System.Windows.Forms.CheckBox thotel_cb;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ImportButton;
    }
}

