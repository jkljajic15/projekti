<?php
    $con = new mysqli("localhost","root","","klub") or die("Connection failed: " . $con->connect_error);
?>
<html>
    <head>
        <title>Sportski klub - Upis</title>
    </head>
    <body>
        <h1 align="center">Unos</h1>
        <h3>Informacije o igracu</h3>
        <form action="" method="post">
            <table>
                <tr>
                    <td>Ime:</td>
                    <td><input type='text' name="ime" required/></td>
                </tr>
                <tr>
                    <td>Prezime:</td>
                    <td><input type='text' name="prezime" required/></td>
                </tr>
                <tr>
                    <td>Pozicija:</td>
                    <td><input type='text' name="pozicija" required/></td>
                </tr>
                <tr>
                    <td>Broj:</td>
                    <td><input type='number' name="broj" min="0" max="99" required/></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right"><input type="submit" name="igrac" value="Unesi"/></td>
                </tr>
                <?php
                    if(isset($_POST['igrac'])){
                        $ime = $_POST['ime'];
                        $prezime = $_POST['prezime'];
                        $broj = $_POST['broj'];
                        $pozicija = $_POST['pozicija'];
                        $query = mysqli_query($con,"SELECT * FROM igraci WHERE broj = '$broj'");
                        
                        if(!$query || mysqli_num_rows($query) == 0){
                            mysqli_query($con,"INSERT INTO igraci VALUES('','$ime','$prezime','$pozicija','$broj')");
                            echo 'Informacije usepesno unete.';
                        }
                        else{
                            echo 'Informacije o igracu vec postoje.';
                        }
                    }
                ?>
            </table>
        </form>
        <h3>Informacije o takmicenju</h3>
        <form action="" method="post">
            <table>
                <tr>
                    <td>Ime takmicenja:</td>
                    <td><input type='text' name="ime_takmicenja"required/></td>
                </tr>
                <tr>
                    <td>Datum:</td>
                    <td><input type='date' name="datum" required/></td>
                </tr>
                <tr>
                    <td>Grad:</td>
                    <td><input type='text' name="grad" required/></td>
                </tr>
                <tr>
                    <td>Osvojeno mesto:</td>
                    <td><input type='text' name="mesto" required/></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right"><input type="submit" name="takmicenje" value="Unesi"/></td>
                </tr>
                <?php
                    if(isset($_POST['takmicenje'])){
                        $ime = $_POST['ime_takmicenja'];
                        $datum = $_POST['datum'];
                        $grad = $_POST['grad'];
                        $mesto = $_POST['mesto'];
                        $query = mysqli_query($con,"SELECT * FROM takmicenja WHERE ime_takmicenja = '$ime' AND datum = '$datum'");
                        
                        if(!$query || mysqli_num_rows($query) == 0){
                            mysqli_query($con,"INSERT INTO takmicenja VALUES('','$ime','$datum','$grad','$mesto')");
                            echo 'Informacije usepesno unete.';
                        }
                        else{
                            echo 'Informacije o takmicenju vec postoje.';
                        }
                    }
                ?>
            </table>
        </form> 
        <a href="pregled.php">Pregled</a>
        <a href="vesti.php">Vesti</a>
    </body>
</html>