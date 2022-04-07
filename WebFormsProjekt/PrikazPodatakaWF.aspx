<%@ Page Title="" Language="C#" MasterPageFile="~/MasterStranica.Master" AutoEventWireup="true" CodeBehind="PrikazPodatakaWF.aspx.cs" Inherits="WebFormsProjekt.PrikazPodatakaWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/prikazPodatakaWF.css" rel="stylesheet" />

    <script>
        window.addEventListener('DOMContentLoaded', () => {
            const inputs = document.querySelectorAll('input[type=text]');
            const td = document.querySelectorAll('td');

            td.forEach(cell => cell.classList.add('align-middle'));
            inputs.forEach(input => input.classList.add('form-control'));

            //document.querySelector('#RegularExpressionValidator1').style.display = 'none'; //osigurava da text validatora ne zauzima mjesto ispod textboxa koji se uređuje

        });


    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container rounded sjena">

        <div class="row">
            <div class="col-md-12">
                <h3 style="padding: 0.3em; margin: 0">Filtiraj podatke</h3>
            </div>
        </div>

        <div class="row mt-3">

            <div class="col-md-4 px-5">
                <div class="row d-flex justify-content-center text-center">
                    <span style="font-weight: bold; font-size: 0.9em">DRŽAVA</span>
                </div>
                <div class="row d-flex justify-content-center text-center">
                    <asp:DropDownList ID="ddlDrzava" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="DrzavaSQL" DataTextField="Naziv" DataValueField="IDDrzava">
                        <asp:ListItem Enabled="true" Text="Odaberite državu" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DrzavaSQL" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" SelectCommand="SELECT * FROM [Drzava]"></asp:SqlDataSource>
                </div>
            </div>

            <div class="col-md-4 px-5">
                <div class="row d-flex justify-content-center text-center">
                    <span style="font-weight: bold; font-size: 0.9em">GRAD</span>
                </div>
                <div class="row d-flex justify-content-center text-center">
                    <asp:DropDownList ID="ddlGrad" runat="server" CssClass="form-control" DataSourceID="GradSQL" DataTextField="Naziv" DataValueField="IDGrad" AutoPostBack="True">
                        <asp:ListItem Enabled="true" Text="Odaberite grad" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="GradSQL" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" SelectCommand="SELECT * FROM [Grad] WHERE ([DrzavaID] = @DrzavaID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlDrzava" Name="DrzavaID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>

            <div class="col-md-4 px-5">
                <div class="row d-flex justify-content-center text-center">
                    <span style="font-weight: bold; font-size: 0.9em">STAVKI PO STRANICI</span>
                </div>
                <div class="row d-flex justify-content-center text-center">
                    <asp:DropDownList ID="ddlBrojStavki" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem Enabled="true" Text="Odaberite vrijednost" Value="-1"></asp:ListItem>

                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>

                    </asp:DropDownList>
                </div>
            </div>

        </div>


         <div class="row">
            <div class="col-md-12 mt-5">
                 <div class="row">
            <div class="col-md-12 mt-5">


                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />



                <asp:GridView ID="tablicaKupci" runat="server" BackColor="White" BorderColor="#E26276" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="IDKupac" DataSourceID="KupacSQLTablica" CssClass="table table-striped table-responsive-md" ValidateRequestMode="Enabled" >
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:BoundField DataField="IDKupac" HeaderText="IDKupac" InsertVisible="False" ReadOnly="True"  SortExpression="IDKupac"  />


                        <asp:TemplateField HeaderText="Ime" SortExpression="Ime">

                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Ime") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ime je obavezno!" ControlToValidate="TextBox1" Text="" Display="None"></asp:RequiredFieldValidator>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Ime") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Prezime" SortExpression="Prezime">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Prezime") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Prezime je obavezno!" ControlToValidate="TextBox2" Text="" Display="None"></asp:RequiredFieldValidator>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Prezime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" SortExpression="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Neispravan forma Email-a" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email je obavezan!" ControlToValidate="TextBox3" Text="" Display="None"></asp:RequiredFieldValidator>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefon" SortExpression="Telefon">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Telefon") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Telefon je obavezan!" ControlToValidate="TextBox4" Text="" Display="None"></asp:RequiredFieldValidator>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Telefon") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="GradID" SortExpression="GradID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("GradID")  %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TextBox5" runat="server" ErrorMessage="GradID mora biti broj!" ValidationExpression="^[1-9]\d*$" Display="None"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="GradID je obavezan" ControlToValidate="TextBox5" Text="" Display="None"></asp:RequiredFieldValidator>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("GradID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
      
                    </Columns>

                  
                            
                    <HeaderStyle BackColor="#E26276" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#E26276" ForeColor="White" HorizontalAlign="Center" BorderColor="Transparent" BorderStyle="None" Font-Underline="true"  />
                    
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>



                <asp:SqlDataSource ID="KupacSQLTablica" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" DeleteCommand="DELETE FROM [Kupac] WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))" InsertCommand="INSERT INTO [Kupac] ([Ime], [Prezime], [Email], [Telefon], [GradID]) VALUES (@Ime, @Prezime, @Email, @Telefon, @GradID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Kupac] WHERE ([GradID] = @GradID)" UpdateCommand="UPDATE [Kupac] SET [Ime] = @Ime, [Prezime] = @Prezime, [Email] = @Email, [Telefon] = @Telefon, [GradID] = @GradID WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))">
                    <DeleteParameters>
                        <asp:Parameter Name="original_IDKupac" Type="Int32" />
                        <asp:Parameter Name="original_Ime" Type="String" />
                        <asp:Parameter Name="original_Prezime" Type="String" />
                        <asp:Parameter Name="original_Email" Type="String" />
                        <asp:Parameter Name="original_Telefon" Type="String" />
                        <asp:Parameter Name="original_GradID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Ime" Type="String" />
                        <asp:Parameter Name="Prezime" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Telefon" Type="String" />
                        <asp:Parameter Name="GradID" Type="Int32" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlGrad" Name="GradID" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Ime" Type="String" />
                        <asp:Parameter Name="Prezime" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Telefon" Type="String" />
                        <asp:Parameter Name="GradID" Type="Int32" />
                        <asp:Parameter Name="original_IDKupac" Type="Int32" />
                        <asp:Parameter Name="original_Ime" Type="String" />
                        <asp:Parameter Name="original_Prezime" Type="String" />
                        <asp:Parameter Name="original_Email" Type="String" />
                        <asp:Parameter Name="original_Telefon" Type="String" />
                        <asp:Parameter Name="original_GradID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>



                <asp:SqlDataSource ID="KupacSQL" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" DeleteCommand="DELETE FROM [Kupac] WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))" InsertCommand="INSERT INTO [Kupac] ([Ime], [Prezime], [Email], [Telefon], [GradID]) VALUES (@Ime, @Prezime, @Email, @Telefon, @GradID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Kupac] WHERE ([GradID] = @GradID)" UpdateCommand="UPDATE [Kupac] SET [Ime] = @Ime, [Prezime] = @Prezime, [Email] = @Email, [Telefon] = @Telefon, [GradID] = @GradID WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))">
                    <DeleteParameters>
                        <asp:Parameter Name="original_IDKupac" Type="Int32"/>
                        <asp:Parameter Name="original_Ime" Type="String" />
                        <asp:Parameter Name="original_Prezime" Type="String" />
                        <asp:Parameter Name="original_Email" Type="String" />
                        <asp:Parameter Name="original_Telefon" Type="String" />
                        <asp:Parameter Name="original_GradID" Type="Int32" />
                    </DeleteParameters>

                    <InsertParameters>
                        <asp:Parameter Name="Ime" Type="String"/>
                        <asp:Parameter Name="Prezime" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Telefon" Type="String" />
                        <asp:Parameter Name="GradID" Type="Int32" />
                    </InsertParameters>

                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlGrad" Name="GradID" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>

                    <UpdateParameters>
                        <asp:Parameter Name="Ime" Type="String" />
                        <asp:Parameter Name="Prezime" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Telefon" Type="String" />
                        <asp:Parameter Name="GradID" Type="Int32" />
                        <asp:Parameter Name="original_IDKupac" Type="Int32" />
                        <asp:Parameter Name="original_Ime" Type="String" />
                        <asp:Parameter Name="original_Prezime" Type="String" />
                        <asp:Parameter Name="original_Email" Type="String" />
                        <asp:Parameter Name="original_Telefon" Type="String" />
                        <asp:Parameter Name="original_GradID" Type="Int32" />
                    </UpdateParameters>



      </asp:SqlDataSource>

                <br />
                <br />

            </div>
        </div>
            </div>

        </div>


    </div>
</asp:Content>
