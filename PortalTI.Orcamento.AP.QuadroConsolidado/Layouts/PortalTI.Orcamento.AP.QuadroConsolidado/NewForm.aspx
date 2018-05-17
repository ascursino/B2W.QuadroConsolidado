<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewForm.aspx.cs" Inherits="PortalTI.Orcamento.AP.QuadroConsolidado.Layouts.PortalTI.Orcamento.AP.QuadroConsolidado.NewForm" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/_layouts/15/1046/styles/Themable/corev15.css?rev=O7tiGGfiAl4rUEO%2BNm34WA%3D%3D"/>
    <style type="text/css">
    .ms-bodyareaframe {
	    padding: 8px;
	    border: none;
    }

    .ms-formlabel {
    white-space: nowrap;
    font-weight: bold;
    padding: 6px 5px 6px 0px;
    border-top: 1px solid #d8d8d8;
    color: #525252;
    }

    .ms-formbody {
    vertical-align: top;
    background: #f6f6f6;
    border-top: 1px solid #d8d8d8;
    padding: 6px 0px;
    }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div> <asp:Label runat="server" ID="lblErro" ForeColor="#ff3300" Visible="false" /></div>
<table runat="server" class="ms-formtable" style="margin-top: 8px;" border="0" cellpadding="0" cellspacing="0" width="80%">
    <tr>
		<td valign="top" class="ms-formlabel" style="width:113px;">
            <h3 class="ms-standardheader">Ano<span class="ms-accentText" title="Este é um campo obrigatório."> *</span></h3>
		</td>
		<td valign="top" class="ms-formbody">
            <asp:TextBox ID="txbAno" runat="server" MaxLength="255" CssClass="ms-long ms-spellcheck-true"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvAno" ControlToValidate="txbAno" ForeColor="#ff3300" ErrorMessage="Preencha o ano" />
    	</td>
	</tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Bloco<span class="ms-accentText" title="Este é um campo obrigatório."> *</span></h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <asp:TextBox ID="txbBloco" runat="server" MaxLength="255" CssClass="ms-long ms-spellcheck-true"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvBloco" ControlToValidate="txbBloco" ForeColor="#ff3300" ErrorMessage="Preencha o bloco" />
    	</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Tipo de Bloco<span class="ms-accentText" title="Este é um campo obrigatório."> *</span></h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <asp:TextBox ID="txbTipoBloco" runat="server" MaxLength="255" CssClass="ms-long ms-spellcheck-true"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvTipoBloco" ControlToValidate="txbTipoBloco" ForeColor="#ff3300" ErrorMessage="Preencha o Tipo de bloco" />
    	</td>
    </tr>
	<tr>
		<td colspan="2" valign="top" class="ms-formlabel">
            <table width="100%">
                <tr>
                    <td><h3 class="ms-standardheader">Ano:</h3><asp:TextBox ID="txbAnop" runat="server" MaxLength="100" Width="100px" CssClass="ms-long ms-spellcheck-true"></asp:TextBox></td>
                    <td><h3 class="ms-standardheader">Bloco:</h3><asp:TextBox ID="txbBlocop" runat="server" MaxLength="100" CssClass="ms-long ms-spellcheck-true"></asp:TextBox></td>
                    <td><h3 class="ms-standardheader">Tipo de Bloco:</h3><asp:TextBox ID="txbTipoBlocop" runat="server" MaxLength="100" CssClass="ms-long ms-spellcheck-true"></asp:TextBox></td>
                    <td><asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" /></td>
                </tr>
            </table>
		</td>
    </tr>

    <!--------- BLOCO CAPEX KTLO ----------------->
	<tr>
		<td colspan="2" valign="top" class="ms-formbody">
            <h3 class="ms-standardheader"><strong>Capex Ktlo</strong></h3>
		</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Fornecedores</h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <table>
                <tr>
                    <td><asp:ListBox ID="lbKtloForn1" runat="server" Width="600px" Height="80px" SelectionMode="Multiple"></asp:ListBox>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnKtloFornAdd" runat="server" Text="Adicionar" Width="82px" OnClick="btnKtloFornAdd_Click" /></td>
                </tr>
                <tr>
                    <td><asp:ListBox ID="lbKtloForn2" runat="server" Width="600px" Height="80px"  SelectionMode="Multiple"></asp:ListBox>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnKtloFornRem" runat="server" Text="Remover" Width="82px" OnClick="btnKtloFornRem_Click" /></td>
                </tr>
            </table>
    	</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Fórmula</h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <asp:TextBox ID="txbKtloFormula" runat="server" MaxLength="255" CssClass="ms-long ms-spellcheck-true"></asp:TextBox>&nbsp;
            <asp:Button ID="btnCalcularKtlo" runat="server" Text="Calcular" OnClick="btnCalcularKtlo_Click" />&nbsp;&nbsp;&nbsp;
             <asp:Label runat="server" ID="Label1" Text="[KtloLin1]  [KtloLin2]... " />&nbsp;&nbsp;&nbsp;
             <asp:Label runat="server" ID="lblMsg_KtloFormula" ForeColor="#ff3300" Visible="false" />
    	</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Valor</h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <asp:TextBox ID="txbKtloValor" runat="server" MaxLength="255" CssClass="ms-long ms-spellcheck-true" ReadOnly="true"></asp:TextBox>
    	</td>
    </tr>

    <!--------- BLOCO CAPEX INOVAÇÃO ----------------->
	<tr>
		<td colspan="2" valign="top" class="ms-formbody">
            <h3 class="ms-standardheader"><strong>Capex Inovação</strong></h3>
		</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Fornecedores</h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <table>
                <tr>
                    <td><asp:ListBox ID="lbInovForn1" runat="server" Width="600px" Height="80px" SelectionMode="Multiple"></asp:ListBox>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnInovFornAdd" runat="server" Text="Adicionar" Width="82px" OnClick="btnInovFornAdd_Click" /></td>
                </tr>
                <tr>
                    <td><asp:ListBox ID="lbInovForn2" runat="server" Width="600px" Height="80px"  SelectionMode="Multiple"></asp:ListBox>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnInovFornRem" runat="server" Text="Remover" Width="82px" OnClick="btnInovFornRem_Click" /></td>
                </tr>
            </table>
    	</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Fórmula</h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <asp:TextBox ID="txbInovFormula" runat="server" MaxLength="255" CssClass="ms-long ms-spellcheck-true"></asp:TextBox>&nbsp;
            <asp:Button ID="btnCalcularInov" runat="server" Text="Calcular" OnClick="btnCalcularInov_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="Label2" Text="[InovLin1]  [InovLin2]... " />&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMsg_InovFormula" ForeColor="#ff3300" Visible="false" />
    	</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Valor</h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <asp:TextBox ID="txbInovValor" runat="server" MaxLength="255" CssClass="ms-long ms-spellcheck-true" ReadOnly="true"></asp:TextBox>
    	</td>
    </tr>

    <!--------- BLOCO DESPESA ----------------->
	<tr>
		<td colspan="2" valign="top" class="ms-formbody">
            <h3 class="ms-standardheader"><strong>Despesa</strong></h3>
		</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Fornecedores</h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <table>
                <tr>
                    <td><asp:ListBox ID="lbDespForn1" runat="server" Width="600px" Height="80px" SelectionMode="Multiple"></asp:ListBox>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDespFornAdd" runat="server" Text="Adicionar" Width="82px" OnClick="btnDespFornAdd_Click" /></td>
                </tr>
                <tr>
                    <td><asp:ListBox ID="lbDespForn2" runat="server" Width="600px" Height="80px"  SelectionMode="Multiple"></asp:ListBox>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDespFornRem" runat="server" Text="Remover" Width="82px" OnClick="btnDespFornRem_Click" /></td>
                </tr>
            </table>
    	</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Fórmula</h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <asp:TextBox ID="txbDespFormula" runat="server" MaxLength="255" CssClass="ms-long ms-spellcheck-true"></asp:TextBox>&nbsp;
            <asp:Button ID="btnCalcularDesp" runat="server" Text="Calcular" OnClick="btnCalcularDesp_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="Label3" Text="[DespLin1], [DespLin2]... " />&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMsg_DespFormula" ForeColor="#ff3300" Visible="false" />
    	</td>
    </tr>
	<tr>
		<td valign="top" class="ms-formlabel">
            <h3 class="ms-standardheader">Valor</h3>
		</td>
    	<td valign="top" class="ms-formbody">
            <asp:TextBox ID="txbDespValor" runat="server" MaxLength="255" CssClass="ms-long ms-spellcheck-true" ReadOnly="true"></asp:TextBox>
    	</td>
    </tr>
	<tr style="text-align:right;">
		<td colspan="2"><asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" /></td>
    </tr>
</table>







</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Novo Consolidado
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Novo Consolidado
</asp:Content>
