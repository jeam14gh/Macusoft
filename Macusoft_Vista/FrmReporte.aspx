<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="FrmReporte.aspx.cs" Inherits="FrmReporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel ID="" runat="server">
        <ContentTemplate>--%>
    <div class="container">
        <div class="well">
            <center><strong><h3>Reporte</h3></strong></center>
        </div>  

        <div class="well">
            <div class="form-group">
                <asp:Label ID="lblFactura" runat="server" Text="No Factuta: "></asp:Label>
                <asp:TextBox ID="txtFactura" runat="server"></asp:TextBox>
                <asp:Button ID="btnFactura" runat="server" Text="Generar Reporte" OnClick="btnFactura_Click"/>
            </div>
            <rsweb:ReportViewer ID="rvFacturaVenta" runat="server" Width="100%" ZoomMode="FullPage" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="ReportFactura.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
                
            </rsweb:ReportViewer>
            
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DS_FacturaVentaTableAdapters.SP_ReporteVentaJhonTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtFactura" Name="Dian" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>            
        </div>
              
        <%--<div class="well">
            <div class="form-group">
                <asp:Label ID="lblDian" runat="server" Text="No Factuta: "></asp:Label>
                <asp:TextBox ID="txtDian" runat="server"></asp:TextBox>
                <asp:Button ID="btnReporte" runat="server" Text="Generar Reporte" OnClick="btnReporte_Click" />
            </div>

            <rsweb:ReportViewer ID="ReportViewerVentas" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" ZoomMode="FullPage">
                <LocalReport ReportPath="ReportVenta.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSetReporteVenta" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DS_ReporteVentaTableAdapters.SP_ReporteVentaTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtDian" Name="Dian" PropertyName="Text" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>--%>


        
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

