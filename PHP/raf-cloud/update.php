<?php
session_start();
?>

<!doctype html>
<html lang="en">
<head>
    <title>RAF - Cloud</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
          integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
<?php
if (isset($_GET['id'])){

    require_once 'konekcija.php';
    $id = $_GET['id'];
    $sql = "select id, name from masine where id = :id";
    $stmt = $pdo->prepare($sql);
    $stmt->execute([
        'id'=> $id
    ]);
    $masina = $stmt->fetch();
}

?>
<div class="container text-center">

    <h1 class="display-4"><?= $masina['name']?></h1>

    <?php if (isset($_SESSION['masinaErr'])): ?>
        <div class="m-1" style="color: darkred"><?= $_SESSION['masinaErr'] ?></div>
        <?php unset($_SESSION['masinaErr']); ?>
    <?php endif; ?>
    <div class="row justify-content-center">
        <form action="start.php?id=<?= $id ?>" method="post" class="m-2">
            <input type="hidden" name="masinaid">
            <button type="submit" class="btn btn-primary">Start</button>
        </form>
        <form action="stop.php?id=<?= $id ?>" method="post" class="m-2">
            <input type="hidden" name="masinaid">
            <button type="submit" class="btn btn-primary">Stop</button>
        </form>
        <form action="destroy.php?id=<?= $id ?>" method="post" class="m-2">
            <input type="hidden" name="masinaid">
            <button type="submit" class="btn btn-primary">Destroy</button>
        </form>
    </div>
</div>
<!-- Optional JavaScript -->
<!-- jQuery first, then Popper.js, then Bootstrap JS -->
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"
        integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"
        crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
        integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"
        crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
        integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"
        crossorigin="anonymous"></script>
</body>
</html>
