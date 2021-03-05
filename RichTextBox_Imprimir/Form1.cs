using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace RichTextBox_Imprimir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StreamReader leitor = null;

        #region Novo
        private void mnuNovo_Click(object sender, EventArgs e)
        {
            ChamaSalvarArquivo();
            rtxtb1.Clear();
            rtxtb1.Focus();
        }

        private void toolStripNovo_Click(object sender, EventArgs e)
        {
            ChamaSalvarArquivo();
            rtxtb1.Clear();
            rtxtb1.Focus();
        }


        #endregion

        #region Abrir Arquivo
        private void mnuAbrir_Arquivo(object sender, EventArgs e)
        {
            AbrirArquivo();
        }

        private void toolStripAbrir_Click(object sender, EventArgs e)
        {
            AbrirArquivo();
        }

        private void AbrirArquivo()
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Selecionar Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\PICHAU\Documents\";
            openFileDialog1.Filter = "Images (*.TXT)|*.TXT|" + "All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {

                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader m_streamReader = new StreamReader(fs);
                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.rtxtb1.Text = "";
                    string strLine = m_streamReader.ReadLine();
                    while (strLine != null)
                    {
                        this.rtxtb1.Text += strLine + "\n";
                        strLine = m_streamReader.ReadLine();
                    }

                    m_streamReader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        #endregion

        #region Salvar
        private void mnu_Salvar_Click(object sender, EventArgs e)
        {
            ChamaSalvarArquivo();
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            ChamaSalvarArquivo();
        }
        private void ChamaSalvarArquivo()
        {
            if (!string.IsNullOrEmpty(rtxtb1.Text))
            {
                if ((MessageBox.Show("Deseja Salvar o arquivo ?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                {
                    SalvarArquivo();
                }
            }
        }
        private void SalvarArquivo()
        {
            saveFileDialog1.DefaultExt = "*.txt";
            saveFileDialog1.Filter = "TXT Files|*.txt";
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter m_streamWriter = new StreamWriter(fs);
                    m_streamWriter.Flush();
                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    m_streamWriter.Write(this.rtxtb1.Text);
                    m_streamWriter.Flush();
                    m_streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Copiar
        private void mnu_Copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void toolStripCopiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void Copiar()
        {
            rtxtb1.Copy();
        }
        #endregion

        #region Colar
        private void mnu_Colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void toolStripColar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Colar()
        {
            rtxtb1.Paste();
        }
        #endregion

        #region Refazer
        private void RefazertoolStripMenu_Click(object sender, EventArgs e)
        {
            Refazer();
        }
        private void Refazer()
        {
            rtxtb1.Redo();
        }
        #endregion

        #region Desfazer
        private void DesfazertoolStripMenu_Click(object sender, EventArgs e)
        {
            Desfazer();
        }
        private void Desfazer()
        {
            rtxtb1.Undo();
        }
        #endregion

        #region Negrito
        private void mnu_Negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void toolStripNegrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void Negrito()
        {
            string nome_fonte = rtxtb1.Font.Name;
            float tamanho_fonte = rtxtb1.Font.Size;
            /*bool negrito = false;
            negrito = rtxtb1.Font.Bold;*/

            try
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Bold);
            }
            catch
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Regular);
            }

        }
        #endregion

        #region Italico
        private void mnu_Italico_Click(object sender, EventArgs e)
        {
            Italico();
        }
        private void toolStripItalico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void Italico()
        {
            string nome_fonte = rtxtb1.Font.Name;
            float tamanho_fonte = rtxtb1.Font.Size;
            bool italico = false;
            italico = rtxtb1.Font.Italic;

            if (italico == false)
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Italic);
            }
            else
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Regular);
            }
        }
        #endregion

        #region Sublinhado
        private void mnu_Sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void toolStripSublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void Sublinhado()
        {
            string nome_fonte = rtxtb1.Font.Name;
            float tamanho_fonte = rtxtb1.Font.Size;
            bool sublinhado = false;
            sublinhado = rtxtb1.Font.Underline;

            if (sublinhado == false)
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Underline);
            }
            else
            {
                rtxtb1.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Regular);
            }
        }
        #endregion

        #region Alterar Fonte
        private void mnu_AlterarFonte_Click(object sender, EventArgs e)
        {
            AlterarFonte();
        }

        private void toolStripFonte_Click(object sender, EventArgs e)
        {
            AlterarFonte();
        }

        private void AlterarFonte()
        {
            DialogResult result = fontDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (rtxtb1.SelectionFont != null)
                {
                    rtxtb1.SelectionFont = fontDialog1.Font;
                }
            }
        }
        #endregion

        #region Alinhar Texto
        private void mnuAlinharEsquerda_Click(object sender, EventArgs e)
        {
            rtxtb1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void mnuAlinharCentro_Click(object sender, EventArgs e)
        {
            rtxtb1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void mnuAlinhaDireita_Click(object sender, EventArgs e)
        {
            rtxtb1.SelectionAlignment = HorizontalAlignment.Right;
        }
        #endregion

        #region ConfigImprimir
        private void mnuConfig_Impresao_Click(object sender, EventArgs e)
        {
            ConfigImpressao();
        }

        private void toolStripConfigImprimir_Click(object sender, EventArgs e)
        {
            ConfigImpressao();
        }
        
        private void ConfigImpressao()
        {
            try
            {
                this.printDialog1.Document = this.printDocument1;
                printDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region VisualizarImpressao
        private void mnuVisualizar_Impressao(object sender, EventArgs e)
        {
            visualizaImpressao();
        }
        private void toolStripVisualizar_Click(object sender, EventArgs e)
        {
            visualizaImpressao();
        }

        private void visualizaImpressao()
        {
            try
            {
                string strTexto = this.rtxtb1.Text;
                leitor = new StreamReader(strTexto);
                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                var prn = printPreviewDialog1;
                prn.Document = this.printDocument1;
                prn.Text = "Visualizando a impressão";
                prn.WindowState = FormWindowState.Maximized;
                prn.PrintPreviewControl.Zoom = 1;
                prn.FormBorderStyle = FormBorderStyle.Fixed3D;
                prn.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Imprimir
        private void mnu_Imprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
        private void toolStripImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }       
        private void Imprimir()
        {
            try
            {
                AbrirArquivo();
                printDialog1.Document = printDocument1;
                string strTexto = this.rtxtb1.Text;
                leitor = new StreamReader(strTexto);
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.printDocument1.Print();
                }
            }
            catch 
            {
                MessageBox.Show("Não foi possível imprimir o arquivo", "Erro ao imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhas_paginas = 0;
            float posicao_Y = 0;
            int contador = 0;

            float Margem_Esquerda = e.MarginBounds.Left - 50;
            float Margem_Superior = e.MarginBounds.Top - 50;

            if(Margem_Esquerda < 5)
            {
                Margem_Esquerda = 20;
            }

            if (Margem_Superior < 5)
            {
                Margem_Superior = 20;
            }

            string linha = null;
            Font FonteDeImpressao = this.rtxtb1.Font;
            SolidBrush meupincel = new SolidBrush(Color.Black);
            linhas_paginas = e.MarginBounds.Height / FonteDeImpressao.GetHeight(e.Graphics);
            linha = leitor.ReadLine();

            while (contador < linhas_paginas)
            {
                posicao_Y = (Margem_Superior + (contador * FonteDeImpressao.GetHeight(e.Graphics)));
                e.Graphics.DrawString(linha, FonteDeImpressao, meupincel, Margem_Esquerda, posicao_Y, new StringFormat());
                contador += 1;
                linha = leitor.ReadLine();
            }

            if ((linha != null))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

            meupincel.Dispose();
        }
        #endregion

        #region Sobre
        private void toolStripAjuda_Click(object sender, EventArgs e)
        {
            Sobre();
        }
        private void SobreToolStripMenu_Click(object sender, EventArgs e)
        {
            Sobre();
        }
        private void Sobre()
        {
            System.Diagnostics.Process.Start("C:/Program Files (x86)/Google/Chrome/Application/chrome.exe", "https://github.com/Angelowh");
        }
        #endregion

        #region Sair
        private void SairToolStrip_Click(object sender, EventArgs e)
        {
            Sair();
        }
        private void toolStripSair_Click(object sender, EventArgs e)
        {
            Sair();
        }
        private void SairtoolStripMenu_Click(object sender, EventArgs e)
        {
            Sair();
        }
        private void Sair()
        {
            string message = "Deseja fechar o aplicativo?";
            string title = "Fechar aplicação";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

    }
}
