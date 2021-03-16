
namespace JarvisGoogleAPI.View
{
    partial class WelcomeForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.startButton = new System.Windows.Forms.Button();
            this.changeProgrammsButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.saveCommandsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(23, 477);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(283, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Запустить";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // changeProgrammsButton
            // 
            this.changeProgrammsButton.Location = new System.Drawing.Point(23, 448);
            this.changeProgrammsButton.Name = "changeProgrammsButton";
            this.changeProgrammsButton.Size = new System.Drawing.Size(283, 23);
            this.changeProgrammsButton.TabIndex = 1;
            this.changeProgrammsButton.Text = "Редактировать список программ";
            this.changeProgrammsButton.UseVisualStyleBackColor = true;
            this.changeProgrammsButton.Click += new System.EventHandler(this.changeProgrammsButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Jarvis";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // saveCommandsButton
            // 
            this.saveCommandsButton.Location = new System.Drawing.Point(23, 419);
            this.saveCommandsButton.Name = "saveCommandsButton";
            this.saveCommandsButton.Size = new System.Drawing.Size(283, 23);
            this.saveCommandsButton.TabIndex = 2;
            this.saveCommandsButton.Text = "Сохранить";
            this.saveCommandsButton.UseVisualStyleBackColor = true;
            this.saveCommandsButton.Click += new System.EventHandler(this.saveCommandsButton_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 514);
            this.Controls.Add(this.saveCommandsButton);
            this.Controls.Add(this.changeProgrammsButton);
            this.Controls.Add(this.startButton);
            this.KeyPreview = true;
            this.Name = "WelcomeForm";
            this.Text = "JARVIS";
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button changeProgrammsButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button saveCommandsButton;
    }
}