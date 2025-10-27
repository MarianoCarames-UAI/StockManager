using StockManager.BLL.DTOs;
using StockManager.BLL.Services;
using StockManager.BLL.Session;
using StockManager.Services.Localization;

namespace StockManager.UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly LocalizationService _localization;

        public LoginForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            _localization = LocalizationService.Instance;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Cargar idiomas disponibles
            CargarIdiomas();
            
            // Aplicar traducciones iniciales
            AplicarTraducciones();
            
            // Suscribirse al evento de cambio de idioma
            _localization.OnLanguageChanged += (s, lang) => AplicarTraducciones();
        }

        private void CargarIdiomas()
        {
            var idiomas = _localization.GetAvailableLanguages();
            cmbLanguage.DataSource = idiomas;
            cmbLanguage.DisplayMember = "Name";
            cmbLanguage.ValueMember = "Code";
            
            // Seleccionar idioma actual
            cmbLanguage.SelectedValue = _localization.CurrentLanguage;
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedValue != null)
            {
                var language = cmbLanguage.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(language))
                {
                    _localization.SetLanguage(language);
                }
            }
        }

        private void AplicarTraducciones()
        {
            // Título del formulario
            this.Text = _localization.GetString("Login_Title");
            
            // Labels
            lblEmail.Text = _localization.GetString("Login_Email");
            lblPassword.Text = _localization.GetString("Login_Password");
            lblLanguage.Text = _localization.GetString("Login_SelectLanguage");
            
            // Botones
            btnLogin.Text = _localization.GetString("Login_Login");
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show(
                        _localization.GetString("Login_InvalidCredentials"),
                        _localization.GetString("Login_Error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                btnLogin.Enabled = false;

                var loginDto = new LoginDTO
                {
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text
                };

                var result = await _authService.LoginAsync(loginDto);

                if (result.IsSuccess && result.Data != null)
                {
                    SessionManager.Instance.Login(result.Data);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        result.Message,
                        _localization.GetString("Login_Error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{_localization.GetString("Login_Error")}: {ex.Message}",
                    _localization.GetString("Common_Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnLogin.Enabled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
