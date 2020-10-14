$(document).ready(function () {
    /* Sign up button */

    $("#btn-signup").click(function () {
        $('#signUpModal').modal('show');
    });

    $("#ProductName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Search/GetProducts/",
                type: "POST",
                dataType: "json",
                data: { ProductName: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.ProductName, value: item.ProductName };
                    }))
                }
            })
        },
        messages: {
            noResults: '',
            results: function (resultsCount) { }
        }
    });  

   
   

    
    $("#btn-sign-up").click(function () {

        

       // var file = $("input[type=file]").get(0).files[0];
        //var filename = file.name;

        var username = $("#username").val();
        var email = $("#email").val();
        var password = $("#password").val();
        var confirmpassword = $("#confirmpassword").val();

        if (password != confirmpassword) {
            alert("Passwords do not match.");
            return false;
        }

        var formData = new FormData();
        formData.append("username", username);
        formData.append("email", email);
        formData.append("password", password);

        $.ajax({
            url: "/Login/Save",
            type: 'POST',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                alert(response);
            }
        });


        return true;


    });

    $("#btn-search-product").click(function () {


        var searchitem = $(".txt-prod-search").val();

        if (searchitem.length === 0) {
            alert("Please enter an item");
            window.location.href = "/Search/SearchPage/"
        } else {
            window.location.href = "/Search/Search/?searchitem=" + searchitem;
        }

       
    });

    $("#loadjson").click(function () {

      
       var productName = $("#ProductName").val();
      
        $.ajax({
            url: "/Search/GetProductsJson/",
            type: "POST",
            dataType: "json",
            data: { productName },
            success: function (data) {
                document.getElementById("products-list-canvas").innerHTML = "";
                data.forEach(function (item) {
                    console.log(item);
                    var product_card = "<div class='card' style='width: 15rem; cursor:pointer; float:left; margin-right:10px; margin-bottom:15px;'> <img  iindex='" + item.ProductID + "' class='card-img-top img-thumbnail prod-items' src='/Images/Products/" + item.Picture + "' alt='Card image cap'> <div class='card-body'> <h6 class='card-title text-center'>" + item.ProductName + "</h6> <h6 class='card-title text-center'>" + item.Series + "</h6> <h6 class='card-title text-center'>" + item.ModelName + "</h6> <p class='card-text text-center'>" + item.Airflow + " CFM</p> <p class='card-text text-center'>" + item.Fan_Speed_Max + " at Max Speed</p> <p class='card-text text-center'>" + item.Sound_Max_Speed + " dbA at max speed</p> <p class='card-text text-center'>" + item.Fan_Sweep_Diameter + " sweep diameter</p> <div class='form-check'> <input class='form-check-input chkitem' type='checkbox' value='" + item.ProductID + "'> <label class='form-check-label' for='defaultCheck1'> <span style='font-weight:bold'>Compare</span> </label> <a href='#' class='btn btn-primary pull-right btn-sm'>Add to</a> </div>";
                    $("#products-list-canvas").append(product_card);;
                });



            }
        })
    });

    $(document).on("click", "#testbtn", function () {

        var searchIDs = $('input:checked').map(function () {
            return $(this).val();
        });
        var arr = searchIDs.get();


        var param = "?";
        for (var i = 0; i < arr.length; i++) {
            param = param + "arr=" + arr[i] + "&";
        }
        param = param.substring(0, param.length - 1);


        window.location.href = "/Products/Compare/" + param;
    });

  
    $("#loadjsonw").click(function () {

        $.ajax({
            url: "/Products/GetProductProductDetailJson/",
            type: "POST",
            dataType: "json",
            data: { pid:1},
            success: function (data) {
       
                
                console.log(data);

                $("#lbl-series").text(data[0].Series);
                $("#lbl-model").text(data[0].Fan_Speed_Max);
                $("#lbl-usertype").text(data[0].Fan_Speed_Max);
                $("#lbl-application").text(data[0].Application);
                $("#lbl-mounting-location").text(data[0].Mounting_Location);
                $("#lbl-accessories").text(data[0].Accessories);
                $("#lbl-model-year").text(data[0].Model_Year);
                $("#lbl-airflow").text(data[0].Airflow);
                $("#lbl-fan-speed-max").text(data[0].Fan_Speed_Max);
                $("#lbl-fan-speed-min").text(data[0].Fan_Speed_Min);
                $("#lbl-fan-swap-diameter").text(data[0].Fan_Sweep_Diameter);
                $("#lbl-sound-max-speed").text(data[0].Sound_Max_Speed);
                $("#lbl-num-fan-speed").text(data[0].Airflow);
                $("#lbl-fan-swap-diamete").text(data[0].Fan_Sweep_Diameter);
                $("#lbl-weight").text(data[0].Weight);
                $("#lbl-height").text(data[0].Height);
                $("#lbl-oper-vol-min").text(data[0].Operating_Voltage_Min);
                $("#lbl-oper-vol-max").text(data[0].Operating_Voltage_Max);
                $("#lbl-power-max").text(data[0].Power_Max);
                $("#lbl-power-min").text(data[0].Power_Min);
               
              

            }
        })
    });
    

});