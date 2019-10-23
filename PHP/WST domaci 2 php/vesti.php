<html>
    <head>
        <title>Sportski klub - Vesti</title>
    </head>
    <body>
        <h1 align="center">Vesti</h1>
        <?php 
            $con = new mysqli("localhost","root","","klub") or die("Connection failed: " . $con->connect_error);
        
            $query = mysqli_query($con,"SELECT * FROM vesti "); //ORDER BY id DESC LIMIT 3
            while($query == true && $result = mysqli_fetch_assoc($query)){
                $vest = $result['vesti'];
                echo '<p>'.$vest.'</p>';
            }
        ?>
        <form action="" method="post">
            <textarea rows="5" cols="50" name="textarea"></textarea>
            <input type="submit" name="submit" value="Postuj">
        </form>
        <?php
            if(isset($_POST['textarea']) && !empty($_POST['textarea'])){
                $tekst = $_POST['textarea'];
                mysqli_query($con,"INSERT INTO vesti VALUES('','$tekst')");
                header('location:vesti.php');
            }
        ?>
        <a href="index.php">Unos</a>
        <a href="pregled.php">Pregled</a>
    </body>
</html>