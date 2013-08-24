using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace envioEMail
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Limpo o conteudo do objeto label
            this.lbl_status.Text = "";
            // Verifico se a pagina NÃO foi submetida
            if (!IsPostBack)
            {
                // Obtenho o caminho completo da localização do arquivo ContatoAssunto.xml
                string urlXmlService = Server.MapPath("XMLFiles/ContatoAssunto.xml");
                // Executo o metodo que le o arquivo XML e preenche em um ComboBox
                //FillDropdownList ddl = new FillDropdownList(this.DDListAssunto, urlXmlService, "Descricao", "IDAssunto", "assunto", "Selecione");
                //ddl.FillDropdown();

                // Obtenho o caminho completo da localização do arquivo Estados.xml
                string urlXmlEstado = Server.MapPath("XMLFiles/Estados.xml");
                // Executo o metodo que le o arquivo XML e preenche em um ComboBox
                //FillDropdownList ddlUF = new FillDropdownList(this.DDListEstados, urlXmlEstado, "IDEstado", "IDEstado", "Estado", "Selecione");
                //ddlUF.FillDropdown();
            }
            // Forco o foco no primeiro campo do formulario
            //this.DDListAssunto.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Rotina de Envio de E-mail, estou utilizando tratamento de erro Try..Catch
            // isto é minha rotina esta dentro da chave try, se por ventura acontecer algum 
            // erro a execução passa IMEDIATAMENTE para o codigo existente na chave Catch
            try
            {
                //// Criando variaveis de recebimento de dados;
                //DateTime _dtNow = DateTime.UtcNow;

                // Montando o corpo da E-mail
                string CorpoEmail = ""
                                    + "<br>Data   : " + DateTime.UtcNow.ToString()
                                    + "<br>Assunto: (Assunto)"
                                    + "<br>Nome   : " + "Nome"
                                    + "<br>E-Mail : " + "email"
                                    + "<br>Empresa: " + "Empresa"
                    //+ "<br>País   : " + this.txt_pais.Text.ToString()
                    //+ "<br>Cidade : " + this.txt_cidade.Text.ToString()
                    //+ "<br>Estado : " + this.DDListEstados.SelectedValue.ToString()
                                    + "<br>Fone 1 : " + "FOne"
                    //+ "<br>Fone 2 : " + this.txt_fone2.Text
                    //+ "<br>Depto  : " + this.txt_departamento.Text
                    //+ "<br>Setor  : " + this.txt_setor.Text.ToString()
                                    + "<br>Observ : " + "E-mail gerado automaticamente";

                Response.Write("Para ocultar este texto, comente estas linhas....<hr>");
                Response.Write(CorpoEmail.ToString());
                Response.Write("<br/><hr>");
                return;
                // Estancia da Classe de Mensagem
                MailMessage mailMessage = new MailMessage();

                // Remetente MEU E-MAIL, estando esta pagina em seu site quem esta enviando
                // o e-mail é vc MESMO o cliente esta apenas fornecendo dados para que VOCE
                // possa posteriormente entrar encontato com ele.

                mailMessage.From = new MailAddress("danielofars@gmail.com");

                // O Destinario tambem TAMBÉM é VOCE, para que assim o e-mail chegue a sua conta (outlook)
                mailMessage.To.Add("danielofars@gmail.com");

                // Se houver necessidade vc pode enviar uma copia do e-mail para alguem, como por exemplo
                // para o proprio cliente para que ele fique ciente de o e-mail de contato foi enviado e que
                // logo voce entrara em contato

                mailMessage.CC.Add("CopiarEmailPara@MinhaEmpresa.com.br");

                // Assunto
                mailMessage.Subject = "Contato MinhaEmpresa.com.br - >> ";

                // A mensagem é do tipo HTML(true) ou Texto Puro (false)?   
                mailMessage.IsBodyHtml = true;

                // Corpo da Mensagem, conteudo da variavel criada acima
                mailMessage.Body = CorpoEmail.ToString();
                // ***************************************************************************
                // *** 
                // ***                              A T E N C A O
                // *** 
                // ***************************************************************************
                // Se voce pode habilitar este trecho para enviar arquivos em anexo.
                // NAO SE ESQUECA DE INCLUIR O OBJETO FileUpload NO DESIGNER DA PAGINA
                // criando um loop pode ser enviado mais de um anexo.
                // Recupera o binario enviado pelo FileUpload   
                //    MemoryStream MS = new MemoryStream(fileAnexo.FileBytes);   
                // Anexa o Stream do arquivo   
                //    Attachment anexo = new Attachment(MS, fileAnexo.FileName);   
                //    mailMessage.Attachments.Add(anexo);   
                // ***************************************************************************

                // Estancia a Classe de Envio; as informações aqui inseridas voce obtem com o provedor
                // onde hospedou seu site

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                // Credencial para envio por SMTP Seguro (APENAS QUANDO O SERVIDOR EXIGE AUTENTICAÇÃO)   
                smtpClient.Credentials = new NetworkCredential("danielofars@gmail.com", "acktoskar321");

                // Envia a mensagem   
                smtpClient.Send(mailMessage);

                // Informa que o e-mail foi enviado com sucesso
                this.lbl_status.Text = "Dados enviado com sucesso. Em breve entraremos em contato.";

                /*
                // Limpa os campos do formulario
                this.DDListAssunto.SelectedIndex = 0;
                this.DDListEstados.SelectedIndex = 0;
                this.txt_nome.Text = "";
                this.txt_email.Text = "";
                this.txt_EmailConf.Text = "";
                this.txt_empresa.Text = "";
                this.txt_pais.Text = "";
                this.txt_cidade.Text = "";
                this.txt_fone1.Text = "";
                this.txt_fone2.Text = "";
                this.txt_departamento.Text = "";
                this.txt_setor.Text = "";
                this.txt_Obs.Text = "";
                 */ 
            }
            catch (Exception f)
            {
                // Se houver algum erro informa o usuário
                this.lbl_status.Text = "Não foi possível enviar dados. Tente mais tarde";
            }
            //
        }
    }
}
