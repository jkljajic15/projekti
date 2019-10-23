<?php
    $host="localhost";
    $user="root";
    $pass="";
    $database="dbo_studenti";

    $pdo=new PDO("mysql:host=$host;dbname=$database", $user, $pass);
    $pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);
