using System;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PortalTI.Orcamento.AP.QuadroConsolidado.srListData;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using MSScriptControl;
using System.Data;
using System.Web.UI;


namespace PortalTI.Orcamento.AP.QuadroConsolidado.Layouts.PortalTI.Orcamento.AP.QuadroConsolidado
{
    public partial class NewForm : LayoutsPageBase
    {
        Config itemConfig = new Config();
        string vURI = null;

        //List<lstConsolidadoBloco> lstConsolidadoBlocoResult = new List<lstConsolidadoBloco>();

        public void Page_Load(object sender, EventArgs e)
        {
            
        }

        #region ======== FUNÇÕES ============

        public string CalculaFormula(string vFormula, string vTipo)
        {
            lblMsg_KtloFormula.Visible = false;
            lblMsg_InovFormula.Visible = false;
            lblMsg_DespFormula.Visible = false;

            int pos = 0;
            string linha = string.Empty;
            string Item = string.Empty;
            string Valor = string.Empty;
            string ValorExpr = string.Empty;
            decimal ValorFinal = 0;
            string vResult = string.Empty;

            if(vTipo == "ktlo")
            {
                try
                {
                    ValorExpr = vFormula.ToUpper();

                    for (int i = 0; i < lbKtloForn2.Items.Count; i++)
                    {
                        pos = i + 1;
                        linha = "[KTLOLIN" + pos.ToString() + "]";

                        Item = lbKtloForn2.Items[i].Text;
                        Valor = (Item.Substring(Item.IndexOf("R$") + 3)).Replace(".", "").Replace(",", ".");

                        ValorExpr = ValorExpr.Replace(linha, Valor);
                    }

                    DataTable dt = new DataTable();
                    ValorFinal = (decimal)dt.Compute(ValorExpr, "");

                    vResult = string.Format("{0:0,0.00}", ValorFinal);
                }
                catch
                {
                    lblMsg_KtloFormula.Text = "Preencha a fórmula corretamente";
                    lblMsg_KtloFormula.Visible = true;
                }
            }

            else if (vTipo == "inov")
            {
                try
                {
                    ValorExpr = vFormula.ToUpper();

                    for (int i = 0; i < lbInovForn2.Items.Count; i++)
                    {
                        pos = i + 1;
                        linha = "[INOVLIN" + pos.ToString() + "]";

                        Item = lbInovForn2.Items[i].Text;
                        Valor = (Item.Substring(Item.IndexOf("R$") + 3)).Replace(".", "").Replace(",", ".");

                        ValorExpr = ValorExpr.Replace(linha, Valor);
                    }

                    DataTable dt = new DataTable();
                    ValorFinal = (decimal)dt.Compute(ValorExpr, "");

                    vResult = string.Format("{0:0,0.00}", ValorFinal);
                }
                catch
                {
                    lblMsg_InovFormula.Text = "Preencha a fórmula corretamente";
                    lblMsg_InovFormula.Visible = true;
                }
            }

            else if (vTipo == "desp")
            {
                try
                {
                    ValorExpr = vFormula.ToUpper();

                    for (int i = 0; i < lbDespForn2.Items.Count; i++)
                    {
                        pos = i + 1;
                        linha = "[DESPLIN" + pos.ToString() + "]";

                        Item = lbDespForn2.Items[i].Text;
                        Valor = (Item.Substring(Item.IndexOf("R$") + 3)).Replace(".", "").Replace(",", ".");

                        ValorExpr = ValorExpr.Replace(linha, Valor);
                    }

                    DataTable dt = new DataTable();
                    ValorFinal = (decimal)dt.Compute(ValorExpr, "");

                    vResult = string.Format("{0:0,0.00}", ValorFinal);
                }
                catch
                {
                    lblMsg_DespFormula.Text = "Preencha a fórmula corretamente";
                    lblMsg_DespFormula.Visible = true;
                }
            }

            return vResult;
        }

        public bool VerificaDadosForm()
        {
            lblMsg_KtloFormula.Visible = false;
            lblMsg_InovFormula.Visible = false;
            lblMsg_DespFormula.Visible = false;
            lblErro.Visible = false;

            bool vResultKtlo = false;
            bool vResultInov = false;
            bool vResultDesp = false;
            bool vResult = false;

            if (lbKtloForn2.Items.Count == 0 && lbInovForn2.Items.Count == 0 && lbDespForn2.Items.Count == 0)
            {
                lblErro.Text = "Obrigatório o preenchimento dos dados de algum consolidado";
                lblErro.Visible = true;
                vResult = false;
            }
            else
            {
                //Verifica dados Capex Ktlo
                if (lbKtloForn2.Items.Count == 0) //considerar que usuário não tem info pra esse consolidado
                {
                    vResultKtlo = true;
                }
                else
                {
                    if (txbKtloFormula.Text == "")
                    {
                        lblMsg_KtloFormula.Text = "Preencha a fórmula";
                        lblMsg_KtloFormula.Visible = true;
                        vResultKtlo = false;
                    }
                    else
                    {
                        vResultKtlo = true;
                    }
                }

                //Verifica dados Capex Inov
                if (lbInovForn2.Items.Count == 0) //considerar que usuário não tem info pra esse consolidado
                {
                    vResultInov = true;
                }
                else
                {
                    if (txbInovFormula.Text == "")
                    {
                        lblMsg_InovFormula.Text = "Preencha a fórmula";
                        lblMsg_InovFormula.Visible = true;
                        vResultInov = false;
                    }
                    else
                    {
                        vResultInov = true;
                    }
                }

                //Verifica dados Despesa
                if (lbDespForn2.Items.Count == 0) //considerar que usuário não tem info pra esse consolidado
                {
                    vResultDesp = true;
                }
                else
                {
                    if (txbDespFormula.Text == "")
                    {
                        lblMsg_DespFormula.Text = "Preencha a fórmula";
                        lblMsg_DespFormula.Visible = true;
                        vResultDesp = false;
                    }
                    else
                    {
                        vResultDesp = true;
                    }
                }
            }

            if (vResultKtlo == true && vResultInov == true && vResultDesp == true)
                vResult = true;
            else
                vResult = false;

            return vResult;
        }

        public void GravaListaSharepoint()
        {
            vURI = itemConfig.site + itemConfig.uri;

            PortalDeOrçamentoDataContext dc = new PortalDeOrçamentoDataContext(new Uri(vURI));
            dc.Credentials = new NetworkCredential(itemConfig.user, itemConfig.password, itemConfig.domain);

            //Monta Fornecedores Capex Ktlo
            string vFornKtlo = string.Empty;

            for (int i = 0; i < lbKtloForn2.Items.Count; i++)
            {
                vFornKtlo += ";" + lbKtloForn2.Items[i].Value;
            }
            if (vFornKtlo != "")
            {
                vFornKtlo = vFornKtlo.Substring(1);
            }

            //Monta Fornecedores Capex Inov
            string vFornInov = string.Empty;

            for (int i = 0; i < lbInovForn2.Items.Count; i++)
            {
                vFornInov += ";" + lbInovForn2.Items[i].Value;
            }
            if (vFornInov != "")
            {
                vFornInov = vFornInov.Substring(1);
            }

            //Monta Fornecedores Despesa
            string vFornDesp = string.Empty;

            for (int i = 0; i < lbDespForn2.Items.Count; i++)
            {
                vFornDesp += ";" + lbDespForn2.Items[i].Value;
            }
            if (vFornDesp != "")
            {
                vFornDesp = vFornDesp.Substring(1);
            }

            Consolidado_BlocoItem novoitem = new Consolidado_BlocoItem();

            novoitem.Ano = txbAno.Text;
            novoitem.Bloco = txbBloco.Text;
            novoitem.TipoBloco = txbTipoBloco.Text;
            novoitem.CapexKtlo_Forn = vFornKtlo;
            novoitem.CapexKtlo_Orcado = "";
            novoitem.CapexKtlo_Formula = txbKtloFormula.Text;
            novoitem.CapexKtlo_Valor = txbKtloValor.Text;
            novoitem.CapexInov_Forn = vFornInov;
            novoitem.CapexInov_Orcado = "";
            novoitem.CapexInov_Formula = txbInovFormula.Text;
            novoitem.CapexInov_Valor = txbInovValor.Text;
            novoitem.Despesa_Forn = vFornDesp;
            novoitem.Despesa_Orcado = "";
            novoitem.Despesa_Formula = txbDespFormula.Text;
            novoitem.Despesa_Valor = txbDespValor.Text;

            dc.AddToConsolidado_Bloco(novoitem);
            dc.SaveChanges();
        }

        #endregion


        #region ======== EVENTOS ============

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            lblErro.Visible = false;

            if (txbAnop.Text == "" && txbBlocop.Text == "" && txbTipoBlocop.Text == "")
            {
                lblErro.Text = "Preencha algum campo da pesquisa";
                lblErro.Visible = true;
            }
            else
            {
                vURI = itemConfig.site + itemConfig.uri;

                PortalDeOrçamentoDataContext dc = new PortalDeOrçamentoDataContext(new Uri(vURI));
                dc.Credentials = new NetworkCredential(itemConfig.user, itemConfig.password, itemConfig.domain);

                List<mdOrcamento> ListaResultOrcamento = new List<mdOrcamento>();
                mdOrcamento itemOrcamento = null;

                //Busca dados da pesquisa de itens do orçamento
                var query = (from lstOrcamento in dc.Orçamento
                             where lstOrcamento.Ano.Equals(txbAnop.Text) &&
                                 //lstOrcamento.Bloco.Título.Equals(txbBlocop.Text) &&
                                 lstOrcamento.TipoDeBloco.Título.Equals(txbTipoBlocop.Text)
                             select new
                             {
                                 ID = lstOrcamento.ID,
                                 Fornecedor = lstOrcamento.Fornecedor.Nome.ToString(),
                                 Bloco = lstOrcamento.Bloco.Título.ToString(),
                                 TipoBloco = lstOrcamento.TipoDeBloco.Título.ToString(),
                                 Valor = lstOrcamento.OrçadoTotal
                             });

                try
                {
                    double vItemValor;
                    //string vItemBloco;

                    foreach (var itemQuery in query)
                    {
                        if (itemQuery.Valor == null)
                            vItemValor = 0;
                        else
                            vItemValor = itemQuery.Valor.Value;

                        //if (itemQuery.Bloco == null)
                        //    vItemBloco = string.Empty;
                        //else
                        //    vItemBloco = itemQuery.Bloco.ToString();

                        itemOrcamento = new mdOrcamento();

                        itemOrcamento.ID = itemQuery.ID.ToString();
                        itemOrcamento.Texto = itemQuery.Fornecedor.ToString() + " - " +
                                                itemQuery.Bloco.ToString() + " - " +
                                                itemQuery.TipoBloco.ToString() + " - " +
                                                "R$ " + string.Format("{0:0,0.00}", vItemValor);

                        //itemOrcamento.Texto = vItemBloco;

                        ListaResultOrcamento.Add(itemOrcamento);
                    }

                    lbKtloForn1.DataTextField = "Texto";
                    lbKtloForn1.DataValueField = "ID";
                    lbKtloForn1.DataSource = ListaResultOrcamento;
                    lbKtloForn1.DataBind();

                    lbInovForn1.DataTextField = "Texto";
                    lbInovForn1.DataValueField = "ID";
                    lbInovForn1.DataSource = ListaResultOrcamento;
                    lbInovForn1.DataBind();

                    lbDespForn1.DataTextField = "Texto";
                    lbDespForn1.DataValueField = "ID";
                    lbDespForn1.DataSource = ListaResultOrcamento;
                    lbDespForn1.DataBind();

                    Dispose();

                }
                catch(Exception ex)
                {
                    lbKtloForn1.ClearSelection();
                    lbInovForn1.ClearSelection();
                    lbDespForn1.ClearSelection();
                }
            }
        }

        protected void btnKtloFornAdd_Click(object sender, EventArgs e)
        {
            while (lbKtloForn1.Items.Count > 0)
            {
                if (lbKtloForn1.SelectedIndex > -1)
                {
                    lbKtloForn2.Items.Add(lbKtloForn1.Items[lbKtloForn1.SelectedIndex]);
                    lbKtloForn1.Items.Remove(lbKtloForn1.Items[lbKtloForn1.SelectedIndex]);
                }
                else { break; }
            }
        }

        protected void btnKtloFornRem_Click(object sender, EventArgs e)
        {
            while (lbKtloForn2.Items.Count > 0)
            {
                if (lbKtloForn2.SelectedIndex > -1)
                {
                    lbKtloForn1.Items.Add(lbKtloForn2.Items[lbKtloForn2.SelectedIndex]);
                    lbKtloForn2.Items.Remove(lbKtloForn2.Items[lbKtloForn2.SelectedIndex]);
                }
                else { break; }
            }
        }

        protected void btnInovFornAdd_Click(object sender, EventArgs e)
        {
            while (lbInovForn1.Items.Count > 0)
            {
                if (lbInovForn1.SelectedIndex > -1)
                {
                    lbInovForn2.Items.Add(lbInovForn1.Items[lbInovForn1.SelectedIndex]);
                    lbInovForn1.Items.Remove(lbInovForn1.Items[lbInovForn1.SelectedIndex]);
                }
                else { break; }
            }
        }

        protected void btnInovFornRem_Click(object sender, EventArgs e)
        {
            while (lbInovForn2.Items.Count > 0)
            {
                if (lbInovForn2.SelectedIndex > -1)
                {
                    lbInovForn1.Items.Add(lbInovForn2.Items[lbInovForn2.SelectedIndex]);
                    lbInovForn2.Items.Remove(lbInovForn2.Items[lbInovForn2.SelectedIndex]);
                }
                else { break; }
            }
        }

        protected void btnDespFornAdd_Click(object sender, EventArgs e)
        {
            while (lbDespForn1.Items.Count > 0)
            {
                if (lbDespForn1.SelectedIndex > -1)
                {
                    lbDespForn2.Items.Add(lbDespForn1.Items[lbDespForn1.SelectedIndex]);
                    lbDespForn1.Items.Remove(lbDespForn1.Items[lbDespForn1.SelectedIndex]);
                }
                else { break; }
            }
        }

        protected void btnDespFornRem_Click(object sender, EventArgs e)
        {
            while (lbDespForn2.Items.Count > 0)
            {
                if (lbDespForn2.SelectedIndex > -1)
                {
                    lbDespForn1.Items.Add(lbDespForn2.Items[lbDespForn2.SelectedIndex]);
                    lbDespForn2.Items.Remove(lbDespForn2.Items[lbDespForn2.SelectedIndex]);
                }
                else { break; }
            }
        }

        protected void btnCalcularKtlo_Click(object sender, EventArgs e)
        {
            txbKtloValor.Text = CalculaFormula(txbKtloFormula.Text, "ktlo");
        }

        protected void btnCalcularInov_Click(object sender, EventArgs e)
        {
            txbInovValor.Text = CalculaFormula(txbInovFormula.Text, "inov");
        }

        protected void btnCalcularDesp_Click(object sender, EventArgs e)
        {
            txbDespValor.Text = CalculaFormula(txbDespFormula.Text, "desp");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //Verifica se dados já existem na lista de Consolidado Bloco
            vURI = itemConfig.site + itemConfig.uri;

            PortalDeOrçamentoDataContext dc = new PortalDeOrçamentoDataContext(new Uri(vURI));
            dc.Credentials = new NetworkCredential(itemConfig.user, itemConfig.password, itemConfig.domain);

            var query = (from lstConsolidado in dc.Consolidado_Bloco
                         where lstConsolidado.Ano.Equals(txbAno.Text) &&
                                lstConsolidado.Bloco.Equals(txbBloco.Text) &&
                                lstConsolidado.TipoBloco.Equals(txbTipoBloco.Text)
                            select new
                            {
                                ID = lstConsolidado.ID
                            });

            if(query.Count() > 0) //item já existe
            {
                lblErro.Text = "Um consolidado com essas informações já existe";
                lblErro.Visible = true;
            }
            else
            {
                if (VerificaDadosForm())
                {
                    //gravar
                    try
                    {
                        GravaListaSharepoint();

                        Response.Redirect("NewForm.aspx",false);
                    }
                    catch(Exception ex)
                    {
                        Response.Redirect("/orcamento/SitePages/ErroForm.aspx",false);
                    }
                }
            }





        }


        #endregion






    }
}
