using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD2AJoaoPhelipe.BLL;
using CRUD2AJoaoPhelipe.Model; 

namespace CRUD2AJoaoPhelipe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Metodo limpar os campos 
        public void Limpar()
        {
            txtCodigo.Clear(); 
            txtNome.Clear();
            mtbCPF.Clear();
            mtbCelular.Clear(); 
            txtEndereco.Clear();    
            txtBairro.Clear();  
            txtCidade.Clear();  
            mtbCEP.Clear();
            cbSexo.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            txtNome.BackColor = Color.White;    
            mtbCPF.BackColor = Color.White;
            cbSexo.BackColor = Color.White;
        }


        //Metodo para editar

        public void Alterar(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtNome.Text.Trim() == string.Empty || txtNome.Text.Trim().Length < 3)
                {
                    MessageBox.Show("O campo NOME não pode estar vazio! ", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.LightYellow;
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.White;

                }
                else if (!mtbCPF.MaskCompleted)
                {
                    MessageBox.Show("O campo CPF não pode estar vazio! ", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.LightYellow;
                }
                else if (cbSexo.Text == string.Empty)
                {
                    MessageBox.Show("O campo SEXO não pode estar vazio! ", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    cbSexo.BackColor = Color.LightYellow;
                    mtbCPF.BackColor = Color.White;
                }
                else
                {
                    pessoa.Id = Convert.ToInt32(txtCodigo.Text);
                    pessoa.Nome = txtNome.Text;
                    pessoa.Nascimento = dtNascimento.Text;
                    pessoa.Sexo = cbSexo.Text;
                    mtbCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //remove a mascara 
                    pessoa.Cpf = mtbCPF.Text;
                    mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Celular = mtbCelular.Text;
                    pessoa.Endereco = txtEndereco.Text;
                    pessoa.Bairro = txtBairro.Text;
                    pessoa.Cidade = txtCidade.Text;
                    pessoa.Estado = cbEstado.Text;
                    mtbCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Cep = mtbCEP.Text;


                    pessoaBLL.Alterar(pessoa);
                    MessageBox.Show("Cadastro alterado com sucesso! ", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();

                }

            }
            catch (Exception erro )
            {

                MessageBox.Show("Erro ao Alterar cadastro! " + erro, "Erro!\n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        //Metodo para salvar 
        private void Salvar(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtNome.Text.Trim() == string.Empty || txtNome.Text.Trim().Length<3)
                {
                    MessageBox.Show("O campo NOME não pode estar vazio! ", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.LightYellow;
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.White;
                  
                }
                else if (!mtbCPF.MaskCompleted)
                {
                    MessageBox.Show("O campo CPF não pode estar vazio! ", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.LightYellow;
                }
                else if (cbSexo.Text == string.Empty)
                {
                    MessageBox.Show("O campo SEXO não pode estar vazio! ", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    cbSexo.BackColor = Color.LightYellow;
                    mtbCPF.BackColor = Color.White;
                }
                else
                {
                    pessoa.Nome = txtNome.Text;
                    pessoa.Nascimento = dtNascimento.Text;
                    pessoa.Sexo = cbSexo.Text;
                    mtbCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //remove a mascara 
                    pessoa.Cpf = mtbCPF.Text;
                    mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; 
                    pessoa.Celular = mtbCelular.Text;
                    pessoa.Endereco = txtEndereco.Text;
                    pessoa.Bairro = txtBairro.Text;
                    pessoa.Cidade = txtCidade.Text;
                    pessoa.Estado = cbEstado.Text;
                    mtbCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; 
                    pessoa.Cep = mtbCEP.Text;   


                    pessoaBLL.Salvar(pessoa);
                    MessageBox.Show("Cadastro realizado com sucesso! ", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar(); 

                }

            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro ao realizar cadastro! "+erro, "Erro!\n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }

        }


        //Metodos para listar dados do grid
        private void Listar()
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                dataGridView.DataSource = pessoaBLL.Listar();

                //Renomear Colunas
                dataGridView.Columns[0].HeaderText="Código";
                dataGridView.Columns[1].HeaderText = "Nome";
                dataGridView.Columns[2].HeaderText = "Dt Nascimento";
                dataGridView.Columns[3].HeaderText = "Sexo";
                dataGridView.Columns[4].HeaderText = "CPF";
                dataGridView.Columns[5].HeaderText = "Tel.Celular";
                dataGridView.Columns[6].HeaderText = "Endereço";
                dataGridView.Columns[7].HeaderText = "Bairro";
                dataGridView.Columns[8].HeaderText = "Cidade";

                //Remover colunas do datagrid
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
                dataGridView.Columns[8].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].Visible = false;

                //Ajustar largura das colunas
                dataGridView.Columns[0].Width = 45;
                dataGridView.Columns[1].Width = 160;
                dataGridView.Columns[2].Width = 70;
                dataGridView.Columns[3].Width = 40;
                dataGridView.Columns[4].Width = 75;
                dataGridView.Columns[5].Width = 90;


            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro ao exibir os dados!\n" + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void btnExibir_Click(object sender, EventArgs e)
        {
            Listar(); 
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Salvar(pessoa);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar(); 
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
           
            txtCodigo.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            dtNascimento.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            cbSexo.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            mtbCPF.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            mtbCelular.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            txtEndereco.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            txtBairro.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();   
            txtCidade.Text = dataGridView.CurrentRow.Cells[8].Value.ToString();
            cbEstado.Text = dataGridView.CurrentRow.Cells[9].Value.ToString();
            mtbCEP.Text = dataGridView.CurrentRow.Cells[10].Value.ToString();


        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();

            Alterar(pessoa); 
        }
    }
}
