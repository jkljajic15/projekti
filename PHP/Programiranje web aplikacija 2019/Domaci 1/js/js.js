$(document).ready(function (e){
    //console.log("ready");
    $.ajax({
        url:"/jkljajic15/api.php",
        type:"POST",
        success: function(result){
            //console.log(result);
             let obj = JSON.parse(result)
            for(let i =0; i<obj.length; i++)
            {
                //console.log(obj[i].Ime);
                //$('#table').append('<tr>');
                $('#frmView').append('<tr><td>'+ obj[i].Ime +'</td><td>'+ obj[i].Prezime +'</td><td>'+ obj[i].BrojUpisa +'</td><td>'+ obj[i].GodinaUpisa +'</td>'+
                '<td><button type = button class = delete id = delete_'+obj[i].StudentId+'>Delete</button></td>'+
                '<td><a href = update.php?id='+obj[i].StudentId+'><button>Edit</button></a></td></tr>');
                
                // <form action = update.php method = post><input type = submit value = Edit class = edit id = frmEdit_'+obj[i].StudentId+'/> </form>
                //$('#table').append('</tr>');

                //<td><button type = button>Delete</button></td>
                
            }

        }
    });
});

// $(document).on('click', '.delete', function(e){
//     console.log("klik");
//     });

$(document).on('click','.delete',function(e){
    var el = this;
    var id = this.id;
    var splitid = id.split("_");
    var deleteid = splitid[1];

    // console.log(el);
    // console.log(id);
    // console.log(splitid);
    // console.log(splitid[1]);
    $.ajax({
        url: "/jkljajic15/delete.php",
        type: "POST",
        data:"id="+ deleteid,
        success: function(response)
        {
            $(el).closest('tr').fadeOut(800,function(){
                $(this).remove();
             });
        }
        
    });
});

// $(document).on('click','#submit',function(e){
//     e.preventDefault();
    
    
//     console.log("Klik");


// });

$(function(){

        $('#err_ime').hide();
        $('#err_prezime').hide();
        $('#err_broj').hide();
        $('#err_godina').hide();

        var err_ime= false;
        var err_prezime = false;
        var err_broj = false;
        var err_godina = false;

        $("#polje_ime").focusout(function(){
            proveriIme();
        });

        $("#polje_prezime").focusout(function(){
            proveriPrezime();
        });

        $("#polje_broj").focusout(function(){
            proveriBroj();
        });

        $("#polje_godina").focusout(function(){
            proveriGodinu();
        });

        function proveriIme()
        {
            var patern = /^[a-zA-Z]*$/;
            var polje_ime = $('#polje_ime').val();
            if(patern.test(polje_ime) && polje_ime !== '')
            {
                $('#err_ime').hide();   
            }
            else
            {
                $('#err_ime').html("<b style=color:red>Greska pri unosu!</b>");
                $('#err_ime').show();
                err_ime = true;
                //console.log(err_ime);
            }
        }

        function proveriPrezime()
        {
            var patern = /^[a-zA-Z]*$/;
            var polje_prezime = $('#polje_prezime').val();
            if(patern.test(polje_prezime) && polje_prezime !== '')
            {
                $('#err_prezime').hide();   
            }
            else
            {
                $('#err_prezime').html("<b style=color:red>Greska pri unosu!</b>");
                $('#err_prezime').show();
                err_prezime = true;
            }
        }

        function proveriBroj()
        {
            var patern = /^(s)([0-9]+)(\/)(2003|20[01]\d)$/ //  (s)([0-9]+)(\/)(2003|20[01]\d)
            var polje_broj = $('#polje_broj').val();
            if(patern.test(polje_broj) && polje_broj !== '')
            {
                $('#err_broj').hide();   
            }
            else
            {
                $('#err_broj').html("<b style = color:red;>Pogresan format!</b>");
                $('#err_broj').show();
                err_broj = true;
            }
        }

        function proveriGodinu()
        {
            var patern = /^2003|20[01]\d$/; 
            var polje_godina = $('#polje_godina').val();
            if(patern.test(polje_godina) && polje_godina !== '')
            {
                $('#err_godina').hide();   
            }
            else
            {
                $('#err_godina').html("<b style = color:red;>Godina mora biti u opsegu!</b>"); // <b style = solid orange;>Godina mora biti u opsegu!</b>
                $('#err_godina').show();
                err_godina = true;
            }
        }
        
        $('#update_frm').submit(function(){
            
             err_ime= false;
             err_prezime = false;
             err_broj = false;
             err_godina = false;

            proveriIme();
            proveriPrezime();
            proveriBroj();
            proveriGodinu();

            //console.log(err_ime,err_prezime,err_broj,err_godina);

            if(err_ime == false && err_prezime == false && err_broj == false && err_godina == false)
            {
                // e.preventDefault();
                alert("Uspesna izmena.");
                return true;
            }
            else
            {
                // e.preventDefault();
                alert("Uneti podaci nisu odgovarajuci!");
                return false;
            }
            

        });

});