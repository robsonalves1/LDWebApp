<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="HomeLiturgiaDiaria.aspx.cs" Inherits="LDWebApp.View.HomeLiturgiaDiaria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <title>Liturgia Diária</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="NavLiturgy" class="border border-1 shadow-sm fixed-top" runat="server">
            <nav class="navbar navbar-expand-lg fs-4">
                <div class="container">
                    <a class="navbar-brand fs-4" id="LinkHomeLiturgy" runat="server" href="HomeLiturgiaDiaria.aspx">Liturgia Diária</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav" id="UlNavbar" runat="server">
                            <li class="nav-item">
                                <button type="button" class="nav-link" id="BtnFirstLecture" onserverclick="SelectLecture_Click" runat="server">1º Leitura</button>
                            </li>
                            <li class="nav-item">
                                <button type="button" class="nav-link" id="BtnSecondLecture" onserverclick="SelectLecture_Click" runat="server">2º Leitura</button>
                            </li>
                            <li class="nav-item">
                                <button type="button" class="nav-link" id="BtnPsalm" onserverclick="SelectLecture_Click" runat="server">Salmo</button>
                            </li>
                            <li class="nav-item">
                                <button type="button" class="nav-link" id="BtnGospel" onserverclick="SelectLecture_Click" runat="server">Evangelho</button>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>

        <div class="container mt-5 pt-4" id="DivLeituras" runat="server">
            <div id="DivTitle" runat="server"></div>
            <div id="DivFirstLecture" runat="server"></div>
            <div id="DivSecondLecture" runat="server"></div>
            <div id="DivPsalm" runat="server"></div>
            <div id="DivGospel" runat="server"></div>
        </div>

        <footer class="my-5 pt-5 text-body-secondary text-center text-small">
            <p class="mb-1">©2023 Liturgia Diária RP</p>
        </footer>
    </form>

    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.7.0.min.js"></script>
</body>
</html>
