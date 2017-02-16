using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int[,] completo = new int[4, 4];

        int lv = 200;
        int lh = 50;
        private void button1_Click(object sender, EventArgs e)
        {

            int[,,] tablero = new int[200, 4, 4];
            int[,,] candidato = new int[10, 4, 4];
            int indtab = 0, indcad = 0;
            int[,,] visitados = new int[500, 4, 4];
            int indvis = 0;
            int H = 0, haux = 0;//marca errores
            int index = -1;
            string cad = "";
            bool rep = false;
            TextBox[] V = new TextBox[2000];//textbox donde se mostraran las vertices

            stak.Controls.Clear();
            //inicializar valores de tablero inicial 
            visitados[0, 0, 0] = tablero[indtab, 0, 0] = int.Parse(I00.Text);
            visitados[0, 0, 1] = tablero[indtab, 0, 1] = int.Parse(I01.Text);
            visitados[0, 0, 2] = tablero[indtab, 0, 2] = int.Parse(I02.Text);
            visitados[0, 0, 3] = tablero[indtab, 0, 3] = int.Parse(I03.Text);
            visitados[0, 1, 0] = tablero[indtab, 1, 0] = int.Parse(I10.Text);
            visitados[0, 1, 1] = tablero[indtab, 1, 1] = int.Parse(I11.Text);
            visitados[0, 1, 2] = tablero[indtab, 1, 2] = int.Parse(I12.Text);
            visitados[0, 1, 3] = tablero[indtab, 1, 3] = int.Parse(I13.Text);
            visitados[0, 2, 0] = tablero[indtab, 2, 0] = int.Parse(I20.Text);
            visitados[0, 2, 1] = tablero[indtab, 2, 1] = int.Parse(I21.Text);
            visitados[0, 2, 2] = tablero[indtab, 2, 2] = int.Parse(I22.Text);
            visitados[0, 2, 3] = tablero[indtab, 2, 3] = int.Parse(I23.Text);
            visitados[0, 3, 0] = tablero[indtab, 3, 0] = int.Parse(I30.Text);
            visitados[0, 3, 1] = tablero[indtab, 3, 1] = int.Parse(I31.Text);
            visitados[0, 3, 2] = tablero[indtab, 3, 2] = int.Parse(I32.Text);
            visitados[0, 3, 3] = tablero[indtab, 3, 3] = int.Parse(I33.Text);
            indvis++;
            //inicializar valores de tablero completo

            int contador = 1;
            for (int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 4; j++)
                {

                    completo[k, j] = contador;
                    contador++;
                }
                cad += Environment.NewLine;
            }
            completo[3, 3] = 0;

            index = -1;
            bool mverror = false;
            int contv = 0;
           
            while (H < 15)
            //for (int t = 0; t < 742; t++)
            {
                for (int r = 0; r <= indtab; r++)
                {

                  
                    H = 0;
                    for (int k = 0; k < 2; k++)
                    {//buscar en x
                        haux = 0;

                        try
                        {


                            cad = "";
                            for (int t = 0; t < 4; t++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    cad += tablero[indtab, t, j].ToString();
                                    cad += ",";
                                }
                                cad += Environment.NewLine;
                            }
                            cad += Environment.NewLine;
                            mverror = mover_x(tablero, index, indtab);//mueve en eje 
                            
                            for (int t = 0;t < 4; t++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    cad += tablero[indtab,t, j].ToString();
                                    cad += ",";
                                }
                                cad += Environment.NewLine;
                            }
                            textBox1.Text = cad;
                            
                            rep = Busca_en_vistados(tablero, visitados, indvis, indtab);//busca que no este repetido

                            if (rep == false)
                            {
                              
                                try
                                {
                                    Copia_vist(visitados, tablero, indvis, indtab);//guarda a visitados
                                    indvis++;
                                    haux = Compara_competo(tablero, indtab);//busca cuantos aciertos tiene el nuevo movimiento
                                   

                                    if (haux > H)//si es mayor al aterior entra
                                    {
                                        indcad = 0;
                                        Copia_matriz(candidato, tablero, indtab, indcad);//copia el nuevo movimiento a candidato 
                                        H = haux;// guarda en H para seguir comparando

                                    }
                                    else if (haux == H)
                                    {
                                        indcad++;
                                        Copia_matriz(candidato, tablero, indtab, indcad);

                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());

                                }



                            }




                        }
                        catch (Exception )
                        {
                            mverror = true;
                        }

                        index = index * -1;




                        if (mverror == false)
                        {

                           mover_x(tablero, index, indtab);

                        }


                        mverror = false;

                    }


                    for (int k = 0; k < 2; k++)
                    {//buscar en y
                        haux = 0;

                        try
                        {
                            cad = "";
                            for (int t = 0; t < 4; t++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    cad += tablero[indtab, t, j].ToString();
                                    cad += ",";
                                }
                                cad += Environment.NewLine;
                            }
                            cad += Environment.NewLine;

                            mverror = mover_y(tablero, index, indtab);//mueve en eje y
                            
                            for (int t = 0; t < 4; t++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    cad += tablero[indtab, t, j].ToString();
                                    cad += ",";
                                }
                                cad += Environment.NewLine;
                            }
                            textBox1.Text = cad;
                            rep = Busca_en_vistados(tablero, visitados, indvis, indtab);


                            if (rep == false)
                            {
                                try
                                {
                                    Copia_vist(visitados, tablero, indvis, indtab);//guarda a visitados
                                    indvis++;
                                    haux = Compara_competo(tablero, indtab);
                                    
                                    if (haux > H)
                                    {
                                        indcad = 0;
                                        Copia_matriz(candidato, tablero, indtab, indcad);
                                        H = haux;
                                    }
                                    else if (haux == H)
                                    {
                                        indcad++;
                                        Copia_matriz(candidato, tablero, indtab, indcad);

                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }

                            }



                        }
                        catch (Exception es)
                        {
                            mverror = true;
                        }



                        index = index * -1;

                        if (mverror == false)
                            mover_y(tablero, index, indtab);

                        mverror = false;



                    }


                }

                lv = 200;

                for (int m = 0; m < 4; m++)
                {

                    lv = 200;
                    for (int j = 0; j < 4; j++)
                    {

                        

                        V[contv] = new TextBox();

                        V[contv].Text = tablero[indtab, m,j].ToString();
                        V[contv].Size = new Size(20, 20);
                        V[contv].Location = new Point(lv, lh);
                        V[contv].BackColor = Color.AliceBlue;
                        Controls.Add(V[contv]);
                        stak.Controls.Add(V[contv]);
                        lv += 20;
                        contv++;






                        Pen myPe;
                        myPe = new Pen(Color.Black);
                        Graphics formGraphic;
                        formGraphic = stak.CreateGraphics();
                        stak.CreateGraphics().Save();
                        formGraphic.DrawLine(myPe, 230, lh, 230, lh+90);
                        myPe.Dispose();
                        formGraphic.Dispose();







                    }

                    lh += 20;
                   
                }

                
                V[contv] = new TextBox();

                V[contv].Text = (H-1).ToString();
                V[contv].Size = new Size(20, 20);
                V[contv].Location = new Point(lv, lh);
                
                V[contv].BackColor = Color.AliceBlue;
                Controls.Add(V[contv]);
                stak.Controls.Add(V[contv]);
                lv += 20;
                contv++;

                lh += 70;

                indtab = indcad;
                cand_tab(candidato, indcad, tablero, indtab);







              
            }





            for (int m = 0; m < 4; m++)
            {
                lv = 200;
                for (int j = 0; j < 4; j++)
                {



                    V[contv] = new TextBox();

                    V[contv].Text = tablero[indtab, m, j].ToString();
                    V[contv].Size = new Size(20, 20);
                    V[contv].Location = new Point(lv, lh);
                    V[contv].BackColor = Color.AliceBlue;
                    Controls.Add(V[contv]);
                    stak.Controls.Add(V[contv]);
                    lv += 20;
                    contv++;




                }

                lh += 20;
            }


            



        }


        public void cand_tab(int[,,] cand, int indcand, int[,,] tablero, int indtab)
        {
            for (int j = 0; j <= indcand; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        tablero[j, k, l] = cand[j, k, l];
                    }

                }
            }

        }
        public bool mover_x(int[,,] tablero, int index, int indtab)
        {
            bool mverror=false;
            int[,] pos0 = new int[1, 2];

               

            try
            {
                busca_pos0(tablero, pos0, indtab);

                tablero[indtab, pos0[0, 0], pos0[0, 1]] = tablero[indtab, pos0[0, 0] + index, pos0[0, 1]];
                tablero[indtab, pos0[0, 0] + index, pos0[0, 1]] = 0;
            }
            catch (Exception)
            {
                mverror = true;
            }
            return mverror;
        }


        public bool mover_y(int[,,] tablero, int index, int indtab)
        {

            int[,] pos0 = new int[1, 2];
            bool mverror = false;

            try
            {
                busca_pos0(tablero, pos0, indtab);

                tablero[indtab, pos0[0, 0], pos0[0, 1]] = tablero[indtab, pos0[0, 0], pos0[0, 1] + index];
                tablero[indtab, pos0[0, 0], pos0[0, 1] + index] = 0;
            }
            catch (Exception)
            {
                mverror = true;
            }

            return mverror;
        }

        public void busca_pos0(int[,,] tablero, int[,] pos0, int indtab)
        {

            for (int k = 0; k < 4; k++)//buscar 0 (espacio)
            {

                for (int j = 0; j < 4; j++)
                {

                    if (tablero[indtab, k, j] == 0)
                    {
                        pos0[0, 0] = k;
                        pos0[0, 1] = j;
                    }

                }


            }

        }

        public int Compara_competo(int[,,] tablero, int indtab)
        {
            int haux = 0;

            for (int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (tablero[indtab, k, j] == completo[k, j])
                        haux++;



                }
            }

            return haux;
        }

        public void Copia_matriz(int[,,] candidato, int[,,] tablero, int indtab, int indcand)
        {



            for (int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 4; j++)
                {

                    candidato[indcand, k, j] = tablero[indtab, k, j];

                }
            }
        }


        public void Copia_vist(int[,,] visitados, int[,,] tablero, int index, int indtab)
        {

            for (int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 4; j++)
                {

                    visitados[index, k, j] = tablero[indtab, k, j];



                }
            }
        }

        public bool Busca_en_vistados(int[,,] Tablero, int[,,] visitados, int indvisit, int indtab)
        {

            int contador = 0;
            bool rep = false;
            for (int k = 0; k <= indvisit; k++)
            {
                contador = 0;

                for (int j = 0; j < 4; j++)
                {
                    for (int l = 0; l < 4; l++)
                    {


                        if (Tablero[indtab, j, l] == visitados[k, j, l])
                        {

                            contador++;
                        }
                    }
                }

                if (contador >= 15)
                {
                    rep = true;
                    break;
                }



            }

            return rep;
        }

        private void stak_Paint(object sender, PaintEventArgs e)
        {

            Pen myPen;
            myPen = new Pen(Color.Black);
            Graphics formGraphics;
            formGraphics = stak.CreateGraphics();
            stak.CreateGraphics().Save();
            formGraphics.DrawLine(myPen, 230, 50, 230, lh );
            myPen.Dispose();
            formGraphics.Dispose();
        }
    }
}
