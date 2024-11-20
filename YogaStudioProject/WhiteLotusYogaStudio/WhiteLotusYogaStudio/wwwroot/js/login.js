$(document).ready(function () {


    $('#btnlogIn').click(function (e) {
        e.preventDefault();

        var email = $('#txtlogId').val();
        var password = $('#txtPassword').val();

        $.ajax({
            url: apiBaseUrl+`GetLogindetails?Email=${email}&password=${password}`,
            type: 'POST',
        
            success: function (response) {
                if(response.length>0){
                debugger
                localStorage.setItem('userRole', response[0].role);

                    window.location.href = '/App/Index';}
else{
    alert("invalid credentials");
}
                
            },
            error: function (xhr, status, error) {
                // Handle error
                console.error(xhr.responseText);
            }
        });
    });
    // $('#registerForm').submit(function (e) {
        $('#btnSignUp').on('click', function(e) {

        
    e.preventDefault();
       var Name= $('#StudioName').val();
       var  Address= $('#Address').val();
       var  City= $('#City').val();
       var State= $('#State').val();
       var  Zipcode=$('#zipcode').val();
       var Email= $('#Email').val();
       var StudioOwner=$('#StudioOwner').val();
// Get the current date
var currentDate = new Date();

// Format the current date as 'YYYY-MM-DD'
var formattedDate = currentDate.toISOString().split('T')[0];

// Set the formatted date as the value of the StartDate input

    debugger
    $.ajax({

        url: apiBaseUrl +`Addstudio?Name=${Name}&Address=${Address}&City=${City}&State=${State}&Zipcode=${Zipcode}&Email=${Email}&StudioOwner=${StudioOwner}&Description=""&StartDate=${formattedDate}`,
        
        type: 'POST',
        success: function (response) {
            debugger
            alert('Studio registered successfully!');
            $('#registerForm')[0].reset();
            window.location.href = '/App/Index';

        },
        error: function (xhr, status, error) {
            alert('Failed to register studio. Please try again.');
            console.error('Error:', error,xhr,status);
        }
    });
});

});
