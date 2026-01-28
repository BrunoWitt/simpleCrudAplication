using simpleCrudAplication.Repositories;
using simpleCrudAplication.Models;

namespace simpleCrudAplication
{
    public partial class Form1 : Form
    {
        private CadastroRepository repository = new CadastroRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CarregarLista();
        }

        private void ConfigurarGrid()
        {
            dgvDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDados.AutoGenerateColumns = false;
            dgvDados.Columns.Clear();

            dgvDados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Numero",
                HeaderText = "Número",
                DataPropertyName = "Numero",
                ReadOnly = true
            });

            dgvDados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Texto",
                HeaderText = "Texto",
                DataPropertyName = "Texto",
                Width = 200
            });

            dgvDados.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Editar",
                Text = "✏",
                UseColumnTextForButtonValue = true,
                Width = 40
            });

            dgvDados.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Deletar",
                Text = "🗑",
                UseColumnTextForButtonValue = true,
                Width = 40
            });
        }

        private void CarregarLista()
        {
            dgvDados.DataSource = repository.Listar();
        }

        private void LimparCampos()
        {
            txtTexto.Clear();
            numNumero.Value = 0;
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTexto.Text))
            {
                MessageBox.Show("Informe o texto.");
                return;
            }

            if (numNumero.Value <= 0)
            {
                MessageBox.Show("Número deve ser maior que zero.");
                return;
            }

            var cadastro = new Cadastro
            {
                Texto = txtTexto.Text,
                Numero = (int)numNumero.Value
            };

            try
            {
                repository.Inserir(cadastro);
                CarregarLista();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var coluna = dgvDados.Columns[e.ColumnIndex].Name;
            var cadastro = (Cadastro)dgvDados.Rows[e.RowIndex].DataBoundItem;

            if (coluna == "Deletar")
            {
                DeletarCadastro(cadastro);
            }
            else if (coluna == "Editar")
            {
                EditarCadastro(cadastro);
            }
        }

        private void DeletarCadastro(Cadastro cadastro)
        {
            var confirmacao = MessageBox.Show(
                $"Deseja excluir o número {cadastro.Numero}?",
                "Confirmação",
                MessageBoxButtons.YesNo
            );

            if (confirmacao != DialogResult.Yes)
                return;

            repository.Deletar(cadastro);
            CarregarLista();
        }
        private void EditarCadastro(Cadastro cadastro)
        {
            txtTexto.Text = cadastro.Texto;
            numNumero.Value = cadastro.Numero;

            numNumero.Enabled = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            var cadastro = new Cadastro
            {
                Texto = txtTexto.Text,
                Numero = (int)numNumero.Value
            };

            repository.Update(cadastro);

            numNumero.Enabled = true;
            LimparCampos();
            CarregarLista();
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "📌 COMO USAR O SISTEMA\n\n" +
                "➕ ADICIONAR:\n" +
                "• Informe o Número\n" +
                "• Informe o Texto\n" +
                "• Clique em 'Adicionar'\n\n" +

                "✏ EDITAR:\n" +
                "• Altere o texto que queira editar\n" +
                "• Clique no botão ✏ \n" +
                "• Clique em 'Atualizar'\n\n" +

                "🗑 EXCLUIR:\n" +
                "• Clique no botão 🗑 da linha\n" +
                "• Confirme a exclusão\n\n" +

                "🔄 ATUALIZAR:\n" +
                "• Usado após editar um cadastro\n\n" +

                "⚠ O número não pode ser alterado após o cadastro.",
                "Ajuda",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
