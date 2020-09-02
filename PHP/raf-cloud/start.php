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
        $_SESSION['masinaErr'] = 'masina je vec startovana';
        header("location: update.php?id=$id");
        die();
    }



    $stmt = $pdo -> prepare("update masine set status = 2 where id = :id ");
    $stmt ->execute([
        'id' => $id
    ]);
    $name = $masina['name'];
    $_SESSION['masinaMsg'] = "$name je startovana";
    sleep(2);
    header("location: dashboard.php");
}
