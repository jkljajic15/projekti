<?php
if (isset($_POST)) {
    require 'konekcija.php';
    $imeErr = $prezimeErr = $brojErr = $godinaErr='';
    $errors = false;
    $ime = test_input($_POST['ime']);
    $prezime = test_input($_POST['prezime']);
    $broj = test_input($_POST['broj']);
    $godina = (int)$_POST['godina'];
    if (empty($ime)) {
        $imeErr = "Ime ne moze da bude prazno";
        $errors=true;
    }
    if (empty($prezime)) {
        $prezime = "Prezime ne moze da bude prazno";
        $errors=true;
    }
    if ($broj<0) {
        $brojErr="Broj ne moze biti negativan";
        $errors=true;
    }
    if ($godina<2003) {
        $godinaErr="Godina ne moze biti ranija od 2003.";
        $errors = true;
    }
    if ($errors) {
        header("Location:home.php?imeErr=$imeErr&prezimeErr=$prezimeErr&brojErr=$brojErr&godinaErr=$godinaErr");
        exit();
    }

    $sql = "INSERT INTO studenti(Ime,Prezime,BrojUpisa,GodinaUpisa)
        VALUES(:ime,:prezime,:broj,:godina)";
    $stmt = $pdo -> prepare($sql);
    $stmt -> execute([
        'ime'=> $ime,
        'prezime' => $prezime,
        'broj'=> $broj,
        'godina'=>$godina
    ]);
    header("Location:home.php");

}
function test_input($data) {
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlspecialchars($data);
    return $data;
}