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
    if ($masina['status'] == 'STOPPED'){
        $_SESSION['masinaErr'] = 'masina je vec stopirana';
        header("location: update.php?id=$id");
        die();
    }



    $stmt = $pdo -> prepare("update masine set status = 1 where id = :id ");
    $stmt ->execute([
        'id' => $id
    ]);
    $name = $masina['name'];
    $_SESSION['masinaMsg'] = "$name je stopirana";
    sleep(2);
    header("location: dashboard.php");
}
