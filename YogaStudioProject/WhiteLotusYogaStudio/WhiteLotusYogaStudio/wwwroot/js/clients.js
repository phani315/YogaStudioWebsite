var clientIdTemp;
var passwordTemp;
$(document).ready(function() {
 
    loadClientDetails()
   
    //   // Add an event listener to the "Save" button
    //   $('#editClientForm').submit(function(e) {
       
    //     updateClient(clientIdTemp, $('#editName').val(), $('#editEmail').val(), $('#editPhone').val(), $('input[name="editGender"]:checked').val(),passwordTemp);

    // });
    
    // Add an event listener to the "Save" button
    $('#addClientForm').submit(function(e) {
        // Get the form data
        var name = $('#Name').val();
        var email = $('#email').val();
        var phoneNumber = $('#PhoneNumber').val();
        var gender = $('input[name="Gender"]:checked').val();
        var password = phoneNumber; // Set the password here, you may want to handle this securely
    
        // Call the addClient function with the form data
        addClient(name, email, phoneNumber, gender, password);
    });
    
})
function addClient(name, email, phoneNumber, gender, password) {
    var url = apiBaseUrl+`AddClient?Name=${name}&Email=${email}&PhoneNumber=${phoneNumber}&Gender=${gender}&password=${password}`;
    
    $.ajax({
        url: url,
        type: 'POST',
        success: function(response) {
            // Handle success response
            console.log('Client added successfully:', response);
            $('#addApplicationModal').modal('hide');
            Swal.fire(
             'Added!',
             'Your client has been added.',
             'success'
         );
            loadClientDetails()
        },
        error: function(error) {
             // Handle success response
             Swal.fire(
                'Failed!',
                'Failed adding the client.',
                'Error'
            );
            console.error('Error adding client:', error);
            // Handle error, show error message, etc.
        }
    });
}

function loadClientDetails() {
    $.ajax({
        url: apiBaseUrl+'GetAllClients',
        crossDomain: true, // Add this line to enable cross-domain requests

        type: 'GET',
        dataType: 'json',
        success: function (clientsData) {
            
            if ($.fn.DataTable.isDataTable("#ClientDetailsTable")) {
                // DataTable is already initialized, destroy it before reinitializing
                $("#ClientDetailsTable").DataTable().destroy();
            }
            var table = $('#ClientDetailsTable').DataTable({
                data: clientsData,
                columns: [
                    { data: 'name' },
                    { data: 'email' },
                    { data: 'ph_num' },
                    { data: 'gender' },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return `
                                <button class="btn btn-subtle-primary btn-sm" data-bs-toggle="modal" data-bs-target="#editClientModal" onclick="editClient('${row.clientID}','${row.name}','${row.email}','${row.ph_num}','${row.gender}',${row.password})">
                                    <i class="bi bi-pencil-square"></i> Edit
                                </button>
                                <button class="btn btn-subtle-danger btn-sm" onclick="deleteClient('${row.clientID}')">
                                    <i class="bi bi-trash3 text-danger"></i> Delete
                                </button>`;
                        }
                    }
                ],
                scrollX: true, // Enable horizontal scrolling
                autoWidth: false // Disable automatic column width calculation
            });
        },
        error: function (xhr, status, error) {
            console.error('Failed to load client data:', error);
        }
    });
}



function deleteClient(clientId) {
    Swal.fire({
        title: 'Are you sure?',
        text: 'You will not be able to recover this client once deleted!',
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            // User confirmed, make delete AJAX call
            $.ajax({
                url: apiBaseUrl+`RemoveClient?ClientID=${clientId}`,
                type: 'POST',
                success: function (response) {
                    // Handle success response
                    Swal.fire(
                        'Deleted!',
                        'Your client has been deleted.',
                        'success'
                    );
                    loadClientDetails()
                },
                error: function (xhr, status, error) {
                    // Handle error response
                    Swal.fire(
                        'Error!',
                        'Failed to delete client',
                        'error'
                    );
                }
            });
        }
    });
}
function editClient(clientId, name, email, phoneNumber, gender,password) {
    clientIdTemp=clientId;
    passwordTemp=password;
    // Populate the modal with client data
    $('#editName').val(name);
    $('#editEmail').val(email);
    $('#editPhone').val(phoneNumber);
    $('input[name="editGender"][value="' + gender + '"]').prop('checked', true);

    // Show the modal
    $('#editClientModal').modal('show');

    // Save changes button click event
    $('#btnEditClient').off('click').on('click', function() {
        // Call the updateClient function with the updated data
        updateClient(clientId, $('#editName').val(), $('#editEmail').val(), $('#editPhone').val(), $('input[name="editGender"]:checked').val(),password);
    });
}

function updateClient(clientId, name, email, phoneNumber, gender,password) {
    // Make a PUT AJAX call to update the client
    $.ajax({
        url: `http://localhost:12902/YogaAPI/V1/UpdateClient?ClientID=${clientId}&Name=${name}&Email=${email}&PhoneNumber=${phoneNumber}&Gender=${gender}&password=${password}`,
        type: 'POST',
        success: function(response) {
            console.log('Client updated successfully');
            // Close the modal
            $('#editClientModal').modal('hide');
            Swal.fire(
                'Updated!',
                'Your client has been Updated.',
                'success'
            );
            loadClientDetails()

        },
        error: function(xhr, status, error) {
            Swal.fire(
                'Failed!',
                'Your client Update failed.',
                'Error'
            );            console.error('Error updating client:', error);
        }
    });
}

