<?php
    require 'konekcija.php';
    $stmt = $pdo->query("SELECT * FROM studenti ");
    $results = $stmt->fetchAll();
    echo json_encode($results);