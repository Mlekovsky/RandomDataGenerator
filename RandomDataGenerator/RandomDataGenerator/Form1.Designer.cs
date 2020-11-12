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
            this.ValueTextbox.Location = new System.Drawing.Point(329, 214);
            this.ValueTextbox.Name = "ValueTextbox";
            this.ValueTextbox.Size = new System.Drawing.Size(100, 23);
            this.ValueTextbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Podaj liczbe elementów do dodania";
            // 
            // ReservationButton
            // 
            this.ReservationButton.Location = new System.Drawing.Point(199, 290);
            this.ReservationButton.Name = "ReservationButton";
            this.ReservationButton.Size = new System.Drawing.Size(124, 51);
            this.ReservationButton.TabIndex = 4;
            this.ReservationButton.Text = "Generuj rezerwacje";
            this.ReservationButton.UseVisualStyleBackColor = true;
            this.ReservationButton.Click += new System.EventHandler(this.ReservationButton_Click);
            // 
            // UsersButton
            // 
            this.UsersButton.Location = new System.Drawing.Point(357, 290);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(152, 51);
            this.UsersButton.TabIndex = 8;
            this.UsersButton.Text = "Generuj użytkowników";
            this.UsersButton.UseVisualStyleBackColor = true;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // RegionButton
            // 
            this.RegionButton.Location = new System.Drawing.Point(42, 290);
            this.RegionButton.Name = "RegionButton";
            this.RegionButton.Size = new System.Drawing.Size(123, 51);
            this.RegionButton.TabIndex = 9;
            this.RegionButton.Text = "Generuj kraje i regiony";
            this.RegionButton.UseVisualStyleBackColor = true;
            this.RegionButton.Click += new System.EventHandler(this.RegionButton_Click);
            // 
            // FlightsButton
            // 
            this.FlightsButton.Location = new System.Drawing.Point(541, 290);
            this.FlightsButton.Name = "FlightsButton";
            this.FlightsButton.Size = new System.Drawing.Size(104, 51);
            this.FlightsButton.TabIndex = 10;
            this.FlightsButton.Text = "Generuj samoloty";
            this.FlightsButton.UseVisualStyleBackColor = true;
            this.FlightsButton.Click += new System.EventHandler(this.FlightsButton_Click);
            // 
            // HotelsButton
            // 
            this.HotelsButton.Location = new System.Drawing.Point(672, 290);
            this.HotelsButton.Name = "HotelsButton";
            this.HotelsButton.Size = new System.Drawing.Size(103, 51);
            this.HotelsButton.TabIndex = 11;
            this.HotelsButton.Text = "Generuj hotele";
            this.HotelsButton.UseVisualStyleBackColor = true;
            this.HotelsButton.Click += new System.EventHandler(this.HotelsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

