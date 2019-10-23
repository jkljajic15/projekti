<?php
if (isset($_POST))
{

    $id = $_GET['id'];
    //var_dump($id);
    $ime = $_POST['ime'];
    $prezime = $_POST['prezime'];
    $brojUpisa = $_POST['brojUpisa'];
    $godinaUpisa = $_POST['godinaUpisa'];
    require 'konekcija.php';
    $stmt = $pdo -> prepare("UPDATE dbo_studenti.studenti SET Ime = '$ime', Prezime = '$prezime', BrojUpisa = '$brojUpisa', GodinaUpisa = $godinaUpisa WHERE StudentId = $id");
    // var_dump($stmt);

    if($stmt -> execute())
    {
        header("Location: home.php");
    }
    else
    {
        var_dump($id);
        var_dump($stmt);
        echo 'sql naredba se nije izvrsila';
    }
}
