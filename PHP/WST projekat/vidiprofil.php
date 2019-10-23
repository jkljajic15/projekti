<?php 
    session_start();
    $con = new mysqli("localhost","root","","moja_baza");
    $nalog = $_SESSION['username'];
    
    
   /* $query = mysqli_query($con,"SELECT Username FROM korisnici");
    while($result = mysqli_fetch_assoc($query)){
        $username = $result['Username'];
    }*/
    if($nalog == $_GET['korisnik']){
        header('location:profil.php');
    }
    $username = $_GET['korisnik'];
    if($username == null){
        header('location:profil.php');
    }
    /*if(isset($_GET['korisnik'])){
        echo $_GET['korisnik'];
    } kopiraj u table */
    

?>
<html>
<head>
</head>
<body>
    <h4><?php echo $username; ?></h4>
    <?php
        $query = mysqli_query($con,"SELECT * FROM korisnici WHERE Username = '$username'");
        $row = mysqli_fetch_assoc($query);
        if($row['Profilna'] == ""){
            echo '<img width="150" height="150" src="slike/default.png">';
        }
        else{
            $ime = $row['Profilna'];
            echo '<img width="200" height="150" src="slike/'.$ime.'">';
        } 
    ?> 
    <form action="" method="post">
        <input type="submit" value="Posalji zahtev za prijateljstvo" name="zahtev" />
    </form>
    <?php
        if(isset($_POST['zahtev'])){
            $uslov = "SELECT * FROM zahtevi WHERE od = '$nalog' AND ka = '$username'" or die($con->error) ;
            $q = mysqli_query($con,$uslov) or die($con->error);
            $r = mysqli_num_rows($q);
            
            $q2 = mysqli_query($con,"SELECT * FROM prijatelji WHERE (user1='$nalog' AND user2='$username') OR (user1='$username' AND user2='$nalog')");
            if($r2 = mysqli_num_rows($q2) !== 0){
                echo 'Vec prijatelji.';
                return;    
            }                   
            if($r == 0 && $nalog != $username){
                mysqli_query($con,"INSERT INTO `zahtevi` (`od`,`ka`) VALUES('$nalog','$username')") or die(mysqli_error($con));
                echo 'Zahtev za prijateljstvo je poslat ';
            }
            else{
                echo 'Zahtev je vec poslat! ';
            
            }
            echo '<a href=profil.php>Nazad</a';
        }                
    ?>
</body>


</html>