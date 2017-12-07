<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Team4Talent.index" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Team 4 Talent case | Dries Van Hertbruggen</title>
    <link rel="icon" href="https://wemake.be/app/uploads/2017/02/03_Team4Talent_Brand-mark-960x842.jpg" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css" integrity="sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script src="js.js"></script>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <main>
            <h1 class="jumbotron">Team4Talent Lunchables</h1>
            <div id="store" class="container">
                <div class="container">
                    <h2 class="text-center">Sandwiches</h2>
                    <div class="row">
                        <div class="col-4 itemcontainer"><h3>Smos kaas</h3>
                            <img src="http://www.snackattack.be/media/catalog/product/cache/1/image/600x600/9df78eab33525d08d6e5fb8d27136e95/t/o/top20_smos_kaas.jpg" alt="Smos kaas" class="imgitem" />
                            <div class="itemprice"><span>prijs: €</span><span class="price">2.30</span></div>
                            <div class="itemselection">
                                <button type="button" class="itemdecrease">-</button>
                                <span class="itemamount">0</span>
                                <button type="button" class="itemincrease">+</button>
                            </div>
                            <button type="button" class="itembutton">Toevoegen aan winkelwagen</button>
                        </div>
                        <div class="col-4 itemcontainer"><h3>Smos hesp</h3>
                            <img src="http://www.snackattack.be/media/catalog/product/cache/1/image/600x600/9df78eab33525d08d6e5fb8d27136e95/t/o/top20_smos_hesp.jpg" alt="Smos hesp" class="imgitem" />
                            <div class="itemprice"><span>prijs: €</span><span class="price">2.30</span></div>
                            <div class="itemselection">
                                <button type="button" class="itemdecrease">-</button>
                                <span class="itemamount">0</span>
                                <button type="button" class="itemincrease">+</button>
                            </div>
                            <button type="button" class="itembutton">Toevoegen aan winkelwagen</button>
                        </div>
                        <div class="col-4 itemcontainer"><h3>Smos kaas hesp</h3>
                            <img src="http://www.snackattack.be/media/catalog/product/cache/1/image/600x600/9df78eab33525d08d6e5fb8d27136e95/t/o/top20_smos_kaas_hesp.jpg" alt="Smos kaas hesp" class="imgitem" />
                            <div class="itemprice"><span>prijs: €</span><span class="price">2.50</span></div>
                            <div class="itemselection">
                                <button type="button" class="itemdecrease">-</button>
                                <span class="itemamount">0</span>
                                <button type="button" class="itemincrease">+</button>
                            </div>
                            <button type="button" class="itembutton">Toevoegen aan winkelwagen</button>
                        </div>
                    </div>
                    
                </div>
            </div>
            <div id="confirmorder" style="display:none" class="container">
                <div>   
                    <h2 class="text-center">Jouw bestelling</h2>
                </div>
                <div id="cOrder" class="container"></div>
                <div>
                    <span>Naam</span>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </div>
                <div>
                    <span>E-mail</span>
                    <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                </div>
                <button type="button" runat="server" class="itembutton" onserverclick="order_click">Bestel</button>
                <input type="text" runat="server" id="hiddeninput" style="display:none;" />
            </div>
            <button type="button" id="switchorder"onclick="switchView()">Ga naar winkelwagen</button>
            
        </main>
        <footer class="footer">
            <div class="container">Case @Dries Van Hertbruggen - Photos ©Snackattack</div>
        </footer>
    </div>
    </form>
</body>
</html>
