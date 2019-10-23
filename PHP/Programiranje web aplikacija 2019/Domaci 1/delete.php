<?php

    
    
    if(isset($_POST['id']))
    {

        require 'konekcija.php';
        $id = $_POST['id'];
        //var_dump($id);
        $stmt = $pdo->prepare("DELETE FROM studenti WHERE StudentId=:id");
        //var_dump($stmt);
        $stmt -> execute(['id'=>$id]);
        //var_dump($stmt);


    }