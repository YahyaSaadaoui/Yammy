namespace Yammy
{
    partial class Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.textBoxnom = new System.Windows.Forms.TextBox();
            this.textBoxprénom = new System.Windows.Forms.TextBox();
            this.textBoxtel = new System.Windows.Forms.TextBox();
            this.textBoxemail = new System.Windows.Forms.TextBox();
            this.textBoxaddersse = new System.Windows.Forms.TextBox();
            this.Ajouter = new System.Windows.Forms.Button();
            this.Supprimer = new System.Windows.Forms.Button();
            this.Rechercher = new System.Windows.Forms.Button();
            this.Modifier = new System.Windows.Forms.Button();
            this.Premier = new System.Windows.Forms.Button();
            this.Précedent = new System.Windows.Forms.Button();
            this.Suivant = new System.Windows.Forms.Button();
            this.Dérniere = new System.Windows.Forms.Button();
            this.dataGridViewClient = new System.Windows.Forms.DataGridView();
            this.Retour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N°";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Addresse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Prénom";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nom";
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(145, 55);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(100, 20);
            this.textBoxN.TabIndex = 8;
            // 
            // textBoxnom
            // 
            this.textBoxnom.Location = new System.Drawing.Point(145, 87);
            this.textBoxnom.Name = "textBoxnom";
            this.textBoxnom.Size = new System.Drawing.Size(100, 20);
            this.textBoxnom.TabIndex = 9;
            // 
            // textBoxprénom
            // 
            this.textBoxprénom.Location = new System.Drawing.Point(145, 124);
            this.textBoxprénom.Name = "textBoxprénom";
            this.textBoxprénom.Size = new System.Drawing.Size(100, 20);
            this.textBoxprénom.TabIndex = 10;
            // 
            // textBoxtel
            // 
            this.textBoxtel.Location = new System.Drawing.Point(502, 52);
            this.textBoxtel.Name = "textBoxtel";
            this.textBoxtel.Size = new System.Drawing.Size(100, 20);
            this.textBoxtel.TabIndex = 11;
            // 
            // textBoxemail
            // 
            this.textBoxemail.Location = new System.Drawing.Point(502, 87);
            this.textBoxemail.Name = "textBoxemail";
            this.textBoxemail.Size = new System.Drawing.Size(100, 20);
            this.textBoxemail.TabIndex = 12;
            // 
            // textBoxaddersse
            // 
            this.textBoxaddersse.Location = new System.Drawing.Point(502, 124);
            this.textBoxaddersse.Name = "textBoxaddersse";
            this.textBoxaddersse.Size = new System.Drawing.Size(100, 20);
            this.textBoxaddersse.TabIndex = 13;
            // 
            // Ajouter
            // 
            this.Ajouter.Location = new System.Drawing.Point(37, 181);
            this.Ajouter.Name = "Ajouter";
            this.Ajouter.Size = new System.Drawing.Size(75, 23);
            this.Ajouter.TabIndex = 14;
            this.Ajouter.Text = "Ajouter";
            this.Ajouter.UseVisualStyleBackColor = true;
            this.Ajouter.Click += new System.EventHandler(this.Ajouter_Click);
            // 
            // Supprimer
            // 
            this.Supprimer.Location = new System.Drawing.Point(201, 181);
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Size = new System.Drawing.Size(75, 23);
            this.Supprimer.TabIndex = 17;
            this.Supprimer.Text = "Supprimer";
            this.Supprimer.UseVisualStyleBackColor = true;
            this.Supprimer.Click += new System.EventHandler(this.Supprimer_Click);
            // 
            // Rechercher
            // 
            this.Rechercher.Location = new System.Drawing.Point(541, 181);
            this.Rechercher.Name = "Rechercher";
            this.Rechercher.Size = new System.Drawing.Size(75, 23);
            this.Rechercher.TabIndex = 18;
            this.Rechercher.Text = "Rechercher";
            this.Rechercher.UseVisualStyleBackColor = true;
            this.Rechercher.Click += new System.EventHandler(this.Rechercher_Click);
            // 
            // Modifier
            // 
            this.Modifier.Location = new System.Drawing.Point(367, 181);
            this.Modifier.Name = "Modifier";
            this.Modifier.Size = new System.Drawing.Size(75, 23);
            this.Modifier.TabIndex = 19;
            this.Modifier.Text = "Modifier";
            this.Modifier.UseVisualStyleBackColor = true;
            this.Modifier.Click += new System.EventHandler(this.Modifier_Click);
            // 
            // Premier
            // 
            this.Premier.Location = new System.Drawing.Point(38, 246);
            this.Premier.Name = "Premier";
            this.Premier.Size = new System.Drawing.Size(75, 23);
            this.Premier.TabIndex = 20;
            this.Premier.Text = "Premier";
            this.Premier.UseVisualStyleBackColor = true;
            this.Premier.Click += new System.EventHandler(this.Premier_Click);
            // 
            // Précedent
            // 
            this.Précedent.Location = new System.Drawing.Point(170, 244);
            this.Précedent.Name = "Précedent";
            this.Précedent.Size = new System.Drawing.Size(75, 23);
            this.Précedent.TabIndex = 21;
            this.Précedent.Text = "Précedent";
            this.Précedent.UseVisualStyleBackColor = true;
            this.Précedent.Click += new System.EventHandler(this.Précedent_Click);
            // 
            // Suivant
            // 
            this.Suivant.Location = new System.Drawing.Point(413, 244);
            this.Suivant.Name = "Suivant";
            this.Suivant.Size = new System.Drawing.Size(75, 23);
            this.Suivant.TabIndex = 22;
            this.Suivant.Text = "Suivant";
            this.Suivant.UseVisualStyleBackColor = true;
            this.Suivant.Click += new System.EventHandler(this.Suivant_Click);
            // 
            // Dérniere
            // 
            this.Dérniere.Location = new System.Drawing.Point(541, 244);
            this.Dérniere.Name = "Dérniere";
            this.Dérniere.Size = new System.Drawing.Size(75, 23);
            this.Dérniere.TabIndex = 23;
            this.Dérniere.Text = "Dérniere";
            this.Dérniere.UseVisualStyleBackColor = true;
            this.Dérniere.Click += new System.EventHandler(this.Dérniere_Click);
            // 
            // dataGridViewClient
            // 
            this.dataGridViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClient.Location = new System.Drawing.Point(22, 273);
            this.dataGridViewClient.Name = "dataGridViewClient";
            this.dataGridViewClient.Size = new System.Drawing.Size(607, 150);
            this.dataGridViewClient.TabIndex = 24;
            // 
            // Retour
            // 
            this.Retour.Location = new System.Drawing.Point(37, 444);
            this.Retour.Name = "Retour";
            this.Retour.Size = new System.Drawing.Size(75, 23);
            this.Retour.TabIndex = 27;
            this.Retour.Text = "Retour";
            this.Retour.UseVisualStyleBackColor = true;
            this.Retour.Click += new System.EventHandler(this.Retour_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 540);
            this.Controls.Add(this.Retour);
            this.Controls.Add(this.dataGridViewClient);
            this.Controls.Add(this.Dérniere);
            this.Controls.Add(this.Suivant);
            this.Controls.Add(this.Précedent);
            this.Controls.Add(this.Premier);
            this.Controls.Add(this.Modifier);
            this.Controls.Add(this.Rechercher);
            this.Controls.Add(this.Supprimer);
            this.Controls.Add(this.Ajouter);
            this.Controls.Add(this.textBoxaddersse);
            this.Controls.Add(this.textBoxemail);
            this.Controls.Add(this.textBoxtel);
            this.Controls.Add(this.textBoxprénom);
            this.Controls.Add(this.textBoxnom);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.TextBox textBoxnom;
        private System.Windows.Forms.TextBox textBoxprénom;
        private System.Windows.Forms.TextBox textBoxtel;
        private System.Windows.Forms.TextBox textBoxemail;
        private System.Windows.Forms.TextBox textBoxaddersse;
        private System.Windows.Forms.Button Ajouter;
        private System.Windows.Forms.Button Supprimer;
        private System.Windows.Forms.Button Rechercher;
        private System.Windows.Forms.Button Modifier;
        private System.Windows.Forms.Button Premier;
        private System.Windows.Forms.Button Précedent;
        private System.Windows.Forms.Button Suivant;
        private System.Windows.Forms.Button Dérniere;
        private System.Windows.Forms.DataGridView dataGridViewClient;
        private System.Windows.Forms.Button Retour;
    }
}