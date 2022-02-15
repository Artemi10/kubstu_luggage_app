using System.ComponentModel;
using System.Windows.Forms;

namespace luggage_app.front_end
{
    partial class LuggageTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.аналитикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчёт1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчёт2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.idColumn = new System.Windows.Forms.Label();
            this.itemsAmountColumn = new System.Windows.Forms.Label();
            this.codeColumn = new System.Windows.Forms.Label();
            this.passengerSurnameColumn = new System.Windows.Forms.Label();
            this.weightColumn = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.добавитьToolStripMenuItem, this.редактироватьToolStripMenuItem, this.удалитьToolStripMenuItem, this.аналитикаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += this.добавитьToolStripMenuItem_Click;
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += this.редактироватьToolStripMenuItem_Click;
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += this.удалитьToolStripMenuItem_Click;
            // 
            // аналитикаToolStripMenuItem
            // 
            this.аналитикаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.отчёт1ToolStripMenuItem, this.отчёт2ToolStripMenuItem});
            this.аналитикаToolStripMenuItem.Name = "аналитикаToolStripMenuItem";
            this.аналитикаToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.аналитикаToolStripMenuItem.Text = "Аналитика";
            // 
            // отчёт1ToolStripMenuItem
            // 
            this.отчёт1ToolStripMenuItem.Name = "отчёт1ToolStripMenuItem";
            this.отчёт1ToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.отчёт1ToolStripMenuItem.Text = "Отчёт1";
            this.отчёт1ToolStripMenuItem.Click += new System.EventHandler(this.отчёт1ToolStripMenuItem_Click);
            // 
            // отчёт2ToolStripMenuItem
            // 
            this.отчёт2ToolStripMenuItem.Name = "отчёт2ToolStripMenuItem";
            this.отчёт2ToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.отчёт2ToolStripMenuItem.Text = "Отчёт2";
            this.отчёт2ToolStripMenuItem.Click += new System.EventHandler(this.отчёт2ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(0, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Багаж\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
             // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5});
            this.dataGridView1.Location = new System.Drawing.Point(60, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(678, 250);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Rows[0].ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "Код ячейки";
            this.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "Фамилия\rвладельца";
            this.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "Шифр";
            this.dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Name = "Вес багажа";
            this.dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Name = "Количество вещей";
            this.dataGridViewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 61);
            this.button1.TabIndex = 3;
            this.button1.Text = "Изменить максимальный вес";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += this.button1_Click;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(322, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 61);
            this.button2.TabIndex = 4;
            this.button2.Text = "Сохранить в файл";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(534, 358);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 61);
            this.button3.TabIndex = 5;
            this.button3.Text = "Выгрузить из файла";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // LuggageTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LuggageTable";
            this.Text = "LuggageTable";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;
        
        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Label idColumn;
        private System.Windows.Forms.Label passengerSurnameColumn;
        private System.Windows.Forms.Label codeColumn;
        private System.Windows.Forms.Label weightColumn;
        private System.Windows.Forms.Label itemsAmountColumn;

        private System.Windows.Forms.Label label1;
        

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem аналитикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчёт1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчёт2ToolStripMenuItem;

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        
        #endregion
    }
}