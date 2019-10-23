<?php
    
    session_start();

    $con = new mysqli('localhost','root','','moja_baza');
    
    $nalog = $_POST['username'];
    $pw = $_POST['password'];
    
    
    $q = mysqli_query($con,"SELECT * FROM korisnici WHERE Username = '$nalog' AND Password = '$pw' AND Potvrdjen = '1'") or die('Greska: ' . $con -> error); 
    $r = mysqli_num_rows($q);
    
    //echo var_dump($result);
    
    
    if($r > 0){
        
        header('Location:profil.php');
        $_SESSION['username']=$nalog;
        
    }
    else{
        
        echo 'Vas Username/Password je neispravan ili nalog nije aktiviran! <a href=index.html>Nazad</a>';
        
    }


?>
