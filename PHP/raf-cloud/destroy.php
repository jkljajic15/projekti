<?php
session_start();
if (isset($_GET['id'])){

    $id = $_GET['id'];

    require_once 'konekcija.php';

    $stmt = $pdo -> prepare("select * from masine where id = :id ");
    $stmt ->execute([
        'id' => $id
    ]);
    $masina = $stmt -> fetch();
    if ($masina['status'] == 'RUNNING'){
        $_SESSION['masinaErr'] = 'stopiraj masinu da bi je izbrisao';
        header("location: update.php?id=$id");
        die();
    }



    $stmt = $pdo -> prepare("delete from masine where id = :id ");
    $stmt ->execute([
        'id' => $id
    ]);
    $name = $masina['name'];
    $_SESSION['startMsg'] = "$name je izbrisana";
    header("location: dashboard.php");
}
