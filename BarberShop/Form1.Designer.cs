namespace BarberShop
{
    partial class barberForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(barberForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sofa4Label = new System.Windows.Forms.Label();
            this.sofa3Label = new System.Windows.Forms.Label();
            this.sofa2Label = new System.Windows.Forms.Label();
            this.sofa1Label = new System.Windows.Forms.Label();
            this.barberChair1Label = new System.Windows.Forms.Label();
            this.barberChair2Label = new System.Windows.Forms.Label();
            this.barberChair3Label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
            // 
            // sofa4Label
            // 
            resources.ApplyResources(this.sofa4Label, "sofa4Label");
            this.sofa4Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.sofa4Label.Name = "sofa4Label";
            // 
            // sofa3Label
            // 
            resources.ApplyResources(this.sofa3Label, "sofa3Label");
            this.sofa3Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.sofa3Label.Name = "sofa3Label";
            // 
            // sofa2Label
            // 
            resources.ApplyResources(this.sofa2Label, "sofa2Label");
            this.sofa2Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.sofa2Label.Name = "sofa2Label";
            // 
            // sofa1Label
            // 
            resources.ApplyResources(this.sofa1Label, "sofa1Label");
            this.sofa1Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.sofa1Label.Name = "sofa1Label";
            // 
            // barberChair1Label
            // 
            resources.ApplyResources(this.barberChair1Label, "barberChair1Label");
            this.barberChair1Label.BackColor = System.Drawing.Color.Lime;
            this.barberChair1Label.Name = "barberChair1Label";
            // 
            // barberChair2Label
            // 
            resources.ApplyResources(this.barberChair2Label, "barberChair2Label");
            this.barberChair2Label.BackColor = System.Drawing.Color.Lime;
            this.barberChair2Label.Name = "barberChair2Label";
            // 
            // barberChair3Label
            // 
            resources.ApplyResources(this.barberChair3Label, "barberChair3Label");
            this.barberChair3Label.BackColor = System.Drawing.Color.Lime;
            this.barberChair3Label.Name = "barberChair3Label";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Red;
            this.label7.Name = "label7";
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.BackColor = System.Drawing.Color.Gray;
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // barberForm
            // 
            this.AcceptButton = this.startButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CancelButton = this.exitButton;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.barberChair1Label);
            this.Controls.Add(this.barberChair2Label);
            this.Controls.Add(this.barberChair3Label);
            this.Controls.Add(this.sofa1Label);
            this.Controls.Add(this.sofa2Label);
            this.Controls.Add(this.sofa3Label);
            this.Controls.Add(this.sofa4Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "barberForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sofa4Label;
        private System.Windows.Forms.Label sofa3Label;
        private System.Windows.Forms.Label sofa2Label;
        private System.Windows.Forms.Label sofa1Label;
        private System.Windows.Forms.Label barberChair1Label;
        private System.Windows.Forms.Label barberChair2Label;
        private System.Windows.Forms.Label barberChair3Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button exitButton;
    }
}

